using System;

namespace PCL_SoftClinic.str
{
    public class strPago
    {
        public string Uid { get; set; }
        public long? Tratamiento { get; set; }
        public DateTime? Fecha { get; set; }
        public string Folio { get; set; }
        public decimal? Importe { get; set; }
        public string Concepto { get; set; }
    }
}