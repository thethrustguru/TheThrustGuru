using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.DataModels
{
    class ReceiptDataModel
    { 
        public string id { get; set; }
        public string salesRep { get; set; }
        public string repId { get; set; }
        public string invoiceNo { get; set; }
        public decimal totalPrice { get; set; }
        public string discount { get; set; }
        public decimal totalAmtPaid { get; set; }
        public string salesType { get; set; }
        public string serviceCharge { get; set; }
        public string date { get; set; }
        public List<SalesDataModel> soldItems { get; set; }
       

    }
}
