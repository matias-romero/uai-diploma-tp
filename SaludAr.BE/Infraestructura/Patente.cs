using System;

namespace SaludAr.BE.Infraestructura
{
    /// <summary>
    /// Representa un permiso que puede asignarse a un usuario para que acceda a una funcionalidad específica
    /// </summary>
    public class Patente : IPermiso
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool ConcederAcceso(string codigoPermiso)
        {
            return string.Equals(this.Codigo, codigoPermiso, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", this.Codigo, this.Descripcion);
        }
    }
}