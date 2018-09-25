namespace SaludAr.GUI
{
    partial class frmInstalador
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.lblBaseDeDatos = new System.Windows.Forms.Label();
            this.groupCredenciales = new System.Windows.Forms.GroupBox();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtBaseDeDatos = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.chkUsarKerberos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupCredenciales.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Controls.Add(this.txtBaseDeDatos);
            this.groupBox1.Controls.Add(this.groupCredenciales);
            this.groupBox1.Controls.Add(this.lblBaseDeDatos);
            this.groupBox1.Controls.Add(this.lblServidor);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(18, 28);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(56, 13);
            this.lblServidor.TabIndex = 0;
            this.lblServidor.Text = "lblServidor";
            // 
            // lblBaseDeDatos
            // 
            this.lblBaseDeDatos.AutoSize = true;
            this.lblBaseDeDatos.Location = new System.Drawing.Point(18, 65);
            this.lblBaseDeDatos.Name = "lblBaseDeDatos";
            this.lblBaseDeDatos.Size = new System.Drawing.Size(83, 13);
            this.lblBaseDeDatos.TabIndex = 1;
            this.lblBaseDeDatos.Text = "lblBaseDeDatos";
            // 
            // groupCredenciales
            // 
            this.groupCredenciales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredenciales.Controls.Add(this.chkUsarKerberos);
            this.groupCredenciales.Controls.Add(this.txtUsuario);
            this.groupCredenciales.Controls.Add(this.txtContraseña);
            this.groupCredenciales.Controls.Add(this.lblContraseña);
            this.groupCredenciales.Controls.Add(this.lblUsuario);
            this.groupCredenciales.Enabled = false;
            this.groupCredenciales.Location = new System.Drawing.Point(15, 106);
            this.groupCredenciales.Name = "groupCredenciales";
            this.groupCredenciales.Size = new System.Drawing.Size(431, 88);
            this.groupCredenciales.TabIndex = 2;
            this.groupCredenciales.TabStop = false;
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfigurar.Location = new System.Drawing.Point(206, 292);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(75, 23);
            this.btnConfigurar.TabIndex = 1;
            this.btnConfigurar.Text = "btnConfigurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(18, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(18, 57);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(71, 13);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "lblContraseña";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(116, 25);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(317, 20);
            this.txtServidor.TabIndex = 2;
            // 
            // txtBaseDeDatos
            // 
            this.txtBaseDeDatos.Location = new System.Drawing.Point(116, 58);
            this.txtBaseDeDatos.Name = "txtBaseDeDatos";
            this.txtBaseDeDatos.Size = new System.Drawing.Size(317, 20);
            this.txtBaseDeDatos.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(101, 23);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(317, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContraseña.Location = new System.Drawing.Point(101, 57);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(317, 20);
            this.txtContraseña.TabIndex = 5;
            // 
            // chkUsarKerberos
            // 
            this.chkUsarKerberos.AutoSize = true;
            this.chkUsarKerberos.Checked = true;
            this.chkUsarKerberos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsarKerberos.Location = new System.Drawing.Point(6, 0);
            this.chkUsarKerberos.Name = "chkUsarKerberos";
            this.chkUsarKerberos.Size = new System.Drawing.Size(108, 17);
            this.chkUsarKerberos.TabIndex = 4;
            this.chkUsarKerberos.Text = "chkUsarKerberos";
            this.chkUsarKerberos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido al asistente de configuración SQL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInstalador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfigurar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstalador";
            this.Text = "frmInstalador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupCredenciales.ResumeLayout(false);
            this.groupCredenciales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBaseDeDatos;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.GroupBox groupCredenciales;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtBaseDeDatos;
        private System.Windows.Forms.CheckBox chkUsarKerberos;
        private System.Windows.Forms.Label label1;
    }
}