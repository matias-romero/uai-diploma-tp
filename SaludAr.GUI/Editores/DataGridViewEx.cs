using System;
using System.Windows.Forms;

namespace SaludAr.GUI.Editores
{
    public partial class DataGridViewEx : DataGridView
    {
        public event EventHandler<DataGridViewCellEventArgs> RowButtonClick;
        public event EventHandler<DataGridViewCellEventArgs> EditRowRequested;
        public event EventHandler NewRowRequested;
        
        public DataGridViewEx()
        {
            InitializeComponent();
            this.AllowUserToAddRows = false;
            this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.MultiSelect = false;
        }

        public void AddButtonColumn(string name, string text)
        {
            this.Columns.Add(new DataGridViewButtonColumn
            {
                Name = name,
                Text = text,
                UseColumnTextForButtonValue = true
                //DataPropertyName = nameof(EntradaAgenda.Duracion),
                //HeaderText = _traductor.TraducirCampoEntidad<EntradaAgenda>(nameof(EntradaAgenda.Duracion))
            });
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
                this.OnNewRowRequested();
            else
                base.OnCellClick(e);
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            var senderGrid = this;
            var columnButton = senderGrid.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
            if (columnButton != null && e.RowIndex >= 0)
                this.OnRowButtonClick(e);
            else
                base.OnCellContentClick(e);
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                this.OnEditRowRequested(e);
            else
                base.OnCellDoubleClick(e);
        }

        protected void OnRowButtonClick(DataGridViewCellEventArgs e)
        {
            if(RowButtonClick != null)
                RowButtonClick(this, e);
        }

        protected void OnNewRowRequested()
        {
            if (NewRowRequested != null)
                NewRowRequested(this, EventArgs.Empty);
        }

        protected void OnEditRowRequested(DataGridViewCellEventArgs e)
        {
            if (EditRowRequested != null)
                EditRowRequested(this, e);
        }
    }
}
