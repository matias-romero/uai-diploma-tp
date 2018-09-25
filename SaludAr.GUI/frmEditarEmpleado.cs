using SaludAr.GUI.Editores;
using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using Empleado = SaludAr.BE.Empleados.Empleado;

namespace SaludAr.GUI
{
    public partial class frmEditarEmpleado : frmDialogo<Empleado>
    {
        public frmEditarEmpleado(IServiciosDeAplicacion serviciosDeAplicacion, Empleado empleado)
            : base(serviciosDeAplicacion, empleado, ConstantesDeTexto.MenuEmpleados)
        {
            this.Height = 500;
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, Empleado item)
        {
            var esNuevo = Guid.Empty.Equals(item.Id);
            return new ctlEditarEmpleado(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.Empleado, serviciosDeAplicacion.GestorDePermisos, item, esNuevo);
        }
    }
}
