using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL_Comun.Utilidades;
using PCL_SoftClinic.str;
using PCL_SoftClinic.dao;

namespace PCL_SoftClinic.BusinessRules
{
    public class strBrPaciente
    {
        public List<ElementoComboBox> BusquedaPacientes(string filtro, List<strPaciente> lista)
        {
            List<ElementoComboBox> elementos = new List<ElementoComboBox>();

            elementos.Add(new ElementoComboBox() { value = "-1", text = "=Seleccionar paciente=" });

            if (lista == null)
            {
                return elementos;
            }
            else
            {
                var list = (from p in lista
                            where p.ApellidoPaterno.StartsWith(filtro) ||
                            p.ApellidoPaterno.Contains(filtro) ||
                            p.ApellidoPaterno.EndsWith(filtro) ||
                            p.Nombre.StartsWith(filtro) ||
                            p.Nombre.Contains(filtro) ||
                            p.Nombre.EndsWith(filtro) ||
                            p.ApellidoMaterno.StartsWith(filtro) ||
                            p.ApellidoMaterno.Contains(filtro) ||
                            p.ApellidoMaterno.EndsWith(filtro)
                            select p).ToList();

                foreach (var item in list)
                    elementos.Add(new ElementoComboBox() { value = item.Id, text = item.ToString() });
            }

            return elementos;
        }
    }
}