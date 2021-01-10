using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoUsuarios
    {
        public static int Insert(strUsuario str)
        {
            int save = 0;

            string query = "Insert into Usuarios (Usuario,Password,Tipo) values (@Usuario,@Password,@Tipo) ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Update(strUsuario str)
        {
            int save = 0;

            string query = "Update Usuarios set Password=@Password,Tipo=@Tipo where Usuario=@Usuario ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AddParameters(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(string Usuario)
        {
            int save = 0;

            string query = "Delete from Usuarios where Usuario=@Usuario ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static strUsuario GetIn(string Usuario, string Password)
        {
            strUsuario obj = null;

            string query = "Select * from Usuarios " +
                "where Usuario collate Latin1_General_CI_AS like '" + Usuario + "' " +
                "and Password collate Latin1_General_CI_AS like '" + Password + "' ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            return obj;
        }

        public static List<strUsuario> GetAll()
        {
            List<strUsuario> lista = null;

            string query = "Select * from Usuarios order by Usuario asc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadData(reader, lista);

            reader.Close();

            return lista;
        }

        public static strUsuario GetObject(string Usuario)
        {
            strUsuario obj = null;

            string query = "Select * from Usuarios where Usuario=@Usuario ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Usuario", Usuario);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            return obj;
        }

        private static strUsuario LoadObject(SqlDataReader reader, strUsuario obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strUsuario();
                obj.Usuario = reader["Usuario"].ToString();
                obj.Password = reader["Password"].ToString();
                obj.Tipo = CargarTipo(reader["Tipo"].ToString());
            }
            return obj;
        }

        private static List<strUsuario> LoadData(SqlDataReader reader, List<strUsuario> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strUsuario>();
                lista.Add(new strUsuario()
                {
                    Usuario = reader["Usuario"].ToString(),
                    Password = reader["Password"].ToString(),
                    Tipo = CargarTipo(reader["Tipo"].ToString())
                });
            }
            return lista;
        }

        private static strUsuario.eTipo CargarTipo(string value)
        {
            switch (value)
            {
                case "1":
                    {
                        return strUsuario.eTipo.SUPERVISOR;
                    }
                case "2":
                    {
                        return strUsuario.eTipo.OPERADOR;
                    }
                default:
                    {
                        return strUsuario.eTipo.ANONYMUS;
                    }
            }
        }

        private static void AddParameters(SqlCommand cmd, strUsuario str)
        {
            cmd.Parameters.AddWithValue("@Usuario", str.Usuario);
            cmd.Parameters.AddWithValue("@Password", str.Password);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
        }
    }
}