using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PCL_Comun.Utilidades;
using PCL_SoftClinic.dao;

namespace ClinicaApp
{
    public partial class RNotas : System.Web.UI.Page
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
                ddlPacientes.DataSource = elementos;
                ddlPacientes.DataBind();
            }
        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/RNotasGenerar.aspx?id=" + ddlPacientes.SelectedValue);
        }
    }
}