using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class StockAdjustmentDataModel
    {
        public string id { get; set; }
        public string stockName { get; set; }
        public string stockId { get; set; }
        public int initialQuantity { get; set; }
        public int newQuantity { get; set; }
        public int adjustedQuantity { get; set; }
        public string description { get; set; }
        public string categoryName { get; set; }
        public string categoryId { get; set; }
        public string storeName { get; set; }
        public string storeId { get; set; }
        public DateTime date { get; set; }

    }
}
