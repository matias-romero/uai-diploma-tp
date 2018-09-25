using System;
using System.Collections.Generic;

namespace SaludAr.BE.Agenda
{
    public class DefinicionAgenda
    {
        public DefinicionAgenda()
        {
            this.Desde = DateTime.Today;
            this.Hasta = DateTime.MaxValue;
            this.Bloques = new List<EntradaAgenda>();
        }

        public Guid Id { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public Especialidad Especialidad { get; set; }
        public CentroDeSalud CentroDeSalud { get; set; }

        public IList<EntradaAgenda>Bloques { get; set; }
    }
}
