using System.Collections.Generic;
using PCL_SoftClinic.str;
using PCL_Comun.Utilidades;

namespace PCL_SoftClinic.BusinessRules
{
    public class strBRUsuarioSistema
    {
        public static List<ElementoComboBox> TiposUsuario()
        {
            return new List<ElementoComboBox>()
            {
                CrearTipoUsuario(strUsuario.eTipo.SUPERVISOR, "SUPERVISOR"),
                CrearTipoUsuario(strUsuario.eTipo.OPERADOR, "OPERADOR")
            };
        }

        private static ElementoComboBox CrearTipoUsuario(strUsuario.eTipo value, string text)
        {
            return new ElementoComboBox() { value = value, text = text };
        }
    }
}