using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_SoftClinic.BusinessRules;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmListadoTratamiento : ConfigGeneral
    {
        strBrPaciente strBr = new strBrPaciente();

        List<strPaciente> lista = new List<strPaciente>();

        long idTratamiento = -1;

        public frmListadoTratamiento()
        {
            InitializeComponent();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string texto = txtBuscar.Text;

            cbPaciente.DataSource = strBr.BusquedaPacientes(texto, lista);
        }

        private void cbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            long _id = -1;
            long.TryParse(cbPaciente.SelectedValue.ToString(), out _id);
            List<strTratamiento> lista = daoTratamiento.GetList(_id);
            gvTratamiento.DataSource = lista;
            if (_id == -1) return;
            if (lista != null)
            {
                gvTratamiento.Columns["Id"].Visible = false;
                gvTratamiento.Columns["Paciente"].Visible = false;
            }
        }

        private void frmListadoTratamiento_Load(object sender, EventArgs e)
        {
            lista = daoPaciente.GetList();

            txtBuscar.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbPaciente.SelectedValue != null && cbPaciente.SelectedValue.ToString() != "-1")
            {
                frmListadoAltaTratamiento frm = new frmListadoAltaTratamiento();
                long id = long.Parse(cbPaciente.SelectedValue.ToString());
                frm.strp = new strPaciente() { Id = id };
                frm.ShowDialog();

                if (frm.guardo)
                    CargarGrid();
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            frmListadoPagos frm = new frmListadoPagos();
            frm.IdTratamiento = idTratamiento;
            frm.IdPaciente = long.Parse(cbPaciente.SelectedValue.ToString());
            frm.ShowDialog();
            idTratamiento = -1;
        }

        private void gvTratamiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTratamiento = long.Parse(gvTratamiento.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            MessageBox.Show("Tratamiento seleccionado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idTratamiento == -1)
            {
                MessageBox.Show("Seleccione un Tratamiento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Está Seguro(a) de eliminar el tratamiento?", this.Text, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                daoTratamiento dao = new daoTratamiento();
                var str = daoTratamiento.GetObject(idTratamiento, long.Parse(cbPaciente.SelectedValue.ToString()));
                if (dao.Eliminar(idTratamiento))
                {
                    BRLog log = 
                        new BRLog(DateTime.Now, (byte)TipoLog.Delete, 
                        str.Paciente.Value.ToString(), this.Text, this.Usuario);

                    MessageBox.Show("Tratamiento Eliminado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                else
                {
                    MessageBox.Show("Error", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}