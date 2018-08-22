using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class ExpensesDataModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public string date { get; set; }
        public string desc { get; set; }
        
    }
}
