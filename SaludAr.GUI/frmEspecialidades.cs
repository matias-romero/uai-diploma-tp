using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Vistas;

namespace SaludAr.GUI
{
    public partial class frmEspecialidades : frmListado<BE.Especialidad>
    {
        public frmEspecialidades(IServiciosDeAplicacion serviciosDeAplicacion) 
            : base(serviciosDeAplicacion, new VistaListadoEspecialidad(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        private string[] ColumnasVisibles()
        {
            return new[]
            {
                nameof(BE.Especialidad.Id),
                nameof(BE.Especialidad.Nombre)
            };
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            this.DefinirColumnasTipadas(dataGridView, this.ColumnasVisibles());
            //base.DefinirColumnas(dataGridView);
        }

        protected override void InvocarFormularioAlta()
        {
            var nuevoItem = new BE.Especialidad();
            this.InvocarFormularioEdicion(nuevoItem);
        }

        protected override Form InstanciarEditor(BE.Especialidad item)
        {
            return new frmEditarEspecialidad(_serviciosDeAplicacion, item);
        }
    }
}
