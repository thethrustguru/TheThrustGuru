using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class CustomerDataModel
    {
        public string id { get; set; }
        public string customerName { get; set; }
        public string phone { get; set; }
        public bool isVoucherAvailable { get; set; }
        public string voucherCode { get; set; }
        public string address { get; set; }
        public string other { get; set; }

    }
}
