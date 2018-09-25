using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI.Compartidos
{
    public abstract partial class frmDialogo<T> : Form, ISubscriptorCambioIdioma
    {
        private readonly string _claveTitulo;
        private readonly ITraductorUsuario _traductorUsuario;

        protected frmDialogo(IServiciosDeAplicacion serviciosDeAplicacion, T item, string claveTitulo)
        {
            InitializeComponent();

            _claveTitulo = claveTitulo;
            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
            this.LoadEditor(serviciosDeAplicacion, item);
        }

        private void LoadEditor(IServiciosDeAplicacion serviciosDeAplicacion, T item)
        {
            var editorEnlazado = this.CrearControlDeEditorEnlazado(serviciosDeAplicacion, item);
            var ctlEditor = (Control)editorEnlazado; //Debe ser un control compatible con WindowsForms
            ctlEditor.Dock = DockStyle.Fill;
            this.@group.Controls.Add(ctlEditor);

            editorEnlazado.CargarDesdeModeloAInterfazVisual();
            this.IdiomaCambiado(_traductorUsuario.IdiomaPreferido);
        }

        private IEditorEnlazado EditorEnlazado
        {
            get { return (IEditorEnlazado)this.@group.Controls[0]; }
        }

        protected abstract IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, T item);

        public virtual void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion);
            this.lblEncabezado.Text = _traductorUsuario.Traducir(_claveTitulo);

            this.btnOk.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonOk);
            this.btnCancel.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonCancelar);

            if (this.@group.Controls.Count > 0)
                ((ISubscriptorCambioIdioma)this.@group.Controls[0]).IdiomaCambiado(nuevoIdioma);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.EditorEnlazado.GuardarCambiosEnElModelo();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (ErrorDeValidacionException excepcion)
            {
                this.MostrarDialogoError(_traductorUsuario, excepcion);
                this.DialogResult = DialogResult.None;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
