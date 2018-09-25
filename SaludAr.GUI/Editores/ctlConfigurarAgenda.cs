using System;
using System.Windows.Forms;
using SaludAr.BE.Agenda;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using CentroDeSalud = SaludAr.BE.CentroDeSalud;
using Especialidad = SaludAr.BE.Especialidad;

namespace SaludAr.GUI.Editores
{
    public partial class ctlConfigurarAgenda : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IAgenda _agendaBll;
        private readonly ICentroDeSalud _centroDeSaludBll;
        private readonly IEspecialidad _especialidadBll;
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;
        private readonly DefinicionAgenda _item;

        public ctlConfigurarAgenda(IServiciosDeAplicacion serviciosDeAplicacion, BE.Agenda.DefinicionAgenda item)
        {
            InitializeComponent();

            _traductor = serviciosDeAplicacion.TraductorUsuario;
            _agendaBll = serviciosDeAplicacion.Agenda;
            _centroDeSaludBll = serviciosDeAplicacion.CentroDeSalud;
            _especialidadBll = serviciosDeAplicacion.Especialidad;
            _serviciosDeAplicacion = serviciosDeAplicacion;
            _item = item;

            this.dtGridView.Columns.Clear();
            this.dtGridView.AutoGenerateColumns = false;
            this.dtGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(EntradaAgenda.DiaSemana),
                DataPropertyName = nameof(EntradaAgenda.DiaSemana),
                HeaderText = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.DiaSemana))
            });

            var inicioBloqueColumn = new DataGridViewTextBoxColumn
            {
                Name = nameof(EntradaAgenda.InicioBloque),
                DataPropertyName = nameof(EntradaAgenda.InicioBloque),
                HeaderText = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.InicioBloque))
            };
            inicioBloqueColumn.DefaultCellStyle.Format = "T";
            this.dtGridView.Columns.Add(inicioBloqueColumn);

            var finBloqueColumn = new DataGridViewTextBoxColumn
            {
                Name = nameof(EntradaAgenda.FinBloque),
                DataPropertyName = nameof(EntradaAgenda.FinBloque),
                HeaderText = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.FinBloque))
            };
            finBloqueColumn.DefaultCellStyle.Format = "T";
            this.dtGridView.Columns.Add(finBloqueColumn);

            this.dtGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(EntradaAgenda.Duracion),
                DataPropertyName = nameof(EntradaAgenda.Duracion),
                HeaderText = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.Duracion))
            });

            this.dtGridView.AddButtonColumn(string.Empty, _traductor.Traducir(ConstantesDeTexto.BotonEliminar));
            this.dtDesde.MinDate = DateTime.Today;
            this.dtHasta.MaxDate = DateTime.Today.AddYears(100);
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.cboCentroSalud.EnlazarListado(_centroDeSaludBll.Listar(), nameof(BE.CentroDeSalud.Nombre), nameof(BE.CentroDeSalud.Id));
            this.cboEspecialidad.EnlazarListado(_especialidadBll.Listar(), nameof(BE.Especialidad.Nombre), nameof(BE.Especialidad.Id));
            this.dtDesde.EstablecerValorEntreElRangoPermitido(_item.Desde);
            this.dtHasta.EstablecerValorEntreElRangoPermitido(_item.Hasta);

            if(_item.CentroDeSalud != null)
                this.cboEspecialidad.SelectedValue = _item.CentroDeSalud.Id;
            if(_item.Especialidad != null)
                this.cboEspecialidad.SelectedValue = _item.Especialidad.Id;
        }

        public void GuardarCambiosEnElModelo()
        {
            _item.CentroDeSalud = (CentroDeSalud) this.cboCentroSalud.SelectedItem;
            _item.Especialidad = (Especialidad) this.cboEspecialidad.SelectedItem;
            _item.Desde = this.dtDesde.Value;
            _item.Hasta = this.dtHasta.Value;
            _agendaBll.Actualizar(_item);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblCentroSalud.Text = _traductor.TraducirEntidad<BE.CentroDeSalud>();
            this.lblEspecialidad.Text = _traductor.TraducirEntidad<BE.Especialidad>();
            this.lblVigencia.Text = _traductor.Traducir(ConstantesDeTexto.Vigencia);
        }

        private void ComboValueChanged(object sender, EventArgs e)
        {
            this.RecargarOferta();
        }

        private void RecargarOferta()
        {
            this.dtGridView.DataSource = null;
            this.dtGridView.DataSource = _item.Bloques.AsObservable();
        }

        private void dtGridView_NewRowRequested(object sender, EventArgs e)
        {
            var nuevaEntrada = new BE.Agenda.EntradaAgenda();
            this.EditarEntradaAgenda(nuevaEntrada, true);
        }

        private void dtGridView_RowButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            //Delete
            var selected = this.dtGridView.Rows[e.RowIndex].DataBoundItem as EntradaAgenda;
            _item.Bloques.Remove(selected);

            this.RecargarOferta();
        }

        private void dtGridView_EditRowRequested(object sender, DataGridViewCellEventArgs e)
        {
            //Edit
            var selected = this.dtGridView.Rows[e.RowIndex].DataBoundItem as EntradaAgenda;
            this.EditarEntradaAgenda(selected, false);
        }

        private void EditarEntradaAgenda(EntradaAgenda entradaEnEdicion, bool esNuevo)
        {
            using (var form = new frmOfertaAgenda(_serviciosDeAplicacion, entradaEnEdicion))
            {
                if (form.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    //TODO: Debería comprobar que no cargue bloques inconsistentes de rangos (dia -> Inicio/Fin)
                    if(esNuevo)
                        _item.Bloques.Add(entradaEnEdicion);

                    this.RecargarOferta();
                    //this.dtGridView.ResetBindings();
                }
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            this.dtHasta.MinDate = this.dtDesde.Value;
        }
    }
}
