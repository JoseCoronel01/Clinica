using System.Collections.Generic;
using PCL_SoftClinic.str;
using System.Data.SqlClient;
using System;

namespace PCL_SoftClinic.dao
{
    public class daoTipoDocumentos
    {
        public static int Insert(strTipoDocumento str)
        {
            int save = 0;

            var query = "Insert into tipo_documento (Id,Nombre) values (@Id,@Nombre)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        private static void AgregarParametros(SqlCommand cmd, strTipoDocumento str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
        }

        public static int Update(strTipoDocumento str)
        {
            int save = 0;

            var query = "Update tipo_documento set Nombre=@Nombre where Id=@Id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(int Id)
        {
            int save = 0;

            var query = "Delete from tipo_documento where Id=@Id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static List<strTipoDocumento> GetList()
        {
            List<strTipoDocumento> lista = null;

            var query = "Select * from tipo_documento order by Nombre asc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        private static List<strTipoDocumento> CargarLista(SqlDataReader lector, List<strTipoDocumento> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strTipoDocumento>();
                lista.Add(new strTipoDocumento()
                {
                    Id = int.Parse(lector["Id"].ToString()),
                    Nombre = lector["Nombre"].ToString()
                });
            }
            return lista;
        }

        public static strTipoDocumento GetObject(int Id)
        {
            strTipoDocumento objeto = null;

            var query = "Select * from tipo_documento where Id = @Id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static strTipoDocumento CargarObjeto(SqlDataReader lector, strTipoDocumento objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strTipoDocumento();
                objeto.Id = int.Parse(lector["Id"].ToString());
                objeto.Nombre = lector["Nombre"].ToString();
            }
            return objeto;
        }

        public static int CreateId()
        {
            int Id = 0;

            var query = "Select TOP 1 Id from tipo_documento order by Id desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector != null && lector.Read())
            {
                Id = int.Parse(lector["Id"].ToString());

                Id = Id + 1;
            }
            else
                Id = 1;

            lector.Close();

            return Id;
        }
    }
}