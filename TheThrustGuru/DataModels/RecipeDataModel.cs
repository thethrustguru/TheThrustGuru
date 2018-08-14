using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class RecipeDataModel
    {
        [JsonProperty(PropertyName = "success")]
        public bool status { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<RecipeData> results { get; set; }
       
        public class RecipeData
        {
            [JsonProperty(PropertyName = "_id")]
            public string id { get; set; }
            [JsonProperty(PropertyName = "name")]
            public string recipeName { get; set; }
            [JsonProperty(PropertyName = "desc")]
            public string recipeDesc { get; set; }
            [JsonProperty(PropertyName = "items")]
            public List<items> itemsData { get; set; }

            public class items
            {
               
                [JsonProperty(PropertyName = "_id")]
                public string id { get; set; }
                [JsonProperty(PropertyName = "unit")]
                public string unit { get; set; }
                [JsonProperty(PropertyName = "quantity")]
                public int quantity { get; set; }
                [JsonProperty(PropertyName = "itemId")]
                public FoodItemsDataModel.FoodItemModel foodItems { get; set; }
                public string recipeId { get; set; }
            }     

        }
    }
}
