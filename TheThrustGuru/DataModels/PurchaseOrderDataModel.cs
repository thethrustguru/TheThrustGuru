using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class PurchaseOrderDataModel
    {
        public string id { get; set; }       
        public string supplierName { get; set; }
        public string supplierId { get; set; }                   
        public string staffName { get; set; }
        public string staffId { get; set; }
        public string status { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime deliveryDate { get; set; }
        public string orderNo { get; set; }
        public int grandTotalQuantity { get; set; }
        public decimal grandTotalPrice { get; set; }
        public List<PurchasedStock> productsList { get; set; }

        public class PurchasedStock
        {
            public string id { get; set; }
            public string stockId { get; set; }
            public string purchaseId { get; set; }           
            public int quantityToSupply { get; set; }
            public DateTime dateCreated { get; set; }

        }
    }
}
