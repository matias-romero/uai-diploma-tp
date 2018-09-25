using System;
using System.Windows.Forms;
using SaludAr.BE.Agenda;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarOfertaAgenda : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IAgenda _agendaBll;
        private readonly EntradaAgenda _item;

        public ctlEditarOfertaAgenda(ITraductor traductor, IAgenda agendaBll, EntradaAgenda item)
        {
            InitializeComponent();

            _traductor = traductor;
            _agendaBll = agendaBll;
            _item = item;

            this.dtInicio.ConfigurarSoloHora();
            this.dtFin.ConfigurarSoloHora();

            this.dtInicio.MinDate = DateTime.MinValue;
            this.dtInicio.MaxDate = this.dtInicio.MinDate.AddDays(1);
            this.dtFin.MinDate = DateTime.MinValue;
            this.dtFin.MaxDate = this.dtFin.MinDate.AddDays(1);

            this.cboDiaSemana.CargarOpciones(_agendaBll.DiasDeLaSemana);
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.cboDiaSemana.SelectedValue = (int)_item.DiaSemana;
            this.txtDuracion.Value = (decimal) _item.Duracion.TotalMinutes;
            this.dtInicio.EstablecerValorEntreElRangoPermitido(_item.InicioBloque);
            this.dtFin.EstablecerValorEntreElRangoPermitido(_item.FinBloque);
        }

        public void GuardarCambiosEnElModelo()
        {
            var duracion = TimeSpan.FromMinutes((double)this.txtDuracion.Value);
            if (this.dtInicio.Value >= this.dtFin.Value)
                throw new Exception("La hora de inicio debe ser menor que la hora de finalización del bloque");
            if (duracion > (this.dtFin.Value - this.dtInicio.Value) || duracion == TimeSpan.Zero)
                throw new Exception("La duración debe estar comprendida entre el bloque horario");

            _item.DiaSemana = (DiaSemana) this.cboDiaSemana.SelectedValue;
            
            _item.Duracion = duracion;
            _item.InicioBloque = this.dtInicio.Value;
            _item.FinBloque = this.dtFin.Value;
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblDiaSemana.Text = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.DiaSemana));
            this.lblInicio.Text = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.InicioBloque));
            this.lblFin.Text = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.FinBloque));
            this.lblDuracion.Text = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.Duracion));
        }
    }
}
