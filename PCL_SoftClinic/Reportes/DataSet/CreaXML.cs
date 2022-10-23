using System;
using dataSet = System.Data;
using System.IO;
using System.Data.SqlClient;
using PCL_SoftClinic.dao;
using System.Configuration;

namespace PCL_SoftClinic.Reportes.DataSet
{
    public class CreaXML
    {
        public static dataSet.DataSet GeneraDataSet(string query = null, string fileName = null)
        {
            SqlConnection cxn = daoConexion.GetSql("db");

            SqlDataAdapter adaptador = new SqlDataAdapter(query, cxn);

            dataSet.DataSet ds = new dataSet.DataSet();

            adaptador.Fill(ds);

            string pathWithFile = Path.Combine(ConfigurationManager.AppSettings["Reportes"].ToString())
                + @"\" + fileName + ".xsd";

            if (!File.Exists(pathWithFile))
            {
                ds.WriteXmlSchema(pathWithFile);
            }
            else
            {
                File.Delete(pathWithFile);
                ds.WriteXmlSchema(pathWithFile);
            }

            return ds;
        }

        public static void GeneraXSD(dataSet.DataSet ds, string nombreReporte)
        {
            string pathWithFile = Path.Combine(ConfigurationManager.AppSettings["Reportes"].ToString())
                + @"\" + nombreReporte + ".xsd";

            if (!File.Exists(pathWithFile))
            {
                ds.WriteXmlSchema(pathWithFile);
            }
            else
            {
                File.Delete(pathWithFile);
                ds.WriteXmlSchema(pathWithFile);
            }
        }
    }
}