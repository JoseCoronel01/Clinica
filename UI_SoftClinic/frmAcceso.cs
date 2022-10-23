using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using PCL_SoftClinic.BusinessRules;
using UI_SoftClinic.Code;

namespace UI_SoftClinic
{
    public partial class frmAcceso : ConfigGeneral
    {
        public bool Entrar { get; set; }
        public strUsuario strUsuario { get; set; }

        int contador;

        static int intentos = 5;

        public frmAcceso()
        {
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {
            contador = 1;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                strUsuario str = daoUsuarios.GetIn(txtUsuario.Text, txtPassword.Text);

                if (str == null)
                {
                    if (contador != intentos)
                    {
                        MessageBox.Show("Intentos de entrar: " + contador + ", usuario o contraseña incorrectos. ",
                            "Alerta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtUsuario.Text = "";
                        txtPassword.Text = "";
                        txtUsuario.Focus();

                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Login, 
                            "Intentos de entrar: " + contador + ", usuario o contraseña incorrectos.", 
                            this.Text, "Sin Acceso");

                        contador++;
                    }
                    else
                    {
                        MessageBox.Show("Intentos de entrar: " + contador + " veces no recuerda la contraseña, " +
                            "por seguridad el sistema se cerrará " +
                            "favor de reportar al departamento de sistemas.",
                            "Alerta",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Login,
                            "Intentos de entrar: " + contador + ", usuario o contraseña incorrectos.",
                            this.Text, "Sin Acceso");

                        this.Entrar = false;
                        this.Close();
                    }
                }
                else
                {
                    contador = 1;

                    this.Entrar = true;

                    this.strUsuario = daoUsuarios.GetObject(str.Usuario);

                    this.GuardaVariableConfiguracion(this.usuario, this.strUsuario.Usuario);

                    this.Close();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}