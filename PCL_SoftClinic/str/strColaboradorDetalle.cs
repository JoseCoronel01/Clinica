using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_SoftClinic.str
{
    public class strColaboradorDetalle
    {
        public long Id { get; set; }
        public long ColaboradorId { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Importe { get; set; }
        public bool Pagado { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Concepto { get; set; }
    }
}
