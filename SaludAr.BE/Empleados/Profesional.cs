using System.Collections.Generic;

namespace SaludAr.BE.Empleados
{
    public class Profesional : Empleado
    {
        public string CodMatricula { get; set; }

        public ICollection<Especialidad> Especialidades { get; set; }
    }
}