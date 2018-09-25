using System;
using SaludAr.BE.Seguridad;

namespace SaludAr.BE.HistoriaClinica
{
    public class EvolucionClinicaTurno : EventoClinico
    {
        [DatoSensible]
        public string Evolucion { get; set; }

        public override string Resumen()
        {
            return this.Evolucion;
        }
    }
}
