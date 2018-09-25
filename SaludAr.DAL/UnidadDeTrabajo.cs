using System;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace SaludAr.DAL
{
    public interface IUnidadDeTrabajo
    {
        int EjecutarSql(string sql, object param);
        T NuevoRepositorio<T>();
    }

    public class UnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        private readonly Internal.IEntityRawSql _entityRawSql;
        private readonly Internal.DatabaseContext _databaseContext;
        
        static UnidadDeTrabajo()
        {
            Internal.DatabaseInitializer.Configure();
        }

        internal UnidadDeTrabajo(DbProviderFactory proveedor, string cadenaDeConexion)
        {
            _databaseContext = new Internal.DatabaseContext(cadenaDeConexion);
            _databaseContext.Database.Log = Internal.DatabaseInitializer.LoggerAction;
            _entityRawSql = new Internal.EntityRawSql(proveedor, cadenaDeConexion);
        }

        public int EjecutarSql(string sql, object param)
        {
            return _entityRawSql.ExecuteSql(sql, param);
        }

        public T NuevoRepositorio<T>()
        {
            //Todas las implementaciones de clases en la DAL respetan esta convencion:
            //--Por cada interface IClaseDal -> Existe una clase ClaseDal
            //--Cada ClaseDal tiene un único constructor que puede recibir cualquiera de los dos helpers de acceso a datos
            var interfaceTypeName = typeof(T).FullName;
            var conventionConcreteName = Regex.Replace(interfaceTypeName, @"\.I(.+)$", @".$1");
            var conreteType = typeof(T).Assembly.GetType(conventionConcreteName);
            var constructorPorDefecto = conreteType.GetConstructors()[0];
            var args = new object[constructorPorDefecto.GetParameters().Length];
            for (var i = 0; i < args.Length; i++)
                args[i] = this.ResolverArgumento(constructorPorDefecto.GetParameters()[i].ParameterType);

            return (T)constructorPorDefecto.Invoke(args);
        }

        public void Dispose()
        {
            _databaseContext?.Dispose();
        }

        private object ResolverArgumento(Type tipoParametro)
        {
            if (typeof(Internal.DatabaseContext).IsAssignableFrom(tipoParametro))
                return _databaseContext;
            if (typeof(Internal.IEntityRawSql).IsAssignableFrom(tipoParametro))
                return _entityRawSql;

            throw new ArgumentOutOfRangeException(nameof(tipoParametro), tipoParametro, "No se reconoce el tipo de parametro indicado");
        }
    }
}