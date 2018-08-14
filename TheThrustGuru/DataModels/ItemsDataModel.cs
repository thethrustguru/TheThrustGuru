using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class ItemsDataModel
    {
        public string id { get; set; }
        public string itemName { get; set; }
        public decimal itemSellingPrice { get; set; }
        public decimal itemCostPrice { get; set; }
        public int itemQuantity { get; set; }
        public string itemCategory { get; set; }
        public string dateCreated { get; set; }

      
    }
}
