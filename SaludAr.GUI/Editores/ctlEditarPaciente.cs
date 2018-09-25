using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.BE.Infraestructura;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarPaciente : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IPaciente _pacienteBll;
        private readonly IEmpleado _empleadoBll;
        private readonly BE.Paciente _pacienteEnEdicion;

        public ctlEditarPaciente(ITraductor traductor, IPaciente pacienteBll, IEmpleado empleadoBll, BE.Paciente pacienteEnEdicion)
        {
            InitializeComponent();

            _traductor = traductor;
            _pacienteBll = pacienteBll;
            _empleadoBll = empleadoBll;
            _pacienteEnEdicion = pacienteEnEdicion;

            this.cboSexo.CargarOpciones(empleadoBll.SexosPosibles);
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.txtNombre.Text = _pacienteEnEdicion.Nombre;
            this.txtApellido.Text = _pacienteEnEdicion.Apellido;
            this.txtDocumento.Text = _pacienteEnEdicion.NumeroDocumento;
            this.cboSexo.SelectedValue = (int)_pacienteEnEdicion.Sexo;
            this.dtFechaNacimiento.EstablecerValorEntreElRangoPermitido(_pacienteEnEdicion.FechaNacimiento);
        }

        public void GuardarCambiosEnElModelo()
        {
            _pacienteEnEdicion.Nombre = this.txtNombre.Text;
            _pacienteEnEdicion.Apellido = this.txtApellido.Text;
            _pacienteEnEdicion.NumeroDocumento = this.txtDocumento.Text;
            _pacienteEnEdicion.Sexo = (BE.Empleados.Sexo)this.cboSexo.SelectedValue;
            _pacienteEnEdicion.FechaNacimiento = this.dtFechaNacimiento.Value;

            _pacienteBll.Actualizar(_pacienteEnEdicion);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblNombre.Text = _traductor.TraducirCampoEntidad<BE.Paciente>(nameof(BE.Paciente.Nombre));
            this.lblApellido.Text = _traductor.TraducirCampoEntidad<BE.Paciente>(nameof(BE.Paciente.Apellido));
            this.lblDocumento.Text = _traductor.TraducirCampoEntidad<BE.Paciente>(nameof(BE.Paciente.NumeroDocumento));
            this.lblSexo.Text = _traductor.TraducirCampoEntidad<BE.Paciente>(nameof(BE.Paciente.Sexo));
            this.lblFechaNac.Text = _traductor.TraducirCampoEntidad<BE.Paciente>(nameof(BE.Paciente.FechaNacimiento));
        }
    }
}
