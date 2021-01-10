using System;
using System.Windows.Forms;
using PCL_SoftClinic.str;
using PCL_Comun.Utilidades;
using UI_SoftClinic.Code;
using PCL_SoftClinic.BusinessRules;

namespace UI_SoftClinic
{
    public partial class Form1 : ConfigGeneral
    {
        strUsuario strUsuario = new strUsuario();

        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Nuevo Paciente",
                    this.Text, this.Usuario);

                frmPaciente frm = new frmPaciente();
                frm.ModoEdicion = false;
                frm.Insert = true;
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Consultar Paciente",
                    this.Text, this.Usuario);

                frmConsultaPaciente frm = new frmConsultaPaciente();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Pagos",
                    this.Text, this.Usuario);

                frmListadoTratamiento frm = new frmListadoTratamiento();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void usuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Gestion Usuarios",
                    this.Text, this.Usuario);

                frmListadoUsuariosSistema frm = new frmListadoUsuariosSistema();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmAcceso frm = new frmAcceso();
            frm.ShowDialog();
            if (!frm.Entrar)
            {
                this.Close();
            }
            else
            {
                this.strUsuario = frm.strUsuario;

                Util.GuardaVariableSistema(this.usuario, this.strUsuario.Usuario);

                leerFondo();

                mnuUsuario.Text = "HOLA " + this.strUsuario.Usuario.ToUpper() + " - MODO " + this.strUsuario.Tipo.ToString();

                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Login,
                    "Acceso satisfactorio",
                    this.Text, this.Usuario);
            }
        }

        private void listadoDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Reportes Paciente",
                    this.Text, this.Usuario);

                frmReportes frm = new frmReportes("Paciente");
                frm.Show();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Reportes Pagos",
                    this.Text, this.Usuario);

                frmReportesPagos frm = new frmReportesPagos();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Documentos",
                    this.Text, this.Usuario);

                frmListadoDocumentos frm = new frmListadoDocumentos();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void respaldarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "RespaldarBD",
                    this.Text, this.Usuario);

                frmRespaldarBD frm = new frmRespaldarBD();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void notasDeEvoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strUsuario.eTipo.SUPERVISOR == strUsuario.Tipo || strUsuario.eTipo.OPERADOR == strUsuario.Tipo)
            {
                BRLog log = new BRLog(DateTime.Now, (byte)TipoLog.Modulo, "Nota Evolucion",
                    this.Text, this.Usuario);

                frmNotaEvolucionListado frm = new frmNotaEvolucionListado();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Acceso no permitido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void agregarFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroEmpresa frm = new frmRegistroEmpresa();
            frm.ShowDialog();
            leerFondo();
        }

        private void leerFondo()
        {
            if (String.IsNullOrEmpty(this.Fondo) == false)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(this.Fondo);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Refresh();
                pictureBox1.Image = System.Drawing.Image.FromFile(this.Fondo);
            }
        }
    }
}