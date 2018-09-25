using System;

namespace SaludAr.BE.Seguridad
{
    /// <summary>
    /// Marca un campo de la entidad como dato sensible a nivel de negocio
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DatoSensibleAttribute : Attribute
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}
