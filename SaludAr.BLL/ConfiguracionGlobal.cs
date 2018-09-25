using System;

namespace SaludAr.BLL
{
    public class ConfiguracionGlobal
    {
        #region "Singleton"

        private static readonly Lazy<ConfiguracionGlobal> DefaultInstance = new Lazy<ConfiguracionGlobal>(() => new ConfiguracionGlobal());

        public static ConfiguracionGlobal Instance
        {
            get { return DefaultInstance.Value; }
        }

        #endregion

        /// <summary>
        /// Devuelve o establece la cadena de conexion utilizada para enlace de datos
        /// </summary>
        public string CadenaDeConexionParaAccesoDatos { get; set; }
    }
}