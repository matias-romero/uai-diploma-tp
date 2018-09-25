using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaludAr.BE.Agenda;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI
{
    public partial class frmOfertaAgenda : frmDialogo<BE.Agenda.EntradaAgenda>
    {
        public frmOfertaAgenda(IServiciosDeAplicacion serviciosDeAplicacion, EntradaAgenda item)
            : base(serviciosDeAplicacion, item, ConstantesDeTexto.EditarOfertaAgenda)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, EntradaAgenda item)
        {
            return new ctlEditarOfertaAgenda(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.Agenda, item);
        }
    }
}
