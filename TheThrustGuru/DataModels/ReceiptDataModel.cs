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
        public string salesRepId { get; set; }
        public string salesRep { get; set; }
        public string repId { get; set; }
        public string customerId { get; set; }
        public string invoiceNo { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discount { get; set; }
        public decimal totalAmtPaid { get; set; }
        public decimal amountPayable { get; set; }
        public string salesType { get; set; }
        public string salesTypeId { get; set; }
        public decimal serviceCharge { get; set; }
        public DateTime date { get; set; }
        public List<SalesDataModel> soldItems { get; set; }
       

    }
}
