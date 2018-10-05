using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class StockDataModel
    {
        public string id { get; set; }
        public string vendorId { get; set; }
        public string categoryId { get; set; }
        public string storeId { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string unit { get; set; }
        public string desc { get; set; }
        public decimal highestCostPrice { get; set; }
        public decimal lowestCostPrice { get; set; }
        public decimal lastCostPrice { get; set; }    
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public string storeLocation { get; set; }
        public DateTime date { get; set; }
        

    }
}
