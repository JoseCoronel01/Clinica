using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace UI_SoftClinic.Code
{
    public class ConfigGeneral : Form
    {
        public string usuario = "Usuario";

        public string Usuario
        {
            get { return (ConfigurationManager.AppSettings[usuario] != null) ? ConfigurationManager.AppSettings[usuario].ToString() : String.Empty; }
        }

        public string Fondo
        {
            get { return (ConfigurationManager.AppSettings["Fondo"] != null) ? ConfigurationManager.AppSettings["Fondo"].ToString() : String.Empty; }
        }

        public enum TipoLog
        {
            Insert=0,Update=1,Delete=2,Login=3,Select=4,BackUp=5,Modulo=6
        }
    }
}