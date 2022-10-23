using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_SoftClinic
{
    public partial class frmColaboradores : Form
    {
        public List<strColaborador> colaboradores = null;
        private bool mostrarFechaP = false;

        public bool Insert { get; set; }
        public strColaboradorDetalle ColaboradorDetalle { get; set; }

        public frmColaboradores()
        {
            InitializeComponent();

            colaboradores = daoColaboradores.GetList();
            cbColaborador.DataSource = colaboradores;
        }

        private void btnNuevoColaborador_Click(object sender, EventArgs e)
        {
            frmColaboradorNuevoListado frm = new frmColaboradorNuevoListado();
            frm.ShowDialog();

            colaboradores = daoColaboradores.GetList();
            cbColaborador.DataSource = colaboradores;
        }

        private void frmColaboradores_Load(object sender, EventArgs e)
        {
            if (!mostrarFechaP)
                dtpFechaDePago.Visible = false;
            else
                dtpFechaDePago.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarForm())
            {
                switch (this.Insert)
                {
                    case true:
                        strColaboradorDetalle nuevo = CargaStr();
                        int save = daoColaboradoresDetalle.Insert(nuevo);
                        if (save > 0)
                        {
                            MessageBox.Show("Registro Agregado Correctamente.", "Aviso", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error Agregando Registro. Reporte al departamento de sistemas.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case false:
                        strColaboradorDetalle modificado = CargaStr(this.ColaboradorDetalle);
                        save = daoColaboradoresDetalle.Update(modificado);
                        if (save > 0)
                        {
                            MessageBox.Show("Registro Actualizado Correctamente.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error Modificando Registro. Reporte al departamento de sistemas.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios. Favor de llenar todos los campos.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public  void MostrarDatos(strColaboradorDetalle detalle)
        {
            cbColaborador.SelectedValue = long.Parse(detalle.ColaboradorId.ToString());
            dtpFechaEmision.Value = detalle.FechaEmision;
            txtImporte.Text = detalle.Importe.ToString();
            chBoxPagado.Checked = detalle.Pagado;
            mostrarFechaP = chBoxPagado.Checked;
            if (chBoxPagado.Checked)
            {
                dtpFechaDePago.Value = detalle.FechaPago.Value;
            }
            txtConcepto.Text = detalle.Concepto;
        }

        private bool validarForm()
        {
            if (cbColaborador.SelectedValue != null && dtpFechaEmision.Text != "" && txtImporte.Text != "" && txtConcepto.Text != "")
            {
                if (chBoxPagado.Checked)
                {
                    if (dtpFechaDePago.Text != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return true;
            }
            else
                return false;
        }

        private strColaboradorDetalle CargaStr()
        {
            strColaboradorDetalle detalle = new strColaboradorDetalle();
            detalle.Id = daoColaboradoresDetalle.NuevoId();
            detalle.ColaboradorId = long.Parse(cbColaborador.SelectedValue.ToString());
            detalle.FechaEmision = DateTime.Parse(dtpFechaEmision.Value.ToString());
            detalle.Importe = decimal.Parse(txtImporte.Text);
            detalle.Pagado = chBoxPagado.Checked;
            if (detalle.Pagado)
            {
                detalle.FechaPago = DateTime.Parse(dtpFechaDePago.Value.ToString());
            }
            detalle.Concepto = txtConcepto.Text;
            return detalle;
        }

        private strColaboradorDetalle CargaStr(strColaboradorDetalle detalle)
        {
            detalle.ColaboradorId = long.Parse(cbColaborador.SelectedValue.ToString());
            detalle.FechaEmision = DateTime.Parse(dtpFechaEmision.Value.ToString());
            detalle.Importe = decimal.Parse(txtImporte.Text);
            detalle.Pagado = chBoxPagado.Checked;
            if (detalle.Pagado)
            {
                detalle.FechaPago = DateTime.Parse(dtpFechaDePago.Value.ToString());
            }
            detalle.Concepto = txtConcepto.Text;
            return detalle;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chBoxPagado_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxPagado.Checked)
            {
                dtpFechaDePago.Visible = true;
            }
            else
            {
                dtpFechaDePago.Visible = false;
            }
        }
    }
}
