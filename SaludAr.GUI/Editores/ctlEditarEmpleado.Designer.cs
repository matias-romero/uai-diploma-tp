namespace SaludAr.GUI.Editores
{
    partial class ctlEditarEmpleado
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
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNroLegajo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblNroLegajo = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboPerfil = new System.Windows.Forms.ComboBox();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.linkNombreUsuario = new System.Windows.Forms.LinkLabel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chkUsuarioHabilitado = new System.Windows.Forms.CheckBox();
            this.cboSexo = new SaludAr.GUI.Editores.ComboEnumerado();
            this.chkEsProfesional = new System.Windows.Forms.CheckBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.Location = new System.Drawing.Point(87, 123);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(180, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtNroLegajo
            // 
            this.txtNroLegajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroLegajo.Location = new System.Drawing.Point(87, 63);
            this.txtNroLegajo.Name = "txtNroLegajo";
            this.txtNroLegajo.Size = new System.Drawing.Size(180, 20);
            this.txtNroLegajo.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellido.Location = new System.Drawing.Point(87, 35);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(180, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(87, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(12, 126);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(59, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "lblTelefono";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(12, 99);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 13);
            this.lblSexo.TabIndex = 6;
            this.lblSexo.Text = "lblSexo";
            // 
            // lblNroLegajo
            // 
            this.lblNroLegajo.AutoSize = true;
            this.lblNroLegajo.Location = new System.Drawing.Point(12, 66);
            this.lblNroLegajo.Name = "lblNroLegajo";
            this.lblNroLegajo.Size = new System.Drawing.Size(66, 13);
            this.lblNroLegajo.TabIndex = 4;
            this.lblNroLegajo.Text = "lblNroLegajo";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(12, 38);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(54, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "lblApellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "lblNombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboPerfil);
            this.groupBox1.Controls.Add(this.lblPerfil);
            this.groupBox1.Controls.Add(this.linkNombreUsuario);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.chkUsuarioHabilitado);
            this.groupBox1.Location = new System.Drawing.Point(15, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 72);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // comboPerfil
            // 
            this.comboPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPerfil.Enabled = false;
            this.comboPerfil.FormattingEnabled = true;
            this.comboPerfil.Location = new System.Drawing.Point(81, 40);
            this.comboPerfil.Name = "comboPerfil";
            this.comboPerfil.Size = new System.Drawing.Size(165, 21);
            this.comboPerfil.TabIndex = 4;
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(6, 43);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(40, 13);
            this.lblPerfil.TabIndex = 3;
            this.lblPerfil.Text = "lblPerfil";
            // 
            // linkNombreUsuario
            // 
            this.linkNombreUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkNombreUsuario.Location = new System.Drawing.Point(81, 20);
            this.linkNombreUsuario.Name = "linkNombreUsuario";
            this.linkNombreUsuario.Size = new System.Drawing.Size(165, 13);
            this.linkNombreUsuario.TabIndex = 2;
            this.linkNombreUsuario.TabStop = true;
            this.linkNombreUsuario.Text = "linkNombreUsuario";
            this.linkNombreUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // chkUsuarioHabilitado
            // 
            this.chkUsuarioHabilitado.AutoSize = true;
            this.chkUsuarioHabilitado.Location = new System.Drawing.Point(6, 0);
            this.chkUsuarioHabilitado.Name = "chkUsuarioHabilitado";
            this.chkUsuarioHabilitado.Size = new System.Drawing.Size(127, 17);
            this.chkUsuarioHabilitado.TabIndex = 0;
            this.chkUsuarioHabilitado.Text = "chkUsuarioHabilitado";
            this.chkUsuarioHabilitado.UseVisualStyleBackColor = true;
            this.chkUsuarioHabilitado.CheckedChanged += new System.EventHandler(this.chkUsuarioHabilitado_CheckedChanged);
            // 
            // cboSexo
            // 
            this.cboSexo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSexo.DisplayMember = "Descripcion";
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Location = new System.Drawing.Point(87, 95);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(180, 21);
            this.cboSexo.TabIndex = 7;
            this.cboSexo.ValueMember = "Valor";
            // 
            // chkEsProfesional
            // 
            this.chkEsProfesional.AutoSize = true;
            this.chkEsProfesional.Location = new System.Drawing.Point(87, 152);
            this.chkEsProfesional.Name = "chkEsProfesional";
            this.chkEsProfesional.Size = new System.Drawing.Size(108, 17);
            this.chkEsProfesional.TabIndex = 10;
            this.chkEsProfesional.Text = "chkEsProfesional";
            this.chkEsProfesional.UseVisualStyleBackColor = true;
            this.chkEsProfesional.CheckedChanged += new System.EventHandler(this.chkEsProfesional_CheckedChanged);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatricula.Enabled = false;
            this.txtMatricula.Location = new System.Drawing.Point(87, 175);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(180, 20);
            this.txtMatricula.TabIndex = 12;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(12, 178);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(60, 13);
            this.lblMatricula.TabIndex = 11;
            this.lblMatricula.Text = "lblMatricula";
            // 
            // ctlEditarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.chkEsProfesional);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboSexo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNroLegajo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblNroLegajo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Name = "ctlEditarEmpleado";
            this.Size = new System.Drawing.Size(282, 292);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboEnumerado cboSexo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNroLegajo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblNroLegajo;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUsuarioHabilitado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.LinkLabel linkNombreUsuario;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox comboPerfil;
        private System.Windows.Forms.CheckBox chkEsProfesional;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblMatricula;
    }
}
