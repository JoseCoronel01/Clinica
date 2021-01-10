using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_SoftClinic.BusinessRules;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using PCL_Comun.Utilidades;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmConsultaPaciente : Form
    {
        strPaciente str = new strPaciente();

        List<strPaciente> lista = null;

        strBrPaciente strBr = new strBrPaciente();

        public frmConsultaPaciente()
        {
            InitializeComponent();
        }

        private void frmConsultaPaciente_Load(object sender, EventArgs e)
        {
            gBoxDatos.BackColor = Color.LightCyan;

            lista = daoPaciente.GetList();

            cbEstatus.DataSource = Util.Estatus();

            cbTipo.DataSource = Base.TiposDeTratamiento();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string texto = txtBuscar.Text;

            cbPaciente.DataSource = strBr.BusquedaPacientes(texto, lista);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cbPaciente.SelectedValue != null && cbPaciente.SelectedValue.ToString() != "-1")
            {
                frmPaciente frm = new frmPaciente();
                frm.ModoEdicion = true;
                frm.Insert = false;
                frm.str = this.str;
                frm.MostrarDatos();
                frm.ShowDialog();
                MostrarDatos(cbPaciente.SelectedValue);
            }
            else
                MessageBox.Show("Seleccionar un paciente para editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos(cbPaciente.SelectedValue);
        }

        private void MostrarDatos(object id)
        {
            long _id = -1;
            long.TryParse(id.ToString(), out _id);
            str = daoPaciente.GetObject(_id);
            if (str == null)
            {
                limpiarForm();
                return;
            }
            txtApePat.Text = str.ApellidoPaterno;
            txtApeMat.Text = str.ApellidoMaterno;
            txtLugarResidencia.Text = str.LugarResidencia;
            txtNombre.Text = str.Nombre;
            txtResponsable.Text = str.Responsable;
            txtTelefono.Text = str.TelContacto;
            cbEstatus.SelectedValue = GetValue(str.Estatus);
            cbTipo.SelectedValue = GetTipo(str.TipoTratamiento);
        }

        private object GetTipo(strPaciente.eTipo tipoTratamiento)
        {
            switch (tipoTratamiento)
            {
                case strPaciente.eTipo.ETAPA_EXPERIMENTAL:
                    {
                        return "1";
                    }
                case strPaciente.eTipo.SEGUIMIENTO_DE_TRATAMIENTO:
                    {
                        return "2";
                    }
                case strPaciente.eTipo.PREVENCION_DE_RECAIDAS:
                    {
                        return "3";
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private object GetValue(strPaciente.eEstatus estatus)
        {
            switch (estatus)
            {
                case strPaciente.eEstatus.ACTIVO:
                    {
                        return "1";
                    }
                case strPaciente.eEstatus.INACTIVO:
                    {
                        return "2";
                    }
                case strPaciente.eEstatus.BAJA:
                    {
                        return "3";
                    }
                default:
                    {
                        return "0";
                    }
            }
        }

        private void limpiarForm()
        {
            txtApeMat.Text = "";
            txtApePat.Text = "";
            txtLugarResidencia.Text = "";
            txtNombre.Text = "";
            txtResponsable.Text = "";
            txtTelefono.Text = "";
        }
    }
}