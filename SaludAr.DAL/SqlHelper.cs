using System.Data.Common;

namespace SaludAr.DAL
{
    public class SqlHelper
    {
        private static string _cadenaDeConexion;

        public static void ConfigurarPorDefecto(string cadenaDeConexion)
        {
            _cadenaDeConexion = cadenaDeConexion;
        }

        public static void EliminarBaseDeDatosSiExiste()
        {
            System.Data.Entity.Database.Delete(_cadenaDeConexion);
        }

        /// <summary>
        /// Ofrece una nueva unidad de trabajo para realizar un juego de transacciones relacionadas
        /// </summary>
        public IUnidadDeTrabajo NuevaUnidadDeTrabajo()
        {
            return new UnidadDeTrabajo(GetCurrentProvider(), _cadenaDeConexion);
        }

        private DbProviderFactory GetCurrentProvider()
        {
            return DbProviderFactories.GetFactory("System.Data.SqlClient");
        }
    }
}