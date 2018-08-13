using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    public class LoginResultDataModel
    {
        public int id { get; set; }
        [JsonProperty(PropertyName = "success")]
        public bool status { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string token { get; set; }
    }
}
