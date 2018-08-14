using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    public class NetworkConnectivity
    {
        public static bool DnsTest()
        {
            try
            {
                System.Net.IPHostEntry ipHe =
                    System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
