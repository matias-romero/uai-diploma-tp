using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;
using CentroDeSalud = SaludAr.BE.CentroDeSalud;

namespace SaludAr.GUI
{
    public partial class frmEditarCentroDeSalud : frmDialogo<BE.CentroDeSalud>
    {
        public frmEditarCentroDeSalud(IServiciosDeAplicacion serviciosDeAplicacion, BE.CentroDeSalud item)
        :base(serviciosDeAplicacion, item, ConstantesDeTexto.MenuCentrosDeSalud)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, CentroDeSalud item)
        {
            return new ctlEditarCentroSalud(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.CentroDeSalud, item);
        }
    }
}
