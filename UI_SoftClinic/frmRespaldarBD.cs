using System;
using System.Windows.Forms;
using System.Configuration;
using PCL_SoftClinic.BusinessRules;
using System.IO;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmRespaldarBD : ConfigGeneral
    {
        public frmRespaldarBD()
        {
            InitializeComponent();
        }

        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (!Directory.Exists(ConfigurationManager.AppSettings["RutaBD"].ToString()))
                Directory.CreateDirectory(ConfigurationManager.AppSettings["RutaBD"].ToString());

            save.InitialDirectory = ConfigurationManager.AppSettings["RutaBD"].ToString();

            try
            {
                if (File.Exists(save.InitialDirectory + "Respaldos_automáticos"))
                    File.Create(save.InitialDirectory + "Respaldos_automáticos_" + Guid.NewGuid().ToString());
                else
                    File.Create(save.InitialDirectory + "Respaldos_automáticos");
            }
            catch { }
            finally { }

            if (save.ShowDialog() == DialogResult.OK)
            {
                BRRespaldar resp = new BRRespaldar();

                int back = resp.Respaldo(save.FileName);

                if (back > 0)
                {
                    BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.BackUp, "Base de datos respaldada.",
                        this.Text, this.Usuario);

                    MessageBox.Show("Base de datos respaldada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}