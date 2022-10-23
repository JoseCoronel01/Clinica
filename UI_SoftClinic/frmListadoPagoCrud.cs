using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using PCL_SoftClinic.BusinessRules;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmListadoPagoCrud : ConfigGeneral
    {
        strPago str = new strPago();
        public long Tratamiento;
        //public DateTime Fecha;
        //public string Folio;
        //public decimal Importe;

        public bool Insert { get; set; }

        public frmListadoPagoCrud()
        {
            InitializeComponent();
        }

        private void frmListadoPagoCrud_Load(object sender, EventArgs e)
        {
            //txtFactNo.Text = Folio;
            txtFactNo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtFactNo.Text != "" && txtConcepto.Text != "" && dtpFecha.Text != "" && txtImporte.Text != "")
            {
                if (this.Insert)
                {
                    str.Tratamiento = Tratamiento;
                    str.Fecha = dtpFecha.Value;
                    str.Folio = txtFactNo.Text;
                    str.Importe = (decimal.Parse(txtImporte.Text));
                    str.Concepto = txtConcepto.Text;

                    int save = daoPago.Insert(str);

                    if (save > 0)
                    {
                        this.Insert = false;

                        BRLog log = new BRLog(DateTime.Now, (byte)ConfigGeneral.TipoLog.Insert,
                            "Pago realizado con éxito",
                            this.Text, this.Usuario);

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