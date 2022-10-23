using System;

namespace PCL_SoftClinic.str
{
    public class strTratamiento
    {
        public long Id { get; set; }
        public long? Paciente { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal? CostoIngreso { get; set; }
        //public decimal? PlanMensual { get; set; }
        public override string ToString()
        {
            return "Desde " + this.FechaIngreso.Value.ToShortDateString() + " Hasta " + this.FechaSalida.Value.ToShortDateString();
        }
    }
}