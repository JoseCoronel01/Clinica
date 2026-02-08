using System;
using System.Windows.Forms;
using System.Data;
using PCL_SoftClinic.Reportes.DataSet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;

namespace UI_SoftClinic
{
    public partial class frmReportes : Form
    {
        private DataSet reportDataSet;
        private string currentReportName;

        public frmReportes(string nombreReporte = null, long? idPaciente = null)
        {
            InitializeComponent();
            currentReportName = nombreReporte;

            if (nombreReporte == "Paciente")
            {
                reportDataSet = CreaXML.GeneraDataSet(
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
                    "order by Id desc ", nombreReporte);
                GeneratePacientePDF(reportDataSet);
            }
            else if (nombreReporte == "Pagos")
            {
                reportDataSet = ListarPagos(idPaciente, nombreReporte);
                GeneratePagosPDF(reportDataSet);
            }
            else if (nombreReporte == "NotaEvolucion")
            {
                string query = "Select ne.Titulo, ne.Descripcion, ne.Fecha, ne.Usuario, es.Nombre as Estado, " +
                    "p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre as Paciente " +
                    "from notaevolucion ne " +
                    "inner join paciente p on p.Id = ne.Paciente " +
                    "inner join estado es on es.Id = ne.Estado " +
                    "group by ne.Paciente, p.ApellidoPaterno, p.ApellidoMaterno, p.Nombre, " +
                    "ne.Titulo, ne.Descripcion, ne.Fecha, ne.Usuario, es.Nombre " +
                    "order by ne.Fecha desc ";
                reportDataSet = CreaXML.GeneraDataSet(query, nombreReporte);
                GenerateNotaEvolucionPDF(reportDataSet);
            }
            else if (nombreReporte == "Colaboradores")
            {
                reportDataSet = CreaXML.GeneraDataSet("Select * From colaboradores order by Nombre asc", nombreReporte);
                GenerateColaboradoresPDF(reportDataSet);
            }
            else if (nombreReporte == "ColaboradoresDetalle")
            {
                reportDataSet = CreaXML.GeneraDataSet("Select cd.*, c.Nombre From colaboradoresDetalle cd " +
                    "inner join colaboradores c on c.Id = cd.ColaboradorId order by c.Id, cd.FechaEmision desc ",
                    nombreReporte);
                GenerateColaboradoresDetallePDF(reportDataSet);
            }
        }

        private void GeneratePacientePDF(DataSet ds)
        {
            string pdfPath = Path.Combine(GetReportPath(), "Pacientes.pdf");
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A1, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Add title
                var titleFont = FontFactory.GetFont("Arial", 18);
                var title = new Paragraph("Listado de Pacientes", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Create table
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;

                // Add headers
                var headerFont = FontFactory.GetFont("Arial", 12);
                table.AddCell(new PdfPCell(new Phrase("ID", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Nombre", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Apellido Paterno", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Apellido Materno", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Teléfono", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Responsable", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Estatus", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Tipo", headerFont)));

                // Add data
                var normalFont = FontFactory.GetFont("Arial", 10);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    table.AddCell(new PdfPCell(new Phrase(row["Id"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Nombre"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["ApellidoPaterno"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["ApellidoMaterno"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["TelContacto"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Responsable"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Estatus"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Tipo"].ToString(), normalFont)));
                }

                document.Add(table);
                document.Close();
            }
            System.Diagnostics.Process.Start(pdfPath);
        }

        private void GeneratePagosPDF(DataSet ds)
        {
            string pdfPath = Path.Combine(GetReportPath(), "Pagos.pdf");
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A1, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                var titleFont = FontFactory.GetFont("Arial", 18);
                var title = new Paragraph("Reporte de Pagos", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;

                var headerFont = FontFactory.GetFont("Arial", 12);
                table.AddCell(new PdfPCell(new Phrase("Paciente", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Fecha", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Folio", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Importe", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Concepto", headerFont)));

                var normalFont = FontFactory.GetFont("Arial", 10);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    table.AddCell(new PdfPCell(new Phrase(row["NombreCompleto"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(Convert.ToDateTime(row["Fecha"]).ToShortDateString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Folio"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Importe"].ToString(), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(row["Concepto"].ToString(), normalFont)));
                }

                document.Add(table);
                document.Close();
            }
            System.Diagnostics.Process.Start(pdfPath);
        }

        private void GenerateNotaEvolucionPDF(DataSet ds)
        {
            string pdfPath = Path.Combine(GetReportPath(), "NotasEvolucion.pdf");
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A1, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                var titleFont = FontFactory.GetFont("Arial", 18);
                var title = new Paragraph("Notas de Evolución", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                var normalFont = FontFactory.GetFont("Arial", 10);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    document.Add(new Paragraph($"Paciente: {row["Paciente"]}", FontFactory.GetFont("Arial", 12)));
                    document.Add(new Paragraph($"Título: {row["Titulo"]}", normalFont));
                    document.Add(new Paragraph($"Fecha: {Convert.ToDateTime(row["Fecha"]).ToString()}", normalFont));
                    document.Add(new Paragraph($"Usuario: {row["Usuario"]}", normalFont));
                    document.Add(new Paragraph($"Estado: {row["Estado"]}", normalFont));
                    document.Add(new Paragraph("Descripción:", normalFont));
                    document.Add(new Paragraph(row["Descripcion"].ToString(), normalFont));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                }

                document.Close();
            }
            System.Diagnostics.Process.Start(pdfPath);
        }

        private void GenerateColaboradoresPDF(DataSet ds)
        {
            string pdfPath = Path.Combine(GetReportPath(), "Colaboradores.pdf");
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A1, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                var titleFont = FontFactory.GetFont("Arial", 18);
                var title = new Paragraph("Listado de Colaboradores", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(ds.Tables[0].Columns.Count);
                table.WidthPercentage = 100;

                var headerFont = FontFactory.GetFont("Arial", 12);
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    table.AddCell(new PdfPCell(new Phrase(column.ColumnName, headerFont)));
                }

                var normalFont = FontFactory.GetFont("Arial", 10);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.ToString(), normalFont)));
                    }
                }

                document.Add(table);
                document.Close();
            }
            System.Diagnostics.Process.Start(pdfPath);
        }

        private void GenerateColaboradoresDetallePDF(DataSet ds)
        {
            string pdfPath = Path.Combine(GetReportPath(), "ColaboradoresDetalle.pdf");
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                Document document = new Document(PageSize.A1, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                var titleFont = FontFactory.GetFont("Arial", 18);
                var title = new Paragraph("Detalle de Colaboradores", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(ds.Tables[0].Columns.Count);
                table.WidthPercentage = 100;

                var headerFont = FontFactory.GetFont("Arial", 12);
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    table.AddCell(new PdfPCell(new Phrase(column.ColumnName, headerFont)));
                }

                var normalFont = FontFactory.GetFont("Arial", 10);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.ToString(), normalFont)));
                    }
                }

                document.Add(table);
                document.Close();
            }
            System.Diagnostics.Process.Start(pdfPath);
        }

        private string GetReportPath()
        {
            string path = ConfigurationManager.AppSettings["Reportes"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public DataSet ListarPagos(long? idPaciente, string nombreReporte)
        {
            DataSet ds = CreaXML.GeneraDataSet("select p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + " +
                                       "p.Nombre as NombreCompleto, " +
                                       "pa.Fecha, pa.Folio, pa.Importe, pa.Concepto " +
                                       "from paciente p " +
                                       "inner " +
                                       "join tratamiento t on t.Paciente = p.Id " +
                                       "inner " +
                                       "join pago pa on pa.Tratamiento = t.Id " +
                                       "where p.Id = " + idPaciente + " " +
                                       "order by t.FechaIngreso, pa.Fecha asc " +
                                       "", nombreReporte);

            return ds;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
        }
    }
}