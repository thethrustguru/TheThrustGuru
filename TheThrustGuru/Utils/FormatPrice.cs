using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    class FormatPrice
    {
        public static string format(decimal value)
        {
            return "₦" + value.ToString("N2");
        }
    }
}
