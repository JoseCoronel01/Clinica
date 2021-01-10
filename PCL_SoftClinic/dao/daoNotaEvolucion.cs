using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoNotaEvolucion
    {
        public static int Insert(strNotaEvolucion str)
        {
            int save = 0;

            var query = "Insert into notaevolucion (" +
                "id,titulo,descripcion,fecha,paciente,usuario,estado) " +
                "values (@id,@titulo,@descripcion,@fecha,@paciente,@usuario,@estado)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        private static void AgregarParametros(SqlCommand cmd, strNotaEvolucion str)
        {
            cmd.Parameters.AddWithValue("@id", str.Id);
            cmd.Parameters.AddWithValue("@titulo", str.Titulo);
            cmd.Parameters.AddWithValue("@descripcion", str.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", str.Fecha);
            cmd.Parameters.AddWithValue("@paciente", str.Paciente);
            cmd.Parameters.AddWithValue("@usuario", str.Usuario);
            cmd.Parameters.AddWithValue("@estado", str.Estado);
        }

        public static long NuevoId()
        {
            long id = 0;

            var query = "Select Id from notaevolucion order by id desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector != null && lector.Read())
            {
                id = long.Parse(lector["Id"].ToString());

                id = id + 1;
            }
            else
                id = 1;

            lector.Close();

            return id;
        }

        public static int Update(strNotaEvolucion str)
        {
            int save = 0;

            var query = "Update notaevolucion set " +
                "titulo=@titulo,descripcion=@descripcion,fecha=@fecha,paciente=@paciente," +
                "usuario=@usuario,estado=@estado " +
                "where id = @id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(long id)
        {
            int save = 0;

            var query = "Delete from notaevolucion where id = @id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@id", id);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static List<strNotaEvolucion> GetList(string condicion = null)
        {
            List<strNotaEvolucion> lista = null;

            var query = "Select * from notaevolucion " + condicion + " order by Fecha desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        private static List<strNotaEvolucion> CargarLista(SqlDataReader lector, List<strNotaEvolucion> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strNotaEvolucion>();
                lista.Add(new strNotaEvolucion()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    Titulo = lector["Titulo"].ToString(),
                    Descripcion = lector["Descripcion"].ToString(),
                    Fecha = DateTime.Parse(lector["Fecha"].ToString()),
                    Paciente = long.Parse(lector["Paciente"].ToString()),
                    Usuario = lector["Usuario"].ToString(),
                    Estado = int.Parse(lector["Estado"].ToString())
                });
            }
            return lista;
        }

        public static strNotaEvolucion GetObject(long id)
        {
            strNotaEvolucion objeto = null;

            var query = "Select * from notaevolucion where id = @id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static strNotaEvolucion CargarObjeto(SqlDataReader lector, strNotaEvolucion objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strNotaEvolucion();
                objeto.Id = long.Parse(lector["Id"].ToString());
                objeto.Titulo = lector["Titulo"].ToString();
                objeto.Descripcion = lector["Descripcion"].ToString();
                objeto.Fecha = DateTime.Parse(lector["Fecha"].ToString());
                objeto.Paciente = long.Parse(lector["Paciente"].ToString());
                objeto.Usuario = lector["Usuario"].ToString();
                objeto.Estado = int.Parse(lector["Estado"].ToString());
            }
            return objeto;
        }
    }
}