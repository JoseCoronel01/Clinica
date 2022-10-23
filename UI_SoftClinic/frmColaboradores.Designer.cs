
namespace UI_SoftClinic
{
    partial class frmColaboradores
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
            this.cbColaborador = new System.Windows.Forms.ComboBox();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.txtImporte = new TextBoxEx.CtrlTextBox();
            this.chBoxPagado = new System.Windows.Forms.CheckBox();
            this.dtpFechaDePago = new System.Windows.Forms.DateTimePicker();
            this.txtConcepto = new TextBoxEx.CtrlTextBox();
            this.btnNuevoColaborador = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Colaborador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Emisión";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pagado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Concepto";
            // 
            // cbColaborador
            // 
            this.cbColaborador.DisplayMember = "Nombre";
            this.cbColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColaborador.FormattingEnabled = true;
            this.cbColaborador.Location = new System.Drawing.Point(213, 21);
            this.cbColaborador.Name = "cbColaborador";
            this.cbColaborador.Size = new System.Drawing.Size(250, 21);
            this.cbColaborador.TabIndex = 6;
            this.cbColaborador.ValueMember = "Id";
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(213, 78);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaEmision.TabIndex = 7;
            // 
            // txtImporte
            // 
            this.txtImporte.AplicarColorFoco = true;
            this.txtImporte.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtImporte.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtImporte.Location = new System.Drawing.Point(213, 134);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(103, 20);
            this.txtImporte.TabIndex = 8;
            this.txtImporte.Tecleado = TextBoxEx.CtrlTextBox.Validar.Numeros;
            // 
            // chBoxPagado
            // 
            this.chBoxPagado.AutoSize = true;
            this.chBoxPagado.Location = new System.Drawing.Point(213, 188);
            this.chBoxPagado.Name = "chBoxPagado";
            this.chBoxPagado.Size = new System.Drawing.Size(63, 17);
            this.chBoxPagado.TabIndex = 9;
            this.chBoxPagado.Text = "Pagado";
            this.chBoxPagado.UseVisualStyleBackColor = true;
            this.chBoxPagado.CheckedChanged += new System.EventHandler(this.chBoxPagado_CheckedChanged);
            // 
            // dtpFechaDePago
            // 
            this.dtpFechaDePago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDePago.Location = new System.Drawing.Point(213, 235);
            this.dtpFechaDePago.Name = "dtpFechaDePago";
            this.dtpFechaDePago.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaDePago.TabIndex = 10;
            // 
            // txtConcepto
            // 
            this.txtConcepto.AplicarColorFoco = true;
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.ColorControlDesenfocado = System.Drawing.Color.White;
            this.txtConcepto.ColorControlEnfocado = System.Drawing.Color.LightCyan;
            this.txtConcepto.Location = new System.Drawing.Point(213, 287);
            this.txtConcepto.MaxLength = 200;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(250, 69);
            this.txtConcepto.TabIndex = 11;
            this.txtConcepto.Tecleado = TextBoxEx.CtrlTextBox.Validar.Normal;
            // 
            // btnNuevoColaborador
            // 
            this.btnNuevoColaborador.Location = new System.Drawing.Point(478, 21);
            this.btnNuevoColaborador.Name = "btnNuevoColaborador";
            this.btnNuevoColaborador.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoColaborador.TabIndex = 12;
            this.btnNuevoColaborador.Text = "...";
            this.btnNuevoColaborador.UseVisualStyleBackColor = true;
            this.btnNuevoColaborador.Click += new System.EventHandler(this.btnNuevoColaborador_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(339, 412);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(443, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 447);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevoColaborador);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.dtpFechaDePago);
            this.Controls.Add(this.chBoxPagado);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.dtpFechaEmision);
            this.Controls.Add(this.cbColaborador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmColaboradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmColaboradores_Load);
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
        private System.Windows.Forms.ComboBox cbColaborador;
        private System.Windows.Forms.DateTimePicker dtpFechaEmision;
        private TextBoxEx.CtrlTextBox txtImporte;
        private System.Windows.Forms.CheckBox chBoxPagado;
        private System.Windows.Forms.DateTimePicker dtpFechaDePago;
        private TextBoxEx.CtrlTextBox txtConcepto;
        private System.Windows.Forms.Button btnNuevoColaborador;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}