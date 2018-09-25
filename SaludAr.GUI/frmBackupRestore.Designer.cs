namespace SaludAr.GUI
{
    partial class frmBackupRestore
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtBackupName = new System.Windows.Forms.TextBox();
            this.lstBackups = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBackupName);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBackups);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 275);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(6, 246);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(461, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "btnRestore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(392, 17);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "btnBackup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupName
            // 
            this.txtBackupName.Location = new System.Drawing.Point(6, 19);
            this.txtBackupName.Name = "txtBackupName";
            this.txtBackupName.Size = new System.Drawing.Size(380, 20);
            this.txtBackupName.TabIndex = 3;
            // 
            // lstBackups
            // 
            this.lstBackups.FormattingEnabled = true;
            this.lstBackups.Location = new System.Drawing.Point(6, 15);
            this.lstBackups.Name = "lstBackups";
            this.lstBackups.Size = new System.Drawing.Size(461, 225);
            this.lstBackups.TabIndex = 3;
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupRestore";
            this.Text = "frmBackupRestore";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtBackupName;
        private System.Windows.Forms.ListBox lstBackups;
    }
}