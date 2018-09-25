namespace SaludAr.GUI.Compartidos
{
    abstract partial class frmListado<T>
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
            this.dtGridView = new System.Windows.Forms.DataGridView();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridView
            // 
            this.dtGridView.AllowUserToAddRows = false;
            this.dtGridView.AllowUserToDeleteRows = false;
            this.dtGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Location = new System.Drawing.Point(12, 56);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.ReadOnly = true;
            this.dtGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridView.Size = new System.Drawing.Size(638, 338);
            this.dtGridView.TabIndex = 0;
            this.dtGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellDoubleClick);
            // 
            // picHeader
            // 
            this.picHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHeader.BackColor = System.Drawing.Color.Black;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(667, 50);
            this.picHeader.TabIndex = 1;
            this.picHeader.TabStop = false;
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.BackColor = System.Drawing.Color.Black;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Location = new System.Drawing.Point(8, 12);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(127, 20);
            this.lblEncabezado.TabIndex = 2;
            this.lblEncabezado.Text = "lblEncabezado";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(575, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "btnNuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 398);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.dtGridView);
            this.Name = "frmListado";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnNuevo;
    }
}