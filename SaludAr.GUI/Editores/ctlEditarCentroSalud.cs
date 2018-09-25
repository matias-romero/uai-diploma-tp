using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using CentroDeSalud = SaludAr.BE.CentroDeSalud;

namespace SaludAr.GUI.Editores
{
    public partial class ctlEditarCentroSalud : UserControl, IEditorEnlazado, ISubscriptorCambioIdioma
    {
        private readonly ITraductor _traductor;
        private readonly ICentroDeSalud _centroDeSaludBll;
        private readonly CentroDeSalud _centroDeSaludEnEdicion;

        public ctlEditarCentroSalud(ITraductor traductor, ICentroDeSalud centroDeSaludBll, BE.CentroDeSalud centroDeSaludEnEdicion)
        {
            InitializeComponent();

            _traductor = traductor;
            _centroDeSaludBll = centroDeSaludBll;
            _centroDeSaludEnEdicion = centroDeSaludEnEdicion;
        }

        public void CargarDesdeModeloAInterfazVisual()
        {
            this.txtId.Text = _centroDeSaludEnEdicion.Id.ToString();
            this.txtDescripcion.Text = _centroDeSaludEnEdicion.Nombre;
        }

        public void GuardarCambiosEnElModelo()
        {
            _centroDeSaludEnEdicion.Nombre = this.txtDescripcion.Text;

            _centroDeSaludBll.Actualizar(_centroDeSaludEnEdicion);
        }

        public void IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.lblId.Text = _traductor.TraducirCampoEntidad<BE.CentroDeSalud>(c => c.Id);
            this.lblDescripcion.Text = _traductor.TraducirCampoEntidad<BE.CentroDeSalud>(c => c.Nombre);
        }
    }
}
