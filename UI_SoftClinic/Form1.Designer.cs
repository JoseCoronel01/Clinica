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
            this.mnucolaboradores = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cambiarContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnucolaboradores,
            this.documentosToolStripMenuItem,
            this.pacienteToolStripMenuItem,
            this.reportesStripMenuItem1,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem,
            this.mnuUsuario});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnucolaboradores
            // 
            this.mnucolaboradores.Name = "mnucolaboradores";
            this.mnucolaboradores.Size = new System.Drawing.Size(121, 24);
            this.mnucolaboradores.Text = "Colaboradores";
            this.mnucolaboradores.Click += new System.EventHandler(this.mnucolaboradores_Click);
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
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
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.consultaToolStripMenuItem.Text = "Consultar";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // tratamientoToolStripMenuItem
            // 
            this.tratamientoToolStripMenuItem.Name = "tratamientoToolStripMenuItem";
            this.tratamientoToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.tratamientoToolStripMenuItem.Text = "Pagos";
            this.tratamientoToolStripMenuItem.Click += new System.EventHandler(this.tratamientoToolStripMenuItem_Click);
            // 
            // notasDeEvoluciónToolStripMenuItem
            // 
            this.notasDeEvoluciónToolStripMenuItem.Name = "notasDeEvoluciónToolStripMenuItem";
            this.notasDeEvoluciónToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.notasDeEvoluciónToolStripMenuItem.Text = "Notas de Evolución";
            this.notasDeEvoluciónToolStripMenuItem.Click += new System.EventHandler(this.notasDeEvoluciónToolStripMenuItem_Click);
            // 
            // reportesStripMenuItem1
            // 
            this.reportesStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDePacientesToolStripMenuItem,
            this.pagosToolStripMenuItem});
            this.reportesStripMenuItem1.Name = "reportesStripMenuItem1";
            this.reportesStripMenuItem1.Size = new System.Drawing.Size(82, 24);
            this.reportesStripMenuItem1.Text = "Reportes";
            // 
            // listadoDePacientesToolStripMenuItem
            // 
            this.listadoDePacientesToolStripMenuItem.Name = "listadoDePacientesToolStripMenuItem";
            this.listadoDePacientesToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.listadoDePacientesToolStripMenuItem.Text = "Listado de pacientes";
            this.listadoDePacientesToolStripMenuItem.Click += new System.EventHandler(this.listadoDePacientesToolStripMenuItem_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosDelSistemaToolStripMenuItem,
            this.respaldarBaseDeDatosToolStripMenuItem,
            this.cambiarContrasena});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 24);
            this.toolStripMenuItem1.Text = "Configuración";
            // 
            // usuariosDelSistemaToolStripMenuItem
            // 
            this.usuariosDelSistemaToolStripMenuItem.Name = "usuariosDelSistemaToolStripMenuItem";
            this.usuariosDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.usuariosDelSistemaToolStripMenuItem.Text = "Usuarios del sistema";
            this.usuariosDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.usuariosDelSistemaToolStripMenuItem_Click);
            // 
            // respaldarBaseDeDatosToolStripMenuItem
            // 
            this.respaldarBaseDeDatosToolStripMenuItem.Name = "respaldarBaseDeDatosToolStripMenuItem";
            this.respaldarBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.respaldarBaseDeDatosToolStripMenuItem.Text = "Respaldar base de datos";
            this.respaldarBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.respaldarBaseDeDatosToolStripMenuItem_Click);
            // 
            // cambiarContrasena
            // 
            this.cambiarContrasena.Name = "cambiarContrasena";
            this.cambiarContrasena.Size = new System.Drawing.Size(255, 26);
            this.cambiarContrasena.Text = "Cambiar Contraseña";
            this.cambiarContrasena.Click += new System.EventHandler(this.cambiarContrasena_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(41, 24);
            this.mnuUsuario.Text = "***";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem cambiarContrasena;
        private System.Windows.Forms.ToolStripMenuItem mnucolaboradores;
    }
}

