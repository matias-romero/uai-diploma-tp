using System;

namespace SaludAr.BE
{
    public class Paciente
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public BE.Empleados.Sexo Sexo { get; set; }

        public string NumeroDocumento { get; set; }

        public int EdadEnAños()
        {
            return (int) ((DateTime.Today - this.FechaNacimiento).TotalDays / 365);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Nombre, this.Apellido);
        }
    }
}
