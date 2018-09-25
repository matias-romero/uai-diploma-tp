using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Vistas;

namespace SaludAr.GUI
{
    public partial class frmEmpleados : frmListado<BE.Empleados.Empleado>
    {
        public frmEmpleados(IServiciosDeAplicacion serviciosDeAplicacion)
            : base(serviciosDeAplicacion, new VistaListadoEmpleado(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override void InvocarFormularioAlta()
        {
            var nuevoItem = new BE.Empleados.Empleado();
            this.InvocarFormularioEdicion(nuevoItem);
        }

        protected override Form InstanciarEditor(BE.Empleados.Empleado item)
        {
            return new frmEditarEmpleado(_serviciosDeAplicacion, item);
        }

        private string[] ColumnasVisibles()
        {
            return new[]
            {
                nameof(BE.Empleados.Empleado.Id),
                nameof(BE.Empleados.Empleado.Nombre),
                nameof(BE.Empleados.Empleado.Apellido),
                nameof(BE.Empleados.Empleado.Sexo)
            };
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            this.DefinirColumnasTipadas(dataGridView, this.ColumnasVisibles());
        }
    }
}
