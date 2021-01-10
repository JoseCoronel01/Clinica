using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClinicaApp.Model;
using ClinicaApp.Code;

namespace ClinicaApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                db.log.Add(new log()
                {
                    Uid = Guid.NewGuid().ToString(),
                    Fecha = DateTime.Now,
                    Modulo = "LogOut",
                    Usuario = Session["Usuario"].ToString(),
                    Accion = (byte)EnumLog.TipoLog.Login,
                    Valor = "Terminada la sesión",
                    IP = Environment.MachineName
                });
            }
            Session.Remove("Usuario");
            this.Page.Response.Redirect("/LogIn.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/Inicio.aspx");
        }

        protected void btnPaciente_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/Paciente.aspx");
        }

        protected void btnTratamiento_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/Tratamiento.aspx");
        }

        protected void btnPago_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/Pago.aspx");
        }

        protected void btnNotasEvolucion_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("/NotasEvolucion.aspx");
        }
    }
}