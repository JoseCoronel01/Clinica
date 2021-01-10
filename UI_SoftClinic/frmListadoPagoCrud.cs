using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmListadoPagoCrud : Form
    {
        strPago str = new strPago();
        public long Tratamiento;
        public DateTime Fecha;
        public string Folio;
        public decimal Importe;

        public bool Insert { get; set; }

        public frmListadoPagoCrud()
        {
            InitializeComponent();
        }

        private void frmListadoPagoCrud_Load(object sender, EventArgs e)
        {
            txtFactNo.Text = Folio;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtFactNo.Text != "" && txtConcepto.Text != "")
            {
                if (this.Insert)
                {
                    str.Uid = Guid.NewGuid().ToString();
                    str.Tratamiento = Tratamiento;
                    str.Fecha = Fecha;
                    str.Folio = txtFactNo.Text;
                    str.Importe = Importe;
                    str.Concepto = txtConcepto.Text;

                    int save = daoPago.Insert(str);

                    if (save > 0)
                    {
                        this.Insert = false;
                        MessageBox.Show("Pago realizado con éxito", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ops! Error.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Faltan campos por llenar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}