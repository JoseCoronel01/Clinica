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
            List<strPago> pagos = brPago.ConvertPagosGrid(lista, this.IdTratamiento, this.IdPaciente);
            if (pagos == null) return;
            gvPagos.DataSource = pagos;
            gvPagos.Columns["Uid"].Visible = false;
            gvPagos.Columns["Tratamiento"].Visible = false;
        }

        private void gvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmListadoPagoCrud frm = new frmListadoPagoCrud();

            frm.Tratamiento = long.Parse(gvPagos.Rows[e.RowIndex].Cells["Tratamiento"].Value.ToString());
            frm.Fecha = DateTime.Parse(gvPagos.Rows[e.RowIndex].Cells["Fecha"].Value.ToString());
            frm.Folio = gvPagos.Rows[e.RowIndex].Cells["Folio"].Value.ToString();
            frm.Importe = decimal.Parse(gvPagos.Rows[e.RowIndex].Cells["Importe"].Value.ToString());
            frm.Insert = true;

            frm.ShowDialog();

            if (!frm.Insert)
                CargarGrid();
        }
    }
}