namespace SaludAr.GUI.AtencionMedica
{
    partial class frmAtencionMedica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtencionMedica));
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupEvolucion = new System.Windows.Forms.GroupBox();
            this.txtEvolucion = new System.Windows.Forms.TextBox();
            this.groupHC = new System.Windows.Forms.GroupBox();
            this.listEventosClinicos = new System.Windows.Forms.ListBox();
            this.picPaciente = new System.Windows.Forms.PictureBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.checkSolicitarRx = new System.Windows.Forms.CheckBox();
            this.checkSolicitarLaboratorio = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupEvolucion.SuspendLayout();
            this.groupHC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeader
            // 
            this.picHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHeader.BackColor = System.Drawing.Color.Black;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(803, 102);
            this.picHeader.TabIndex = 7;
            this.picHeader.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 99);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupEvolucion);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupHC);
            this.splitContainer.Size = new System.Drawing.Size(803, 421);
            this.splitContainer.SplitterDistance = 482;
            this.splitContainer.TabIndex = 3;
            // 
            // groupEvolucion
            // 
            this.groupEvolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEvolucion.Controls.Add(this.checkSolicitarLaboratorio);
            this.groupEvolucion.Controls.Add(this.checkSolicitarRx);
            this.groupEvolucion.Controls.Add(this.btnFinalizar);
            this.groupEvolucion.Controls.Add(this.txtEvolucion);
            this.groupEvolucion.Location = new System.Drawing.Point(3, 10);
            this.groupEvolucion.Name = "groupEvolucion";
            this.groupEvolucion.Size = new System.Drawing.Size(476, 400);
            this.groupEvolucion.TabIndex = 0;
            this.groupEvolucion.TabStop = false;
            this.groupEvolucion.Text = "groupEvolucion";
            // 
            // txtEvolucion
            // 
            this.txtEvolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEvolucion.Location = new System.Drawing.Point(6, 19);
            this.txtEvolucion.Multiline = true;
            this.txtEvolucion.Name = "txtEvolucion";
            this.txtEvolucion.Size = new System.Drawing.Size(464, 336);
            this.txtEvolucion.TabIndex = 0;
            // 
            // groupHC
            // 
            this.groupHC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupHC.Controls.Add(this.listEventosClinicos);
            this.groupHC.Location = new System.Drawing.Point(8, 10);
            this.groupHC.Name = "groupHC";
            this.groupHC.Size = new System.Drawing.Size(300, 400);
            this.groupHC.TabIndex = 0;
            this.groupHC.TabStop = false;
            this.groupHC.Text = "groupHC";
            // 
            // listEventosClinicos
            // 
            this.listEventosClinicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listEventosClinicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEventosClinicos.FormattingEnabled = true;
            this.listEventosClinicos.ItemHeight = 16;
            this.listEventosClinicos.Location = new System.Drawing.Point(7, 20);
            this.listEventosClinicos.Name = "listEventosClinicos";
            this.listEventosClinicos.ScrollAlwaysVisible = true;
            this.listEventosClinicos.Size = new System.Drawing.Size(287, 372);
            this.listEventosClinicos.TabIndex = 0;
            this.listEventosClinicos.DoubleClick += new System.EventHandler(this.listEventosClinicos_DoubleClick);
            // 
            // picPaciente
            // 
            this.picPaciente.BackColor = System.Drawing.Color.DarkGray;
            this.picPaciente.Image = ((System.Drawing.Image)(resources.GetObject("picPaciente.Image")));
            this.picPaciente.Location = new System.Drawing.Point(12, 9);
            this.picPaciente.Name = "picPaciente";
            this.picPaciente.Size = new System.Drawing.Size(64, 64);
            this.picPaciente.TabIndex = 9;
            this.picPaciente.TabStop = false;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.BackColor = System.Drawing.Color.Black;
            this.lblPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPaciente.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaciente.ForeColor = System.Drawing.Color.White;
            this.lblPaciente.Location = new System.Drawing.Point(82, 9);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(98, 18);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "lblPaciente";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.BackColor = System.Drawing.Color.Black;
            this.lblEdad.ForeColor = System.Drawing.Color.White;
            this.lblEdad.Location = new System.Drawing.Point(100, 37);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(42, 13);
            this.lblEdad.TabIndex = 1;
            this.lblEdad.Text = "lblEdad";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.BackColor = System.Drawing.Color.Black;
            this.lblSexo.ForeColor = System.Drawing.Color.White;
            this.lblSexo.Location = new System.Drawing.Point(100, 60);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 13);
            this.lblSexo.TabIndex = 2;
            this.lblSexo.Text = "lblSexo";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Location = new System.Drawing.Point(395, 361);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "btnFinalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // checkSolicitarRx
            // 
            this.checkSolicitarRx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSolicitarRx.AutoSize = true;
            this.checkSolicitarRx.Location = new System.Drawing.Point(6, 365);
            this.checkSolicitarRx.Name = "checkSolicitarRx";
            this.checkSolicitarRx.Size = new System.Drawing.Size(106, 17);
            this.checkSolicitarRx.TabIndex = 1;
            this.checkSolicitarRx.Text = "checkSolicitarRx";
            this.checkSolicitarRx.UseVisualStyleBackColor = true;
            // 
            // checkSolicitarLaboratorio
            // 
            this.checkSolicitarLaboratorio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkSolicitarLaboratorio.AutoSize = true;
            this.checkSolicitarLaboratorio.Location = new System.Drawing.Point(184, 365);
            this.checkSolicitarLaboratorio.Name = "checkSolicitarLaboratorio";
            this.checkSolicitarLaboratorio.Size = new System.Drawing.Size(146, 17);
            this.checkSolicitarLaboratorio.TabIndex = 2;
            this.checkSolicitarLaboratorio.Text = "checkSolicitarLaboratorio";
            this.checkSolicitarLaboratorio.UseVisualStyleBackColor = true;
            // 
            // frmAtencionMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.picPaciente);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.picHeader);
            this.Name = "frmAtencionMedica";
            this.Text = "frmAtencionMedica";
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupEvolucion.ResumeLayout(false);
            this.groupEvolucion.PerformLayout();
            this.groupHC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPaciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox groupEvolucion;
        private System.Windows.Forms.GroupBox groupHC;
        private System.Windows.Forms.PictureBox picPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ListBox listEventosClinicos;
        private System.Windows.Forms.TextBox txtEvolucion;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.CheckBox checkSolicitarLaboratorio;
        private System.Windows.Forms.CheckBox checkSolicitarRx;
    }
}