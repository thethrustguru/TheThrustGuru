using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class ServiceChargeDataModel
    {
        public string id { get; set;}
        public decimal discount { get; set; }
        public bool isPercent { get; set; }
        public string title { get; set; }
        public decimal percent { get; set; }

    }
}
