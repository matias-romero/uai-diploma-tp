using System;
using SaludAr.BE.Empleados;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;

namespace SaludAr.GUI
{
    public partial class frmEspecialidadesPorProfesional : frmDialogo<BE.Empleados.Profesional>
    {
        public frmEspecialidadesPorProfesional(IServiciosDeAplicacion serviciosDeAplicacion, BE.Empleados.Profesional item)
            : base(serviciosDeAplicacion, item, ConstantesDeTexto.MenuProfesionales)
        {
            InitializeComponent();
        }

        protected override IEditorEnlazado CrearControlDeEditorEnlazado(IServiciosDeAplicacion serviciosDeAplicacion, Profesional item)
        {
            return new ctlEditarEspecialidadesPorProfesional(serviciosDeAplicacion.TraductorUsuario, serviciosDeAplicacion.Empleado, serviciosDeAplicacion.Especialidad, item);
        }
    }
}
