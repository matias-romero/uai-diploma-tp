namespace SaludAr.DAL.Internal
{
    public interface IRepositorioABM<T> where T : class
    {
        T CrearNuevo();
        void Actualizar(T entidad);
    }

    internal class RepositorioABM<T> : RepositorioBase<T>, IRepositorioABM<T> where T : class, new()
    {
        public RepositorioABM(DatabaseContext contexto)
            :base(contexto)
        {
            
        }

        public T CrearNuevo()
        {
            return this.MyDbSet().Create();
        }

        public virtual void Actualizar(T entidad)
        {
            using (var ctx = this.CreateIsolatedContext())
            {
                this.DoEntityUpdate(ctx, entidad);
                ctx.SaveChanges();
            }
        }

        protected virtual void DoEntityUpdate(DatabaseContext ctx, T entidad)
        {
            ctx.UpdateEntity(entidad, true);
        }
    }
}
