using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    public partial class frmBackupRestore : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly BLL.IBackupRestore _backupRestoreBll;

        public frmBackupRestore(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);

            _backupRestoreBll = serviciosDeAplicacion.BackupRestore;
            this.ReloadBackupList();
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuBackupRestore);

            this.btnBackup.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonBackup);
            this.btnRestore.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonRestore);
        }

        private void ReloadBackupList()
        {
            this.lstBackups.DataSource = null;
            this.lstBackups.DataSource = _backupRestoreBll.ListarPuntosRestauracion();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            _backupRestoreBll.CrearPuntoRestauracion(this.txtBackupName.Text);
            this.ReloadBackupList();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var puntoDeRestauracionSeleccionado = (PuntoDeRestauracion) this.lstBackups.SelectedItem;
            if (puntoDeRestauracionSeleccionado != null)
            {
                var restaurado = _backupRestoreBll.VolverAlPuntoDeRestauracion(puntoDeRestauracionSeleccionado.Nombre);
                if (restaurado)
                    this.MostrarDialogoInformacion(_traductorUsuario, ConstantesDeTexto.SistemaRestauradoCorrectamente);

                var form = Application.OpenForms["frmMain"];
                form.Close();
            }

            //TODO: Else mostrar una advertencia que selccione uno primero
        }
    }
}