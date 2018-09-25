using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SaludAr.BE.Bitacora;
using SaludAr.BE.Empleados;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI
{
    public partial class frmLogEntries : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly BLL.IBitacora _bitacoraBll;
        private readonly BLL.IEmpleado _empleadoBll;


        public frmLogEntries(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _bitacoraBll = serviciosDeAplicacion.Bitacora;
            _empleadoBll = serviciosDeAplicacion.Empleado;
            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);

            this.dtPickerFrom.Value = DateTime.Today;
            this.dtPickerTo.Value = DateTime.Now;
            this.EnlazarEventosDisponiblesFiltrado();
            this.EnlazarFiltroUsuario();
        }

        private void EnlazarFiltroUsuario()
        {
            var listado = _empleadoBll.ListarEmpleadosSoloConCredenciales()
                .Select(e => new KeyValuePair<string, string>(e.CredencialUsuario?.Nombre, e.ToString()));

            //this.cboUsuario.EnlazarListado(listado, string.Empty, nameof(BE.Empleados.Empleado.Id));
            this.cboUsuario.DataSource = null;
            this.cboUsuario.DataSource = listado.ToArray();
            this.cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EnlazarEventosDisponiblesFiltrado()
        {
            var listado = _bitacoraBll.ObtenerEventosDisponibles(_traductorUsuario).AsObservable();
            listado.Insert(0, new Evento{ Id = -1, Descripcion = _traductorUsuario.Traducir(ConstantesDeTexto.LeyendaFiltrarTodos)});

            this.cboEvento.EnlazarListado(listado, nameof(Evento.Descripcion), nameof(Evento.Id));
            this.cboEvento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtPickerFrom.Value;
            var fechaHasta = dtPickerTo.Value;
            var eventoParaFiltrar = (Evento) this.cboEvento.SelectedItem;

            if (fechaDesde > fechaHasta)
            {
                this.MostrarDialogoAdvertencia(_traductorUsuario, ConstantesDeTexto.BitacoraRangoFechasInvalido);
                return;
            }

            //Obtengo los registros de la bitácora entre ese rango de fechas
            var eventosEnBitacora = _bitacoraBll
                .ObtenerTodasLasEntradasEnBitacora(_traductorUsuario, fechaDesde, fechaHasta, eventoParaFiltrar)
                .ToArray();

            if (this.chkFiltrarUsuario.Checked)
            {
                var usuarioFiltrado = ((KeyValuePair<string,string>) this.cboUsuario.SelectedItem).Key;
                eventosEnBitacora = eventosEnBitacora.Where(evt => string.Equals(evt.Usuario?.Nombre, usuarioFiltrado))
                    .ToArray();
            }

            this.dataGridView.DataSource = null;
            this.dataGridView.DataSource = eventosEnBitacora;
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BitacoraTitulo);

            this.btnFilter.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BitacoraFiltrar);
            this.lblDateRange.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BitacoraRangoFechas);
            this.lblTipoEvento.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BitacoraEventoSeguridad);
            this.lblUsuario.Text = _traductorUsuario.TraducirEntidad<BE.Infraestructura.Usuario>();
        }

        private void chkFiltrarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            this.cboUsuario.Enabled = this.chkFiltrarUsuario.Checked;
        }
    }
}