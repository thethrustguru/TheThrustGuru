using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
   public class VoucherDataModel
    {
        public string id  { get;set; }
        public string code { get; set; }
        public string customerId { get; set; }
        public int usedCount { get; set; }
    }
}
