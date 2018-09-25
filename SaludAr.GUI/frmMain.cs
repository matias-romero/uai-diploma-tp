using System;
using System.Linq;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.AdmisionarTurno;

namespace SaludAr.GUI
{
    public partial class frmMain : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;

        public frmMain(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _serviciosDeAplicacion = serviciosDeAplicacion;
            _traductorUsuario = _serviciosDeAplicacion.TraductorUsuario;
            _traductorUsuario.Subscribirse(this);

            this.CargarMenuIdiomas();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ControlDeAutorizacion(_serviciosDeAplicacion.ControlDePatentes);
        }

        private void ControlDeAutorizacion(IControlDePatentes controlDePatentes)
        {
            this.mnuCentrosDeSaludToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.ConfigurarCentrosDeSalud);
            this.mnuEspecialidadesToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.ConfigurarEspecialidadesDeLaRed);
            this.mnuPacientesToolStripMenuItem.Enabled = true;

            this.backupRestoreToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.RealizarTareasDeBackup);
            this.systemLogToolStripMenuItem.Enabled = true;

            this.mnuAsignarTurnoToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.DarTurnoPaciente);
            this.mnuAdmisionarTurnosToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.AdmisionDePaciente);
            this.mnuMisTurnosToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.AtenderPacienteRegistrarEvolucion);

            this.mnuProfesionalesToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.EditarEspecialidadesDelProfesional);
            this.mnuGestionPerfilesToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.AsignarRolesPorUsuario);

            this.mnuConfigurarAgendaToolStripMenuItem.Enabled = controlDePatentes.ConcederAcceso(ControlDePatentes.DefinirAgenda);
            this.mnuVisualizarAgendaToolStripMenuItem.Enabled = false; //ControlDePatentes.VerTurnosAsignados
            this.MostrarMenuSoloSiTieneHijosVisibles(this.mnuAgendasToolStripMenuItem);
        }

        private void MostrarMenuSoloSiTieneHijosVisibles(ToolStripMenuItem menuItem)
        {
            menuItem.Enabled = menuItem.DropDownItems.Cast<ToolStripItem>().Any(submenu => submenu.Enabled);
        }

        #region "Idioma"

        private void CargarMenuIdiomas()
        {
            foreach (var idioma in _traductorUsuario.IdiomasSoportados)
            {
                var menuItem = new ToolStripMenuItem(idioma.Nombre) { Tag = idioma };
                languageToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            languageToolStripMenuItem.DropDownItemClicked += IdiomaMenuItem_DropDownItemClicked;
        }

        private void IdiomaMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var idiomaPreferido = (BE.Infraestructura.Idioma)e.ClickedItem.Tag;
            _traductorUsuario.IdiomaPreferido = idiomaPreferido;
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion);

            this.fileMenu.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuArchivo);
            this.mnuCentrosDeSaludToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuCentrosDeSalud);
            this.mnuEspecialidadesToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuEspecialidades);
            this.mnuAgendasToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuAgendas);
            this.mnuConfigurarAgendaToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuConfigurarAgenda);
            this.backupRestoreToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuBackupRestore);
            this.exitToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuSalir);
            this.hRToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuRRHH);
            this.mnuEmpleadosToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuEmpleados);
            this.mnuProfesionalesToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuProfesionales);
            this.mnuGestionPerfilesToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuGestionPerfiles);
            this.optionsToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuOpciones);
            this.languageToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuIdioma);
            this.toolsMenu.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuHerramientas);
            this.cryptoServicesToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.CifradoTitulo);
            this.systemLogToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BitacoraTitulo);

            this.appointmentsToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuTurnos);
            this.mnuAsignarTurnoToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuAsignarTurno);
            this.mnuVerDisponibilidadTurnosToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuVerDisponibilidadTurnos);
            this.mnuMisTurnosToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuMisTurnos);
            this.mnuAdmisionarTurnosToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuAdmisionarTurnos);

            this.mnuPacientesToolStripMenuItem.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuPacientes);
            this.toolStripStatusLabel.Text = _traductorUsuario.TraducirConFormato(ConstantesDeTexto.TituloUsuarioEnLinea, SessionManager.Instance.UsuarioActual.Nombre);
        }

        #endregion

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cryptoServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmHashing>();
        }

        private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmLogEntries>();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmBackupRestore>();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Me aseguro de liberar todos los formularios que pudiesen quedar abiertos primero
            foreach (var mdiChild in this.MdiChildren)
            {
                mdiChild.Close();
                mdiChild.Dispose();
            }

            //Me desenlazo de los servicios de traducción
            _traductorUsuario.Desubscribirse(this);

            //Cierro la sesión del usuario actual
            var usuarioBll = _serviciosDeAplicacion.Usuario;
            usuarioBll.FinalizarSesion();
        }

        private Form CreateMDIChild<T>() where T : Form
        {
            //Todos los MDI deben recibir el traductor como regla general para ser compatibles con las funcionalidades de traducción
            var childForm = (Form)Activator.CreateInstance(typeof(T), _serviciosDeAplicacion);
            childForm.Text = string.Empty;
            childForm.MdiParent = this;
            childForm.Show();
            return childForm;
        }

        #region "Accesos a los menu de ABM"
        private void mnuEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmEmpleados>();
        }
        private void mnuProfesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmProfesionales>();
        }
        private void mnuGestionPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmGestionDePermisos>();
        }
        private void mnuCentrosDeSaludToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmCentrosDeSalud>();
        }
        private void mnuEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmEspecialidades>();
        }
        private void mnuConfigurarAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmConfigurarAgendas>();
        }
        private void mnuPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmPacientes>();
        }
        private void mnuAsignarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmAsignarTurno>();
        }
        private void mnuMisTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmMisTurnos>();
        }
        private void mnuAdmisionarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateMDIChild<frmAdmisionarTurno>();
        }
        #endregion
    }
}