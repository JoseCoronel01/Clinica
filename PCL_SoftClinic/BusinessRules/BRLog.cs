using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace PCL_SoftClinic.BusinessRules
{
    public class BRLog
    {
        public BRLog(DateTime fecha, byte accion, string valor, string modulo, string usuario, string ip = null)
        {
            strLog log = new strLog();
            log.Uid = Guid.NewGuid().ToString();
            log.Fecha = fecha;
            log.Accion = accion;
            log.Valor = valor;
            log.Modulo = modulo;
            log.Usuario = usuario;
            log.IP = (ip == null) ? Environment.MachineName : ip;
            daoLog.Insert(log);
        }
    }
}