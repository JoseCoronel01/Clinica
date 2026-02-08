using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using PCL_Comun.Utilidades;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using UI_SoftClinic.Code;
using PCL_SoftClinic.BusinessRules;

namespace UI_SoftClinic
{
    public partial class frmPaciente : ConfigGeneral
    {
        public strPaciente str = new strPaciente();

        public bool ModoEdicion { get; set; }

        public bool Insert { get; set; }

        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            gBoxDatos.BackColor = Color.LightCyan;

            txtApePat.Focus();

            if (!this.ModoEdicion)
            {
                CargarEstatus();
                cbTipo.DataSource = Base.TiposDeTratamiento();
            }
        }

        private void CargarEstatus()
        {
            List<ElementoComboBox> elementos = new List<ElementoComboBox>();

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.ACTIVO, text = "ACTIVO" });

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.INACTIVO, text = "INACTIVO" });

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.BAJA, text = "BAJA" });

            cbEstatus.DataSource = elementos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApePat.Text != "" && txtApeMat.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "" &&
                txtResponsable.Text != "" && txtLugarResidencia.Text != "" && cbTipo.SelectedIndex != -1)
            {
                if (this.Insert)
                {
                    long? id = daoPaciente.NuevoId();

                    str = CargarDatos(str, id);

                    int save = daoPaciente.Insert(str);

                    if (save > 0)
                    {
                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Insert,
                            "Registro guardado",
                            this.Text, this.Usuario);

                        MessageBox.Show("Registro guardado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarForm();

                        if (MessageBox.Show("¿Desea agregar otro registro nuevo?", "Aviso", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                            DialogResult.Yes)
                        {
                            this.Insert = true;
                        }
                        else
                        {
                            this.Insert = false;
                            this.Close();
                        }
                    }
                }
                else if (this.ModoEdicion)
                {
                    str = CargarDatos(str);

                    int save = daoPaciente.Update(str);

                    if (save > 0)
                    {
                        this.ModoEdicion = false;

                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Update,
                            "Registro actualizado",
                            this.Text, this.Usuario);

                        MessageBox.Show("Registro actualizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cbEstatus.SelectedIndex = 0;
            cbTipo.SelectedIndex = -1;

            txtApePat.Focus();
        }

        private strPaciente CargarDatos(strPaciente str, long? id = null)
        {
            if (id != null)
                str.Id = (long)id;
            str.ApellidoMaterno = txtApeMat.Text;
            str.ApellidoPaterno = txtApePat.Text;
            str.Estatus = (strPaciente.eEstatus)cbEstatus.SelectedValue;
            str.LugarResidencia = txtLugarResidencia.Text;
            str.Nombre = txtNombre.Text;
            str.Responsable = txtResponsable.Text;
            str.TelContacto = txtTelefono.Text;
            str.TipoTratamiento = daoPaciente.GetTipo(cbTipo.SelectedValue.ToString());
            return str;
        }

        public void MostrarDatos()
        {
            CargarEstatus();
            cbTipo.DataSource = Base.TiposDeTratamiento();
            txtApeMat.Text = str.ApellidoMaterno;
            txtApePat.Text = str.ApellidoPaterno;
            txtLugarResidencia.Text = str.LugarResidencia;
            txtNombre.Text = str.Nombre;
            txtResponsable.Text = str.Responsable;
            txtTelefono.Text = str.TelContacto;
            cbEstatus.SelectedValue = str.Estatus;
            cbTipo.SelectedValue = daoPaciente.GetTipo(str.TipoTratamiento);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gBoxDatos_Enter(object sender, EventArgs e)
        {
            gBoxDatos.BackColor = Color.LightCyan;
        }

        private void gBoxDatos_Leave(object sender, EventArgs e)
        {
            gBoxDatos.BackColor = Color.Transparent;
        }
    }
}