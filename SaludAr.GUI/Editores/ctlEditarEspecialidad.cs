using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using Especialidad = SaludAr.BE.Especialidad;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarEspecialidad : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IEspecialidad _especialidadBll;
        private readonly Especialidad _especialidadEnEdicion;

        public ctlEditarEspecialidad(ITraductor traductor, IEspecialidad especialidadBll, BE.Especialidad especialidadEnEdicion)
        {
            InitializeComponent();

            _traductor = traductor;
            _especialidadBll = especialidadBll;
            _especialidadEnEdicion = especialidadEnEdicion;
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.txtId.Text = _especialidadEnEdicion.Id.ToString();
            this.txtDescripcion.Text = _especialidadEnEdicion.Nombre;
        }

        public void GuardarCambiosEnElModelo()
        {
            _especialidadEnEdicion.Nombre = this.txtDescripcion.Text;

            _especialidadBll.Actualizar(_especialidadEnEdicion);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblId.Text = _traductor.TraducirCampoEntidad<BE.Especialidad>(c => c.Id);
            this.lblDescripcion.Text = _traductor.TraducirCampoEntidad<BE.Especialidad>(c => c.Nombre);
        }
    }
}
