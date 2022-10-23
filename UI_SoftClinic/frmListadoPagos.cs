using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_SoftClinic.BusinessRules;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmListadoPagos : Form
    {
        public long IdTratamiento { get; set; }
        public long IdPaciente { get; set; }

        List<strPago> lista = null;

        strBrPago brPago = new strBrPago();

        private int index = -1;

        public frmListadoPagos()
        {
            InitializeComponent();
        }

        private void frmListadoPagos_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            lista = daoPago.GetAll(this.IdTratamiento);
            //List<strPago> pagos = brPago.ConvertPagosGrid(lista, this.IdTratamiento, this.IdPaciente);
            //if (pagos == null) return;
            if (lista == null) return;
            gvPagos.DataSource = lista; //pagos;
            gvPagos.Columns["Uid"].Visible = false;
            gvPagos.Columns["Tratamiento"].Visible = false;
        }

        private void gvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //index = e.RowIndex;
            //NuevoPago(index);
        }

        private void NuevoPago(int index)
        {
            frmListadoPagoCrud frm = new frmListadoPagoCrud();
            if (index != -1)
            {
                frm.Tratamiento = IdTratamiento; //long.Parse(gvPagos.Rows[index].Cells["Tratamiento"].Value.ToString());
                //frm.Fecha = DateTime.Parse(gvPagos.Rows[index].Cells["Fecha"].Value.ToString());
                //frm.Folio = gvPagos.Rows[index].Cells["Folio"].Value.ToString();
                //frm.Importe = decimal.Parse(gvPagos.Rows[index].Cells["Importe"].Value.ToString());
                frm.Insert = true;
                frm.ShowDialog();
            }
            else
            {
                frm.Tratamiento = this.IdTratamiento;
                frm.Insert = true;
                frm.ShowDialog();
            }

            if (!frm.Insert)
                CargarGrid();

            index = -1;
        }

        private void gvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoPago(index);
        }
    }
}