namespace SaludAr.GUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCentrosDeSaludToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisualizarAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfigurarAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.systemLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAsignarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerDisponibilidadTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdmisionarTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMisTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProfesionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestionPerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptoServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.appointmentsToolStripMenuItem,
            this.hRToolStripMenuItem,
            this.toolsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1168, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCentrosDeSaludToolStripMenuItem,
            this.mnuEspecialidadesToolStripMenuItem,
            this.mnuAgendasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mnuPacientesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.backupRestoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.systemLogToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // mnuCentrosDeSaludToolStripMenuItem
            // 
            this.mnuCentrosDeSaludToolStripMenuItem.Name = "mnuCentrosDeSaludToolStripMenuItem";
            this.mnuCentrosDeSaludToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mnuCentrosDeSaludToolStripMenuItem.Text = "mnuCentrosDeSalud";
            this.mnuCentrosDeSaludToolStripMenuItem.Click += new System.EventHandler(this.mnuCentrosDeSaludToolStripMenuItem_Click);
            // 
            // mnuEspecialidadesToolStripMenuItem
            // 
            this.mnuEspecialidadesToolStripMenuItem.Name = "mnuEspecialidadesToolStripMenuItem";
            this.mnuEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mnuEspecialidadesToolStripMenuItem.Text = "mnuEspecialidades";
            this.mnuEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.mnuEspecialidadesToolStripMenuItem_Click);
            // 
            // mnuAgendasToolStripMenuItem
            // 
            this.mnuAgendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVisualizarAgendaToolStripMenuItem,
            this.mnuConfigurarAgendaToolStripMenuItem});
            this.mnuAgendasToolStripMenuItem.Name = "mnuAgendasToolStripMenuItem";
            this.mnuAgendasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mnuAgendasToolStripMenuItem.Text = "mnuAgendas";
            // 
            // mnuVisualizarAgendaToolStripMenuItem
            // 
            this.mnuVisualizarAgendaToolStripMenuItem.Name = "mnuVisualizarAgendaToolStripMenuItem";
            this.mnuVisualizarAgendaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuVisualizarAgendaToolStripMenuItem.Text = "mnuVisualizarAgenda";
            this.mnuVisualizarAgendaToolStripMenuItem.Visible = false;
            // 
            // mnuConfigurarAgendaToolStripMenuItem
            // 
            this.mnuConfigurarAgendaToolStripMenuItem.Name = "mnuConfigurarAgendaToolStripMenuItem";
            this.mnuConfigurarAgendaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.mnuConfigurarAgendaToolStripMenuItem.Text = "mnuConfigurarAgenda";
            this.mnuConfigurarAgendaToolStripMenuItem.Click += new System.EventHandler(this.mnuConfigurarAgendaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
            // 
            // mnuPacientesToolStripMenuItem
            // 
            this.mnuPacientesToolStripMenuItem.Name = "mnuPacientesToolStripMenuItem";
            this.mnuPacientesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mnuPacientesToolStripMenuItem.Text = "mnuPacientes";
            this.mnuPacientesToolStripMenuItem.Click += new System.EventHandler(this.mnuPacientesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 6);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup / Restore";
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // systemLogToolStripMenuItem
            // 
            this.systemLogToolStripMenuItem.Name = "systemLogToolStripMenuItem";
            this.systemLogToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.systemLogToolStripMenuItem.Text = "System Log";
            this.systemLogToolStripMenuItem.Click += new System.EventHandler(this.systemLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(180, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAsignarTurnoToolStripMenuItem,
            this.mnuVerDisponibilidadTurnosToolStripMenuItem,
            this.mnuAdmisionarTurnosToolStripMenuItem,
            this.mnuMisTurnosToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // mnuAsignarTurnoToolStripMenuItem
            // 
            this.mnuAsignarTurnoToolStripMenuItem.Name = "mnuAsignarTurnoToolStripMenuItem";
            this.mnuAsignarTurnoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.mnuAsignarTurnoToolStripMenuItem.Text = "mnuAsignarTurno";
            this.mnuAsignarTurnoToolStripMenuItem.Click += new System.EventHandler(this.mnuAsignarTurnoToolStripMenuItem_Click);
            // 
            // mnuVerDisponibilidadTurnosToolStripMenuItem
            // 
            this.mnuVerDisponibilidadTurnosToolStripMenuItem.Name = "mnuVerDisponibilidadTurnosToolStripMenuItem";
            this.mnuVerDisponibilidadTurnosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.mnuVerDisponibilidadTurnosToolStripMenuItem.Text = "mnuVerDisponibilidadTurnos";
            this.mnuVerDisponibilidadTurnosToolStripMenuItem.Visible = false;
            // 
            // mnuAdmisionarTurnosToolStripMenuItem
            // 
            this.mnuAdmisionarTurnosToolStripMenuItem.Name = "mnuAdmisionarTurnosToolStripMenuItem";
            this.mnuAdmisionarTurnosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.mnuAdmisionarTurnosToolStripMenuItem.Text = "mnuAdmisionarTurnos";
            this.mnuAdmisionarTurnosToolStripMenuItem.Click += new System.EventHandler(this.mnuAdmisionarTurnosToolStripMenuItem_Click);
            // 
            // mnuMisTurnosToolStripMenuItem
            // 
            this.mnuMisTurnosToolStripMenuItem.Name = "mnuMisTurnosToolStripMenuItem";
            this.mnuMisTurnosToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.mnuMisTurnosToolStripMenuItem.Text = "mnuMisTurnos";
            this.mnuMisTurnosToolStripMenuItem.Click += new System.EventHandler(this.mnuMisTurnosToolStripMenuItem_Click);
            // 
            // hRToolStripMenuItem
            // 
            this.hRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmpleadosToolStripMenuItem,
            this.mnuProfesionalesToolStripMenuItem,
            this.mnuGestionPerfilesToolStripMenuItem});
            this.hRToolStripMenuItem.Name = "hRToolStripMenuItem";
            this.hRToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.hRToolStripMenuItem.Text = "HR";
            // 
            // mnuEmpleadosToolStripMenuItem
            // 
            this.mnuEmpleadosToolStripMenuItem.Name = "mnuEmpleadosToolStripMenuItem";
            this.mnuEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mnuEmpleadosToolStripMenuItem.Text = "mnuEmpleados";
            this.mnuEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.mnuEmpleadosToolStripMenuItem_Click);
            // 
            // mnuProfesionalesToolStripMenuItem
            // 
            this.mnuProfesionalesToolStripMenuItem.Name = "mnuProfesionalesToolStripMenuItem";
            this.mnuProfesionalesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mnuProfesionalesToolStripMenuItem.Text = "mnuProfesionales";
            this.mnuProfesionalesToolStripMenuItem.Click += new System.EventHandler(this.mnuProfesionalesToolStripMenuItem_Click);
            // 
            // mnuGestionPerfilesToolStripMenuItem
            // 
            this.mnuGestionPerfilesToolStripMenuItem.Name = "mnuGestionPerfilesToolStripMenuItem";
            this.mnuGestionPerfilesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mnuGestionPerfilesToolStripMenuItem.Text = "mnuGestionPerfiles";
            this.mnuGestionPerfilesToolStripMenuItem.Click += new System.EventHandler(this.mnuGestionPerfilesToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.cryptoServicesToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(47, 20);
            this.toolsMenu.Text = "&Tools";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // cryptoServicesToolStripMenuItem
            // 
            this.cryptoServicesToolStripMenuItem.Name = "cryptoServicesToolStripMenuItem";
            this.cryptoServicesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cryptoServicesToolStripMenuItem.Text = "CryptoServices";
            this.cryptoServicesToolStripMenuItem.Click += new System.EventHandler(this.cryptoServicesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1168, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1168, 679);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cryptoServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem systemLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCentrosDeSaludToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAgendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualizarAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigurarAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuProfesionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuGestionPerfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAsignarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVerDisponibilidadTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMisTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmisionarTurnosToolStripMenuItem;
    }
}



