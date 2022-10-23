using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL_SoftClinic.str;
using System.Data.SqlClient;

namespace PCL_SoftClinic.dao
{
    public class daoColaboradores
    {
        public static int Insert(strColaborador str)
        {
            int save = 0;

            var query = "Insert into colaboradores (" +
                "Id,Nombre) " +
                "values (@Id,@Nombre)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Update(strColaborador str)
        {
            int save = 0;

            var query = "Update colaboradores set " +
                "Nombre=@Nombre " +
                "where Id=@Id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(long Id)
        {
            int save = 0;

            var query = "Delete from colaboradores where Id=@Id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static bool ExisteColaborador(string Nombre)
        {
            strColaborador objeto = null;

            var query = "Select * from colaboradores where Nombre = @Nombre";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Nombre", Nombre);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            if (objeto != null)
                return true;
            else
                return false;
        }

        public static List<strColaborador> GetList()
        {
            List<strColaborador> lista = null;

            var query = "Select * from colaboradores order by Nombre asc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        public static long NuevoId()
        {
            long id = -1;

            var query = "Select Top 1 Id from colaboradores order by Id desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read() && lector != null)
            {
                id = long.Parse(lector["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            lector.Close();

            return id;
        }

        public static strColaborador GetObject(long Id)
        {
            strColaborador objeto = null;

            var query = "Select * from colaboradores where Id = @Id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static List<strColaborador> CargarLista(SqlDataReader lector, List<strColaborador> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strColaborador>();
                lista.Add(new strColaborador()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    Nombre = lector["Nombre"].ToString()
                });
            }
            return lista;
        }

        private static strColaborador CargarObjeto(SqlDataReader lector, strColaborador objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strColaborador();
                objeto.Id = long.Parse(lector["Id"].ToString());
                objeto.Nombre = lector["Nombre"].ToString();
            }
            return objeto;
        }

        private static void AgregarParametros(SqlCommand cmd, strColaborador str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
        }
    }
}
