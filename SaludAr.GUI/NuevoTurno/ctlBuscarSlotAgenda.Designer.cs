namespace SaludAr.GUI.NuevoTurno
{
    partial class ctlBuscarSlotAgenda
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
            this.groupFiltro = new System.Windows.Forms.GroupBox();
            this.dtFechaTentativa = new System.Windows.Forms.DateTimePicker();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.cboCentroSalud = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFechaTentativa = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblCentroSalud = new System.Windows.Forms.Label();
            this.groupCalendario = new System.Windows.Forms.GroupBox();
            this.dtGridOferta = new SaludAr.GUI.Editores.DataGridViewEx();
            this.groupFiltro.SuspendLayout();
            this.groupCalendario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOferta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFiltro
            // 
            this.groupFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFiltro.Controls.Add(this.dtFechaTentativa);
            this.groupFiltro.Controls.Add(this.cboEspecialidad);
            this.groupFiltro.Controls.Add(this.cboCentroSalud);
            this.groupFiltro.Controls.Add(this.btnBuscar);
            this.groupFiltro.Controls.Add(this.lblFechaTentativa);
            this.groupFiltro.Controls.Add(this.lblEspecialidad);
            this.groupFiltro.Controls.Add(this.lblCentroSalud);
            this.groupFiltro.Location = new System.Drawing.Point(0, 0);
            this.groupFiltro.Name = "groupFiltro";
            this.groupFiltro.Size = new System.Drawing.Size(606, 74);
            this.groupFiltro.TabIndex = 0;
            this.groupFiltro.TabStop = false;
            // 
            // dtFechaTentativa
            // 
            this.dtFechaTentativa.Location = new System.Drawing.Point(104, 41);
            this.dtFechaTentativa.Name = "dtFechaTentativa";
            this.dtFechaTentativa.Size = new System.Drawing.Size(200, 20);
            this.dtFechaTentativa.TabIndex = 5;
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Location = new System.Drawing.Point(406, 13);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(194, 21);
            this.cboEspecialidad.TabIndex = 3;
            // 
            // cboCentroSalud
            // 
            this.cboCentroSalud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroSalud.FormattingEnabled = true;
            this.cboCentroSalud.Location = new System.Drawing.Point(104, 13);
            this.cboCentroSalud.Name = "cboCentroSalud";
            this.cboCentroSalud.Size = new System.Drawing.Size(200, 21);
            this.cboCentroSalud.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(530, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFechaTentativa
            // 
            this.lblFechaTentativa.AutoSize = true;
            this.lblFechaTentativa.Location = new System.Drawing.Point(6, 43);
            this.lblFechaTentativa.Name = "lblFechaTentativa";
            this.lblFechaTentativa.Size = new System.Drawing.Size(92, 13);
            this.lblFechaTentativa.TabIndex = 4;
            this.lblFechaTentativa.Text = "lblFechaTentativa";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(323, 16);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(77, 13);
            this.lblEspecialidad.TabIndex = 2;
            this.lblEspecialidad.Text = "lblEspecialidad";
            // 
            // lblCentroSalud
            // 
            this.lblCentroSalud.AutoSize = true;
            this.lblCentroSalud.Location = new System.Drawing.Point(6, 16);
            this.lblCentroSalud.Name = "lblCentroSalud";
            this.lblCentroSalud.Size = new System.Drawing.Size(75, 13);
            this.lblCentroSalud.TabIndex = 0;
            this.lblCentroSalud.Text = "lblCentroSalud";
            // 
            // groupCalendario
            // 
            this.groupCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCalendario.Controls.Add(this.dtGridOferta);
            this.groupCalendario.Location = new System.Drawing.Point(0, 80);
            this.groupCalendario.Name = "groupCalendario";
            this.groupCalendario.Size = new System.Drawing.Size(606, 451);
            this.groupCalendario.TabIndex = 1;
            this.groupCalendario.TabStop = false;
            // 
            // dtGridOferta
            // 
            this.dtGridOferta.AllowUserToAddRows = false;
            this.dtGridOferta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridOferta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridOferta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridOferta.Location = new System.Drawing.Point(3, 9);
            this.dtGridOferta.MultiSelect = false;
            this.dtGridOferta.Name = "dtGridOferta";
            this.dtGridOferta.Size = new System.Drawing.Size(597, 436);
            this.dtGridOferta.TabIndex = 0;
            this.dtGridOferta.DoubleClick += new System.EventHandler(this.dtGridOferta_DoubleClick);
            // 
            // ctlBuscarSlotAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupCalendario);
            this.Controls.Add(this.groupFiltro);
            this.Name = "ctlBuscarSlotAgenda";
            this.Size = new System.Drawing.Size(606, 531);
            this.groupFiltro.ResumeLayout(false);
            this.groupFiltro.PerformLayout();
            this.groupCalendario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOferta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFiltro;
        private System.Windows.Forms.GroupBox groupCalendario;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblCentroSalud;
        private System.Windows.Forms.Label lblFechaTentativa;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.ComboBox cboCentroSalud;
        private System.Windows.Forms.DateTimePicker dtFechaTentativa;
        private Editores.DataGridViewEx dtGridOferta;
    }
}
