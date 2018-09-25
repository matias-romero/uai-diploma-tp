using System;
using System.Windows.Forms;
using SaludAr.BE.Empleados;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using Empleado = SaludAr.BE.Empleados.Empleado;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarEmpleado : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IEmpleado _empleadoBll;

        private readonly bool _esNuevo;
        private Empleado _empleadoEnEdicion;

        public ctlEditarEmpleado(ITraductor traductor, IEmpleado empleadoBll, IGestorDePermisos gestorDePermisos, Empleado empleadoEnEdicion, bool esNuevo)
        {
            InitializeComponent();

            _traductor = traductor;
            _empleadoBll = empleadoBll;
            _empleadoEnEdicion = empleadoEnEdicion;
            _esNuevo = esNuevo;

            this.cboSexo.CargarOpciones(empleadoBll.SexosPosibles);
            this.comboPerfil.EnlazarListado(gestorDePermisos.ListarFamilias(), nameof(Familia.Descripcion), nameof(Familia.Codigo));
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.txtNombre.Text = _empleadoEnEdicion.Nombre;
            this.txtApellido.Text = _empleadoEnEdicion.Apellido;
            this.txtNroLegajo.Text = _empleadoEnEdicion.NroLegajo.ToString();
            this.cboSexo.SelectedValue = (int) _empleadoEnEdicion.Sexo;
            this.txtTelefono.Text = _empleadoEnEdicion.Telefono;

            var nombreUsuario = "<N/A>";
            if (_empleadoEnEdicion.CredencialUsuario != null)
            {
                this.chkUsuarioHabilitado.Checked = true;
                nombreUsuario = _empleadoEnEdicion.CredencialUsuario.Nombre;
            }
            this.linkNombreUsuario.Text = nombreUsuario;

            this.chkEsProfesional.Enabled = _esNuevo;
            var profesional = _empleadoEnEdicion as BE.Empleados.Profesional;
            if (profesional == null)
                this.chkEsProfesional.Checked = false;
            else
            {
                this.chkEsProfesional.Checked = true;
                this.txtMatricula.Text = profesional.CodMatricula;
            }
        }

        public void GuardarCambiosEnElModelo()
        {
            if(_esNuevo && this.chkEsProfesional.Checked)
                _empleadoEnEdicion = new Profesional();

            _empleadoEnEdicion.Nombre = this.txtNombre.Text;
            _empleadoEnEdicion.Apellido = this.txtApellido.Text;
            _empleadoEnEdicion.NroLegajo = int.Parse(this.txtNroLegajo.Text);
            _empleadoEnEdicion.Sexo = (Sexo) this.cboSexo.SelectedValue;

            if (!_empleadoBll.ValidarLegajo(_empleadoEnEdicion))
                throw new ErrorDeValidacionException(ConstantesDeTexto.ErrorLegajoRepetido);

            var profesional = _empleadoEnEdicion as BE.Empleados.Profesional;
            if (profesional != null)
            {
                profesional.CodMatricula = this.txtMatricula.Text;
                if (string.IsNullOrWhiteSpace(profesional.CodMatricula))
                    throw ErrorDeValidacionException.Literal("***El Nro de matrícula es requerido para los profesionales");
            }

            var credencialUsuario = _empleadoEnEdicion.CredencialUsuario;
            _empleadoBll.Actualizar(_empleadoEnEdicion);

            if (this.chkUsuarioHabilitado.Checked)
            {
                //Debo crearle las credenciales por defecto
                var nombreUsuario = "USR" + _empleadoEnEdicion.NroLegajo.ToString();
                if (credencialUsuario != null)
                    nombreUsuario = credencialUsuario.Nombre;
                
                var perfil = (Familia)this.comboPerfil.SelectedItem;
                _empleadoBll.HabilitarCredenciales(_empleadoEnEdicion, nombreUsuario, perfil);
            }
            else
                _empleadoBll.EliminarCredenciales(_empleadoEnEdicion);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblNombre.Text = _traductor.TraducirCampoEntidad<Empleado>(e => e.Nombre);
            this.lblApellido.Text = _traductor.TraducirCampoEntidad<Empleado>(e => e.Apellido);
            this.lblNroLegajo.Text = _traductor.TraducirCampoEntidad<Empleado>(e => e.NroLegajo);
            this.lblSexo.Text = _traductor.TraducirCampoEntidad<Empleado>(e => e.Sexo);
            this.lblTelefono.Text = _traductor.TraducirCampoEntidad<Empleado>(e => e.Telefono);

            this.chkUsuarioHabilitado.Text = _traductor.Traducir(ConstantesDeTexto.HabilitarComoUsuario);
            this.lblUsuario.Text = _traductor.TraducirCampoEntidad<BE.Infraestructura.Usuario>(u => u.Nombre);
            this.lblPerfil.Text = _traductor.TraducirCampoEntidad<BE.Infraestructura.Usuario>(u => u.Permiso);

            this.chkEsProfesional.Text = _traductor.Traducir(ConstantesDeTexto.EsProfesionalDeLaSalud);
            this.lblMatricula.Text = _traductor.TraducirCampoEntidad<Profesional>(p => p.CodMatricula);
        }

        private void chkUsuarioHabilitado_CheckedChanged(object sender, System.EventArgs e)
        {
            this.comboPerfil.Enabled = this.chkUsuarioHabilitado.Checked;
        }

        private void chkEsProfesional_CheckedChanged(object sender, EventArgs e)
        {
            this.txtMatricula.Enabled = this.chkEsProfesional.Checked;
        }
    }
}
