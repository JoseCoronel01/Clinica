using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PCL_SoftClinic.Reportes.DataSet;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace ClinicaApp
{
    public partial class RNotasGenerar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Session["Usuario"] == null)
                this.Page.Response.Redirect("/LogIn.aspx");

            if (IsPostBack) return;

            ReportDocument doc = new ReportDocument();

            string query = "Select ne.Titulo, ne.Descripcion, ne.Fecha, ne.Usuario, es.Nombre as Estado, " +
                "p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre as Paciente " +
                "from notaevolucion ne " +
                "inner join paciente p on p.Id = ne.Paciente " +
                "inner join estado es on es.Id = ne.Estado " +
                "where p.Id = " + this.Page.Request.QueryString["id"].ToString() +
                "order by ne.Fecha desc ";

            DataSet ds = CreaXML.GeneraDataSet(query, "NotaEvolucion");

            doc.Load(Server.MapPath("/rpt/crNota.rpt"));

            doc.SetDataSource(ds);

            Stream stream = doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            var pdfbyteArray = new byte[stream.Length];

            stream.Position = 0;
            stream.Read(pdfbyteArray, 0, Convert.ToInt32(stream.Length));
            Context.Response.ClearContent();
            Context.Response.ClearHeaders();
            Context.Response.AddHeader("content-disposition", "filename=NotaEvolucion.pdf");
            Context.Response.ContentType = "application/pdf";
            Context.Response.AddHeader("content-length", pdfbyteArray.Length.ToString());
            Context.Response.BinaryWrite(pdfbyteArray);
        }
    }
}