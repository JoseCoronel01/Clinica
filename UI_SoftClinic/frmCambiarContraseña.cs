using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmCambiarContraseña : ConfigGeneral
    {
        public frmCambiarContraseña()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G)
            {
                Guardar();
            }
        }

        private void Guardar()
        {
            if (txtActual.Text != "" && txtNueva.Text != "" && txtConfirmar.Text != "")
            {
                var obj = daoUsuarios.GetObject(this.Usuario, txtActual.Text);
                if (obj != null)
                {
                    if (txtNueva.Text == txtConfirmar.Text)
                    {
                        strUsuario str = new strUsuario();
                        str.Usuario = this.Usuario;
                        str.Password = txtConfirmar.Text;
                        int save = daoUsuarios.UpdatePass(str);
                        if (save > 0)
                        {
                            MessageBox.Show("Contraseña Actualizada", this.Text, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Nueva Contraseña no Coincide con la de Confirmación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña Actual es Incorrecta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hay Campos Vacíos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtActual.Text = "";
            txtNueva.Text = "";
            txtConfirmar.Text = "";
            txtActual.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                this.Close();
            }
        }
    }
}
