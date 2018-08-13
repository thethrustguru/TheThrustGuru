using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class RecipeResultDataModel
    {
        [JsonProperty(PropertyName = "success")]
        public bool success { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string message { get; set; }
    }
}
