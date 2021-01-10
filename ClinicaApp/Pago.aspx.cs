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
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (!IsPostBack)
            {
                List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                var lista = daoTratamiento.GetList();
                foreach (var elem in lista)
                    elementos.Add(new ElementoComboBox() { value = elem.Id, 
                        text = NombrePaciente(elem.Paciente) + ": " + 
                        elem.FechaIngreso.Value.ToString("dd/MM/yyyy") + "--" + 
                        elem.FechaSalida.Value.ToString("dd/MM/yyyy") });
                ddlTratamiento.DataSource = elementos;
                ddlTratamiento.DataBind();
            }
        }

        private string NombrePaciente(long? paciente)
        {
            using (var db = new ClinicaEntities())
            {
                var pac = db.paciente.Where(a => a.Id == paciente).First();
                return pac.ApellidoPaterno + " " + pac.ApellidoMaterno + " " + pac.Nombre;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                using (var db = new ClinicaEntities())
                {
                    long id = daoPago.NuevoId();
                    db.pago.Add(new pago()
                    {
                        Uid = id,
                        Fecha = DateTime.Parse(txtFecha.Text),
                        Folio = txtFolio.Text,
                        Importe = decimal.Parse(txtImporte.Text),
                        Concepto = txtConcepto.Text,
                        Tratamiento = long.Parse(ddlTratamiento.SelectedValue)
                    });
                    db.log.Add(new log()
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Fecha = DateTime.Now,
                        Valor = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}", ddlTratamiento.SelectedItem.Text, 
                            txtFecha.Text, txtFolio.Text, 
                            txtImporte.Text, txtConcepto.Text, ddlTratamiento.SelectedValue, id),
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
            if (txtFecha.Text != "" && txtFolio.Text != "" && txtImporte.Text != "" &&
                ddlTratamiento.SelectedIndex > -1 && txtConcepto.Text != ""
                && Session["Usuario"] != null && Session["idpag"] == null)
            {
                using (var db = new ClinicaEntities())
                {
                    var pago = db.pago.Where(a => a.Fecha == DateTime.Parse(txtFecha.Text)).FirstOrDefault();
                    if (pago == null)
                        return true;
                }
            }

            return false;
        }

        protected void btnPrimero_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.pago.OrderBy(a => a.Uid).FirstOrDefault();
                MostrarStr(str);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idpag"] != null)
                {
                    long idne = (long)Session["idpag"];
                    var str = db.pago.Where(a => a.Uid < idne).OrderByDescending(b => b.Uid).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idpag"] != null)
                {
                    long idne = (long)Session["idpag"];
                    var str = db.pago.Where(a => a.Uid > idne).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.pago.OrderByDescending(a => a.Uid).FirstOrDefault();
                MostrarStr(str);
            }
        }

        private void MostrarStr(pago str)
        {
            if (str == null)
            {
                Nuevo();
            }
            else
            {
                Session["idpag"] = str.Uid;
                txtFecha.TextMode = TextBoxMode.SingleLine;
                txtFecha.Text = str.Fecha.ToString();
                txtFolio.Text = str.Folio;
                txtImporte.Text = str.Importe.ToString();
                txtConcepto.Text = str.Concepto;
                ListItem item = ddlTratamiento.Items.FindByValue(str.Tratamiento.ToString());
                ddlTratamiento.SelectedValue = item.Value;
            }
        }

        private void Nuevo()
        {
            Session.Remove("idpag");
            txtFecha.Text = "";
            txtFecha.TextMode = TextBoxMode.Date;
            txtFolio.Text = "";
            txtImporte.Text = "";
            txtConcepto.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}