using SaludAr.BE.Infraestructura;
using SaludAr.BLL.Traductor;
using System;
using System.Collections.Generic;
using System.Linq;
using SaludAr.BE.Agenda;
using SaludAr.BE.Bitacora;

namespace SaludAr.BLL
{
    public interface IAgenda
    {
        ValorDeEnumeracion[] DiasDeLaSemana { get; }
        BE.Agenda.DefinicionAgenda[] Listar();
        void Actualizar(BE.Agenda.DefinicionAgenda agenda);
        BE.Agenda.SlotDeAgenda[] ConsultarDisponibilidad(BE.Paciente paciente, BE.CentroDeSalud centroDeSalud, BE.Especialidad especialiadad, DateTime fechaTentativa);
    }

    public class Agenda : IAgenda
    {
        private readonly ITraductor _traductor;
        private readonly DAL.IAgenda _agendaDal;
        private readonly BLL.ITurno _turnoBll;

        public Agenda(ITraductor traductor, DAL.IAgenda agendaDal)
        {
            _traductor = traductor;
            _agendaDal = agendaDal;
        }

        public ValorDeEnumeracion[] DiasDeLaSemana
        {
            get { return new Enumerados(_traductor).Listar(typeof(BE.Agenda.DiaSemana)); }
        }

        public BE.Agenda.DefinicionAgenda[] Listar()
        {
            return _agendaDal.Listar();
        }

        public void Actualizar(BE.Agenda.DefinicionAgenda agenda)
        {
            _agendaDal.GrabarDefinicion(agenda);
            //Registro la modificación en la bitácora
            Bitacora.Default.RegistrarEnBitacora(Evento.PlanificadorConfiguroOfertaAgenda, agenda.Id.ToString());
        }

        public BE.Agenda.SlotDeAgenda[] ConsultarDisponibilidad(BE.Paciente paciente, BE.CentroDeSalud centroDeSalud, BE.Especialidad especialiadad, DateTime fechaTentativa)
        {
            var definicionesVigentes = this.Listar()
                .Where(da => da.CentroDeSalud.Id == centroDeSalud.Id 
                             && da.Especialidad.Id == especialiadad.Id
                             && (fechaTentativa >= da.Desde && fechaTentativa <= da.Hasta))
                .ToArray();

            var fechaDesde = fechaTentativa.AddDays(-7).Date; //Fecha con margen de una semana a las 00:00:00
            if(fechaDesde < DateTime.Now) //No tiene sentido dar turnos programados al pasado
                fechaDesde = DateTime.Today;

            var fechaHasta = fechaTentativa.AddDays(8).Date.AddSeconds(-1); //Fecha con margen de una semana despues a las 23:59:59
            var ventanaEnDias = (int)(fechaHasta.Date - fechaDesde.Date).TotalDays;

            var bloquesExistentes = new List<SlotDeAgenda>();
            foreach (var definicionVigente in definicionesVigentes)
            {
                foreach (var entradaAgenda in definicionVigente.Bloques)
                {
                    var bloquesDeHorario = entradaAgenda.ObtenerBloquesAsignables().ToArray();
                    //Analizo cada día de la ventana en busca de entradas coincidentes
                    for (var i = 0; i < ventanaEnDias; i++)
                    {
                        var fecha = fechaDesde.AddDays(i);
                        if (fecha.DayOfWeek == (DayOfWeek)entradaAgenda.DiaSemana)
                        {
                            //Si coincide la fecha con la entrada, creo todos los bloques de esa entrda para esa fecha
                            bloquesExistentes.AddRange(bloquesDeHorario.Select(b =>
                            {
                                var nuevo = b.Clone();
                                nuevo.Horario = new DateTime(fecha.Year, fecha.Month, fecha.Day, b.Horario.Hour, b.Horario.Minute, b.Horario.Second);
                                nuevo.EntradaAgendaOriginal = entradaAgenda;
                                return nuevo;
                            }));

                        }
                    }                    
                }
            }

            //Listo los turnos ya agendados y marco los bloques respectivos como ocupados
            //var turnosAsignados = _turnoBll.Listar();
            //this.CruzarAgendaConTurnosAsignados(bloquesExistentes, turnosAsignados);

            return bloquesExistentes.ToArray();
        }

        private void CruzarAgendaConTurnosAsignados(IEnumerable<BE.Agenda.SlotDeAgenda> agenda, BE.Agenda.Turno[] turnos)
        {
            //Marca los slot donde ya hay turnos como ocupados
            foreach (var turno in turnos)
            {
                var slotsDeAgenda = agenda.Where(s => s.EntradaAgendaOriginal?.Id == turno.BloqueAgendaOriginal?.Id);
                foreach (var slotDeAgenda in slotsDeAgenda)
                {
                    var finEstimadoDelTurno = turno.FechaHora.Add(turno.Duracion);
                    if (turno.FechaHora >= slotDeAgenda.Horario && finEstimadoDelTurno <= slotDeAgenda.HorarioFinalizacion)
                    {
                        slotDeAgenda.Disponible = false;
                        slotDeAgenda.PacienteAsignado = turno.Paciente?.ToString();
                    }
                }

            }
        }
    }
}
