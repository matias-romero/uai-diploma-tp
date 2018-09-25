using System;

namespace SaludAr.BE.Infraestructura
{
    public class PuntoDeRestauracion
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string RutaDelArchivo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} [{1:yyyy-MM-dd HH:mm:ss}]", this.Nombre, this.Fecha);
        }
    }
}