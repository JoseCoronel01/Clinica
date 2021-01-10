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

namespace ClinicaApp
{
    public partial class NotasEvolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (!IsPostBack)
            {
                List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                var lista = daoPaciente.GetList();
                foreach (var elem in lista)
                    elementos.Add(new ElementoComboBox() { value = elem.Id, text = elem.ToString() });
                ddlPaciente.DataSource = elementos;
                ddlPaciente.DataBind();

                ddlEstado.DataSource = daoEstado.GetList();
                ddlEstado.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                using (var db = new ClinicaEntities())
                {
                    db.notaevolucion.Add(new notaevolucion()
                    {
                        Id = daoNotaEvolucion.NuevoId(),
                        Titulo = txtTitulo.Text,
                        Descripcion = txtDescripcion.Text,
                        Fecha = DateTime.Parse(txtFecha.Text),
                        Paciente = long.Parse(ddlPaciente.SelectedValue),
                        Estado = int.Parse(ddlEstado.SelectedValue),
                        Usuario = Session["Usuario"].ToString()
                    });
                    db.log.Add(new log()
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Fecha = DateTime.Now,
                        Valor = txtTitulo.Text,
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
            if (txtTitulo.Text != "" && txtDescripcion.Text != "" && txtFecha.Text != "" && 
                ddlPaciente.SelectedIndex > -1 && ddlEstado.SelectedIndex > -1 
                && Session["Usuario"] != null && Session["idne"] == null)
            {
                return true;
            }

            return false;
        }

        protected void btnPrimero_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.notaevolucion.OrderBy(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idne"] != null)
                {
                    long idne = (long)Session["idne"];
                    var str = db.notaevolucion.Where(a => a.Id < idne).OrderByDescending(b => b.Id).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idne"] != null)
                {
                    long idne = (long)Session["idne"];
                    var str = db.notaevolucion.Where(a => a.Id > idne).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.notaevolucion.OrderByDescending(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        private void MostrarStr(notaevolucion str)
        {
            if (str == null)
            {
                Nuevo();
            }
            else
            {
                Session["idne"] = str.Id;
                txtTitulo.Text = str.Titulo;
                txtDescripcion.Text = str.Descripcion;
                txtFecha.TextMode = TextBoxMode.SingleLine;
                txtFecha.Text = str.Fecha.ToString("yyyy/MM/dd");
                ListItem item = ddlPaciente.Items.FindByValue(str.Paciente.ToString());
                ddlPaciente.SelectedValue = item.Value;
                ddlEstado.SelectedValue = str.Estado.ToString();
            }
        }

        private void Nuevo()
        {
            Session.Remove("idne");
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFecha.TextMode = TextBoxMode.Date;
            txtFecha.Text = "";
            ddlPaciente.SelectedIndex = -1;
            ddlEstado.SelectedIndex = -1;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}