using System;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.GUI.NuevoTurno;

namespace SaludAr.GUI
{
    public partial class frmAsignarTurno : Form, ISubscriptorCambioIdioma
    {
        private int _pasoActual;
        private readonly Action[] _pasos;
        private readonly ITurno _turnoBll;
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;
       
        public frmAsignarTurno(IServiciosDeAplicacion serviciosDeAplicacion)
        { 
            InitializeComponent();

            _turnoBll = serviciosDeAplicacion.Turno;
            _serviciosDeAplicacion = serviciosDeAplicacion;
            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
            
            _pasos = new Action[] {EjecutarPrimerPaso, EjecutarSegundoPaso, FinalizarAsistente };
            this.Ejecutar(0);
        }

        private void Ejecutar(int paso)
        {
            try
            {
                _pasos[paso].Invoke();
                this.HabilitarPrevio(paso > 0);
                this.HabilitarSiguiente(paso < _pasos.Length);
                _pasoActual = paso;
            }
            catch (ErrorDeValidacionException exception)
            {
                this.MostrarDialogoError(_traductorUsuario, exception);
            }
        }

        private void EjecutarPrimerPaso()
        {
            var control = new ctlBuscarPaciente(_traductorUsuario, _serviciosDeAplicacion.Paciente);
            control.CambioPacienteSeleccionado += this.btnSiguiente_Click;
            this.CambiarControlActual(control, null);
        }

        private void EjecutarSegundoPaso()
        {
            var control = new ctlBuscarSlotAgenda(_traductorUsuario, _serviciosDeAplicacion.Agenda, _serviciosDeAplicacion.CentroDeSalud, _serviciosDeAplicacion.Especialidad);
            control.CambioSlotSeleccionado += this.btnSiguiente_Click;
            this.CambiarControlActual(control, actual =>
            {
                var pacienteSeleccionado = ((ctlBuscarPaciente) actual).PacienteSeleccionado;
                if(pacienteSeleccionado == null)
                    throw new ErrorDeValidacionException(ConstantesDeTexto.ErrorPacienteRequerido);

                control.PacienteSeleccionado = pacienteSeleccionado;
            });
        }

        private void FinalizarAsistente()
        {
            var control = (ctlBuscarSlotAgenda)this.ObtenerControlActual();
            var slotSeleccionado = control.SlotSeleccionado;
            if (slotSeleccionado == null)
                throw new ErrorDeValidacionException(ConstantesDeTexto.ErrorSlotAgendaOcupado);

            var turno = _turnoBll.AsignarNuevoTurno(slotSeleccionado, control.PacienteSeleccionado);
            _turnoBll.Actualizar(turno);

            this.MostrarDialogoInformacionFormateado(_traductorUsuario, ConstantesDeTexto.MensajeTurnoAsignado, turno.Paciente, turno.FechaHora);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CambiarControlActual(Control nuevoControl, Action<Control> accionPreviaLiberarControlActual)
        {
            var controlActual = this.ObtenerControlActual();
            if (controlActual != null)
            {
                accionPreviaLiberarControlActual?.Invoke(controlActual);
                this.@group.Controls.Remove(controlActual);
                controlActual.Dispose();
            }

            this.@group.Controls.Add(nuevoControl);
            nuevoControl.Dock = DockStyle.Fill;
            (nuevoControl as ISubscriptorCambioIdioma)?.IdiomaCambiado(_traductorUsuario.IdiomaPreferido);
        }

        private Control ObtenerControlActual()
        {
            return this.@group.Controls.Count == 1 ? this.@group.Controls[0] : null;
        }

        private void HabilitarPrevio(bool valor)
        {
            this.btnAnterior.Enabled = valor;
        }

        private void HabilitarSiguiente(bool valor)
        {
            this.btnSiguiente.Enabled = valor;
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblEncabezado.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuAsignarTurno);
            this.btnAnterior.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonAnterior);
            this.btnSiguiente.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonSiguiente);

            var controlActualTraducible = this.ObtenerControlActual() as ISubscriptorCambioIdioma;
            if (controlActualTraducible != null)
                controlActualTraducible.IdiomaCambiado(nuevoIdioma);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            var nuevoPaso = _pasoActual - 1;
            this.Ejecutar(nuevoPaso);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            var nuevoPaso = _pasoActual + 1;
            this.Ejecutar(nuevoPaso);
        }
    }
}