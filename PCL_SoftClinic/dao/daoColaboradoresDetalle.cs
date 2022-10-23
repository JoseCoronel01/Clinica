using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoColaboradoresDetalle
    {
        public static int Insert(strColaboradorDetalle str)
        {
            int save = 0;

            var query = "Insert into colaboradoresDetalle ( " +
                "Id,ColaboradorId,FechaEmision,Importe,Pagado,FechaPago,Concepto) " +
                "values (@Id,@ColaboradorId,@FechaEmision,@Importe,@Pagado,@FechaPago,@Concepto)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Update(strColaboradorDetalle str)
        {
            int save = 0;

            var query = "Update colaboradoresDetalle set " +
                "FechaEmision=@FechaEmision,Importe=@Importe,Pagado=@Pagado,FechaPago=@FechaPago,Concepto=@Concepto " +
                "where Id=@Id and ColaboradorId=@ColaboradorId";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static int Delete(long Id)
        {
            int save = 0;

            var query = "Delete from colaboradoresDetalle where Id=@Id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static List<strColaboradorDetalle> GetList()
        {
            List<strColaboradorDetalle> lista = null;

            var query = "Select * from colaboradoresDetalle order by FechaEmision desc ";

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

            var query = "Select Top 1 Id from colaboradoresDetalle order by Id desc ";

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

        public static bool ExisteColaboradorDetalle(long ColaboradorId)
        {
            strColaboradorDetalle objeto = null;

            var query = "Select * from colaboradoresDetalle where ColaboradorId = @ColaboradorId";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@ColaboradorId", ColaboradorId);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            if (objeto != null)
                return true;
            else
                return false;
        }

        public static strColaboradorDetalle GetObject(long Id)
        {
            strColaboradorDetalle objeto = null;

            var query = "Select * from colaboradoresDetalle where Id = @Id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static List<strColaboradorDetalle> CargarLista(SqlDataReader lector, List<strColaboradorDetalle> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strColaboradorDetalle>();
                lista.Add(new strColaboradorDetalle()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    ColaboradorId = long.Parse(lector["ColaboradorId"].ToString()),
                    FechaEmision = DateTime.Parse(lector["FechaEmision"].ToString()),
                    Importe = decimal.Parse(lector["Importe"].ToString()),
                    Pagado = bool.Parse(lector["Pagado"].ToString()),
                    FechaPago = (lector["FechaPago"] != DBNull.Value) ? DateTime.Parse(lector["FechaPago"].ToString()) : DateTime.MinValue,
                    Concepto = (lector["Concepto"] != DBNull.Value) ? lector["Concepto"].ToString() : null
                });
            }
            return lista;
        }

        private static strColaboradorDetalle CargarObjeto(SqlDataReader lector, strColaboradorDetalle objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strColaboradorDetalle();
                objeto.Id = long.Parse(lector["Id"].ToString());
                objeto.ColaboradorId = long.Parse(lector["ColaboradorId"].ToString());
                objeto.FechaEmision = DateTime.Parse(lector["FechaEmision"].ToString());
                objeto.Importe = decimal.Parse(lector["Importe"].ToString());
                objeto.Pagado = bool.Parse(lector["Pagado"].ToString());
                objeto.FechaPago = (lector["FechaPago"] != DBNull.Value) ? DateTime.Parse(lector["FechaPago"].ToString()) : DateTime.MinValue;
                objeto.Concepto = (lector["Concepto"] != DBNull.Value) ? lector["Concepto"].ToString() : null;
            }
            return objeto;
        }

        private static void AgregarParametros(SqlCommand cmd, strColaboradorDetalle str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@ColaboradorId", str.ColaboradorId);
            cmd.Parameters.AddWithValue("@FechaEmision", str.FechaEmision);
            cmd.Parameters.AddWithValue("@Importe", str.Importe);
            cmd.Parameters.AddWithValue("@Pagado", str.Pagado);
            if (str.FechaPago != null)
                cmd.Parameters.AddWithValue("@FechaPago", str.FechaPago);
            else
                cmd.Parameters.AddWithValue("@FechaPago", DBNull.Value);
            cmd.Parameters.AddWithValue("@Concepto", str.Concepto);
        }
    }
}
