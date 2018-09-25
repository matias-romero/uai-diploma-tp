using System;
using System.Resources;

namespace SaludAr.BLL.Traductor
{
    public class ConstanteNoEncontradaException: Exception
    {
        public ConstanteNoEncontradaException(string clave, Exception innerException)
            :base(string.Format("No se definió la clave '{0}' en el idioma en uso.", clave), innerException)
        {
            this.Clave = clave;
        }

        public string Clave { get; set; }
    }
}
