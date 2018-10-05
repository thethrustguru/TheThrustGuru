using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class SalesDataModel
    {
        public string id { get; set; }
        public string stockId { get; set; }
        public decimal lastCostPrice { get; set; }
        public decimal soldPrice { get; set; }
        public string receiptId { get; set; }
        public string storeLocation { get; set; }
        public DateTime date { get; set; }
        
        
    }
}
