using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoTratamiento
    {
        public static int Insert(strTratamiento str)
        {
            int save = 0;

            var query = "Insert into tratamiento (" +
                "Id,Paciente,FechaIngreso,FechaSalida,CostoIngreso) " +
                //"PlanMensual) " +
                "values (@Id,@Paciente,@FechaIngreso,@FechaSalida,@CostoIngreso)";
            //@PlanMensual

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static strTratamiento GetObject(long idTratamiento, long idPaciente)
        {
            strTratamiento obj = null;

            var query = "Select * from tratamiento where Paciente=@Paciente and Id=@Id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Paciente", idPaciente);
            cmd.Parameters.AddWithValue("@Id", idTratamiento);

            SqlDataReader lector = cmd.ExecuteReader();

            obj = CargarObjeto(lector, obj);

            lector.Close();

            return obj;
        }

        private static strTratamiento CargarObjeto(SqlDataReader lector, strTratamiento obj)
        {
            if (lector != null && lector.Read())
            {
                if (obj == null) obj = new strTratamiento();
                obj.Id = long.Parse(lector["Id"].ToString());
                obj.Paciente = long.Parse(lector["Paciente"].ToString());
                obj.FechaIngreso = DateTime.Parse(lector["FechaIngreso"].ToString());
                obj.FechaSalida = DateTime.Parse(lector["FechaSalida"].ToString());
                obj.CostoIngreso = decimal.Parse(lector["CostoIngreso"].ToString());
                //obj.PlanMensual = decimal.Parse(lector["PlanMensual"].ToString());
            }
            return obj;
        }

        private static void AgregarParametros(SqlCommand cmd, strTratamiento str)
        {
            cmd.Parameters.AddWithValue("@Id", str.Id);
            cmd.Parameters.AddWithValue("@Paciente", str.Paciente);
            cmd.Parameters.AddWithValue("@FechaIngreso", str.FechaIngreso);
            cmd.Parameters.AddWithValue("@FechaSalida", str.FechaSalida);
            cmd.Parameters.AddWithValue("@CostoIngreso", str.CostoIngreso);
            //cmd.Parameters.AddWithValue("@PlanMensual", str.PlanMensual);
        }

        public static List<strTratamiento> GetList(long paciente)
        {
            List<strTratamiento> lista = null;

            var query = "Select * from tratamiento where Paciente=@Paciente order by FechaIngreso desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Paciente", paciente);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        public bool Eliminar(long idTratamiento)
        {
            var query = "Delete from tratamiento Where Id = @Id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@Id", idTratamiento);

            int delete = cmd.ExecuteNonQuery();

            if (delete > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<strTratamiento> GetList()
        {
            List<strTratamiento> lista = null;

            var query = "Select t.* from tratamiento t " +
                "left join paciente p on t.Paciente = p.Id Where p.Estatus = 1 Order by t.FechaIngreso desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        public static long NuevoId()
        {
            long _id = -1;

            var query = "Select Id from tratamiento order by Id desc ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector != null && lector.Read())
            {
                _id = long.Parse(lector["Id"].ToString());

                _id = _id + 1;
            }
            else
                _id = 1;

            lector.Close();

            return _id;
        }

        private static List<strTratamiento> CargarLista(SqlDataReader lector, List<strTratamiento> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strTratamiento>();
                lista.Add(new strTratamiento()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    Paciente = long.Parse(lector["Paciente"].ToString()),
                    FechaIngreso = DateTime.Parse(lector["FechaIngreso"].ToString()),
                    FechaSalida = DateTime.Parse(lector["FechaSalida"].ToString()),
                    CostoIngreso = decimal.Parse(lector["CostoIngreso"].ToString()),
                    //PlanMensual = decimal.Parse(lector["PlanMensual"].ToString())
                });
            }
            return lista;
        }
    }
}