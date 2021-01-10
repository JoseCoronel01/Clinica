using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmCrudTipoDocs : Form
    {
        public bool ModoEdicion { get; set; }

        public frmCrudTipoDocs()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                if (!ModoEdicion)
                {
                    strTipoDocumento str = new strTipoDocumento();
                    str = CargaObjeto(str);
                    int save = daoTipoDocumentos.Insert(str);
                    if (save > 0)
                    {
                        MessageBox.Show("Tipo Documento Registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiaForm();
                    }
                }
                else
                {
                    strTipoDocumento str = new strTipoDocumento();
                    str = CargaObjeto(str);
                    int save = daoTipoDocumentos.Update(str);
                    if (save > 0)
                    {
                        MessageBox.Show("Tipo Documento Modificado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiaForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Datos Incompletos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiaForm()
        {
            txtId.Text = "";
            txtNombre.Text = "";
        }

        private strTipoDocumento CargaObjeto(strTipoDocumento str)
        {
            str.Id = int.Parse(txtId.Text);
            str.Nombre = txtNombre.Text;
            return str;
        }

        private bool ValidaForm()
        {
            if (txtId.Text != "" && txtNombre.Text != "")
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

        public void MostrarDatos(strTipoDocumento str)
        {
            if (str != null)
            {
                txtId.Text = int.Parse(str.Id.ToString()).ToString();
                txtNombre.Text = str.Nombre;
            }
            else
            {
                txtId.Text = "";
                txtNombre.Text = "";
            }
        }

        private void frmCrudTipoDocs_Load(object sender, EventArgs e)
        {
            if (!ModoEdicion)
                txtId.Text = daoTipoDocumentos.CreateId().ToString();

            txtNombre.Focus();
        }
    }
}