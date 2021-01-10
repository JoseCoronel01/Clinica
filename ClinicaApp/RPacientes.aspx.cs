using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PCL_SoftClinic.Reportes;
using PCL_SoftClinic.Reportes.DataSet;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace ClinicaApp
{
    public partial class RPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (IsPostBack) return;

            ReportDocument doc = new ReportDocument();

            DataSet ds = null;
            ds = CreaXML.GeneraDataSet(
                    "Select Id, ApellidoPaterno, ApellidoMaterno, Nombre, TelContacto, Responsable, LugarResidencia, " +
                    "(CASE Estatus WHEN 1 THEN 'ACTIVO' " +
                    "WHEN 2 THEN 'INACTIVO' " +
                    "WHEN 3 THEN 'BAJA' END) " +
                    "as Estatus, " +
                    "(CASE Tipo WHEN 1 THEN 'ETAPA EXPERIMENTAL' " +
                    "WHEN 2 THEN 'SEGUIMIENTO DE TRATAMIENTO' " +
                    "WHEN 3 THEN 'PREVENCIÓN DE RECAÍDAS' END) " +
                    "as Tipo " +
                    "from paciente " +
                    "order by Id asc ", "Paciente");

            doc.Load(Server.MapPath("/rpt/crPaciente.rpt"));

            doc.SetDataSource(ds);

            Stream stream = doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            var pdfbyteArray = new byte[stream.Length];

            stream.Position = 0;
            stream.Read(pdfbyteArray, 0, Convert.ToInt32(stream.Length));
            Context.Response.ClearContent();
            Context.Response.ClearHeaders();
            Context.Response.AddHeader("content-disposition", "filename=Paciente.pdf");
            Context.Response.ContentType = "application/pdf";
            Context.Response.AddHeader("content-length", pdfbyteArray.Length.ToString());
            Context.Response.BinaryWrite(pdfbyteArray);
        }
    }
}