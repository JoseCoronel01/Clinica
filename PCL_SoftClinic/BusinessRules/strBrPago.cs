using System;
using System.Collections.Generic;
using System.Linq;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace PCL_SoftClinic.BusinessRules
{
    public class strBrPago
    {
        public List<strPago> ConvertPagosGrid(List<strPago> lista, long idTratamiento, long idPaciente)
        {
            strTratamiento str = daoTratamiento.GetObject(idTratamiento, idPaciente);

            List<strPago> pagos = null;

            while (str.FechaIngreso.Value <= str.FechaSalida.Value)
            {
                DateTime fecha = str.FechaIngreso.Value;
                long? bPago = null;
                if (lista != null)
                    bPago = lista.Where(a => a.Fecha.Value.Date == fecha.Date).Select(b => b.Tratamiento).FirstOrDefault();
                if (pagos == null)
                {
                    pagos = new List<strPago>();

                    if (bPago == null)
                    {
                        pagos.Add(new strPago()
                        {
                            Tratamiento = idTratamiento,
                            Fecha = fecha,
                            Folio = "S/N",
                            Importe = str.CostoIngreso,
                            Concepto = ""
                        });
                    }
                }
                else
                {
                    if (bPago == null)
                    {
                        pagos.Add(new strPago()
                        {
                            Tratamiento = idTratamiento,
                            Fecha = fecha,
                            Folio = "S/N",
                            //Importe = str.PlanMensual / 4,
                            Concepto = ""
                        });
                    }
                }
                str.FechaIngreso = str.FechaIngreso.Value.AddDays(7);
            }

            return pagos;
        }
    }
}