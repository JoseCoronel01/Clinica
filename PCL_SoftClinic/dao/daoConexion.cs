using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using PCL_Comun.Utilidades;

namespace PCL_SoftClinic.dao
{
    public class daoConexion
    {
        private static SqlConnection cxn = new SqlConnection();

        public static SqlConnection GetSql(string name)
        {
            try
            {
                string cadena_SqlEncrypt = ConfigurationManager.AppSettings[name].ToString();

                string cadena_Sql = Util.DesEncripta(cadena_SqlEncrypt);

                cxn.ConnectionString = cadena_Sql;

                if (cxn.State == ConnectionState.Open) cxn.Close();

                cxn.Open();
            }
            catch { }
            finally { }

            return cxn;
        }
    }
}