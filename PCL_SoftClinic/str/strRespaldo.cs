using PCL_SoftClinic.dao;

namespace PCL_SoftClinic.str
{
    public class strRespaldo
    {
        public static int HacerRespaldo(string fileName)
        {
            return daoRespaldos.HacerRespaldo(fileName);
        }
    }
}