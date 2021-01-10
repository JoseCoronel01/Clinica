using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace UI_SoftClinic
{
    public partial class frmCrudDocumentos : Form
    {
        public bool ModoEdicion { get; set; }
        byte[] Archivo = null;
        static string MensajeArchivo = "Archivo Cargado...";

        public frmCrudDocumentos()
        {
            InitializeComponent();
        }

        private void frmCrudDocumentos_Load(object sender, EventArgs e)
        {
            cbTipo.DataSource = daoTipoDocumentos.GetList();
        }

        private void btnCrudTipo_Click(object sender, EventArgs e)
        {
            frmListadoTipoDocs frm = new frmListadoTipoDocs();
            frm.ShowDialog();
            cbTipo.DataSource = daoTipoDocumentos.GetList();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFile = new OpenFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                this.Archivo = System.IO.File.ReadAllBytes(saveFile.FileName);
                lbMensajeArchivo.Text = MensajeArchivo;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                if (!ModoEdicion)
                {
                    strDocumento str = new strDocumento();
                    str = CargaObjeto(str);
                    int save = daoDocumentos.Insert(str);
                    if (save > 0)
                    {
                        MessageBox.Show("Documento Registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiaForm();
                    }
                }
                else
                {
                    strDocumento str = new strDocumento();
                    str = CargaObjeto(str);
                    int save = daoDocumentos.Update(str);
                    if (save > 0)
                    {
                        MessageBox.Show("Documento Modificado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtClave.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtDescBreve.Text = "";
            txtEtiqueta.Text = "";
            cbTipo.SelectedIndex = -1;
            lbMensajeArchivo.Text = "";
            this.Archivo = null;
        }

        private strDocumento CargaObjeto(strDocumento str)
        {
            str.Clave = txtClave.Text;
            str.Nombre = txtNombre.Text;
            str.Descripcion = txtDescripcion.Text;
            str.DescripcionBreve = txtDescBreve.Text;
            str.Etiqueta = txtEtiqueta.Text;
            str.Tipo = int.Parse(cbTipo.SelectedValue.ToString());
            str.Archivo = Archivo;
            return str;
        }

        private bool ValidaForm()
        {
            if (txtClave.Text != "" && txtDescripcion.Text != "" && txtDescBreve.Text != "" && txtNombre.Text != "" &&
                txtEtiqueta.Text != "" && cbTipo.SelectedValue != null && this.Archivo != null)
            {
                if (ModoEdicion)
                {
                    strDocumento str_ = daoDocumentos.GetObject(txtClave.Text);
                    if (str_ == null)
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MostrarDatos(strDocumento str)
        {
            if (str != null)
            {
                txtClave.Text = str.Clave;
                txtNombre.Text = str.Nombre;
                txtDescripcion.Text = str.Descripcion;
                txtDescBreve.Text = str.DescripcionBreve;
                txtEtiqueta.Text = str.Etiqueta;
                cbTipo.SelectedValue = str.Tipo;
                this.Archivo = str.Archivo;
                if (this.Archivo != null)
                    lbMensajeArchivo.Text = MensajeArchivo;
                else
                    lbMensajeArchivo.Text = "";
            }
            else
            {
                txtClave.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtDescBreve.Text = "";
                txtEtiqueta.Text = "";

                lbMensajeArchivo.Text = "";
                this.Archivo = null;
            }
        }
    }
}