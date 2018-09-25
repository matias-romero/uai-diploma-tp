using System;
using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using Empleado = SaludAr.BE.Empleados.Empleado;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoEmpleado : VistaListado<BE.Empleados.Empleado>
    {
        private IEmpleado _empleadoBll;

        public VistaListadoEmpleado(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _empleadoBll = serviciosDeAplicacion.Empleado;
            var controlDePatentes = serviciosDeAplicacion.ControlDePatentes;
            this.PuedeAgregar = controlDePatentes.ConcederAcceso(ControlDePatentes.RegistrarNuevoEmpleado);
            this.PuedeEditar = controlDePatentes.ConcederAcceso(ControlDePatentes.RegistrarNuevoEmpleado) || controlDePatentes.ConcederAcceso(ControlDePatentes.EditarDatosDelEmpleado);
            this.PuedeBorrar = controlDePatentes.ConcederAcceso(ControlDePatentes.DesvincularEmpleado);
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuEmpleados; }
        }

        public IEmpleado EmpleadoBll
        {
            get { return _empleadoBll; }
        }

        protected override IEnumerable<Empleado> RecargarListado()
        {
            return _empleadoBll.Listar();
        }
    }
}
