using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_SoftClinic.str
{
    public class strDocumento
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionBreve { get; set; }
        public string Etiqueta { get; set; }
        public int Tipo { get; set; }
        public byte[] Archivo { get; set; }
    }
}