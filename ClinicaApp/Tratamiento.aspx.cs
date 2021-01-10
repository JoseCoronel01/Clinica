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
    public partial class Tratamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (!IsPostBack)
            {
                List<ElementoComboBox> elementos = new List<ElementoComboBox>();
                var lista = daoPaciente.GetList("Where Estatus = 1");
                foreach (var elem in lista)
                    elementos.Add(new ElementoComboBox() { value = elem.Id, text = elem.ToString() });
                ddlPaciente.DataSource = elementos;
                ddlPaciente.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                using (var db = new ClinicaEntities())
                {
                    long id = daoTratamiento.NuevoId();
                    long idpago = -1;
                    db.tratamiento.Add(new tratamiento()
                    {
                        Id = id,
                        Paciente = long.Parse(ddlPaciente.SelectedValue),
                        FechaIngreso = DateTime.Parse(txtFechaI.Text),
                        FechaSalida = DateTime.Parse(txtFechaS.Text),
                        CostoIngreso = decimal.Parse(txtCostoI.Text),
                        PlanMensual = decimal.Parse(txtPlanM.Text)
                    });
                    if (chBoxTratamiento.Checked)
                    {
                        idpago = daoPago.NuevoId();
                        db.pago.Add(new pago()
                        {
                            Uid = idpago,
                            Tratamiento = id,
                            Fecha = DateTime.Parse(txtFechaI.Text),
                            Folio = "S/N",
                            Concepto = "Inicio del Tratamiento",
                            Importe = decimal.Parse(txtCostoI.Text)
                        });
                    }
                    db.log.Add(new log()
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Fecha = DateTime.Now,
                        Valor = ddlPaciente.SelectedItem.Text + "|" + txtFechaI.Text + "|" + txtFechaS.Text + "|" + 
                            txtCostoI.Text + "|" + txtPlanM.Text + "|" + idpago,
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
            if (txtCostoI.Text != "" && txtFechaI.Text != "" && txtFechaS.Text != "" &&
                ddlPaciente.SelectedIndex > -1 && txtPlanM.Text != ""
                && Session["Usuario"] != null && Session["idtrata"] == null)
            {
                return true;
            }

            return false;
        }

        protected void btnPrimero_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.tratamiento.OrderBy(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idtrata"] != null)
                {
                    long idne = (long)Session["idtrata"];
                    var str = db.tratamiento.Where(a => a.Id < idne).OrderByDescending(b => b.Id).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                if (Session["idtrata"] != null)
                {
                    long idne = (long)Session["idtrata"];
                    var str = db.tratamiento.Where(a => a.Id > idne).FirstOrDefault();
                    MostrarStr(str);
                }
            }
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            using (var db = new ClinicaEntities())
            {
                var str = db.tratamiento.OrderByDescending(a => a.Id).FirstOrDefault();
                MostrarStr(str);
            }
        }

        private void MostrarStr(tratamiento str)
        {
            if (str == null)
            {
                Nuevo();
            }
            else
            {
                Session["idtrata"] = str.Id;
                txtCostoI.Text = str.CostoIngreso.ToString();
                txtPlanM.Text = str.PlanMensual.ToString();
                txtFechaI.TextMode = TextBoxMode.SingleLine;
                txtFechaI.Text = str.FechaIngreso.ToString("yyyy/MM/dd");
                txtFechaS.TextMode = TextBoxMode.SingleLine;
                txtFechaS.Text = str.FechaSalida.ToString("yyyy/MM/dd");
                ListItem item = ddlPaciente.Items.FindByValue(str.Paciente.ToString());
                ddlPaciente.SelectedValue = item.Value;
            }
        }

        private void Nuevo()
        {
            Session.Remove("idtrata");
            txtCostoI.Text = "";
            txtPlanM.Text = "";
            txtFechaI.TextMode = TextBoxMode.Date;
            txtFechaI.Text = "";
            txtFechaS.TextMode = TextBoxMode.Date;
            txtFechaS.Text = "";
            ddlPaciente.SelectedIndex = -1;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}