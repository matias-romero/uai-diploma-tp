using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoPaciente : VistaListado<BE.Paciente>
    {
        private IPaciente _pacienteBll;
        private IGestorDePermisos _gestorDePermisos;

        public VistaListadoPaciente(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _pacienteBll = serviciosDeAplicacion.Paciente;
            _gestorDePermisos = serviciosDeAplicacion.GestorDePermisos;
            this.HabilitarGestionParaLaEntidad(serviciosDeAplicacion.ControlDePatentes.ConcederAcceso(ControlDePatentes.EditarDatosDelPadronDePacientes));
            this.PuedeAgregar = serviciosDeAplicacion.ControlDePatentes.ConcederAcceso(ControlDePatentes.AgregarPacienteAlPadron);
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuPacientes; }
        }
        
        public IGestorDePermisos GestorDePermisos
        {
            get { return _gestorDePermisos; }
        }

        protected override IEnumerable<BE.Paciente> RecargarListado()
        {
            return _pacienteBll.Listar();
        }
    }
}
