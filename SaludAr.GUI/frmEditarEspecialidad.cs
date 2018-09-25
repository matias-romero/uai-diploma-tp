using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;
using Especialidad = SaludAr.BE.Especialidad;

namespace SaludAr.GUI
{
    public partial class frmEditarEspecialidad : frmDialogo<BE.Especialidad>
    {
        public frmEditarEspecialidad(IServiciosDeAplicacion serviciosDeAplicacion, BE.Especialidad item)
            :base(serviciosDeAplicacion, item, ConstantesDeTexto.MenuEspecialidades)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, Especialidad item)
        {
            return new ctlEditarEspecialidad(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.Especialidad, item);
        }
    }
}
