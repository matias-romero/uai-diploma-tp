using System.Collections.Generic;
using SaludAr.BE.Agenda;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoDefinicionAgenda : VistaListado<BE.Agenda.DefinicionAgenda>
    {
        private readonly BLL.IAgenda _agendaBll;

        public VistaListadoDefinicionAgenda(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _agendaBll = serviciosDeAplicacion.Agenda;
            this.HabilitarGestionParaLaEntidad(true);
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuConfigurarAgenda; }
        }

        protected override IEnumerable<DefinicionAgenda> RecargarListado()
        {
            return _agendaBll.Listar();
        }
    }
}