using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class StoreLocationDataModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool show { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
