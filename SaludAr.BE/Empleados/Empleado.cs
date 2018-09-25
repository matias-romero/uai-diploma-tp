using System;

namespace SaludAr.BE.Empleados
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int NroLegajo { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefono { get; set; }
        public BE.Infraestructura.Usuario CredencialUsuario { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Nombre, this.Apellido);
        }
    }
}