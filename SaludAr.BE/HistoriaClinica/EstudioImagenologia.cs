using System;
using SaludAr.BE.Seguridad;

namespace SaludAr.BE.HistoriaClinica
{
    public class EstudioImagenologia : EventoClinico
    {
        [DatoSensible]
        public string InformeTecnico { get; set; }
        public string LinkImagen { get; set; }

        public override string Resumen()
        {
            return this.InformeTecnico;
        }
    }
}
