using System;

namespace SaludAr.BE.Agenda
{
    /// <summary>
    /// Esta clase soporta la vista dinamica de la consulta de disponibilidad
    /// </summary>
    public class SlotDeAgenda
    {
        public bool Disponible { get; set; }

        public string PacienteAsignado { get; set; }

        public DateTime Horario { get; set; }

        public TimeSpan Duracion { get; set; }

        public EntradaAgenda EntradaAgendaOriginal { get; set; }

        public DiaSemana DiaSemana
        {
            get { return (DiaSemana)this.Horario.DayOfWeek; }
        }

        public DateTime HorarioFinalizacion
        {
            get { return this.Horario.Add(this.Duracion); }
        }

        public SlotDeAgenda Clone()
        {
            return (SlotDeAgenda) this.MemberwiseClone();
        }
    }
}
