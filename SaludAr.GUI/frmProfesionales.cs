using System;
using System.Windows.Forms;
using SaludAr.BE.Empleados;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Vistas;

namespace SaludAr.GUI
{
    public partial class frmProfesionales : frmListado<BE.Empleados.Profesional>
    {
        public frmProfesionales(IServiciosDeAplicacion serviciosDeAplicacion)
            :base(serviciosDeAplicacion, new VistaListadoProfesional(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override Form InstanciarEditor(Profesional item)
        {
            return new frmEspecialidadesPorProfesional(_serviciosDeAplicacion, item);
        }
    }
}
