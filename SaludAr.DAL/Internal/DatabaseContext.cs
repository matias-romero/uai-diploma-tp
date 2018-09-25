using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using RefactorThis.GraphDiff;
using SaludAr.DAL.DigitosVerificadores;

namespace SaludAr.DAL.Internal
{
    internal class DatabaseContext : DbContextConSoporteParaDigitosVerificadores
    {
        private readonly string _cadenaConexion;
        public DatabaseContext(string cadenaConexion)
            : base(cadenaConexion, new CalculadoraDV())
        {
            _cadenaConexion = cadenaConexion;
        }

        public IDbSet<BE.Empleados.Empleado> Empleados { get; set; }

        public IDbSet<BE.CentroDeSalud> CentrosDeSalud { get; set; }

        public IDbSet<BE.Agenda.DefinicionAgenda> DefinicionesAgenda { get; set; }

        public IDbSet<BE.Infraestructura.Patente> Patentes { get; set; }

        public IDbSet<BE.Infraestructura.Usuario> Usuarios { get; set; }

        public IDbSet<BE.Especialidad> Especialidades { get; set; }

        public IEntityDbSet<T> ResolveDbSet<T>() where T : class
        {
            return new EntityDbSetWrapper<T>(this.Set<T>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Agrego todos los mappers del ensamblado DAL
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public int SaveAndDetachAll()
        {
            var cantidad = base.SaveChanges();
            foreach (var dbEntityEntry in this.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
            }
            return cantidad; 
        }

        public IEntityRawSql CreateRawSqlHelper()
        {
            var currentConnection = this.Database.Connection;
            var providerFactory = DbProviderFactories.GetFactory(currentConnection);
            return new EntityRawSql(providerFactory, currentConnection.ConnectionString);
        }

        public DatabaseContext Clone()
        {
            var ctx = new DatabaseContext(_cadenaConexion);
            ctx.Database.Log = this.Database.Log;
            return ctx;
        }

        /// <summary>
        /// Elimina la entidad desconectada en un contexto aislado
        /// </summary>
        /// <typeparam name="T">Tipo de entidad</typeparam>
        /// <param name="entity">Entidad para eliminar</param>
        /// <returns>Retorna la cantidad de registros afectados</returns>
        public int DeleteEntity<T>(T entity) where T : class
        {
            int affectedCount;
            using (var ctx = this.Clone())
            {
                ctx.Set<T>()
                    .Remove(entity);

                affectedCount = ctx.SaveChanges();
            }

            return affectedCount;
        }

        /// <summary>
        /// Actualiza la entidad desconectada en un contexto aislado
        /// </summary>
        /// <typeparam name="T">Tipo de entidad</typeparam>
        /// <param name="entity">Entidad sin dependencias a persistir</param>
        /// <param name="refreshIdentity">Verdadero si actualiza el campo Id de la entidad luego de grabar</param>
        /// <returns>Retorna la cantidad de registros afectados</returns>
        public int UpdateEntity<T>(T entity, bool refreshIdentity) where T : class, new()
        {
            Action<T> afterUpdate = null;
            if (refreshIdentity)
            {
                afterUpdate = (updated) =>
                {
                    var propId = entity.GetType().GetProperty("Id");
                    var updatedId = propId.GetValue(updated);
                    propId.SetValue(entity, updatedId);
                };
            }

            return this.UpdateEntityGraph(entity, afterUpdate, null);
        }

        /// <summary>
        /// Actualiza el grafo de entidades desconectadas en un contexto aislado
        /// </summary>
        /// <typeparam name="T">Tipo de entidad</typeparam>
        /// <param name="entity">Raíz del grafo de entidades a persistir</param>
        /// <param name="afterUpdateCallback">Callback con el grafo resultante despues de grabar</param>
        /// <param name="mapping">Expresión de mapeado para las subentidades que componen el grafo</param>
        /// <returns>Retorna la cantidad de registros afectados</returns>
        public int UpdateEntityGraph<T>(T entity, Action<T> afterUpdateCallback, Expression<Func<IUpdateConfiguration<T>, object>> mapping) where T : class, new()
        {
            int affectedCount;
            using (var ctx = this.Clone())
            {
                var updated = ctx.UpdateGraph(entity, mapping);

                affectedCount = ctx.SaveChanges();
                if(afterUpdateCallback != null)
                    afterUpdateCallback.Invoke(updated);
            }

            return affectedCount;
        }
    }
}