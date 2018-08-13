using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class RecipeItems
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public decimal totalPrice { get; set; }
        public int quantity { get; set; }
    }
}
