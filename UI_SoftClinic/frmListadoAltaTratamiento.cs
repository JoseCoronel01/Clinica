using System;
using System.Drawing;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using PCL_SoftClinic.BusinessRules;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmListadoAltaTratamiento : ConfigGeneral
    {
        strTratamiento str = new strTratamiento();
        public strPaciente strp = new strPaciente();
        public bool guardo = false;

        public frmListadoAltaTratamiento()
        {
            InitializeComponent();
        }

        private void frmListadoAltaTratamiento_Load(object sender, EventArgs e)
        {
            gboxTratamiento.BackColor = Color.LightCyan;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtpSalida.Value > dtpIngreso.Value)
            {
                if (txtCostoIngreso.Text != "") //&& txtPlanMen.Text != "")
                {
                    str = CargarDatos(str);

                    int save = daoTratamiento.Insert(str);

                    if (save > 0)
                    {
                        guardo = true;

                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Insert,
                            "Registro guardado",
                            this.Text, this.Usuario);

                        MessageBox.Show("Registro guardado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Ops! Error", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Faltan datos por llenar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Rango de fechas incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private strTratamiento CargarDatos(strTratamiento str)
        {
            str.Id = daoTratamiento.NuevoId();
            str.Paciente = strp.Id;
            str.FechaIngreso = dtpIngreso.Value;
            str.FechaSalida = dtpSalida.Value;
            str.CostoIngreso = decimal.Parse(txtCostoIngreso.Text);
            //str.PlanMensual = decimal.Parse(txtPlanMen.Text);
            return str;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}