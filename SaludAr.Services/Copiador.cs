using System.Reflection;

namespace SaludAr.Services
{
    /// <summary>
    /// Ofrece servicios relacionados con la copia de propiedades entre diferentes objetos
    /// </summary>
    public class Copiador
    {
        /// <summary>
        /// Copia todas las propiedades públicas del objeto Source al objeto Target
        /// </summary>
        /// <typeparam name="T">Tipo de ambos objetos a copiar</typeparam>
        /// <param name="source">Objeto con los valores deseados</param>
        /// <param name="target">Objeto con valores por sobrescribir</param>
        public static void CopiarDeManeraSuperficial<T>(T source, T target)
        {
            var properties = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in properties)
            {
                var piTarget = propertyInfo;
                var piSource = propertyInfo;

                if (piTarget.CanWrite && piSource.CanRead)
                {
                    var sourceValue = piSource.GetValue(source, null);
                    piTarget.SetValue(target, sourceValue, null);
                }
            }
        }
    }
}
