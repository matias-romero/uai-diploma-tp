using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.Properties;

namespace SaludAr.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmInstalador.ComprobarInstalacionCompletada();

            //Inicializo los servicios por defecto de sistema
            ConfigurarCapaDeAccesoDatos();
            ConfigurarServiciosDeCriptografia();
            var serviciosAplicacion = new ServiciosDeAplicacion(ConfiguracionGlobal.Instance);

            //var traductorUsuario = new TraductorUsuario();
            var traductorUsuario = serviciosAplicacion.TraductorUsuario;
            ConfigurarIdiomaPorDefecto(traductorUsuario);
            if (!ComprobarIntegridadDelSistema(traductorUsuario))
                return;

            if (PromptForLogin(serviciosAplicacion))
                Application.Run(new frmMain(serviciosAplicacion));
        }

        public static bool PromptForLogin(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            using (var loginForm = new frmLogin(serviciosDeAplicacion))
            {
                var dialogResult = loginForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    return true;

                loginForm.Close();
            }

            return false;
        }

        public static void ConfigurarIdiomaPorDefecto(ITraductorUsuario traductorUsuario)
        {
            var codigoIdiomaPorDefecto = Settings.Default.IdiomaPorDefecto;
            var idiomaPorDefecto =
                traductorUsuario.IdiomasSoportados.Single(
                    i => i.CodigoIso.Equals(codigoIdiomaPorDefecto, StringComparison.InvariantCultureIgnoreCase));
            traductorUsuario.IdiomaPreferido = idiomaPorDefecto;
        }

        public static void ConfigurarServiciosDeCriptografia()
        {
            Criptografia.Default = new Criptografia(Settings.Default.ClaveCompartida);
        }

        public static void ConfigurarCapaDeAccesoDatos()
        {
            ConfiguracionGlobal.Instance.CadenaDeConexionParaAccesoDatos = Settings.Default.CadenaDeConexion;
        }

        public static bool ComprobarIntegridadDelSistema(ITraductorUsuario traductorUsuario)
        {
            try
            {
                var integridadSistema = new BLL.IntegridadSistema(Settings.Default.EstaCorrupto);
                integridadSistema.ComprobarIntegridad();
            }
            catch (IntegridadSistema.SistemaCorruptoException ex)
            {
                var mensaje = traductorUsuario.Traducir(ex.ConstanteError);
                MessageBox.Show(mensaje, traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}