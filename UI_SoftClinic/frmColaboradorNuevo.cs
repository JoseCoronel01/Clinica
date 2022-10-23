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
    public partial class frmColaboradorNuevo : Form
    {
        public bool Insert { get; set; }
        public strColaborador Colaborador { get; set; }

        public frmColaboradorNuevo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarForm())
            {
                switch (this.Insert)
                {
                    case true:
                        strColaborador nuevo = CargarStr();
                        int save = daoColaboradores.Insert(nuevo);
                        if (save > 0)
                        {
                            MessageBox.Show("Colaborador " + nuevo.Nombre + " Agregado Correctamente.", 
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error! Agregando colaborador " + nuevo.Nombre +
                                " reporte al departamento de sistemas.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case false:
                        strColaborador modificado = CargarStr(this.Colaborador);
                        save = daoColaboradores.Update(modificado);
                        if (save > 0)
                        {
                            MessageBox.Show("Colaborador " + modificado.Nombre + " Modificado Correctamente.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error! Modificando colaborador " + modificado.Nombre +
                                " reporte al departamento de sistemas.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacíos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarDatos(strColaborador str)
        {
            if (str == null) return;
            txtNombre.Text = str.Nombre;
        }

        private strColaborador CargarStr(strColaborador str)
        {
            str.Nombre = txtNombre.Text;
            return str;
        }

        private strColaborador CargarStr()
        {
            strColaborador str = new strColaborador();
            str.Id = daoColaboradores.NuevoId();
            str.Nombre = txtNombre.Text;
            return str;
        }

        private bool validarForm()
        {
            if (txtNombre.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmColaboradorNuevo_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
    }
}
