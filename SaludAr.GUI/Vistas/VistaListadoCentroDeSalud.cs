using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using CentroDeSalud = SaludAr.BE.CentroDeSalud;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoCentroDeSalud : VistaListado<BE.CentroDeSalud>
    {
        private readonly IServiciosDeAplicacion _serviciosDeAplicacion;

        public VistaListadoCentroDeSalud(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _serviciosDeAplicacion = serviciosDeAplicacion;
            this.HabilitarGestionParaLaEntidad(_serviciosDeAplicacion.ControlDePatentes.ConcederAcceso(ControlDePatentes.ConfigurarCentrosDeSalud));
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuCentrosDeSalud; }
        }

        protected override IEnumerable<CentroDeSalud> RecargarListado()
        {
            return _serviciosDeAplicacion.CentroDeSalud.Listar();
        }
    }
}