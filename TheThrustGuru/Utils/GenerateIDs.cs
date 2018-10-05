using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    class GenerateIDs
    {

        public static string purchaseOrderId()
        {
            string po = "PO-";
            string id = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            return po + id;
        }

        public static string salesRepId()
        {
            string sr = "SR-";
            string id = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            return sr + id;
        }

        public static string invoiceId()
        {
            string inv = "IN-";
            string id = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            return inv + id;
        }

        public static string password()
        {
            return RandomIDGenerator.randomString(Constants.PASSWORD_LENGTH);
        }

        public static string transferId()
        {
            string tr = "TR-";
            string id = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            return tr + id;
        }

        public static string receivedNoteId()
        {
            string rn = "RN-";
            string id = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            return rn + id;
        }

        public static string voucherCode()
        {
            return RandomIDGenerator.randomString(Constants.VOUCHER_CODE_LENGTH);
        }
    }
}
