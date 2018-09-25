using SaludAr.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaludAr.GUI.Compartidos;

namespace SaludAr.GUI
{
    public partial class frmConfigurarAgendas : frmListado<BE.Agenda.DefinicionAgenda>
    {
        public frmConfigurarAgendas(IServiciosDeAplicacion serviciosDeAplicacion)
            : base(serviciosDeAplicacion, new Vistas.VistaListadoDefinicionAgenda(serviciosDeAplicacion))
        {
            InitializeComponent();
        }

        protected override void InvocarFormularioAlta()
        {
            var nuevoItem = new BE.Agenda.DefinicionAgenda();
            this.InvocarFormularioEdicion(nuevoItem);
        }

        protected override Form InstanciarEditor(BE.Agenda.DefinicionAgenda item)
        {
            return new frmConfigurarAgenda(_serviciosDeAplicacion, item);
        }

        protected override void DefinirColumnas(DataGridView dataGridView)
        {
            //this.DefinirColumnasTipadas<BE.Agenda.DefinicionAgenda>(dataGridView, new[]
            //{
            //    nameof(BE.Agenda.DefinicionAgenda.Id),
            //    nameof(BE.Agenda.DefinicionAgenda.Desde),
            //    nameof(BE.Agenda.DefinicionAgenda.Hasta),
            //    nameof(BE.Agenda.DefinicionAgenda.CentroDeSalud),
            //    nameof(BE.Agenda.DefinicionAgenda.Especialidad)
            //});
            base.DefinirColumnas(dataGridView);
        }
    }
}
