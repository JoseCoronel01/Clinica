using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoEstado
    {
        public static List<strEstado> GetList()
        {
            List<strEstado> lista = null;

            var query = "Select * from estado order by Id desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        private static List<strEstado> CargarLista(SqlDataReader lector, List<strEstado> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strEstado>();
                lista.Add(new strEstado()
                {
                    Id = int.Parse(lector["Id"].ToString()),
                    Nombre = lector["Nombre"].ToString()
                });
            }
            return lista;
        }
    }
}