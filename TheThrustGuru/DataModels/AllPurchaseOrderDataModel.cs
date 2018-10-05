using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class AllPurchaseOrderDataModel
    {
        public string id { get; set; }
        public string date { get; set; }
        public string orderRef { get; set; }
        public string vendorName { get; set; }
        public string supplierName { get; set; }
        public string status { get; set; }
        public string deliveryDate { get; set; }
        public decimal amount { get; set; }

    }
}
