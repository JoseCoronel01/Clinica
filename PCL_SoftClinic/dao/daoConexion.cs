using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using PCL_Comun.Utilidades;
using System;

namespace PCL_SoftClinic.dao
{
    public class daoConexion
    {
        private static SqlConnection cxn = new SqlConnection();

        public static SqlConnection GetSql(string name)
        {
            try
            {
                //string cadena_SqlEncrypt = ConfigurationManager.AppSettings[name].ToString();

                string cadena_Sql = ConfigurationManager.AppSettings[name].ToString(); //Util.DesEncripta(cadena_SqlEncrypt);

                if (cxn.State == ConnectionState.Open) cxn.Close();

                cxn.ConnectionString = cadena_Sql;

                cxn.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { }

            return cxn;
        }
    }
}