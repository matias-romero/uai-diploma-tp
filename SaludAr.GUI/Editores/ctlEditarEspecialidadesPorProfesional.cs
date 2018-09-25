using System.Linq;
using System.Windows.Forms;
using SaludAr.BE.Empleados;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarEspecialidadesPorProfesional : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly IEmpleado _empleadoBll;
        private readonly Profesional _profesional;

        public ctlEditarEspecialidadesPorProfesional(ITraductor traductor, IEmpleado empleadoBll, IEspecialidad especialidadBll, Profesional profesional)
        {
            InitializeComponent();

            _traductor = traductor;
            _empleadoBll = empleadoBll;
            _profesional = profesional;

            this.checkedListBoxEspecialidades.EnlazarListado(especialidadBll.Listar(), nameof(BE.Especialidad.Nombre), nameof(BE.Especialidad.Id));
            this.lblNombreProfesional.Text = profesional.ToString();
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            //Tildamos las especialidades que ya tenga este profesional
            var index = 0;
            var items = this.checkedListBoxEspecialidades.Items.Cast<BE.Especialidad>().ToArray();
            foreach (var item in items)
            {
                if (_profesional.Especialidades.Any(e => e.Id == item.Id))
                    this.checkedListBoxEspecialidades.SetItemChecked(index, true);

                index++;
            }
        }

        public void GuardarCambiosEnElModelo()
        {
            var especialidadesAtendidas = this.checkedListBoxEspecialidades.CheckedItems.Cast<BE.Especialidad>().ToArray();
            if (especialidadesAtendidas.Any())
            {
                _profesional.Especialidades.Clear();
                foreach (var especialidad in especialidadesAtendidas)
                    _profesional.Especialidades.Add(especialidad);

                _empleadoBll.Actualizar(_profesional);
            }
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            
        }
    }
}
