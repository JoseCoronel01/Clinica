using System.Collections.Generic;
using System.Data.SqlClient;
using PCL_SoftClinic.str;

namespace PCL_SoftClinic.dao
{
    public class daoPaciente
    {
        public static int Insert(strPaciente str)
        {
            int save = 0;

            var query = "Insert into paciente (" +
                "id,apellidoPaterno,apellidoMaterno,nombre,telContacto," +
                "responsable,lugarResidencia,estatus,tipo) " +
                "values (@id,@apellidoPaterno,@apellidoMaterno,@nombre,@telContacto,@responsable,@lugarResidencia,@estatus,@tipo)";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);
            
            save = cmd.ExecuteNonQuery();

            return save;
        }

        private static void AgregarParametros(SqlCommand cmd, strPaciente str)
        {
            cmd.Parameters.AddWithValue("@id", str.Id);
            cmd.Parameters.AddWithValue("@apellidoPaterno", str.ApellidoPaterno);
            cmd.Parameters.AddWithValue("@apellidoMaterno", str.ApellidoMaterno);
            cmd.Parameters.AddWithValue("@nombre", str.Nombre);
            cmd.Parameters.AddWithValue("@telContacto", str.TelContacto);
            cmd.Parameters.AddWithValue("@responsable", str.Responsable);
            cmd.Parameters.AddWithValue("@lugarResidencia", str.LugarResidencia);
            cmd.Parameters.AddWithValue("@estatus", str.Estatus);
            cmd.Parameters.AddWithValue("@tipo", str.TipoTratamiento);
        }

        public static long NuevoId()
        {
            long id = 0;

            var query = "Select Id from paciente order by id desc ";

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

        public static int Update(strPaciente str)
        {
            int save = 0;

            var query = "Update paciente set " +
                "apellidoPaterno=@apellidoPaterno,apellidoMaterno=@apellidoMaterno,nombre=@nombre,telContacto=@telContacto," +
                "responsable=@responsable,lugarResidencia=@lugarResidencia,estatus=@estatus,tipo=@tipo " +
                "where id = @id";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            AgregarParametros(cmd, str);

            save = cmd.ExecuteNonQuery();

            return save;
        }

        public static List<strPaciente> GetList(string condicion = null)
        {
            List<strPaciente> lista = null;
            string query = string.Empty;

            if (string.IsNullOrEmpty(condicion) == true)
            {
                query = "Select * from paciente order by ApellidoPaterno,ApellidoMaterno,Nombre asc";
            }
            else
            {
                query = "Select * from paciente " + condicion + " order by ApellidoPaterno,ApellidoMaterno,Nombre asc";
            }

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            SqlDataReader lector = cmd.ExecuteReader();

            lista = CargarLista(lector, lista);

            lector.Close();

            return lista;
        }

        private static List<strPaciente> CargarLista(SqlDataReader lector, List<strPaciente> lista)
        {
            while (lector != null && lector.Read())
            {
                if (lista == null) lista = new List<strPaciente>();
                lista.Add(new strPaciente()
                {
                    Id = long.Parse(lector["Id"].ToString()),
                    ApellidoPaterno = lector["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = lector["ApellidoMaterno"].ToString(),
                    Nombre = lector["Nombre"].ToString(),
                    TelContacto = lector["TelContacto"].ToString(),
                    LugarResidencia = lector["LugarResidencia"].ToString(),
                    Responsable = lector["Responsable"].ToString(),
                    Estatus = GetEstatus(lector["Estatus"].ToString()),
                    TipoTratamiento = GetTipo(lector["Tipo"].ToString())
                });
            }
            return lista;
        }

        public static strPaciente GetObject(long id)
        {
            strPaciente objeto = null;

            var query = "Select * from paciente where id = @id ";

            SqlConnection cxn = daoConexion.GetSql("db");

            SqlCommand cmd = new SqlCommand(query, cxn);

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            objeto = CargarObjeto(lector, objeto);

            lector.Close();

            return objeto;
        }

        private static strPaciente.eEstatus GetEstatus(string estatus)
        {
            if (estatus == "1")
                return strPaciente.eEstatus.ACTIVO;
            else if (estatus == "2")
                return strPaciente.eEstatus.INACTIVO;
            else if (estatus == "3")
                return strPaciente.eEstatus.BAJA;
            else
                return strPaciente.eEstatus.SINESTATUS;
        }

        public static strPaciente.eTipo GetTipo(string tipo)
        {
            if (tipo == "1")
                return strPaciente.eTipo.ETAPA_EXPERIMENTAL;
            else if (tipo == "2")
                return strPaciente.eTipo.SEGUIMIENTO_DE_TRATAMIENTO;
            else if (tipo == "3")
                return strPaciente.eTipo.PREVENCION_DE_RECAIDAS;
            else
                return strPaciente.eTipo.SINTIPO;
        }

        public static string GetTipo(strPaciente.eTipo tipo)
        {
            if (strPaciente.eTipo.ETAPA_EXPERIMENTAL == tipo)
                return "1";
            else if (strPaciente.eTipo.SEGUIMIENTO_DE_TRATAMIENTO == tipo)
                return "2";
            else if (strPaciente.eTipo.PREVENCION_DE_RECAIDAS == tipo)
                return "3";
            else
                return "0";
        }

        private static strPaciente CargarObjeto(SqlDataReader lector, strPaciente objeto)
        {
            if (lector != null && lector.Read())
            {
                if (objeto == null) objeto = new strPaciente();
                objeto.Id = long.Parse(lector["Id"].ToString());
                objeto.ApellidoPaterno = lector["ApellidoPaterno"].ToString();
                objeto.ApellidoMaterno = lector["ApellidoMaterno"].ToString();
                objeto.Nombre = lector["Nombre"].ToString();
                objeto.TelContacto = lector["TelContacto"].ToString();
                objeto.LugarResidencia = lector["LugarResidencia"].ToString();
                objeto.Responsable = lector["Responsable"].ToString();
                objeto.Estatus = GetEstatus(lector["Estatus"].ToString());
                objeto.TipoTratamiento = GetTipo(lector["Tipo"].ToString());
            }
            return objeto;
        }
    }
}