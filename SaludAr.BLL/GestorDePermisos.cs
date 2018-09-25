using System;
using System.Collections.Generic;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;
using SaludAr.DAL.Validaciones;

namespace SaludAr.BLL
{
    public interface IGestorDePermisos
    {
        BE.Infraestructura.IPermiso[] PatentesDisponibles { get; }
        BE.Infraestructura.Familia NuevaFamilia(string descripcion);
        BE.Infraestructura.Familia[] ListarFamilias();
        void Actualizar(BE.Infraestructura.Familia familia);
    }

    public class GestorDePermisos : IGestorDePermisos
    {
        private readonly ITraductor _traductor;
        private readonly IPermiso _permisoDal;

        public GestorDePermisos(ITraductor traductor, DAL.IPermiso permisoDal)
        {
            _traductor = traductor;
            _permisoDal = permisoDal;
        }

        public BE.Infraestructura.IPermiso[] PatentesDisponibles
        {
            get
            {
                var patentesDelSistema = new List<BE.Infraestructura.IPermiso>();
                foreach (var patenteExistente in _permisoDal.PatentesExistentes)
                {
                    patenteExistente.Descripcion = _traductor.Traducir(string.Format("Patente_{0}", patenteExistente.Codigo));
                    patentesDelSistema.Add(patenteExistente);
                }

                return patentesDelSistema.ToArray();
            }
        }

        public BE.Infraestructura.Familia NuevaFamilia(string descripcion)
        {
            if(_permisoDal.ExisteFamilia(descripcion))
                throw new ElementoRepetidoException(null, nameof(BE.Infraestructura.Familia.Descripcion), descripcion);

            var familia = new BE.Infraestructura.Familia
            {
                Codigo = Guid.NewGuid().ToString("N"),
                Descripcion = descripcion
            };
            return familia;
        }

        public BE.Infraestructura.Familia[] ListarFamilias()
        {
            return _permisoDal.ListarFamilias;
        }

        public void Actualizar(BE.Infraestructura.Familia familia)
        {
            _permisoDal.Actualizar(familia);
        }
    }
}
