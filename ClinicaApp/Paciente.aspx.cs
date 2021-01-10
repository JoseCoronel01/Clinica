using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClinicaApp.Model;
using ClinicaApp.Code;
using PCL_SoftClinic.dao;
using PCL_Comun.Utilidades;
using PCL_SoftClinic.str;

namespace ClinicaApp
{
    public partial class Paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (!IsPostBack)
            {
                CargarEstatus();
                ddlTipo.DataSource = Base.TiposDeTratamiento();
                ddlTipo.DataBind();
            }
        }

        private void CargarEstatus()
        {
            List<ElementoComboBox> elementos = new List<ElementoComboBox>();

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.ACTIVO, text = "ACTIVO" });

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.INACTIVO, text = "INACTIVO" });

            elementos.Add(new ElementoComboBox() { value = strPaciente.eEstatus.BAJA, text = "BAJA" });

            ddlEstatus.DataSource = elementos;
            ddlEstatus.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                using (var db = new ClinicaEntities())
                {
                    long id = daoPaciente.NuevoId();
                    db.paciente.Add(new paciente()
                    {
                        Id = id,
                        ApellidoPaterno = txtApePat.Text,
                        ApellidoMaterno = txtApeMat.Text,
                        Nombre = txtNombre.Text,
                        TelContacto = txtTelContacto.Text,
                        Responsable = txtResponsable.Text,
                        LugarResidencia = txtLugarResi.Text,
                        Estatus = ddlEstatus.SelectedValue,
                        Tipo = byte.Parse(ddlTipo.SelectedValue)
                    });
                    db.log.Add(new log()
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Fecha = DateTime.Now,
                        Valor = string.Format("{0}-{1}-{2}", txtApePat.Text,
                            txtApeMat.Text, txtNombre.Text),
                        Accion = (byte)EnumLog.TipoLog.Insert,
                        Modulo = this.Page.Title,
                        Usuario = Session["Usuario"].ToString(),
                        IP = Environment.MachineName
                    });
                    db.SaveChanges();
                }
            }
        }

        private bool ValidaFormulario()
        {
            if (txtApePat.Text != "" && txtApeMat.Text != "" && txtNombre.Text != "" &&
                txtLugarResi.Text != "" && txtResponsable.Text != "" && txtTelContacto.Text != ""
                && Session["Usuario"] != null && Session["idpaciente"] == null)
            {
                return true;
            }

            return false;
        }

        protected void btnPrimero_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.paciente.OrderBy(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idpaciente"] != null)
                {
                    long idne = (long)Session["idpaciente"];
                    var str = db.paciente.Where(a => a.Id < idne).OrderByDescending(b => b.Id).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idpaciente"] != null)
                {
                    long idne = (long)Session["idpaciente"];
                    var str = db.paciente.Where(a => a.Id > idne).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.paciente.OrderByDescending(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        private void MostrarStr(paciente str)
        {
            if (str == null)
            {
                Nuevo();
            }
            else
            {
                Session["idpaciente"] = str.Id;
                txtApePat.Text = str.ApellidoPaterno;
                txtApeMat.Text = str.ApellidoMaterno;
                txtNombre.Text = str.Nombre;
                txtLugarResi.Text = str.LugarResidencia;
                txtTelContacto.Text = str.TelContacto;
                txtResponsable.Text = str.Responsable;
                ListItem item = ddlEstatus.Items.FindByValue(MostrarEstatus(str.Estatus));
                ddlEstatus.SelectedValue = item.Value;
                ListItem item2 = ddlTipo.Items.FindByValue(str.Tipo.ToString());
                ddlTipo.SelectedValue = item2.Value;
            }
        }

        private string MostrarEstatus(string estatus)
        {
            switch (estatus)
            {
                case "1":
                    {
                        return strPaciente.eEstatus.ACTIVO.ToString();
                    }
                case "2":
                    {
                        return strPaciente.eEstatus.INACTIVO.ToString();
                    }
                case "3":
                    {
                        return strPaciente.eEstatus.BAJA.ToString();
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        private void Nuevo()
        {
            Session.Remove("idpaciente");
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtNombre.Text = "";
            txtLugarResi.Text = "";
            txtTelContacto.Text = "";
            txtResponsable.Text = "";
            ddlEstatus.SelectedIndex = -1;
            ddlTipo.SelectedIndex = -1;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}