using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    class Constants
    {
        public static string DB_NAME = "THE_THRUST_GURU_DB";
        public static string FOOD_ITEM_TABLE_NAME = "FOOD_ITEM_TABLE";
        public static string RECIPE_TABLE_NAME = "RECIPE_TABLE";
        public static string FOOD_ITEM_IN_RECIPE_TABLE_NAME = "FOOD_ITEM_IN_RECIPE_TABLE";
        public static string TOKEN_TABLE_NAME = "TOKEN_TABLE_NAME";
        public static string INTERNET_CONNECTION_ERROR = "Internet Connection Error";
        public static string INTERNET_CONNECTION_ERR_MSG = "There seems to be no internet connection or your internet connection is " +
            "bad. \nPlease troubleshoot your connection and try again later.";
        public static string RECIPE_ITEMS_DATA = "RECIPE_ITEMS_DATA_TABLE";
        public static string ITEM_TABLE_NAME = "ITEM_TABLE";
        public static string FOODS_TABLE_NAME = "FOODS_TABLE";
        public static string SUPPLIERS_TABLE_NAME = "SUPPLIERS_TABLE";       
        public static string PURCHASE_TABLE_NAME = "PURCHASE_TABLE";
        public static string PRODUCTS_TABLE_NAME = "PRODUCTS_TABLE";
        public static string CUSTOMER_TABLE_NAME = "CUSTOMER_TABLE";
        public static string VOUCHER_TABLE_NAME = "VOUCHER_TABLE";
        public static string SALES_REP_TABLE_NAME = "SALES_REP_TABLE";
        public static string VENDOR_TABLE_NAME = "VENDOR_TABLE";
        public static string EXPENSES_TABLE_NAME = "EXPENSES_TABLE";
        public static string RECEIPT_TABLE_NAME = "RECEIPT_TABLE";
        public static string SALES_TABLE_NAME = "SALES_TABLE";
        public static string STOCK_TABLE_NAME = "STOCK_TABLE";
        public static string CATEGORY_TABLE_NAME = "CATEGORY_TABLE";

        public static int VOUCHER_CODE_LENGTH = 9;
        public static int REP_ID_LENGTH = 5;
        public static int INVOICE_NO_LENGTH = 7;
    }
}
