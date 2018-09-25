namespace SaludAr.GUI.Editores
{
    partial class ctlEditarEspecialidadesPorProfesional
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
            this.groupPermisos = new System.Windows.Forms.GroupBox();
            this.checkedListBoxEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.lblNombreProfesional = new System.Windows.Forms.Label();
            this.groupPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPermisos
            // 
            this.groupPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPermisos.Controls.Add(this.lblNombreProfesional);
            this.groupPermisos.Controls.Add(this.checkedListBoxEspecialidades);
            this.groupPermisos.Location = new System.Drawing.Point(3, 3);
            this.groupPermisos.Name = "groupPermisos";
            this.groupPermisos.Size = new System.Drawing.Size(534, 474);
            this.groupPermisos.TabIndex = 2;
            this.groupPermisos.TabStop = false;
            // 
            // checkedListBoxEspecialidades
            // 
            this.checkedListBoxEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxEspecialidades.FormattingEnabled = true;
            this.checkedListBoxEspecialidades.Location = new System.Drawing.Point(6, 59);
            this.checkedListBoxEspecialidades.Name = "checkedListBoxEspecialidades";
            this.checkedListBoxEspecialidades.Size = new System.Drawing.Size(522, 409);
            this.checkedListBoxEspecialidades.TabIndex = 0;
            // 
            // lblNombreProfesional
            // 
            this.lblNombreProfesional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProfesional.Location = new System.Drawing.Point(6, 16);
            this.lblNombreProfesional.Name = "lblNombreProfesional";
            this.lblNombreProfesional.Size = new System.Drawing.Size(522, 40);
            this.lblNombreProfesional.TabIndex = 1;
            this.lblNombreProfesional.Text = "lblNombreProfesional";
            this.lblNombreProfesional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctlEditarEspecialidadesPorProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPermisos);
            this.Name = "ctlEditarEspecialidadesPorProfesional";
            this.Size = new System.Drawing.Size(540, 480);
            this.groupPermisos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPermisos;
        private System.Windows.Forms.CheckedListBox checkedListBoxEspecialidades;
        private System.Windows.Forms.Label lblNombreProfesional;
    }
}
