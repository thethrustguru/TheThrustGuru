using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class RecipesDataModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public decimal price { get; set; }
        public string soldBy { get; set; }
        public DateTime dateCreated { get; set; }
        public List<RecipeItems> recipeItems { get; set; }

        public class RecipeItems
        {
            public string id { get; set; }
            public string recipeId { get; set; }
            public string stockId { get; set; }
            public int quantity { get; set; }
        }
    }
}
