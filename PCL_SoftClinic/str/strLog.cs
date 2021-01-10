using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_SoftClinic.str
{
    public class strLog
    {
        public string Uid { get; set; }
        public DateTime Fecha { get; set; }
        public byte Accion { get; set; }
        public string Valor { get; set; }
        public string Modulo { get; set; }
        public string Usuario { get; set; }
        public string IP { get; set; }
    }
}