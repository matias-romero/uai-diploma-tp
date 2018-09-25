using System;
using System.Windows.Forms;
using SaludAr.BLL;
using SaludAr.GUI.AtencionMedica;
using SaludAr.GUI.Compartidos;
using SaludAr.GUI.Editores;
using SaludAr.GUI.Vistas;
using Turno = SaludAr.BE.Agenda.Turno;

namespace SaludAr.GUI
{
    public partial class frmMisTurnos : frmListado<BE.Agenda.Turno>
    {
        public frmMisTurnos(IServiciosDeAplicacion serviciosDeAplicacion)
            :base(serviciosDeAplicacion, new VistaListadoMisTurnos(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override Form InstanciarEditor(Turno item)
        {
            return new frmAtencionMedica(_serviciosDeAplicacion, item);
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;

            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.Id)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.FechaHora)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.FechaHoraAdmision)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.Paciente)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.Profesional)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.FechaHoraInicioAtencion)));
            dataGridView.Columns.Add(this.CrearColumnaEnlazada(nameof(BE.Agenda.Turno.FechaHoraFinAtencion)));
        }
    }
}
