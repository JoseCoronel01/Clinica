namespace UI_SoftClinic
{
    partial class frmConsultaPaciente
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
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLugarResidencia = new TextBoxEx.CtrlTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponsable = new TextBoxEx.CtrlTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new TextBoxEx.CtrlTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new TextBoxEx.CtrlTextBox();
            this.txtApeMat = new TextBoxEx.CtrlTextBox();
            this.txtApePat = new TextBoxEx.CtrlTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuscar = new TextBoxEx.CtrlTextBox();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.cbTipo);
            this.gBoxDatos.Controls.Add(this.label9);
            this.gBoxDatos.Controls.Add(this.cbEstatus);
            this.gBoxDatos.Controls.Add(this.label7);
            this.gBoxDatos.Controls.Add(this.txtLugarResidencia);
            this.gBoxDatos.Controls.Add(this.label6);
            this.gBoxDatos.Controls.Add(this.txtResponsable);
            this.gBoxDatos.Controls.Add(this.label5);
            this.gBoxDatos.Controls.Add(this.txtTelefono);
            this.gBoxDatos.Controls.Add(this.label4);
            this.gBoxDatos.Controls.Add(this.txtNombre);
            this.gBoxDatos.Controls.Add(this.txtApeMat);
            this.gBoxDatos.Controls.Add(this.txtApePat);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Location = new System.Drawing.Point(12, 53);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(936, 347);
            this.gBoxDatos.TabIndex = 4;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Datos personales";
            // 
            // cbTipo
            // 
            this.cbTipo.DisplayMember = "text";
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Enabled = false;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(11, 140);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(277, 21);
            this.cbTipo.TabIndex = 7;
            this.cbTipo.ValueMember = "value";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tipo de Tratamiento";
            // 
            // cbEstatus
            // 
            this.cbEstatus.DisplayMember = "text";
            this.cbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstatus.Enabled = false;
            this.cbEstatus.FormattingEnabled = true;
            this.cbEstatus.Location = new System.Drawing.Point(546, 140);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(121, 21);
            this.cbEstatus.TabIndex = 11;
            this.cbEstatus.ValueMember = "value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Estatus";
            // 
            // txtLugarResidencia
            // 
            this.txtLugarResidencia.AplicarColorFoco = true;
            this.txtLugarResidencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLugarResidencia.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtLugarResidencia.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtLugarResidencia.Location = new System.Drawing.Point(11, 296);
            this.txtLugarResidencia.MaxLength = 200;
            this.txtLugarResidencia.Name = "txtLugarResidencia";
            this.txtLugarResidencia.ReadOnly = true;
            this.txtLugarResidencia.Size = new System.Drawing.Size(464, 20);
            this.txtLugarResidencia.TabIndex = 15;
            this.txtLugarResidencia.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Lugar de residencia";
            // 
            // txtResponsable
            // 
            this.txtResponsable.AplicarColorFoco = true;
            this.txtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResponsable.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtResponsable.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtResponsable.Location = new System.Drawing.Point(11, 221);
            this.txtResponsable.MaxLength = 200;
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.ReadOnly = true;
            this.txtResponsable.Size = new System.Drawing.Size(464, 20);
            this.txtResponsable.TabIndex = 13;
            this.txtResponsable.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Responsable";
            // 
            // txtTelefono
            // 
            this.txtTelefono.AplicarColorFoco = true;
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtTelefono.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtTelefono.Location = new System.Drawing.Point(321, 141);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(154, 20);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.Tecleado = TextBoxEx.CtrlTextBox.Validar.Numeros;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Teléfono de contacto";
            // 
            // txtNombre
            // 
            this.txtNombre.AplicarColorFoco = true;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtNombre.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtNombre.Location = new System.Drawing.Point(634, 63);
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(277, 20);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtApeMat
            // 
            this.txtApeMat.AplicarColorFoco = true;
            this.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeMat.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtApeMat.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtApeMat.Location = new System.Drawing.Point(321, 63);
            this.txtApeMat.MaxLength = 80;
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.ReadOnly = true;
            this.txtApeMat.Size = new System.Drawing.Size(277, 20);
            this.txtApeMat.TabIndex = 3;
            this.txtApeMat.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtApePat
            // 
            this.txtApePat.AplicarColorFoco = true;
            this.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApePat.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtApePat.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtApePat.Location = new System.Drawing.Point(11, 63);
            this.txtApePat.MaxLength = 80;
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.ReadOnly = true;
            this.txtApePat.Size = new System.Drawing.Size(277, 20);
            this.txtApePat.TabIndex = 1;
            this.txtApePat.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(629, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido Materno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido Paterno";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Buscar paciente";
            // 
            // txtBuscar
            // 
            this.txtBuscar.AplicarColorFoco = true;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtBuscar.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtBuscar.Location = new System.Drawing.Point(169, 14);
            this.txtBuscar.MaxLength = 200;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(185, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // cbPaciente
            // 
            this.cbPaciente.DisplayMember = "text";
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.FormattingEnabled = true;
            this.cbPaciente.Location = new System.Drawing.Point(366, 13);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(330, 21);
            this.cbPaciente.TabIndex = 2;
            this.cbPaciente.ValueMember = "value";
            this.cbPaciente.SelectedIndexChanged += new System.EventHandler(this.cbPaciente_SelectedIndexChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(709, 9);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmConsultaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 412);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.cbPaciente);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gBoxDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.frmConsultaPaciente_Load);
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.ComboBox cbEstatus;
        private System.Windows.Forms.Label label7;
        private TextBoxEx.CtrlTextBox txtLugarResidencia;
        private System.Windows.Forms.Label label6;
        private TextBoxEx.CtrlTextBox txtResponsable;
        private System.Windows.Forms.Label label5;
        private TextBoxEx.CtrlTextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private TextBoxEx.CtrlTextBox txtNombre;
        private TextBoxEx.CtrlTextBox txtApeMat;
        private TextBoxEx.CtrlTextBox txtApePat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private TextBoxEx.CtrlTextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label9;
    }
}