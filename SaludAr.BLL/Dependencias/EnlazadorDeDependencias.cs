using System;
using System.Linq;
using System.Reflection;
using StructureMap;

namespace SaludAr.BLL.Dependencias
{
    /// <summary>
    /// Implementa el patrón "Service Locator" y me resuelve la inyección de dependencias en los constructores de cada objeto
    /// </summary>
    internal class EnlazadorDeDependencias : IDisposable
    {
        private readonly IContainer _container;

        public EnlazadorDeDependencias()
            : this(Assembly.GetCallingAssembly())
        {

        }

        public EnlazadorDeDependencias(Assembly ensambladoConRegistrosDeConfiguracion)
        {
            _container = new Container(_ => 
            {
                var registros = ensambladoConRegistrosDeConfiguracion.GetTypes()
                    .Where(t => typeof(Registry).IsAssignableFrom(t))
                    .ToArray();

                foreach (var registro in registros)
                    _.AddRegistry((Registry)Activator.CreateInstance(registro));  
            });
        }

        public T Resolver<T>()
        {
            return _container.GetInstance<T>();
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}
