using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClinicaApp.Model;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;
using ClinicaApp.Code;

namespace ClinicaApp
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                strUsuario str = daoUsuarios.GetIn(txtUsuario.Text, txtPassword.Text);

                if (str == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "GetIn", 
                        "alert('Usuario o Contraseña incorrectos.');", true);
                }
                else
                {
                    Session["Usuario"] = str.Usuario;
                    using (var db = new ClinicaEntities())
                    {
                        db.log.Add(new log()
                        {
                            Uid = Guid.NewGuid().ToString(),
                            Fecha = DateTime.Now,
                            Valor = "Acceso correcto",
                            Accion = (byte)EnumLog.TipoLog.Login,
                            Modulo = this.Page.Title,
                            Usuario = Session["Usuario"].ToString(),
                            IP = Environment.MachineName
                        });
                    }
                    this.Page.Response.Redirect("/Inicio.aspx");
                }
            }
        }
    }
}