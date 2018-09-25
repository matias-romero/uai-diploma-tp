using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    public partial class frmHashing : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;

        public frmHashing(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoTitulo);

            this.lblSource.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoOrigen);
            this.lblTarget.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoDestino);
            this.btnEncrypt.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoEncriptar);
            this.btnDecrypt.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoDesencriptar);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var source = txtSource.Text;
            this.txtTarget.Text = Criptografia.Default.Encriptar(source);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var source = txtSource.Text;
            this.txtTarget.Text = Criptografia.Default.Desencriptar(source);
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            var isEmpty = string.IsNullOrWhiteSpace(((TextBox) sender).Text);
            this.btnDecrypt.Enabled = !isEmpty;
            this.btnEncrypt.Enabled = !isEmpty;
        }
    }
}