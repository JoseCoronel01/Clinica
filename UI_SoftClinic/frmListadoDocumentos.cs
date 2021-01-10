using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using System.IO;

namespace UI_SoftClinic
{
    public partial class frmListadoDocumentos : Form
    {
        List<strDocumento> lista = null;
        strDocumento str = null;

        public frmListadoDocumentos()
        {
            InitializeComponent();
        }

        private void frmListadoDocumentos_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            lista = daoDocumentos.GetList();
            if (lista != null)
            {
                gvDocumentos.DataSource = lista;
                gvDocumentos.Columns["Tipo"].Visible = false;
                gvDocumentos.Columns["Archivo"].Visible = false;
            }
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (lista != null)
            {
                string texto = txtFiltro.Text;
                List<strDocumento> list = new List<strDocumento>();
                list = (from l in lista
                        where l.Clave.StartsWith(texto) ||
                            l.Clave.Contains(texto) ||
                            l.Clave.EndsWith(texto) ||
                            l.Nombre.StartsWith(texto) ||
                            l.Nombre.Contains(texto) ||
                            l.Nombre.EndsWith(texto) ||
                            l.Descripcion.StartsWith(texto) ||
                            l.Descripcion.Contains(texto) ||
                            l.Descripcion.EndsWith(texto) ||
                            l.DescripcionBreve.StartsWith(texto) ||
                            l.DescripcionBreve.Contains(texto) ||
                            l.DescripcionBreve.EndsWith(texto) ||
                            l.Etiqueta.StartsWith(texto) ||
                            l.Etiqueta.Contains(texto) ||
                            l.Etiqueta.EndsWith(texto)
                        select l).ToList();
                gvDocumentos.DataSource = list;
                gvDocumentos.Columns["Archivo"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCrudDocumentos frm = new frmCrudDocumentos();
            frm.ModoEdicion = false;
            frm.ShowDialog();
            CargarGrid();
        }

        private void gvDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            str = new strDocumento();
            str.Clave = gvDocumentos.Rows[e.RowIndex].Cells["Clave"].Value.ToString();
            str.Nombre = gvDocumentos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            str.Descripcion = gvDocumentos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            str.DescripcionBreve = gvDocumentos.Rows[e.RowIndex].Cells["DescripcionBreve"].Value.ToString();
            str.Etiqueta = gvDocumentos.Rows[e.RowIndex].Cells["Etiqueta"].Value.ToString();
            if (gvDocumentos.Rows[e.RowIndex].Cells["Tipo"].Value != null)
            {
                str.Tipo = int.Parse(gvDocumentos.Rows[e.RowIndex].Cells["Tipo"].Value.ToString());
                lbTipoDoc.Text = daoTipoDocumentos.GetObject(str.Tipo).Nombre;
            }
            if (gvDocumentos.Rows[e.RowIndex].Cells["Archivo"].Value != null)
                str.Archivo = (byte[])gvDocumentos.Rows[e.RowIndex].Cells["Archivo"].Value;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCrudDocumentos frm = new frmCrudDocumentos();
            frm.ModoEdicion = true;
            frm.MostrarDatos(str);
            frm.ShowDialog();
            CargarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (str != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este documento? " + str.Nombre + "", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int save = daoDocumentos.Delete(str.Clave);
                    if (save > 0)
                    {
                        MessageBox.Show("Documento con la clave " + str.Clave + " ha sido eliminado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Documento para Eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (str != null && str.Archivo != null)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string fileName = Guid.NewGuid().ToString();
                string ext = ".docx";
                string full = path + fileName + ext;
                using (FileStream fs = File.Create(full))
                {
                    fs.Write(str.Archivo, 0, str.Archivo.Length);
                    Process.Start(full);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Documento para Abrirlo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}