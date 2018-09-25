namespace SaludAr.GUI.Editores
{
    partial class ctlConfigurarAgenda
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCentroSalud = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.cboCentroSalud = new System.Windows.Forms.ComboBox();
            this.dtGridView = new SaludAr.GUI.Editores.DataGridViewEx();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.lblVigencia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCentroSalud
            // 
            this.lblCentroSalud.AutoSize = true;
            this.lblCentroSalud.Location = new System.Drawing.Point(3, 10);
            this.lblCentroSalud.Name = "lblCentroSalud";
            this.lblCentroSalud.Size = new System.Drawing.Size(75, 13);
            this.lblCentroSalud.TabIndex = 0;
            this.lblCentroSalud.Text = "lblCentroSalud";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(3, 37);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(77, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "lblEspecialidad";
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Location = new System.Drawing.Point(93, 34);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(326, 21);
            this.cboEspecialidad.TabIndex = 2;
            this.cboEspecialidad.SelectedValueChanged += new System.EventHandler(this.ComboValueChanged);
            // 
            // cboCentroSalud
            // 
            this.cboCentroSalud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCentroSalud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroSalud.FormattingEnabled = true;
            this.cboCentroSalud.Location = new System.Drawing.Point(93, 7);
            this.cboCentroSalud.Name = "cboCentroSalud";
            this.cboCentroSalud.Size = new System.Drawing.Size(326, 21);
            this.cboCentroSalud.TabIndex = 3;
            this.cboCentroSalud.SelectedValueChanged += new System.EventHandler(this.ComboValueChanged);
            // 
            // dtGridView
            // 
            this.dtGridView.AllowUserToAddRows = false;
            this.dtGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridView.Location = new System.Drawing.Point(3, 87);
            this.dtGridView.MultiSelect = false;
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.Size = new System.Drawing.Size(416, 184);
            this.dtGridView.TabIndex = 4;
            this.dtGridView.RowButtonClick += new System.EventHandler<System.Windows.Forms.DataGridViewCellEventArgs>(this.dtGridView_RowButtonClick);
            this.dtGridView.EditRowRequested += new System.EventHandler<System.Windows.Forms.DataGridViewCellEventArgs>(this.dtGridView_EditRowRequested);
            this.dtGridView.NewRowRequested += new System.EventHandler(this.dtGridView_NewRowRequested);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(93, 61);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(158, 20);
            this.dtDesde.TabIndex = 5;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // dtHasta
            // 
            this.dtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(257, 61);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(162, 20);
            this.dtHasta.TabIndex = 6;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Location = new System.Drawing.Point(3, 67);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(58, 13);
            this.lblVigencia.TabIndex = 7;
            this.lblVigencia.Text = "lblVigencia";
            // 
            // ctlConfigurarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.cboCentroSalud);
            this.Controls.Add(this.cboEspecialidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblCentroSalud);
            this.Name = "ctlConfigurarAgenda";
            this.Size = new System.Drawing.Size(422, 274);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCentroSalud;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.ComboBox cboCentroSalud;
        private DataGridViewEx dtGridView;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label lblVigencia;
    }
}
