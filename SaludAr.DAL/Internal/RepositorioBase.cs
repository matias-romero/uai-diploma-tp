using System.Data.Entity;
using System.Linq;

namespace SaludAr.DAL.Internal
{
    /// <summary>
    /// Sirve como esqueleto de plantilla para todos los repositorios de entidades de solo lectura
    /// </summary>
    internal abstract class RepositorioBase<T> where T : class, new()
    {
        private readonly DatabaseContext _contexto;

        protected RepositorioBase(DatabaseContext contexto)
        {
            _contexto = contexto;
        }

        protected virtual IDbSet<T> MyDbSet() 
        {
            return _contexto.Set<T>();
        }

        protected virtual DatabaseContext CreateIsolatedContext()
        {
            return _contexto.Clone();
        }

        protected T[] ListarPorDefecto()
        {
            return this.MyDbSet().AsNoTracking().ToArray();
        }
    }
}