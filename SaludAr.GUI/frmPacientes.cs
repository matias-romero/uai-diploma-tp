using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Vistas;

namespace SaludAr.GUI
{
    public partial class frmPacientes : frmListado<BE.Paciente>
    {
        public frmPacientes(IServiciosDeAplicacion serviciosDeAplicacion)
            : base(serviciosDeAplicacion, new VistaListadoPaciente(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override void InvocarFormularioAlta()
        {
            var nuevoItem = new BE.Paciente();
            this.InvocarFormularioEdicion(nuevoItem);
        }

        protected override Form InstanciarEditor(BE.Paciente item)
        {
            return new frmEditarPaciente(_serviciosDeAplicacion, item);
        }

        private string[] ColumnasVisibles()
        {
            return new[]
            {
                nameof(BE.Paciente.Id),
                nameof(BE.Paciente.Nombre),
                nameof(BE.Paciente.Apellido),
                nameof(BE.Paciente.NumeroDocumento),
                nameof(BE.Paciente.FechaNacimiento),
                nameof(BE.Paciente.Sexo)
            };
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            this.DefinirColumnasTipadas(dataGridView, this.ColumnasVisibles());
        }
    }
}
