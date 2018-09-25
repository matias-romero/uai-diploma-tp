using System;
using SaludAr.BE.Infraestructura;

namespace SaludAr.BE.Bitacora
{
    /// <summary>
    /// Modela una entrada en la bitácora del sistema
    /// </summary>
    public class EntradaEnBitacora
    {
        public Guid Id { get; set; }
        public Evento Evento { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public Severidad Severidad { get; set; }

        public override string ToString()
        {
            return string.Format("[{0:G}] {1:yyyy-MM-dd HH:mm:ss}: {2}", this.Severidad, this.FechaHora, this.Mensaje);
        }
    }
}