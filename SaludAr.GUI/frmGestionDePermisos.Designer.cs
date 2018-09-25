namespace SaludAr.GUI
{
    partial class frmGestionDePermisos
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
            this.group = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboPerfil = new System.Windows.Forms.ComboBox();
            this.groupPermisos = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.checkedListBoxPermisos = new System.Windows.Forms.CheckedListBox();
            this.group.SuspendLayout();
            this.groupPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // group
            // 
            this.group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group.Controls.Add(this.btnAdd);
            this.group.Controls.Add(this.cboPerfil);
            this.group.Location = new System.Drawing.Point(13, 13);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(953, 58);
            this.group.TabIndex = 0;
            this.group.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(917, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboPerfil
            // 
            this.cboPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfil.FormattingEnabled = true;
            this.cboPerfil.Location = new System.Drawing.Point(17, 19);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Size = new System.Drawing.Size(894, 21);
            this.cboPerfil.TabIndex = 0;
            this.cboPerfil.SelectedValueChanged += new System.EventHandler(this.cboPerfil_SelectedValueChanged);
            // 
            // groupPermisos
            // 
            this.groupPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPermisos.Controls.Add(this.btnGuardar);
            this.groupPermisos.Controls.Add(this.checkedListBoxPermisos);
            this.groupPermisos.Location = new System.Drawing.Point(13, 78);
            this.groupPermisos.Name = "groupPermisos";
            this.groupPermisos.Size = new System.Drawing.Size(953, 522);
            this.groupPermisos.TabIndex = 1;
            this.groupPermisos.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(7, 496);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(935, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "btnGuardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // checkedListBoxPermisos
            // 
            this.checkedListBoxPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxPermisos.FormattingEnabled = true;
            this.checkedListBoxPermisos.Location = new System.Drawing.Point(7, 20);
            this.checkedListBoxPermisos.Name = "checkedListBoxPermisos";
            this.checkedListBoxPermisos.Size = new System.Drawing.Size(935, 469);
            this.checkedListBoxPermisos.TabIndex = 0;
            // 
            // frmGestionDePermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 612);
            this.Controls.Add(this.groupPermisos);
            this.Controls.Add(this.group);
            this.Name = "frmGestionDePermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionDePermisos";
            this.group.ResumeLayout(false);
            this.groupPermisos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.ComboBox cboPerfil;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupPermisos;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermisos;
        private System.Windows.Forms.Button btnGuardar;
    }
}