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
    public partial class frmColaboradoresListado : Form
    {
        List<strColaboradorDetalle> colaboradorDetalles = null;
        strColaboradorDetalle colaboradorDetalle = null;

        public frmColaboradoresListado()
        {
            InitializeComponent();
        }

        private void frmColaboradoresListado_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            colaboradorDetalles = daoColaboradoresDetalle.GetList();
            gvColaboradores.DataSource = colaboradorDetalles;
            if (this.colaboradorDetalles != null)
            {
                gvColaboradores.Columns["Id"].Visible = false;
                gvColaboradores.Columns["ColaboradorId"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmColaboradores frm = new frmColaboradores();
            frm.Insert = true;
            frm.ShowDialog();

            CargarGrid();
            this.colaboradorDetalle = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.colaboradorDetalle == null)
            {
                MessageBox.Show("Favor de seleccionar un registro para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmColaboradores frm = new frmColaboradores();
            frm.Insert = false;
            frm.ColaboradorDetalle = this.colaboradorDetalle;
            frm.MostrarDatos(this.colaboradorDetalle);
            frm.ShowDialog();

            CargarGrid();
            this.colaboradorDetalle = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.colaboradorDetalle == null)
            {
                MessageBox.Show("Favor de seleccionar un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado de "+
                daoColaboradores.GetObject(this.colaboradorDetalle.ColaboradorId).Nombre+ "?", "Aviso", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int delete = daoColaboradoresDetalle.Delete(this.colaboradorDetalle.Id);
                if (delete > 0)
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrid();
                    this.colaboradorDetalle = null;
                }
                else
                {
                    MessageBox.Show("Error en eliminar el registro, Reporte al departamento de sistemas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes("ColaboradoresDetalle");
            frm.Show();
        }

        private void gvColaboradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Id = long.Parse(gvColaboradores.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            var ColaboradorId = long.Parse(gvColaboradores.Rows[e.RowIndex].Cells["ColaboradorId"].Value.ToString());
            var FechaEmision = DateTime.Parse(gvColaboradores.Rows[e.RowIndex].Cells["FechaEmision"].Value.ToString());
            var Importe = decimal.Parse(gvColaboradores.Rows[e.RowIndex].Cells["Importe"].Value.ToString());
            var Pagado = bool.Parse(gvColaboradores.Rows[e.RowIndex].Cells["Pagado"].Value.ToString());
            var FechaPago = DateTime.Parse(gvColaboradores.Rows[e.RowIndex].Cells["FechaPago"].Value.ToString());
            var Concepto = gvColaboradores.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();

            this.colaboradorDetalle = new strColaboradorDetalle();
            this.colaboradorDetalle.Id = Id;
            this.colaboradorDetalle.ColaboradorId = ColaboradorId;
            this.colaboradorDetalle.FechaEmision = FechaEmision;
            this.colaboradorDetalle.Importe = Importe;
            this.colaboradorDetalle.Pagado = Pagado;
            this.colaboradorDetalle.FechaPago = FechaPago;
            this.colaboradorDetalle.Concepto = Concepto;
        }
    }
}
