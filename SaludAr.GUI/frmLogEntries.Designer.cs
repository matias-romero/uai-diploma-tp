namespace SaludAr.GUI
{
    partial class frmLogEntries
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
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.cboEvento = new System.Windows.Forms.ComboBox();
            this.lblTipoEvento = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.chkFiltrarUsuario = new System.Windows.Forms.CheckBox();
            this.filterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGroupBox.Controls.Add(this.chkFiltrarUsuario);
            this.filterGroupBox.Controls.Add(this.cboUsuario);
            this.filterGroupBox.Controls.Add(this.lblUsuario);
            this.filterGroupBox.Controls.Add(this.cboEvento);
            this.filterGroupBox.Controls.Add(this.lblTipoEvento);
            this.filterGroupBox.Controls.Add(this.lblDateRange);
            this.filterGroupBox.Controls.Add(this.btnFilter);
            this.filterGroupBox.Controls.Add(this.dtPickerTo);
            this.filterGroupBox.Controls.Add(this.dtPickerFrom);
            this.filterGroupBox.Location = new System.Drawing.Point(9, 8);
            this.filterGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.filterGroupBox.Size = new System.Drawing.Size(708, 133);
            this.filterGroupBox.TabIndex = 0;
            this.filterGroupBox.TabStop = false;
            // 
            // cboEvento
            // 
            this.cboEvento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEvento.FormattingEnabled = true;
            this.cboEvento.Location = new System.Drawing.Point(248, 43);
            this.cboEvento.Name = "cboEvento";
            this.cboEvento.Size = new System.Drawing.Size(455, 21);
            this.cboEvento.TabIndex = 4;
            // 
            // lblTipoEvento
            // 
            this.lblTipoEvento.AutoSize = true;
            this.lblTipoEvento.Location = new System.Drawing.Point(13, 46);
            this.lblTipoEvento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoEvento.Name = "lblTipoEvento";
            this.lblTipoEvento.Size = new System.Drawing.Size(72, 13);
            this.lblTipoEvento.TabIndex = 3;
            this.lblTipoEvento.Text = "lblTipoEvento";
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(13, 20);
            this.lblDateRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(72, 13);
            this.lblDateRange.TabIndex = 0;
            this.lblDateRange.Text = "lblDateRange";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFilter.Location = new System.Drawing.Point(323, 102);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(63, 27);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "btnFilter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPickerTo.Location = new System.Drawing.Point(482, 16);
            this.dtPickerTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(221, 20);
            this.dtPickerTo.TabIndex = 2;
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPickerFrom.Location = new System.Drawing.Point(248, 16);
            this.dtPickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(223, 20);
            this.dtPickerFrom.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 145);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(708, 399);
            this.dataGridView.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(13, 73);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // cboUsuario
            // 
            this.cboUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUsuario.Enabled = false;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(269, 70);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(434, 21);
            this.cboUsuario.TabIndex = 7;
            // 
            // chkFiltrarUsuario
            // 
            this.chkFiltrarUsuario.AutoSize = true;
            this.chkFiltrarUsuario.Location = new System.Drawing.Point(248, 73);
            this.chkFiltrarUsuario.Name = "chkFiltrarUsuario";
            this.chkFiltrarUsuario.Size = new System.Drawing.Size(15, 14);
            this.chkFiltrarUsuario.TabIndex = 6;
            this.chkFiltrarUsuario.UseVisualStyleBackColor = true;
            this.chkFiltrarUsuario.CheckedChanged += new System.EventHandler(this.chkFiltrarUsuario_CheckedChanged);
            // 
            // frmLogEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 568);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.filterGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLogEntries";
            this.Text = "frmLogEntries";
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblTipoEvento;
        private System.Windows.Forms.ComboBox cboEvento;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox chkFiltrarUsuario;
    }
}