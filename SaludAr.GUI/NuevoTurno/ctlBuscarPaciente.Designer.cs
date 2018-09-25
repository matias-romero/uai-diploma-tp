namespace SaludAr.GUI.NuevoTurno
{
    partial class ctlBuscarPaciente
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtGridResutlados = new SaludAr.GUI.Editores.DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridResutlados)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(0, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(331, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(337, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtGridResutlados
            // 
            this.dtGridResutlados.AllowUserToAddRows = false;
            this.dtGridResutlados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridResutlados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridResutlados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridResutlados.Location = new System.Drawing.Point(0, 26);
            this.dtGridResutlados.MultiSelect = false;
            this.dtGridResutlados.Name = "dtGridResutlados";
            this.dtGridResutlados.Size = new System.Drawing.Size(412, 339);
            this.dtGridResutlados.TabIndex = 1;
            this.dtGridResutlados.DoubleClick += new System.EventHandler(this.dtGridResutlados_DoubleClick);
            // 
            // ctlBuscarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtGridResutlados);
            this.Controls.Add(this.txtBuscar);
            this.Name = "ctlBuscarPaciente";
            this.Size = new System.Drawing.Size(412, 365);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridResutlados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private Editores.DataGridViewEx dtGridResutlados;
        private System.Windows.Forms.Button btnBuscar;
    }
}
