namespace SaludAr.GUI
{
    partial class frmHashing
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.GroupBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(73, 27);
            this.txtSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(454, 20);
            this.txtSource.TabIndex = 0;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEncrypt.Enabled = false;
            this.btnEncrypt.Location = new System.Drawing.Point(179, 135);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(82, 32);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "btnEncrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(13, 29);
            this.lblSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(51, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "lblSource";
            // 
            // lblTarget
            // 
            this.lblTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTarget.Controls.Add(this.txtTarget);
            this.lblTarget.Location = new System.Drawing.Point(11, 62);
            this.lblTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblTarget.Size = new System.Drawing.Size(518, 58);
            this.lblTarget.TabIndex = 5;
            this.lblTarget.TabStop = false;
            this.lblTarget.Text = "lblTarget";
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.Location = new System.Drawing.Point(4, 23);
            this.txtTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ReadOnly = true;
            this.txtTarget.Size = new System.Drawing.Size(511, 20);
            this.txtTarget.TabIndex = 2;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Location = new System.Drawing.Point(275, 135);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(82, 32);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "btnDecrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // frmHashing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 184);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtSource);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHashing";
            this.Text = "frmHashing";
            this.lblTarget.ResumeLayout(false);
            this.lblTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.GroupBox lblTarget;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnDecrypt;
    }
}

