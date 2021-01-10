using PCL_SoftClinic.str;

namespace PCL_SoftClinic.BusinessRules
{
    public class BRRespaldar
    {
        public int Respaldo(string fileName)
        {
            return strRespaldo.HacerRespaldo(fileName);
        }
    }
}