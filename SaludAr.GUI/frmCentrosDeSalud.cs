using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Vistas;
using CentroDeSalud = SaludAr.BE.CentroDeSalud;

namespace SaludAr.GUI
{
    public partial class frmCentrosDeSalud : frmListado<BE.CentroDeSalud>
    {
        public frmCentrosDeSalud(IServiciosDeAplicacion serviciosDeAplicacion)
        :base(serviciosDeAplicacion, new VistaListadoCentroDeSalud(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override void InvocarFormularioAlta()
        {
            var nuevoItem = new BE.CentroDeSalud();
            this.InvocarFormularioEdicion(nuevoItem);
        }

        protected override Form InstanciarEditor(CentroDeSalud item)
        {
            return new frmEditarCentroDeSalud(_serviciosDeAplicacion, item);
        }

        private string[] ColumnasVisibles()
        {
            return new[]
            {
                nameof(BE.CentroDeSalud.Id),
                nameof(BE.CentroDeSalud.Nombre)
            };
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            this.DefinirColumnasTipadas(dataGridView, this.ColumnasVisibles());
        }
    }
}
