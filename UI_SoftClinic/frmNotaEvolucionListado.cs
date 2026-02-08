using System;
using System.Collections.Generic;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using UI_SoftClinic.Code;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using PCL_SoftClinic.BusinessRules;

namespace UI_SoftClinic
{
    public partial class frmNotaEvolucionListado : ConfigGeneral
    {
        static List<strNotaEvolucion> lista = new List<strNotaEvolucion>();
        static strNotaEvolucion nota = new strNotaEvolucion();

        public frmNotaEvolucionListado()
        {
            InitializeComponent();
        }

        private void frmNotaEvolucionListado_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            lista = daoNotaEvolucion.GetList();
            if (lista != null)
            {
                gvNotas.DataSource = lista;
                gvNotas.Columns["Paciente"].Visible = false;
                gvNotas.Columns["Usuario"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNotaEvolucion frm = new frmNotaEvolucion();
            frm.ModoEdicion = false;
            frm.ShowDialog();
            CargarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (nota.Id > 0)
            {
                frmNotaEvolucion frm = new frmNotaEvolucion();
                frm.ModoEdicion = true;
                frm.Nota = nota;
                frm.MostrarDatos();
                frm.ShowDialog();
                CargarGrid();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (nota.Id > 0)
            {
                if (MessageBox.Show("¿Está Seguro de Eliminar la Nota " + nota.Id + "?", "Pregunta",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int save = daoNotaEvolucion.Delete(nota.Id);
                    if (save > 0)
                    {
                        MessageBox.Show("Nota eliminada " + nota.Id + "", "Aviso", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string json = JsonConvert.SerializeObject(nota);
                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Delete, json, this.Text, this.Usuario);
                    }
                    else
                    {
                        MessageBox.Show("Error en eliminar la nota " + nota.Id + ", " +
                            "reporte al departamento de sistemas.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna nota", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            var list = (from l in lista
                        where l.Titulo.StartsWith(txtBuscar.Text) ||
                        l.Titulo.Contains(txtBuscar.Text) ||
                        l.Titulo.EndsWith(txtBuscar.Text)
                        select l).ToList();
            if (list.Count > 0)
                gvNotas.DataSource = list;
            else
                gvNotas.DataSource = lista;
        }

        private void gvNotas_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            nota.Id = int.Parse(gvNotas.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            nota.Titulo = gvNotas.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
            nota.Descripcion = gvNotas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            nota.Fecha = DateTime.Parse(gvNotas.Rows[e.RowIndex].Cells["Fecha"].Value.ToString());
            nota.Usuario = gvNotas.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            nota.Paciente = long.Parse(gvNotas.Rows[e.RowIndex].Cells["Paciente"].Value.ToString());
            nota.Estado = int.Parse(gvNotas.Rows[e.RowIndex].Cells["Estado"].Value.ToString());
            MessageBox.Show("Nota " + nota.Titulo + " seleccionada", "Aviso", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPreliminar_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes("NotaEvolucion");
            BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Select, "Select Nota Evolucion", this.Text, this.Usuario);
        }
    }
}