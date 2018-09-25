using System.Linq;
using SaludAr.DAL.Internal;
using SaludAr.DAL.Internal.Auxiliares;
using SaludAr.Services;

namespace SaludAr.DAL
{
    public interface IPermiso
    {
        BE.Infraestructura.Patente[] PatentesExistentes { get; }
        BE.Infraestructura.Familia[] FamiliasPorDefecto { get; }
        BE.Infraestructura.Familia[] ListarFamilias { get; }
        bool ExisteFamilia(string descripcion);
        void Actualizar(BE.Infraestructura.Familia familia);
    }

    internal class Permiso : IPermiso
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IReadOnlyEntityDbSet<BE.Infraestructura.Familia> _familiaDbSet;
        private readonly IReadOnlyEntityDbSet<Internal.Auxiliares.FamiliaPatente> _familiaPatenteDbSet;

        public Permiso(Internal.DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _familiaDbSet = databaseContext.ResolveDbSet<BE.Infraestructura.Familia>();
            _familiaPatenteDbSet = databaseContext.ResolveDbSet<Internal.Auxiliares.FamiliaPatente>();
        }

        public BE.Infraestructura.Patente[] PatentesExistentes
        {
            get
            {
                return PatentesDelSistema.PatentesDisponibles
                    .Select(codigo => new BE.Infraestructura.Patente
                    {
                        Codigo = codigo
                    })
                    .ToArray();
            }
        }

        public BE.Infraestructura.Familia[] FamiliasPorDefecto
        {
            get
            {
                return Services.FamiliasPorDefecto.FamiliasDisponibles
                    .Select(f =>
                    {
                        var familia = new BE.Infraestructura.Familia
                        {
                            Codigo = f.Item1,
                            Descripcion = f.Item2
                        };
                        foreach (var codigoPatente in f.Item3)
                            familia.Permisos.Add(new BE.Infraestructura.Patente{ Codigo = codigoPatente });

                        return familia;
                    })
                    .ToArray();
            }
        }

        public BE.Infraestructura.Familia[] ListarFamilias
        {
            get
            {
                var familias = _familiaDbSet.FindAll();
                foreach (var familia in familias)
                {
                    var patentes = _familiaPatenteDbSet.FindAll(fp => fp.FamiliaId == familia.Codigo, fp => fp.Patente);
                    foreach (var familiaPatente in patentes)
                        familia.Permisos.Add(familiaPatente.Patente);
                }

                return familias;
            }
        }

        public bool ExisteFamilia(string descripcion)
        {
            return _familiaDbSet.Exists(f => f.Descripcion == descripcion);
        }

        public void Actualizar(BE.Infraestructura.Familia familia)
        {
            using (var ctx = _databaseContext.Clone())
            {
                //Borro todos las patentes relacionadas y conservo solamente el ultimo estado
                var familiaDbSet = ctx.ResolveDbSet<BE.Infraestructura.Familia>();
                var familiaPatenteDbSet = ctx.ResolveDbSet<Internal.Auxiliares.FamiliaPatente>();

                var existente = familiaDbSet.Find(familia.Codigo);
                var existentes = familiaPatenteDbSet.FindAll(fp => fp.FamiliaId == familia.Codigo);
                foreach (var familiaPatente in existentes)
                    familiaPatenteDbSet.Remove(familiaPatente);

                foreach (var patente in familia.Permisos.OfType<BE.Infraestructura.Patente>())
                    familiaPatenteDbSet.Add(new FamiliaPatente { FamiliaId = familia.Codigo, PatenteId = patente.Codigo });

                if (existente == null)
                    familiaDbSet.Add(familia);

                ctx.SaveChanges();
            }
            
        }
    }
}
