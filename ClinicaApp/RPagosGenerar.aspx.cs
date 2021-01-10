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
    public partial class RPagosGenerar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (IsPostBack) return;

            ReportDocument doc = new ReportDocument();

            DataSet ds = CreaXML.GeneraDataSet("select p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + " +
                                       "p.Nombre as NombreCompleto, " +
                                       "pa.Fecha, pa.Folio, pa.Importe, pa.Concepto " +
                                       "from paciente p " +
                                       "inner " +
                                       "join tratamiento t on t.Paciente = p.Id " +
                                       "inner " +
                                       "join pago pa on pa.Tratamiento = t.Id " +
                                       "where p.Id = " + this.Page.Request.QueryString["id"].ToString() + " " +
                                       "order by t.FechaIngreso, pa.Fecha asc " +
                                       "", "Pagos");

            doc.Load(Server.MapPath("/rpt/crPagos.rpt"));

            doc.SetDataSource(ds);

            Stream stream = doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            var pdfbyteArray = new byte[stream.Length];

            stream.Position = 0;
            stream.Read(pdfbyteArray, 0, Convert.ToInt32(stream.Length));
            Context.Response.ClearContent();
            Context.Response.ClearHeaders();
            Context.Response.AddHeader("content-disposition", "filename=Pagos.pdf");
            Context.Response.ContentType = "application/pdf";
            Context.Response.AddHeader("content-length", pdfbyteArray.Length.ToString());
            Context.Response.BinaryWrite(pdfbyteArray);
        }
    }
}