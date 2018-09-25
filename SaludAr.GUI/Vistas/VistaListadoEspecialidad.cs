using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using Especialidad = SaludAr.BE.Especialidad;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoEspecialidad : VistaListado<BE.Especialidad>
    {
        private readonly BLL.IEspecialidad _especialidadBll;
        public VistaListadoEspecialidad(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _especialidadBll = serviciosDeAplicacion.Especialidad;
            this.HabilitarGestionParaLaEntidad(serviciosDeAplicacion.ControlDePatentes.ConcederAcceso(ControlDePatentes.ConfigurarEspecialidadesDeLaRed));
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuEspecialidades; }
        }

        protected override IEnumerable<Especialidad> RecargarListado()
        {
            return _especialidadBll.Listar();
        }
    }
}