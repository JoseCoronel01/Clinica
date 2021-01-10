using System.Collections.Generic;
using PCL_Comun.Utilidades;

namespace UI_SoftClinic.Code
{
    public class Base
    {
        public static List<ElementoComboBox> TiposDeTratamiento()
        {
            List<ElementoComboBox> elementos = new List<ElementoComboBox>();

            elementos.Add(new ElementoComboBox() { value = "1", text = "ETAPA EXPERIMENTAL" });

            elementos.Add(new ElementoComboBox() { value = "2", text = "SEGUIMIENTO DE TRATAMIENTO" });

            elementos.Add(new ElementoComboBox() { value = "3", text = "PREVENCIÓN DE RECAÍDAS" });

            return elementos;
        }
    }
}