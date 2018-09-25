using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI.AdmisionarTurno
{
    public partial class frmAdmisionarTurno : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IPaciente _pacienteBll;
        private readonly ITurno _turnoBll;

        public frmAdmisionarTurno(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            _pacienteBll = serviciosDeAplicacion.Paciente;
            _turnoBll = serviciosDeAplicacion.Turno;

            this.InicializarPaneles();
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
        }

        private void InicializarPaneles()
        {
            var controlBuscarPaciente = new NuevoTurno.ctlBuscarPaciente(_traductorUsuario, _pacienteBll);
            controlBuscarPaciente.Dock = DockStyle.Fill;
            controlBuscarPaciente.CambioPacienteSeleccionado += ControlBuscarPacienteOnCambioPacienteSeleccionado;
            this.splitContainer.Panel1.Controls.Add(controlBuscarPaciente);

            var controlGrillaTurnos = new DataGridViewEx();
            controlGrillaTurnos.Dock = DockStyle.Fill;
            controlGrillaTurnos.EditRowRequested += ControlGrillaTurnosOnEditRowRequested;
            this.splitContainer.Panel2.Controls.Add(controlGrillaTurnos);
        }

        private void ControlGrillaTurnosOnEditRowRequested(object sender, DataGridViewCellEventArgs e)
        {
            var turnoParaAdmisionar = (BE.Agenda.Turno)((DataGridViewEx) sender).Rows[e.RowIndex].DataBoundItem;
            //TODO: Mover a la BLL
            turnoParaAdmisionar.FechaHoraAdmision = DateTime.Now;
            _turnoBll.Actualizar(turnoParaAdmisionar);

            this.MostrarDialogoInformacion(_traductorUsuario, ConstantesDeTexto.MensajeTurnoAdmisionado);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ControlBuscarPacienteOnCambioPacienteSeleccionado(object sender, EventArgs e)
        {
            var paciente = ((NuevoTurno.ctlBuscarPaciente) sender).PacienteSeleccionado;

            var dataGridView = this.ControlGrillaTurnos;
            dataGridView.DataSource = null;
            dataGridView.DataSource = _turnoBll.ListarProgramadosPorPaciente(paciente).AsObservable();
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblEncabezado.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuAdmisionarTurnos);
            this.PropagarCambioIdiomaEnControlesCompatibles(nuevoIdioma);
        }

        private NuevoTurno.ctlBuscarPaciente ControlBuscadorPaciente
        {
            get { return (NuevoTurno.ctlBuscarPaciente) this.splitContainer.Panel1.Controls[0]; }
        }

        private DataGridViewEx ControlGrillaTurnos
        {
            get { return (DataGridViewEx)this.splitContainer.Panel2.Controls[0]; }
        }
    }
}
