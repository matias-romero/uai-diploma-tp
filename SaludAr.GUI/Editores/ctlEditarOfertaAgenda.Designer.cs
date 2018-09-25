namespace SaludAr.GUI.Editores
{
    partial class ctlEditarOfertaAgenda
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
            this.lblDiaSemana = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.cboDiaSemana = new SaludAr.GUI.Editores.ComboEnumerado();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.txtDuracion = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiaSemana
            // 
            this.lblDiaSemana.AutoSize = true;
            this.lblDiaSemana.Location = new System.Drawing.Point(15, 9);
            this.lblDiaSemana.Name = "lblDiaSemana";
            this.lblDiaSemana.Size = new System.Drawing.Size(72, 13);
            this.lblDiaSemana.TabIndex = 0;
            this.lblDiaSemana.Text = "lblDiaSemana";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(15, 39);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(42, 13);
            this.lblInicio.TabIndex = 1;
            this.lblInicio.Text = "lblInicio";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(15, 65);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(31, 13);
            this.lblFin.TabIndex = 2;
            this.lblFin.Text = "lblFin";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(15, 91);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(60, 13);
            this.lblDuracion.TabIndex = 3;
            this.lblDuracion.Text = "lblDuracion";
            // 
            // cboDiaSemana
            // 
            this.cboDiaSemana.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDiaSemana.DisplayMember = "Descripcion";
            this.cboDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaSemana.FormattingEnabled = true;
            this.cboDiaSemana.Location = new System.Drawing.Point(102, 6);
            this.cboDiaSemana.Name = "cboDiaSemana";
            this.cboDiaSemana.Size = new System.Drawing.Size(206, 21);
            this.cboDiaSemana.TabIndex = 4;
            this.cboDiaSemana.ValueMember = "Valor";
            // 
            // dtInicio
            // 
            this.dtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtInicio.Location = new System.Drawing.Point(102, 33);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(206, 20);
            this.dtInicio.TabIndex = 5;
            // 
            // dtFin
            // 
            this.dtFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFin.Location = new System.Drawing.Point(102, 59);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(206, 20);
            this.dtFin.TabIndex = 6;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Location = new System.Drawing.Point(102, 89);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(206, 20);
            this.txtDuracion.TabIndex = 7;
            // 
            // ctlEditarOfertaAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.cboDiaSemana);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblDiaSemana);
            this.Name = "ctlEditarOfertaAgenda";
            this.Size = new System.Drawing.Size(311, 117);
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiaSemana;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblDuracion;
        private ComboEnumerado cboDiaSemana;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.NumericUpDown txtDuracion;
    }
}
