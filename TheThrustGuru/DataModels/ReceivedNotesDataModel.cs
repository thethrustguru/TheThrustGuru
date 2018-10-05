using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class ReceivedNotesDataModel
    {
        public string id { get; set; }
        public string purchaseId { get; set; }
        public string grnId { get; set; }
        public string orderId { get; set; }
        public decimal amount { get; set; }
        public DateTime dateReceived { get; set; }
        public List<GoodsReceived> goodsReceived { get; set; }


        public class GoodsReceived
        {
            public string stockId { get; set; }
            public int quantity { get; set; }
        }
    }
}
