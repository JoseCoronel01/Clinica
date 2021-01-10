using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCL_Comun.Utilidades;

namespace UI_SoftClinic
{
    public partial class frmRegistroEmpresa : Form
    {
        public frmRegistroEmpresa()
        {
            InitializeComponent();
        }

        private void btnAImagen_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                Util.GuardaVariableSistema("Fondo", save.FileName);
                this.Close();
            }
        }
    }
}