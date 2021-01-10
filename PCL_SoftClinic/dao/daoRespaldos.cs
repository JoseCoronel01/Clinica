using System;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Threading;

namespace PCL_SoftClinic.dao
{
    public class daoRespaldos
    {
        public static int HacerRespaldo(string fileName)
        {
            SqlConnection cxn = daoConexion.GetSql("db");

            string Query = "BACKUP DATABASE " + cxn.Database + " TO DISK = '" + fileName + ".bak'";

            SqlCommand cmd = new SqlCommand(Query, cxn);

            int save = cmd.ExecuteNonQuery();

            return save;
        }
    }
}