namespace UI_SoftClinic
{
    partial class frmCrudDocumentos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtClave = new TextBoxEx.CtrlTextBox();
            this.txtNombre = new TextBoxEx.CtrlTextBox();
            this.txtDescripcion = new TextBoxEx.CtrlTextBox();
            this.txtDescBreve = new TextBoxEx.CtrlTextBox();
            this.txtEtiqueta = new TextBoxEx.CtrlTextBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.btnCrudTipo = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lbMensajeArchivo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descripción Breve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Etiqueta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Archivo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(400, 367);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(481, 367);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtClave
            // 
            this.txtClave.AplicarColorFoco = true;
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtClave.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtClave.Location = new System.Drawing.Point(213, 13);
            this.txtClave.MaxLength = 20;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(183, 20);
            this.txtClave.TabIndex = 1;
            this.txtClave.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtNombre
            // 
            this.txtNombre.AplicarColorFoco = true;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtNombre.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtNombre.Location = new System.Drawing.Point(213, 60);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(251, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AplicarColorFoco = true;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtDescripcion.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtDescripcion.Location = new System.Drawing.Point(213, 110);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(344, 20);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtDescBreve
            // 
            this.txtDescBreve.AplicarColorFoco = true;
            this.txtDescBreve.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescBreve.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtDescBreve.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtDescBreve.Location = new System.Drawing.Point(213, 162);
            this.txtDescBreve.MaxLength = 30;
            this.txtDescBreve.Name = "txtDescBreve";
            this.txtDescBreve.Size = new System.Drawing.Size(251, 20);
            this.txtDescBreve.TabIndex = 7;
            this.txtDescBreve.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.AplicarColorFoco = true;
            this.txtEtiqueta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEtiqueta.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtEtiqueta.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtEtiqueta.Location = new System.Drawing.Point(213, 213);
            this.txtEtiqueta.MaxLength = 10;
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(111, 20);
            this.txtEtiqueta.TabIndex = 9;
            this.txtEtiqueta.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // cbTipo
            // 
            this.cbTipo.DisplayMember = "Nombre";
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(213, 262);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(251, 21);
            this.cbTipo.TabIndex = 11;
            this.cbTipo.ValueMember = "Id";
            // 
            // btnCrudTipo
            // 
            this.btnCrudTipo.Location = new System.Drawing.Point(470, 262);
            this.btnCrudTipo.Name = "btnCrudTipo";
            this.btnCrudTipo.Size = new System.Drawing.Size(40, 21);
            this.btnCrudTipo.TabIndex = 12;
            this.btnCrudTipo.Text = "...";
            this.btnCrudTipo.UseVisualStyleBackColor = true;
            this.btnCrudTipo.Click += new System.EventHandler(this.btnCrudTipo_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(213, 315);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 14;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lbMensajeArchivo
            // 
            this.lbMensajeArchivo.AutoSize = true;
            this.lbMensajeArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensajeArchivo.ForeColor = System.Drawing.Color.Red;
            this.lbMensajeArchivo.Location = new System.Drawing.Point(294, 315);
            this.lbMensajeArchivo.Name = "lbMensajeArchivo";
            this.lbMensajeArchivo.Size = new System.Drawing.Size(14, 18);
            this.lbMensajeArchivo.TabIndex = 15;
            this.lbMensajeArchivo.Text = "*";
            // 
            // frmCrudDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 402);
            this.Controls.Add(this.lbMensajeArchivo);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnCrudTipo);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.txtEtiqueta);
            this.Controls.Add(this.txtDescBreve);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCrudDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documento";
            this.Load += new System.EventHandler(this.frmCrudDocumentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private TextBoxEx.CtrlTextBox txtClave;
        private TextBoxEx.CtrlTextBox txtNombre;
        private TextBoxEx.CtrlTextBox txtDescripcion;
        private TextBoxEx.CtrlTextBox txtDescBreve;
        private TextBoxEx.CtrlTextBox txtEtiqueta;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btnCrudTipo;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lbMensajeArchivo;
    }
}