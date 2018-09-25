using System.Windows.Forms;
using SaludAr.BE.Agenda;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI
{
    public partial class frmConfigurarAgenda : frmDialogo<DefinicionAgenda>
    {
        public frmConfigurarAgenda(IServiciosDeAplicacion serviciosDeAplicacion, DefinicionAgenda item)
            : base(serviciosDeAplicacion, item, ConstantesDeTexto.MenuConfigurarAgenda)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, DefinicionAgenda item)
        {
            return new ctlConfigurarAgenda(serviciosDeAplicacion, item);
        }
    }
}
