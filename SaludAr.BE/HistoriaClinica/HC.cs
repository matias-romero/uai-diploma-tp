using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAr.BE.HistoriaClinica
{
    public class HC
    {
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public IList<EventoClinico> Eventos { get; set; }
    }
}
