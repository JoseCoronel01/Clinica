using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_Comun.Utilidades;
using System.Configuration;
using PCL_SoftClinic.Reportes;
using PCL_SoftClinic.BusinessRules;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using System.IO;
using CrystalDecisions.Shared;

namespace UI_SoftClinic
{
    public partial class frmReportesPagos : Form
    {
        strBrPaciente strBr = new strBrPaciente();

        List<strPaciente> lista = null;

        public frmReportesPagos()
        {
            InitializeComponent();
        }

        private void frmReportesPagos_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();

            lista = daoPaciente.GetList();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string texto = txtBuscar.Text;

            cbPaciente.DataSource = strBr.BusquedaPacientes(texto, lista);
        }

        private void btnPreliminar_Click(object sender, EventArgs e)
        {
            long id = long.Parse(cbPaciente.SelectedValue.ToString());
            frmReportes frm = new frmReportes("Pagos", id);
            frm.Show();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            long id = long.Parse(cbPaciente.SelectedValue.ToString());
            frmReportes frm = new frmReportes("Pagos", id);
            crPagos rep = new crPagos();
            frm.ListarPagos(id, "Pagos", out rep);
            Stream stream = rep.ExportToStream(ExportFormatType.PortableDocFormat);
            string emisor = ConfigurationManager.AppSettings["Emisor"].ToString();
            string receptor = ConfigurationManager.AppSettings["Receptor"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string pwd = Util.DesEncripta(ConfigurationManager.AppSettings["pwd"].ToString());
            Util.SendEMail(emisor, receptor, user,
                pwd, "Pagos", false, "Reporte de Pagos", stream);
            MessageBox.Show("Email enviado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}