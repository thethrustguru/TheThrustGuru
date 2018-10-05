using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class StockTransferRecordDataModel
    {
        public string id { get; set; }
        public string transferId { get; set; }
        public string toStoreName { get; set; }
        public string toStoreId { get; set; }
        public string fromStoreName { get; set; }
        public string fromStoreId { get; set; }
        public DateTime dateCreated { get; set; }
        public List<StockItems> stockItems { get; set; }
        
        public class StockItems
        {
            public string stockId { get; set; }
            public int quantity { get; set; }
        }        
    }
}
