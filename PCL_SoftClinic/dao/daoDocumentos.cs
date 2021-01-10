using PCL_SoftClinic.str;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PCL_SoftClinic.dao
{
    public class daoDocumentos
    {
        public static int Insert(strDocumento str)
        {
            int save = 0;

            var query = "Insert into documento (" +
                "Clave,Nombre,Descripcion,DescripcionBreve,Etiqueta,Tipo,Archivo) " +
                "values (@Clave,@Nombre,@Descripcion,@DescripcionBreve,@Etiqueta,@Tipo,@Archivo)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        private static void AgregarParametros(SqlCommand cmd, strDocumento str)
        {
            cmd.Parameters.AddWithValue("@Clave", str.Clave);
            cmd.Parameters.AddWithValue("@Nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", str.Descripcion);
            cmd.Parameters.AddWithValue("@DescripcionBreve", str.DescripcionBreve);
            cmd.Parameters.AddWithValue("@Etiqueta", str.Etiqueta);
            cmd.Parameters.AddWithValue("@Tipo", str.Tipo);
            cmd.Parameters.AddWithValue("@Archivo", str.Archivo);
        }

        public static int Update(strDocumento str)
        {
            int save = 0;

            var query = "Update documento set " +
                "Nombre=@Nombre,Descripcion=@Descripcion," +
                "DescripcionBreve=@DescripcionBreve,Etiqueta=@Etiqueta,Tipo=@Tipo,Archivo=@Archivo " +
                "where Clave=@Clave";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(string Clave)
        {
            int save = 0;

            var query = "Delete from documento where Clave=@Clave";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Clave", Clave);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static List<strDocumento> GetList()
        {
            List<strDocumento> lista = null;

            var query = "Select * from documento order by Clave asc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        public static bool ExisteTipo(int Tipo)
        {
            strDocumento objeto = null;

            var query = "Select TOP 1 * from documento where Tipo = @Tipo";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Tipo", Tipo);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            if (objeto != null)
                return true;
            else
                return false;
        }

        private static List<strDocumento> CargarLista(SqlDataReader lector, List<strDocumento> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strDocumento>();
                lista.Add(new strDocumento()
                {
                    Clave = lector["Clave"].ToString(),
                    Nombre = lector["Nombre"].ToString(),
                    Descripcion = lector["Descripcion"].ToString(),
                    DescripcionBreve = lector["DescripcionBreve"].ToString(),
                    Etiqueta = lector["Etiqueta"].ToString(),
                    Tipo = int.Parse(lector["Tipo"].ToString()),
                    Archivo = (byte[])lector["Archivo"]
                });
            }
            return lista;
        }

        public static strDocumento GetObject(string Clave)
        {
            strDocumento objeto = null;

            var query = "Select * from documento where Clave = @Clave ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Clave", Clave);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static strDocumento CargarObjeto(SqlDataReader lector, strDocumento objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strDocumento();
                objeto.Clave = lector["Clave"].ToString();
                objeto.Nombre = lector["Nombre"].ToString();
                objeto.Descripcion = lector["Descripcion"].ToString();
                objeto.DescripcionBreve = lector["DescripcionBreve"].ToString();
                objeto.Etiqueta = lector["Etiqueta"].ToString();
                objeto.Tipo = int.Parse(lector["Tipo"].ToString());
                objeto.Archivo = (byte[])lector["Archivo"];
            }
            return objeto;
        }
    }
}