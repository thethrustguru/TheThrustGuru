using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    class DateTimeUtils
    {
        private static string dateFormat = "yyyy-MM-dd'T'HH:mm:ss'Z'";

        public static string date(string dateTime)
        {
            DateTime dt = DateTime.Parse(dateTime);

            string s = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            return s;
        }
    }
}
