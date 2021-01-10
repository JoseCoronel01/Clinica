using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaApp.Code
{
    public static class EnumLog
    {
        public enum TipoLog
        {
            Insert = 0, Update = 1, Delete = 2, Login = 3, Select = 4, BackUp = 5, Modulo = 6
        }
    }
}