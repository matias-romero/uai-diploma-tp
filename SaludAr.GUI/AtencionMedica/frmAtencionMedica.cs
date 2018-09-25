using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI.AtencionMedica
{
    public partial class frmAtencionMedica : Form, ISubscriptorCambioIdioma
    {
        private readonly BE.Agenda.Turno _turno;
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;
        private readonly IHistoriaClinica _historiaClinicaBll;

        public frmAtencionMedica(IServiciosDeAplicacion serviciosDeAplicacion, BE.Agenda.Turno turno)
        {
            InitializeComponent();

            _turno = turno;
            _serviciosDeAplicacion = serviciosDeAplicacion;
            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);

            _historiaClinicaBll = serviciosDeAplicacion.HistoriaClinica;
            this.EnlazarDatosPaciente(turno.Paciente);

            var turnoBll = serviciosDeAplicacion.Turno;
            turnoBll.IniciarAtencion(turno);
        }

        private void EnlazarDatosPaciente(BE.Paciente paciente)
        {
            this.lblPaciente.Text = paciente.ToString();

            var hc = _historiaClinicaBll.Recuperar(paciente);
            //this.listEventosClinicos.EnlazarListado(hc.Eventos, string.Empty, nameof(BE.HistoriaClinica.EventoClinico.Id));
            this.listEventosClinicos.EnlazarListado(hc.Eventos, string.Empty, string.Empty);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion);

            this.groupEvolucion.Text = _traductorUsuario.Traducir(ConstantesDeTexto.Evolucion);
            this.groupHC.Text = _traductorUsuario.Traducir(ConstantesDeTexto.HistorialClinico);

            this.lblEdad.Text = string.Format("{0}: {1}",
                _traductorUsuario.Traducir(ConstantesDeTexto.Edad),
                _traductorUsuario.TraducirConFormato(ConstantesDeTexto.EdadEnAños, _turno.Paciente.EdadEnAños()));

            this.lblSexo.Text = _traductorUsuario.Traducir(string.Format("Sexo_{0:G}", _turno.Paciente.Sexo));
            this.checkSolicitarLaboratorio.Text = _traductorUsuario.Traducir(ConstantesDeTexto.SolicitarLaboratorio);
            this.checkSolicitarRx.Text = _traductorUsuario.Traducir(ConstantesDeTexto.SolicitarRadiografia);
            this.btnFinalizar.Text = _traductorUsuario.Traducir(ConstantesDeTexto.FinalizarAtencion);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtEvolucion.Text))
                    throw ErrorDeValidacionException.Literal("***Debe completar la evolución de la visita");

                var nuevosEventos = new List<BE.HistoriaClinica.EventoClinico>();
                if (this.checkSolicitarLaboratorio.Checked)
                {
                    nuevosEventos.Add(new BE.HistoriaClinica.EstudioLaboratorio
                    {
                        Titulo = "Análisis Clínicos",
                        Fecha = DateTime.Now,
                        NroProtocolo = Guid.NewGuid().ToString()
                    });
                }

                if (this.checkSolicitarRx.Checked)
                {
                    nuevosEventos.Add(new BE.HistoriaClinica.EstudioImagenologia
                    {
                        Titulo = "Radiografía Completa",
                        Fecha = DateTime.Now,
                        InformeTecnico = "Sin realizar"
                    });
                }

                nuevosEventos.Add(new BE.HistoriaClinica.EvolucionClinicaTurno
                {
                    Titulo = "Consulta médica",
                    Fecha = DateTime.Now,
                    Evolucion = this.txtEvolucion.Text
                });

                //Actualizo los eventos en la Historia Clínica del paciente
                var hc = _historiaClinicaBll.Recuperar(_turno.Paciente);
                foreach (var nuevoEvento in nuevosEventos)
                    hc.Eventos.Add(nuevoEvento);

                _historiaClinicaBll.Actualizar(hc);

                //Cierro la visita y libero la atención
                var turnoBll = _serviciosDeAplicacion.Turno;
                turnoBll.FinalizarAtencion(_turno);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ErrorDeValidacionException exception)
            {
                this.MostrarDialogoError(_traductorUsuario, exception);
            }
        }

        private void listEventosClinicos_DoubleClick(object sender, EventArgs e)
        {
            var eventoSeleccionado = this.listEventosClinicos.SelectedItem as BE.HistoriaClinica.EventoClinico;
            if (eventoSeleccionado != null)
                MessageBox.Show(eventoSeleccionado.Resumen(), _traductorUsuario.Traducir(ConstantesDeTexto.TituloAplicacion));
        }
    }
}
