using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI.NuevoTurno
{
    public partial class ctlBuscarSlotAgenda : UserControl, ISubscriptorCambioIdioma
    {
        public event EventHandler CambioSlotSeleccionado;

        private readonly ITraductor _traductor;
        private readonly IAgenda _agendaBll;
        private readonly ICentroDeSalud _centroDeSaludBll;
        private readonly IEspecialidad _especialidadBll;

        public ctlBuscarSlotAgenda(ITraductor traductor, BLL.IAgenda agendaBll, BLL.ICentroDeSalud centroDeSaludBll, BLL.IEspecialidad especialidadBll)
        {
            InitializeComponent();

            _traductor = traductor;
            _agendaBll = agendaBll;
            _centroDeSaludBll = centroDeSaludBll;
            _especialidadBll = especialidadBll;

            this.CargarControlesEnlazados();
        }

        private void CargarControlesEnlazados()
        {
            this.cboCentroSalud.EnlazarListado(_centroDeSaludBll.Listar(), nameof(BE.CentroDeSalud.Nombre), nameof(BE.CentroDeSalud.Id));
            this.cboEspecialidad.EnlazarListado(_especialidadBll.Listar(), nameof(BE.Especialidad.Nombre), nameof(BE.Especialidad.Id));
            this.dtFechaTentativa.Value = DateTime.Now;
        }

        public BE.Paciente PacienteSeleccionado { get; set; }

        public BE.Agenda.SlotDeAgenda SlotSeleccionado { get; set; }

        public BE.CentroDeSalud CentroDeSalud
        {
            get { return (BE.CentroDeSalud)this.cboCentroSalud.SelectedItem; }
            set { this.cboCentroSalud.SelectedItem = value; }
        }

        public BE.Especialidad Especialidad
        {
            get { return (BE.Especialidad) this.cboEspecialidad.SelectedItem; }
            set { this.cboEspecialidad.SelectedItem = value; }
        }

        public DateTime FechaTentativa
        {
            get { return this.dtFechaTentativa.Value; }
            set { this.dtFechaTentativa.Value = value; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var slots = _agendaBll.ConsultarDisponibilidad(this.PacienteSeleccionado, this.CentroDeSalud, this.Especialidad, this.FechaTentativa);
            this.dtGridOferta.DataSource = null;
            this.dtGridOferta.DataSource = slots;
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.btnBuscar.Text = _traductor.Traducir(ConstantesDeTexto.BotonBuscar);
            this.lblCentroSalud.Text = _traductor.TraducirEntidad<BE.CentroDeSalud>();
            this.lblEspecialidad.Text = _traductor.TraducirEntidad<BE.Especialidad>();
            this.lblFechaTentativa.Text = _traductor.Traducir(ConstantesDeTexto.FechaTentativa);
        }

        private void dtGridOferta_DoubleClick(object sender, EventArgs e)
        {
            if (this.dtGridOferta.CurrentRow != null)
            {
                this.SlotSeleccionado = (BE.Agenda.SlotDeAgenda) this.dtGridOferta.CurrentRow.DataBoundItem;
                if(CambioSlotSeleccionado != null)
                    CambioSlotSeleccionado(this, EventArgs.Empty);
            }
        }
    }
}
