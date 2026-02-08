using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using PCL_Comun.Utilidades;
using UI_SoftClinic.Code;
using PCL_SoftClinic.BusinessRules;
using Newtonsoft.Json;

namespace UI_SoftClinic
{
    public partial class frmNotaEvolucion : ConfigGeneral
    {
        public bool ModoEdicion { get; set; }
        public strNotaEvolucion Nota { get; set; }

        public frmNotaEvolucion()
        {
            InitializeComponent();

            List<ElementoComboBox> elementos = new List<ElementoComboBox>();
            var pacientes = daoPaciente.GetList();
            if (pacientes != null)
            {
                foreach (var item in pacientes)
                    elementos.Add(new ElementoComboBox() { value = item.Id, text = item.ToString() });
                cbPaciente.DataSource = elementos;
            }

            cbEstado.DataSource = daoEstado.GetList();
        }

        private void gbNotas_Enter(object sender, EventArgs e)
        {
            gbNotas.BackColor = Color.LightCyan;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarForma())
            {
                switch (this.ModoEdicion)
                {
                    case false:
                        {
                            strNotaEvolucion str = new strNotaEvolucion();
                            str.Id = daoNotaEvolucion.NuevoId();
                            str.Titulo = txtTitulo.Text;
                            str.Descripcion = txtDescripcion.Text;
                            str.Fecha = dtpFecha.Value;
                            str.Paciente = long.Parse(cbPaciente.SelectedValue.ToString());
                            str.Usuario = this.Usuario;
                            str.Estado = int.Parse(cbEstado.SelectedValue.ToString());
                            int save = daoNotaEvolucion.Insert(str);
                            if (save > 0)
                            {
                                MessageBox.Show("¡Nota registrada con éxito!", "Aviso", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string json = JsonConvert.SerializeObject(str);
                                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Insert, json, this.Text, this.Usuario);

                                txtTitulo.Text = "";
                                txtDescripcion.Text = "";
                                txtTitulo.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Error en registrar la nota, " +
                                    "reporte al departamento de sistemas.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    case true:
                        {
                            int save = daoNotaEvolucion.Update(Nota);
                            if (save > 0)
                            {
                                MessageBox.Show("¡Nota actualizada con éxito!", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string json = JsonConvert.SerializeObject(Nota);
                                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Update, json, this.Text, this.Usuario);

                                txtTitulo.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Error en actualizar la nota, " +
                                    "reporte al departamento de sistemas.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                }
                this.Close();
            }
            else
                MessageBox.Show("Favor de llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidarForma()
        {
            if (txtTitulo.Text != "" && txtDescripcion.Text != "" && cbPaciente.SelectedIndex > -1)
            {
                return true;
            }
            else
                return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MostrarDatos()
        {
            txtTitulo.Text = Nota.Titulo;
            txtDescripcion.Text = Nota.Descripcion;
            dtpFecha.Value = Nota.Fecha;
            cbPaciente.SelectedValue = Nota.Paciente;
            cbEstado.SelectedValue = Nota.Estado;
        }
    }
}