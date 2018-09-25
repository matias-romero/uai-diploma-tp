using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    /// <summary>
    /// Este formulario es complementario al sistema y solo se incluye como "Medio de instalación"
    /// </summary>
    public partial class frmInstalador : Form, ISubscriptorCambioIdioma
    {
        public static void ComprobarInstalacionCompletada()
        {
            var configFilename = System.Reflection.Assembly.GetExecutingAssembly().Location + ".config";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(configFilename);

            var navigator = xmlDocument.CreateNavigator();
            var node = navigator.SelectSingleNode("//connectionStrings/add");
            node.MoveToAttribute("connectionString", string.Empty);

            if (string.IsNullOrWhiteSpace(node.Value))
            {
                var cnn = ObtenerCadenaDeConexion();
                node.SetValue(cnn);
                xmlDocument.Save(configFilename);
                //Hack para que recargue los settings
                Application.Restart();
                Environment.Exit(0);
            }
        }

        public frmInstalador()
        {
            InitializeComponent();

            this.IdiomaCambiado(null);
            this.txtServidor.Text = "(localdb)\\MSSQLLocalDB";
            this.txtBaseDeDatos.Text = "SaludArDb";
        }

        public string CadenaDeConexion { get; set; }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = "Bienvenido";
            this.lblServidor.Text = "Servidor SQL";
            this.lblBaseDeDatos.Text = "Base de Datos";

            this.chkUsarKerberos.Text = "Utilizar autenticación integrada";
            this.lblUsuario.Text = "Usuario";
            this.lblContraseña.Text = "Contraseña";

            this.btnConfigurar.Text = "Guardar";
        }

        private static string ObtenerCadenaDeConexion()
        {
            using (var form = new frmInstalador())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.CadenaDeConexion;
                }
            }

            MostrarError("Debe indicar un Servidor SQL válido para poder continuar. Por favor vuelva a ejecutar el instalador nuevamente.");
            Environment.Exit(1);
            return null;
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            this.DeshabilitarControles();

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = this.txtServidor.Text,
                InitialCatalog = this.txtBaseDeDatos.Text
            };

            if (this.chkUsarKerberos.Checked)
                sqlConnectionStringBuilder.IntegratedSecurity = true;
            else
            {
                sqlConnectionStringBuilder.UserID = this.txtUsuario.Text;
                sqlConnectionStringBuilder.Password = this.txtContraseña.Text;
            }

            this.CadenaDeConexion = sqlConnectionStringBuilder.ToString();
            if (this.ProbarCadenaDeConexion(this.CadenaDeConexion))
                this.DialogResult = DialogResult.OK;

            this.HabilitarControles();
        }

        private bool ProbarCadenaDeConexion(string cnnString)
        {
            var result = false;
            var cnnStringBuilder = new SqlConnectionStringBuilder(cnnString) { InitialCatalog = "master" };
            using (var conexion = new SqlConnection(cnnStringBuilder.ToString()))
            {
                try
                {
                    conexion.Open();
                    result = true;
                }
                catch (Exception)
                {
                    //Es una prueba controlada
                    MostrarError("No se puede conectar al Servidor SQL solicitado");
                }
            }

            return result;
        }

        private void DeshabilitarControles()
        {
            this.groupBox1.Enabled = false;
            this.btnConfigurar.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
        }

        private void HabilitarControles()
        {
            Cursor.Current = Cursors.Default;
            this.groupBox1.Enabled = true;
            this.btnConfigurar.Enabled = true;
        }

        private static void MostrarError(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
