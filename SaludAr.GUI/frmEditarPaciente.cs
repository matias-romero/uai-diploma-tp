using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI
{
    public partial class frmEditarPaciente : frmDialogo<BE.Paciente>
    {        
        public frmEditarPaciente(IServiciosDeAplicacion serviciosDeAplicacion, BE.Paciente item)
            :base(serviciosDeAplicacion, item, ConstantesDeTexto.MenuPacientes)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, BE.Paciente item)
        {
            return new ctlEditarPaciente(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.Paciente, serviciosDeAplicacion.Empleado, item);
        }
    }
}
