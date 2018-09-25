using System;
using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoProfesional : VistaListado<BE.Empleados.Profesional>
    {
        private readonly IEmpleado _empleadoBll;

        public VistaListadoProfesional(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _empleadoBll = serviciosDeAplicacion.Empleado;
            var controlDePatentes = serviciosDeAplicacion.ControlDePatentes;
            this.PuedeEditar = controlDePatentes.ConcederAcceso(ControlDePatentes.EditarEspecialidadesDelProfesional);
            this.PuedeAgregar = false;
            this.PuedeBorrar = false;
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuProfesionales; }
        }

        protected override IEnumerable<BE.Empleados.Profesional> RecargarListado()
        {
            return _empleadoBll.ListarSoloProfesionales();
        }
    }
}
