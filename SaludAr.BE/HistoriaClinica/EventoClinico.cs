using System;
using SaludAr.BE.Seguridad;

namespace SaludAr.BE.HistoriaClinica
{
    public abstract class EventoClinico : IEntidadConDigitoVerificador
    {
        public Guid Id { get; set; }
        [DatoSensible]
        public string Titulo { get; set; }
        [DatoSensible]
        public DateTime Fecha { get; set; }

        public byte[] DVH { get; set; }

        public virtual string Resumen()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return string.Format("[{0:d}] {1}", this.Fecha, this.Titulo);
        }
    }
}
