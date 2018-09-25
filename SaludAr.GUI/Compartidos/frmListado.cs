using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Vistas;

namespace SaludAr.GUI.Compartidos
{
    public abstract partial class frmListado<T> : Form, ISubscriptorCambioIdioma
    {
        private readonly VistaListado<T> _vistaListado;
        protected readonly ITraductorUsuario _traductorUsuario;
        protected readonly IServiciosDeAplicacion _serviciosDeAplicacion;

        protected frmListado(IServiciosDeAplicacion serviciosDeAplicacion, VistaListado<T> vistaListado)
        {
            InitializeComponent();

            _vistaListado = vistaListado;
            _serviciosDeAplicacion = serviciosDeAplicacion;
            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);   
            this.Enlazar(_vistaListado);
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = string.Empty; //_traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion);

            this.lblEncabezado.Text = _traductorUsuario.Traducir(_vistaListado.Titulo);
            this.btnNuevo.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonNuevo);

            //Esto es para recargar los encabezados de las columnas
            this.RefrescarEnlazados();
        }

        private void Enlazar(IVistaListado vistaListado)
        {
            this.btnNuevo.Visible = vistaListado.PuedeAgregar;

            this.DefinirColumnas(this.dtGridView);
            this.dtGridView.DataSource = null;
            this.dtGridView.DataSource = vistaListado.ListarTodos();
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            this.InvocarFormularioAlta();
        }

        private void dtGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _vistaListado.PuedeEditar)
            {
                var item = dtGridView.Rows[e.RowIndex].DataBoundItem;
                if (item != null)
                    this.InvocarFormularioEdicion((T)item);
            }
        }

        protected void RefrescarEnlazados()
        {
            _vistaListado.Refrescar();
            this.Enlazar(_vistaListado);
        }

        #region "Template Methods"
        protected virtual void InvocarFormularioAlta()
        {
        }

        protected virtual void InvocarFormularioEdicion(T item)
        {
            using (var form = this.InstanciarEditor(item))
            {
                form.ShowDialog();
                this.RefrescarEnlazados();
            }
        }

        protected virtual Form InstanciarEditor(T item)
        {
            return null;
        }

        protected virtual void DefinirColumnas(DataGridView dataGridView)
        {
            //Por defecto van todas las columnas del objeto
            dataGridView.AutoGenerateColumns = true;
        }

        protected virtual void DefinirColumnasTipadas(DataGridView dataGridView, string[] columnasVisibles)
        {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            foreach (var columnaVisible in columnasVisibles)
                dataGridView.Columns.Add(this.CrearColumnaEnlazada(columnaVisible));
        }

        protected DataGridViewTextBoxColumn CrearColumnaEnlazada(string columnaVisible)
        {
            var key = string.Format("{0}_{1}", typeof(T).Name, columnaVisible);
            return new DataGridViewTextBoxColumn
            {
                Name = columnaVisible,
                DataPropertyName = columnaVisible,
                HeaderText = _traductorUsuario.Traducir(key)
            };
        }

        #endregion
    }
}
