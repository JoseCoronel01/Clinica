using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoLog
    {
        public static void Insert(strLog str)
        {
            var query = "Insert into log (" +
                "uid,fecha,accion,valor,modulo,usuario,ip) " +
                "values (@uid,@fecha,@accion,@valor,@modulo,@usuario,@ip)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            cmd.ExecuteNonQuery();
        }

        private static void AgregarParametros(SqlCommand cmd, strLog str)
        {
            cmd.Parameters.AddWithValue("@uid", str.Uid);
            cmd.Parameters.AddWithValue("@fecha", str.Fecha);
            cmd.Parameters.AddWithValue("@accion", str.Accion);
            cmd.Parameters.AddWithValue("@valor", str.Valor);
            cmd.Parameters.AddWithValue("@modulo", str.Modulo);
            cmd.Parameters.AddWithValue("@usuario", str.Usuario);
            cmd.Parameters.AddWithValue("@ip", str.IP);
        }
    }
}