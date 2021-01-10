using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_SoftClinic.str
{
    public class strNotaEvolucion
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public long Paciente { get; set; }
        public string Usuario { get; set; }
        public int Estado { get; set; }
    }
}