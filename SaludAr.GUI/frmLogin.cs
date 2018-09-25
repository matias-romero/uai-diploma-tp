using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    public partial class frmLogin : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;

        public frmLogin(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _serviciosDeAplicacion = serviciosDeAplicacion;
            _traductorUsuario = _serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var usuarioBll = _serviciosDeAplicacion.Usuario;
            var usuario = usuarioBll.IniciarSesion(this.txtUsername.Text, this.txtPassword.Text);
            if (usuario != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                //Notifico que falló el proceso de autenticación
                this.MostrarDialogoError(_traductorUsuario, ConstantesDeTexto.LoginErrorAutenticacion);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion);
            this.btnOk.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonOk);
            this.btnCancel.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonCancelar);

            this.lblBienvenido.Text = _traductorUsuario.Traducir(ConstantesDeTexto.TituloBienvenido);
            this.lblUsername.Text = _traductorUsuario.Traducir(ConstantesDeTexto.LoginNombreUsuario);
            this.lblPassword.Text = _traductorUsuario.Traducir(ConstantesDeTexto.LoginContraseña);
        }
    }
}