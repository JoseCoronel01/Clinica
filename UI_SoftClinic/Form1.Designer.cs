namespace UI_SoftClinic
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasDeEvoluciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldarBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentosToolStripMenuItem,
            this.pacienteToolStripMenuItem,
            this.reportesStripMenuItem1,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem,
            this.mnuUsuario});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.documentosToolStripMenuItem.Text = "Documentos";
            this.documentosToolStripMenuItem.Click += new System.EventHandler(this.documentosToolStripMenuItem_Click);
            // 
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.consultaToolStripMenuItem,
            this.tratamientoToolStripMenuItem,
            this.notasDeEvoluciónToolStripMenuItem});
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.consultaToolStripMenuItem.Text = "Consultar";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // tratamientoToolStripMenuItem
            // 
            this.tratamientoToolStripMenuItem.Name = "tratamientoToolStripMenuItem";
            this.tratamientoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tratamientoToolStripMenuItem.Text = "Pagos";
            this.tratamientoToolStripMenuItem.Click += new System.EventHandler(this.tratamientoToolStripMenuItem_Click);
            // 
            // notasDeEvoluciónToolStripMenuItem
            // 
            this.notasDeEvoluciónToolStripMenuItem.Name = "notasDeEvoluciónToolStripMenuItem";
            this.notasDeEvoluciónToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.notasDeEvoluciónToolStripMenuItem.Text = "Notas de Evolución";
            this.notasDeEvoluciónToolStripMenuItem.Click += new System.EventHandler(this.notasDeEvoluciónToolStripMenuItem_Click);
            // 
            // reportesStripMenuItem1
            // 
            this.reportesStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDePacientesToolStripMenuItem,
            this.pagosToolStripMenuItem});
            this.reportesStripMenuItem1.Name = "reportesStripMenuItem1";
            this.reportesStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.reportesStripMenuItem1.Text = "Reportes";
            // 
            // listadoDePacientesToolStripMenuItem
            // 
            this.listadoDePacientesToolStripMenuItem.Name = "listadoDePacientesToolStripMenuItem";
            this.listadoDePacientesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.listadoDePacientesToolStripMenuItem.Text = "Listado de pacientes";
            this.listadoDePacientesToolStripMenuItem.Click += new System.EventHandler(this.listadoDePacientesToolStripMenuItem_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosDelSistemaToolStripMenuItem,
            this.respaldarBaseDeDatosToolStripMenuItem,
            this.agregarFondoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItem1.Text = "Configuración";
            // 
            // usuariosDelSistemaToolStripMenuItem
            // 
            this.usuariosDelSistemaToolStripMenuItem.Name = "usuariosDelSistemaToolStripMenuItem";
            this.usuariosDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.usuariosDelSistemaToolStripMenuItem.Text = "Usuarios del sistema";
            this.usuariosDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.usuariosDelSistemaToolStripMenuItem_Click);
            // 
            // respaldarBaseDeDatosToolStripMenuItem
            // 
            this.respaldarBaseDeDatosToolStripMenuItem.Name = "respaldarBaseDeDatosToolStripMenuItem";
            this.respaldarBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.respaldarBaseDeDatosToolStripMenuItem.Text = "Respaldar base de datos";
            this.respaldarBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.respaldarBaseDeDatosToolStripMenuItem_Click);
            // 
            // agregarFondoToolStripMenuItem
            // 
            this.agregarFondoToolStripMenuItem.Name = "agregarFondoToolStripMenuItem";
            this.agregarFondoToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.agregarFondoToolStripMenuItem.Text = "Fondo de pantalla";
            this.agregarFondoToolStripMenuItem.Click += new System.EventHandler(this.agregarFondoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(34, 20);
            this.mnuUsuario.Text = "***";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 423);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tratamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuariosDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripMenuItem listadoDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldarBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasDeEvoluciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarFondoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

