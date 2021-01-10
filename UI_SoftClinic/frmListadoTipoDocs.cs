using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmListadoTipoDocs : Form
    {
        List<strTipoDocumento> lista = null;
        strTipoDocumento str = null;

        public frmListadoTipoDocs()
        {
            InitializeComponent();
        }

        private void CargarGrid()
        {
            lista = daoTipoDocumentos.GetList();
            if (lista != null)
                gvDocumentos.DataSource = lista;
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (lista != null)
            {
                string texto = txtFiltro.Text;
                List<strTipoDocumento> list = new List<strTipoDocumento>();
                list = (from l in lista
                        where 
                            l.Nombre.StartsWith(texto) ||
                            l.Nombre.Contains(texto) ||
                            l.Nombre.EndsWith(texto)
                        select l).ToList();
                gvDocumentos.DataSource = list;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCrudTipoDocs frm = new frmCrudTipoDocs();
            frm.ModoEdicion = false;
            frm.ShowDialog();
            CargarGrid();
        }

        private void gvDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            str = new strTipoDocumento();
            str.Id = int.Parse(gvDocumentos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            str.Nombre = gvDocumentos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmCrudTipoDocs frm = new frmCrudTipoDocs();
            frm.ModoEdicion = true;
            frm.MostrarDatos(str);
            frm.ShowDialog();
            CargarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (str != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este tipo de documento? " + str.Nombre + "", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!daoDocumentos.ExisteTipo(str.Id))
                    {
                        int save = daoTipoDocumentos.Delete(str.Id);
                        if (save > 0)
                        {
                            MessageBox.Show("Tipo de Documento " + str.Nombre + " ha sido eliminado.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Tipo de Documento "+str.Nombre+" que ha intentado eliminar esta siendo utilizado, por lo tanto no se puede eliminar.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Tipo de Documento para Eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmListadoTipoDocs_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}