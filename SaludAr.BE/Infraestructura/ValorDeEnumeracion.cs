using System;

namespace SaludAr.BE.Infraestructura
{
    /// <summary>
    /// Modela un valor de un enum generico para ser compatible con el sistema de traducciones
    /// </summary>
    public class ValorDeEnumeracion
    {
        public int Valor { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
