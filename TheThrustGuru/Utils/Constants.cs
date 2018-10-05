using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    class Constants
    {
        public static string DB_NAME = "APP_DB";
        public static string FOOD_ITEM_TABLE_NAME = "foodItem";
        public static string RECIPE_TABLE_NAME = "recipes";
        public static string FOOD_ITEM_IN_RECIPE_TABLE_NAME = "foodRecipe";
        public static string TOKEN_TABLE_NAME = "token";
        public static string INTERNET_CONNECTION_ERROR = "Internet Connection Error";
        public static string INTERNET_CONNECTION_ERR_MSG = "There seems to be no internet connection or your internet connection is " +
            "bad. \nPlease troubleshoot your connection and try again later.";
        public static string RECIPE_ITEMS_TABLE_NAME = "recipeItems";
        public static string ITEM_TABLE_NAME = "item";
        public static string FOODS_TABLE_NAME = "foods";
        public static string SUPPLIERS_TABLE_NAME = "supplier";       
        public static string PURCHASE_TABLE_NAME = "purchase";
        public static string PRODUCTS_TABLE_NAME = "products";
        public static string CUSTOMER_TABLE_NAME = "customers";
        public static string VOUCHER_TABLE_NAME = "vouchers";
        public static string SALES_REP_TABLE_NAME = "salesRep";
        public static string VENDOR_TABLE_NAME = "vendor";
        public static string EXPENSES_TABLE_NAME = "expenses";
        public static string RECEIPT_TABLE_NAME = "receipt";
        public static string SALES_TABLE_NAME = "sales";
        public static string STOCK_TABLE_NAME = "stock";
        public static string CATEGORY_TABLE_NAME = "category";
        public static string SERVICE_CHARGE_TABLE_NAME = "serviceCharge";
        public static string SALES_TYPE_TABLE_NAME = "salesType";
        public static string STORE_LOCATION_TABLE_NAME = "storeLoc";
        public static string LOGIN_CREDENTIALS_TABLE_NAME = "loginCred";       
        public static string STOCK_RECORD_TABLE_NAME = "stockRcrd";
        public static string TRANSFERED_ITEMS_TABLE_NAME = "transItem";
        public static string RECEIVED_NOTES_TABLE_NAME = "notes";
        public static string SOLD_RECIPES = "soldRecipes";
        public static string STOCK_ADJUSTMENT_TABLE = "adjustment";
        public static string CLIENT_USERNAME = "CLIENT";
        public static string CLIENT_PASSWORD = "t2hg4u";
        public static string CLIENT_TABLE_NAME = "client";
        public const string ROLE_SALES_REP = "SALES_REP";
        public const string ROLE_CLIENT = "CLIENT";
        public static string[] ROLES = { "Admin","Supervisor","Audit","Manager","Staff"};
        public static string[] STORE_LOCATIONS = { "Bar", "Bakery", "Hotel", "Laundry", "Restuarant", "Park" };


        public static string PASSCODE = "3957";
        public static int VOUCHER_CODE_LENGTH = 9;
        public static int REP_ID_LENGTH = 5;
        public static int INVOICE_NO_LENGTH = 5;        
        public static int PASSWORD_LENGTH = 6;
        
    }
}


//var json = JsonSerializer.Serialize(new BsonArray(db.Engine.Find("mycol")));

//db.Engine.Insert("mycol", JsonSerializer.Deserialize(json).AsArray.ToArray());