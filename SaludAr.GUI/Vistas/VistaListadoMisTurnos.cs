using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;

namespace SaludAr.GUI.Vistas
{
    public class VistaListadoMisTurnos : VistaListado<BE.Agenda.Turno>
    {
        private readonly ITurno _turnoBll;

        public VistaListadoMisTurnos(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            _turnoBll = serviciosDeAplicacion.Turno;
            this.PuedeEditar = serviciosDeAplicacion.ControlDePatentes.ConcederAcceso(ControlDePatentes.AtenderPacienteRegistrarEvolucion);
            this.PuedeAgregar = false;
            this.PuedeBorrar = false;
        }

        public override string Titulo
        {
            get { return ConstantesDeTexto.MenuMisTurnos; }
        }

        protected override IEnumerable<BE.Agenda.Turno> RecargarListado()
        {
            return _turnoBll.ListarMisTurnos();
        }
    }
}
