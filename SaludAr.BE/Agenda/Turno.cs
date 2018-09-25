using System;
using SaludAr.BE.Empleados;

namespace SaludAr.BE.Agenda
{
    public class Turno
    {
        public Guid Id { get; set; }
        public Paciente Paciente { get; set; }
        public Profesional Profesional { get; set; }

        public EntradaAgenda BloqueAgendaOriginal { get; set; }

        public DateTime FechaHora { get; set; }
        public TimeSpan Duracion { get; set; }

        public DateTime? FechaHoraAdmision { get; set; }
        public DateTime? FechaHoraInicioAtencion { get; set; }
        public DateTime? FechaHoraFinAtencion { get; set; }

        public bool EstaAdmisionado()
        {
            return this.FechaHoraAdmision.HasValue;
        }

        public bool EstaAtendido()
        {
            return this.FechaHoraInicioAtencion.HasValue || this.FechaHoraFinAtencion.HasValue;
        }
    }
}
