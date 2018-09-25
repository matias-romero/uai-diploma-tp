using SaludAr.BE.Seguridad;

namespace SaludAr.BE.Infraestructura
{
    /// <summary>
    /// Modela las credenciales de un usuario del sistema
    /// </summary>
    public class Usuario
    {
        [DatoSensible]
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public IPermiso Permiso { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}