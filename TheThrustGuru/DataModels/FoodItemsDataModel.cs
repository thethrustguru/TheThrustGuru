using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheThrustGuru.DataModels
{
    public class FoodItemsDataModel
    {
        [JsonProperty(PropertyName = "success")]
        public bool status { set; get; }

        [JsonProperty(PropertyName = "results")]
        public List<FoodItemModel> results { set; get; }

        public class FoodItemModel
        {
            [JsonProperty(PropertyName = "_id")]
            public string _id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string name { get; set; }

            [JsonProperty(PropertyName = "count")]
            public int count { get; set; }

            [JsonProperty(PropertyName = "price")]
            public decimal price { get; set; }

            [JsonProperty(PropertyName = "selling_price")]
            public decimal sellingPrice { get; set; }

            [JsonProperty(PropertyName = "total_price")]
            public decimal total_price { get; set; }

            [JsonProperty(PropertyName = "date_added")]
            public string date_added { get; set; }

            [JsonProperty(PropertyName = "date_lastmodified")]
            public string date_lastmodified { get; set; }

            [JsonProperty(PropertyName = "_v")]
            public int _v { get; set; }

        }
    }
}
