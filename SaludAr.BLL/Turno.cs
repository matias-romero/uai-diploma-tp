using System;
using System.Linq;
using SaludAr.BE.Agenda;
using SaludAr.BE.Bitacora;
using SaludAr.BE.Empleados;

namespace SaludAr.BLL
{
    public interface ITurno
    {
        BE.Agenda.Turno[] Listar();
        BE.Agenda.Turno[] ListarMisTurnos();
        BE.Agenda.Turno[] ListarProgramadosPorPaciente(BE.Paciente paciente);
        void Actualizar(BE.Agenda.Turno turno);
        BE.Agenda.Turno AsignarNuevoTurno(BE.Agenda.SlotDeAgenda slotSeleccionado, BE.Paciente paciente);
        void IniciarAtencion(BE.Agenda.Turno turno);
        void FinalizarAtencion(BE.Agenda.Turno turno);
    }

    public class Turno : ITurno
    {
        private readonly DAL.ITurno _turnoDal;
        private readonly DAL.IEmpleado _empleadoDal;

        public Turno(DAL.ITurno turnoDal, DAL.IEmpleado empleadoDal)
        {
            _turnoDal = turnoDal;
            _empleadoDal = empleadoDal;
        }

        public BE.Agenda.Turno[] Listar()
        {
            return _turnoDal.Listar();
        }

        public BE.Agenda.Turno[] ListarMisTurnos()
        {
            var profesional = this.ObtenerProfesionalActual();
            if(profesional == null)
                return new BE.Agenda.Turno[0];

            var turnos = _turnoDal.Listar()
                .Where(t => t.Profesional == null || t.Profesional?.Id == profesional.Id)
                .Where(t => t.EstaAdmisionado())
                .ToArray();

            return turnos;
        }

        public BE.Agenda.Turno[] ListarProgramadosPorPaciente(BE.Paciente paciente)
        {
            return _turnoDal.Listar()
                .Where(t => t.Paciente.Id == paciente.Id 
                            && !t.EstaAdmisionado() 
                            && !t.EstaAtendido())
                .ToArray();
        }

        public void Actualizar(BE.Agenda.Turno turno)
        {
            var esNuevo = turno.Id.Equals(Guid.Empty);
            _turnoDal.Actualizar(turno);

            if(esNuevo)
                Bitacora.Default.RegistrarEnBitacora(Evento.NuevoTurnoAsignado, turno.Id.ToString());
        }

        public BE.Agenda.Turno AsignarNuevoTurno(SlotDeAgenda slotSeleccionado, BE.Paciente paciente)
        {
            slotSeleccionado.Disponible = false;
            slotSeleccionado.PacienteAsignado = paciente.ToString();
            return new BE.Agenda.Turno
            {
                Paciente = paciente,
                BloqueAgendaOriginal = slotSeleccionado.EntradaAgendaOriginal,
                Duracion = slotSeleccionado.Duracion,
                FechaHora = slotSeleccionado.Horario
            };
        }

        public void IniciarAtencion(BE.Agenda.Turno turno)
        {
            turno.FechaHoraInicioAtencion = DateTime.Now;
            Bitacora.Default.RegistrarEnBitacora(Evento.InicioAtencionAmbulatoria, $"Turno: {turno.Id.ToString()}");
        }

        public void FinalizarAtencion(BE.Agenda.Turno turno)
        {
            var profesional = this.ObtenerProfesionalActual();
            
            //Completo los datos para finalizar la visita
            turno.Profesional = profesional;
            turno.FechaHoraFinAtencion = DateTime.Now;
            this.Actualizar(turno);

            Bitacora.Default.RegistrarEnBitacora(Evento.FinAtencionAmbulatoria, $"Turno: {turno.Id.ToString()}");
        }

        /// <summary>
        /// Recupera el profesional de la sesión actual
        /// </summary>
        private BE.Empleados.Profesional ObtenerProfesionalActual()
        {
            var usuarioActual = SessionManager.Instance.UsuarioActual.Nombre;
            var profesional = _empleadoDal.BuscarPorNombreUsuarioRelacionado(usuarioActual) as BE.Empleados.Profesional;
            return profesional;
        }
    }
}
