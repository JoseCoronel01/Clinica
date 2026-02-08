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

namespace UI_SoftClinic
{
    public partial class frmColaboradorNuevoListado : Form
    {
        List<strColaborador> colaboradores = null;
        strColaborador colaborador = null;

        public frmColaboradorNuevoListado()
        {
            InitializeComponent();
        }

        private void frmColaboradorNuevoListado_Load(object sender, EventArgs e)
        {
            this.colaboradores = daoColaboradores.GetList();
            gvColaboradores.DataSource = this.colaboradores;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmColaboradorNuevo frm = new frmColaboradorNuevo();
            frm.Insert = true;
            frm.ShowDialog();

            this.colaboradores = daoColaboradores.GetList();
            gvColaboradores.DataSource = this.colaboradores;
            this.colaborador = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.colaborador == null)
            {
                MessageBox.Show("Favor de seleccionar a un colaborador.", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            frmColaboradorNuevo frm = new frmColaboradorNuevo();
            frm.Insert = false;
            frm.Colaborador = this.colaborador;
            frm.MostrarDatos(this.colaborador);
            frm.ShowDialog();

            this.colaboradores = daoColaboradores.GetList();
            gvColaboradores.DataSource = this.colaboradores;
            this.colaborador = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.colaborador == null)
            {
                MessageBox.Show("Favor de seleccionar a un colaborador.", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar al colaborador "+this.colaborador.Nombre+"?", "Aviso", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var existe = daoColaboradoresDetalle.ExisteColaboradorDetalle(this.colaborador.Id);
                if (existe)
                {
                    MessageBox.Show("El Colaborador " + this.colaborador.Nombre + " no se puede eliminar. " +
                        "Hay Información asociada a este.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int delete = daoColaboradores.Delete(this.colaborador.Id);
                    if (delete > 0)
                    {
                        MessageBox.Show("Colaborador eliminado " + this.colaborador.Nombre + "",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.colaboradores = daoColaboradores.GetList();
                        gvColaboradores.DataSource = this.colaboradores;
                        this.colaborador = null;
                    }
                    else
                    {
                        MessageBox.Show("Error! Eliminando Colaborador " + this.colaborador.Nombre + ", " +
                            "Reporte al departamento de sistemas.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes("Colaboradores");
        }

        private void gvColaboradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = long.Parse(gvColaboradores.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            var nombre = gvColaboradores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

            this.colaborador = new strColaborador();
            this.colaborador.Id = id;
            this.colaborador.Nombre = nombre;
        }
    }
}
