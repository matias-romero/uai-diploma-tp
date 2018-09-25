namespace SaludAr.GUI
{
    partial class frmAsignarTurno
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.group = new System.Windows.Forms.GroupBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.BackColor = System.Drawing.Color.Black;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Location = new System.Drawing.Point(11, 18);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(127, 20);
            this.lblEncabezado.TabIndex = 13;
            this.lblEncabezado.Text = "lblEncabezado";
            // 
            // picHeader
            // 
            this.picHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHeader.BackColor = System.Drawing.Color.Black;
            this.picHeader.Location = new System.Drawing.Point(-1, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(623, 50);
            this.picHeader.TabIndex = 12;
            this.picHeader.TabStop = false;
            // 
            // group
            // 
            this.group.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group.Location = new System.Drawing.Point(4, 56);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(608, 377);
            this.group.TabIndex = 11;
            this.group.TabStop = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSiguiente.Location = new System.Drawing.Point(319, 448);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 10;
            this.btnSiguiente.Text = "btnSiguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnterior.Location = new System.Drawing.Point(223, 448);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.Text = "btnAnterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // frmAsignarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 483);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.group);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Name = "frmAsignarTurno";
            this.Text = "frmAsignarTurno";
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
    }
}