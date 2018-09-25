using System.Collections.Generic;
using System.Linq;

namespace SaludAr.BE.Infraestructura
{
    /// <summary>
    /// Representa un Grupo de permisos asignables para un usuario
    /// </summary>
    public class Familia : IPermiso
    {
        private readonly IList<IPermiso> _permisos = new List<IPermiso>();

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public IList<IPermiso> Permisos
        {
            get { return _permisos; }
        }

        public bool ConcederAcceso(string codigoPermiso)
        {
            return this.Permisos.Any(p => p.ConcederAcceso(codigoPermiso));
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}