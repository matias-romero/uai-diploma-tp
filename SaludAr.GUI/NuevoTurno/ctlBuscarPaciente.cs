using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using Paciente = SaludAr.BE.Paciente;

namespace SaludAr.GUI.NuevoTurno
{
    public partial class ctlBuscarPaciente : UserControl, ISubscriptorCambioIdioma
    {
        public event EventHandler CambioPacienteSeleccionado;

        private readonly ITraductor _traductor;
        private readonly IPaciente _pacienteBll;

        public ctlBuscarPaciente(ITraductor traductor, BLL.IPaciente pacienteBll)
        {
            InitializeComponent();

            _traductor = traductor;
            _pacienteBll = pacienteBll;
        }

        public BE.Paciente PacienteSeleccionado { get; set; }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.btnBuscar.Text = _traductor.Traducir(ConstantesDeTexto.BotonBuscar);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                this.btnBuscar_Click(this.btnBuscar, EventArgs.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var texto = this.txtBuscar.Text;

            var listado = _pacienteBll.Buscar(texto);
            this.dtGridResutlados.DataSource = null;
            this.dtGridResutlados.DataSource = listado.AsObservable();
        }

        private void dtGridResutlados_DoubleClick(object sender, EventArgs e)
        {
            if (this.dtGridResutlados.CurrentRow != null)
            {
                this.PacienteSeleccionado = (BE.Paciente)this.dtGridResutlados.CurrentRow.DataBoundItem;
                if (CambioPacienteSeleccionado != null)
                    CambioPacienteSeleccionado(this, EventArgs.Empty);
            }
        }
    }
}
