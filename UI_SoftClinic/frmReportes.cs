using System;
using System.Windows.Forms;
using System.Data;
using PCL_SoftClinic.Reportes.rpt;
using PCL_SoftClinic.Reportes.DataSet;
using PCL_SoftClinic.str;

namespace UI_SoftClinic
{
    public partial class frmReportes : Form
    {
        public frmReportes(string nombreReporte = null, long? idPaciente = null)
        {
            InitializeComponent();

            DataSet ds = null;

            if (nombreReporte == "Paciente")
            {
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
                    "order by Id desc ", nombreReporte);

                crPaciente rep = new crPaciente();

                rep.SetDataSource(ds);

                crystalReportViewer1.ReportSource = rep;
            }
            else if (nombreReporte == "Pagos")
            {
                crPagos rep = new crPagos();

                ds = ListarPagos(idPaciente, nombreReporte, out rep);

                crystalReportViewer1.ReportSource = rep;
            }
            else if (nombreReporte == "NotaEvolucion")
            {
                crNota rep = new crNota();
                string query = "Select ne.Titulo, ne.Descripcion, ne.Fecha, ne.Usuario, es.Nombre as Estado, " +
                    "p.ApellidoPaterno + ' ' + p.ApellidoMaterno + ' ' + p.Nombre as Paciente " +
                    "from notaevolucion ne " +
                    "inner join paciente p on p.Id = ne.Paciente " +
                    "inner join estado es on es.Id = ne.Estado " +
                    "group by ne.Paciente, p.ApellidoPaterno, p.ApellidoMaterno, p.Nombre, " +
                    "ne.Titulo, ne.Descripcion, ne.Fecha, ne.Usuario, es.Nombre " +
                    "order by ne.Fecha desc ";
                ds = CreaXML.GeneraDataSet(query, nombreReporte);
                rep.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rep;
            }
            else if (nombreReporte == "Colaboradores")
            {
                ds = CreaXML.GeneraDataSet("Select * From colaboradores order by Nombre asc", nombreReporte);

                crColaboradores rep = new crColaboradores();

                rep.SetDataSource(ds);

                crystalReportViewer1.ReportSource = rep;
            }
            else if (nombreReporte == "ColaboradoresDetalle")
            {
                ds = CreaXML.GeneraDataSet("Select cd.*, c.Nombre From colaboradoresDetalle cd " +
                    "inner join colaboradores c on c.Id = cd.ColaboradorId order by c.Id, cd.FechaEmision desc ",
                    nombreReporte);

                crColaboradoresD rep = new crColaboradoresD();

                rep.SetDataSource(ds);

                crystalReportViewer1.ReportSource = rep;
            }
        }

        public DataSet ListarPagos(long? idPaciente, string nombreReporte, out crPagos rep)
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
            rep = new crPagos();

            rep.SetDataSource(ds);

            return ds;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
