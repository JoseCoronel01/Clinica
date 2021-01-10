using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmListadoUsuariosSistema : Form
    {
        strUsuario str = new strUsuario();
        private bool Check;

        public frmListadoUsuariosSistema()
        {
            InitializeComponent();
        }

        private void frmListadoUsuariosSistema_Load(object sender, EventArgs e)
        {
            CargarGrid();

            Check = false;
        }

        private void CargarGrid()
        {
            List<strUsuario> lista = daoUsuarios.GetAll();

            if (lista != null)
            {
                gvUsuarios.DataSource = lista;
                gvUsuarios.Columns["Password"].Visible = false;
            }
            else
                gvUsuarios.DataSource = new List<strUsuario>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmListadoCrudUsuariosSistema frm = new frmListadoCrudUsuariosSistema();
            frm.ModoEdicion = false;
            frm.Insert = true;
            frm.ShowDialog();
            if (!frm.Insert)
                CargarGrid();
            Check = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmListadoCrudUsuariosSistema frm = new frmListadoCrudUsuariosSistema();
            frm.ModoEdicion = true;
            frm.Insert = false;
            frm.Usuario = str;
            frm.CargarComboTipo();
            frm.MostrarDatos();
            frm.ShowDialog();
            if (!frm.ModoEdicion)
                CargarGrid();
            Check = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Check)
                {
                    int delete = daoUsuarios.Delete(str.Usuario);

                    if (delete > 0)
                    {
                        CargarGrid();
                        MessageBox.Show("Registro eliminado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Error!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No se ha seleccionado un usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarStr(strUsuario str, DataGridViewCellEventArgs e)
        {
            str.Usuario = gvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            str.Password = gvUsuarios.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            str.Tipo = (strUsuario.eTipo)gvUsuarios.Rows[e.RowIndex].Cells["Tipo"].Value;
        }

        private void gvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarStr(str, e);
            Check = true;
        }
    }
}