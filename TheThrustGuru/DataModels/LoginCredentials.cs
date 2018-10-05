using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class LoginCredentials
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salesRepId { get; set; }
        public bool isAdmin { get; set; }
        public string storeLocation { get; set; }
        public string role { get; set; }
    }
}
