using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoPago
    {
        public static List<strPago> GetAll(long tratamiento)
        {
            List<strPago> lista = null;

            string query = "Select * from pago where Tratamiento=@Tratamiento order by Fecha asc";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Tratamiento", tratamiento);

            SqlDataReader reader = cmd.ExecuteReader();

            lista = LoadList(reader, lista);

            reader.Close();

            return lista;
        }

        public static int Insert(strPago str)
        {
            int save = 0;

            string sIdPago = "Select top 1 Uid From pago order by Uid desc ";
        
            string query = "Insert into pago (Uid,Tratamiento,Fecha,Folio,Importe,Concepto) values (@Uid,@Tratamiento,@Fecha,@Folio,@Importe,@Concepto) ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd1 = new SqlCommand(sIdPago, cxn);

            SqlDataReader lector = cmd1.ExecuteReader();

            long idPago = -1;

            if (lector != null && lector.Read())
            {
                idPago = int.Parse(lector["Uid"].ToString());

                idPago = idPago + 1;

                str.Uid = idPago;

                SqlCommand cmd = new SqlCommand(query, cxn);

                AddParameters(cmd, str);

                lector.Close();

                save = cmd.ExecuteNonQuery();
            }
            else
            {
                lector.Close();
                str.Uid = 1;
                SqlCommand cmd = new SqlCommand(query, cxn);
                AddParameters(cmd, str);
                save = cmd.ExecuteNonQuery();
            }

            return save;
        }

        private static void AddParameters(SqlCommand cmd, strPago str)
        {
            cmd.Parameters.AddWithValue("@Uid", str.Uid);
            cmd.Parameters.AddWithValue("@Tratamiento", str.Tratamiento);
            cmd.Parameters.AddWithValue("@Fecha", str.Fecha);
            cmd.Parameters.AddWithValue("@Folio", str.Folio);
            cmd.Parameters.AddWithValue("@Importe", str.Importe);
            cmd.Parameters.AddWithValue("@Concepto", str.Concepto);
        }

        public static long NuevoId()
        {
            long id = 0;

            string query = "Select Uid from pago order by Uid desc";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.Read())
            {
                id = long.Parse(reader["Uid"].ToString());

                id = id + 1;
            }
            else
            {
                id = 1;
            }

            reader.Close();

            return id;
        }

        public static strPago GetObject(long idTratamiento)
        {
            strPago obj = null;

            string query = "Select * from pago where Tratamiento=@Tratamiento ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Tratamiento", idTratamiento);

            SqlDataReader reader = cmd.ExecuteReader();

            obj = LoadObject(reader, obj);

            reader.Close();

            return obj;
        }

        private static strPago LoadObject(SqlDataReader reader, strPago obj)
        {
            if (reader != null && reader.Read())
            {
                if (obj == null) obj = new strPago();
                obj.Uid = long.Parse(reader["Uid"].ToString());
                obj.Tratamiento = long.Parse(reader["Tratamiento"].ToString());
                obj.Fecha = (reader["Fecha"] != DBNull.Value) ? DateTime.Parse(reader["Fecha"].ToString()) : DateTime.MinValue;
                obj.Folio = reader["Folio"].ToString();
                obj.Importe = decimal.Parse(reader["Importe"].ToString());
                obj.Concepto = reader["Concepto"].ToString();
            }
            return obj;
        }

        private static List<strPago> LoadList(SqlDataReader reader, List<strPago> lista)
        {
            while (reader != null && reader.Read())
            {
                if (lista == null) lista = new List<strPago>();
                lista.Add(new strPago()
                {
                    Uid = long.Parse(reader["Uid"].ToString()),
                    Tratamiento = long.Parse(reader["Tratamiento"].ToString()),
                    Fecha = (reader["Fecha"] != DBNull.Value) ? DateTime.Parse(reader["Fecha"].ToString()) : DateTime.MinValue,
                    Folio = reader["Folio"].ToString(),
                    Importe = decimal.Parse(reader["Importe"].ToString()),
                    Concepto = reader["Concepto"].ToString()
                });
            }
            return lista;
        }
    }
}