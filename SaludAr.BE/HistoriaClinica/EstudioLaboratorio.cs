using System;
using SaludAr.BE.Seguridad;

namespace SaludAr.BE.HistoriaClinica
{
    public class EstudioLaboratorio : EventoClinico
    {
        [DatoSensible]
        public string NroProtocolo { get; set; }

        public override string Resumen()
        {
            return string.Format("Protocolo Nro.: {0}", this.NroProtocolo);
        }
    }
}
