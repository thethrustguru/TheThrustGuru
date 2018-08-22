
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.DataModels;
using TheThrustGuru.Interfaces;
using TheThrustGuru.Utils;

namespace TheThrustGuru.Database
{
    class DatabaseOperations
    {
        public static void addData(List<FoodItemsDataModel.FoodItemModel> items)
        {

            //Open database or create if it doesn't exist
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                //get the collection for the table name supplied i.e 'Constants.FOOD_ITEM_TABLE_NAME'
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                try
                {
                    //loop through the data to be added to db and insert into the collection
                    foreach (FoodItemsDataModel.FoodItemModel item in items)
                    {
                        FoodItemCollection.EnsureIndex(x => x._id, true);
                        FoodItemCollection.Insert(item);
                    }
                } catch (LiteException ex)
                {
                    //show a messagebox with error message
                    MessageBox.Show(ex.Message, "Error");
                }

            } //The using block closes the DB connection automatically when done.  

        }

        public static void addSingleData(FoodItemsDataModel.FoodItemModel foodItem)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                try
                {
                    FoodItemCollection.EnsureIndex(x => x.name, true);
                    FoodItemCollection.Insert(foodItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        //Since LiteDb returns data as IEnumerable we choose to use that as return type
        public static IEnumerable<FoodItemsDataModel.FoodItemModel> getData()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                try
                {
                    var FoodItem = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);

                    //liteDB query to get 100 records in FoodItems Table and sort in ascending order using 'name' 
                    var data = FoodItem.Find(Query.All("name", Query.Ascending), limit: 100);

                    return data;

                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }

            }
        }

        public static void addRecipe(RecipeDataModel.RecipeData recipe)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);

                try
                {
                    RecipeCollection.EnsureIndex(x => x.id, true);
                    RecipeCollection.Insert(recipe);
                    foreach (var data in recipe.itemsData)
                    {
                        data.id = recipe.id;
                        RecipeItemsDataCollection.EnsureIndex(x => x.id);
                        RecipeItemsDataCollection.Insert(data);
                        FoodItemInRecipeCollection.Insert(new FoodItemsInRecipe { id = (FoodItemInRecipeCollection.Count() + 1).ToString(), itemId = data.id, foodItemId = data.foodItems._id });

                    }
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public static void addRecipe(RecipeDataModel recipeDataModel)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);

                try
                {
                    foreach (var recipe in recipeDataModel.results)
                    {

                        RecipeCollection.EnsureIndex(x => x.id, true);
                        RecipeCollection.Insert(recipe);
                        if (recipe.itemsData != null && recipe.itemsData.Any())
                            foreach (var data in recipe.itemsData)
                            {
                                data.recipeId = recipe.id;
                                RecipeItemsDataCollection.EnsureIndex(x => x.id);
                                RecipeItemsDataCollection.Insert(data);
                                if (data.foodItems != null)
                                    FoodItemInRecipeCollection.Insert(new FoodItemsInRecipe { id = (FoodItemInRecipeCollection.Count() + 1).ToString(), itemId = data.id, foodItemId = data.foodItems._id });

                            }
                    }
                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public static IEnumerable<RecipeDataModel.RecipeData> getRecipe()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel.RecipeData>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
                var RecipeItemsDataCollection = db.GetCollection<RecipeDataModel.RecipeData.items>(Constants.RECIPE_ITEMS_DATA);
                var FoodItemCollection = db.GetCollection<FoodItemsDataModel.FoodItemModel>(Constants.FOOD_ITEM_TABLE_NAME);


                var recipeData = RecipeCollection.Find(Query.All("recipeName", Query.Ascending), limit: 100);
                if (recipeData == null || !recipeData.Any())
                    return null;
                foreach (var recipe in recipeData)
                {
                    var recipeItems = RecipeItemsDataCollection.Find(Query.EQ("recipeId", recipe.id));
                    if (recipeItems == null || !recipeItems.Any())
                        return null;
                    for (int j = 0; j < recipeItems.Count(); j++)
                    {
                        var data = FoodItemInRecipeCollection.FindOne(Query.EQ("itemId", recipeItems.ElementAt(j).id));
                        if (data == null)
                            continue;
                        var food = FoodItemCollection.FindOne(Query.EQ("_id", data.foodItemId));
                        if (food == null)
                            continue;
                        recipeItems.ElementAt(j).foodItems = food;
                    }
                    recipe.itemsData = recipeItems.ToList();
                }
                return recipeData;


                //try
                //{
                //    var recipeData = RecipeCollection.Find(Query.All("recipeName", Query.Ascending), limit: 100);
                //    if (recipeData == null || !recipeData.Any())
                //        return null;
                //    foreach(var recipe in recipeData)
                //    {
                //        var recipeItems = RecipeItemsDataCollection.Find(Query.EQ("recipeId", recipe.id));
                //        if (recipeItems == null || !recipeItems.Any())
                //            return null;
                //        for (int j = 0; j <= recipeItems.Count(); j++)
                //        {
                //            var data = FoodItemInRecipeCollection.FindOne(Query.EQ("itemId", recipeItems.ElementAt(j).id));
                //            if (data == null)
                //                continue;
                //            var food = FoodItemCollection.FindOne(Query.EQ("_id", data.foodItemId));
                //            if (food == null)
                //                continue;
                //            recipeItems.ElementAt(j).foodItems = food;
                //        }
                //        recipe.itemsData = recipeItems.ToList();
                //    }
                //    return recipeData;
                //}catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return null;
                //}
            }
        }

        public static void deleteRecipe(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var RecipeCollection = db.GetCollection<RecipeDataModel>(Constants.RECIPE_TABLE_NAME);
                var FoodItemInRecipeCollection = db.GetCollection<FoodItemsInRecipe>(Constants.FOOD_ITEM_IN_RECIPE_TABLE_NAME);
            }
        }

        public static void saveToken(LoginResultDataModel loginResult)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var tokenCollection = db.GetCollection<LoginResultDataModel>(Constants.TOKEN_TABLE_NAME);
                int count = tokenCollection.Count();


                try
                {
                    if (count == 0)
                    {
                        loginResult.id = (count + 1);
                        tokenCollection.Insert(loginResult);
                    }
                    else
                    {
                        loginResult.id = count;
                        tokenCollection.Update(loginResult);
                    }


                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public static LoginResultDataModel getToken()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var tokenCollection = db.GetCollection<LoginResultDataModel>(Constants.TOKEN_TABLE_NAME);
                try
                {
                    return tokenCollection.FindById(tokenCollection.Count());

                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return null;
                }
            }
        }

        public static void saveItems(ItemsDataModel items)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var itemCollection = db.GetCollection<ItemsDataModel>(Constants.ITEM_TABLE_NAME);
                int count = itemCollection.Count();

                try
                {
                    items.id = (count + 1).ToString();
                    itemCollection.EnsureIndex(x => x.id, true);
                    itemCollection.Insert(items);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<ItemsDataModel> getItems()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var itemCollection = db.GetCollection<ItemsDataModel>(Constants.ITEM_TABLE_NAME);
                try
                {
                    return itemCollection.Find(Query.All("itemName", Query.Ascending), limit: 100);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void AddFood(FoodsDataModel foods)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var foodsCollection = db.GetCollection<FoodsDataModel>(Constants.FOODS_TABLE_NAME);
                try
                {
                    int index = foodsCollection.Count() + 1;
                    foods.id = index.ToString();
                    foodsCollection.EnsureIndex(x => x.id, true);
                    foodsCollection.Insert(foods);
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<FoodsDataModel> getFoods()
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var foodsCollection = db.GetCollection<FoodsDataModel>(Constants.FOODS_TABLE_NAME);
                try
                {
                    return foodsCollection.Find(Query.All("name", Query.Ascending));
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addSuppliers(SupplierDataModel suppliers)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var suppliersCollection = db.GetCollection<SupplierDataModel>(Constants.SUPPLIERS_TABLE_NAME);
                try
                {
                    int index = suppliersCollection.Count() + 1;
                    suppliers.id = index.ToString();
                    suppliersCollection.EnsureIndex(x => x.id, true);
                    suppliersCollection.Insert(suppliers);
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<SupplierDataModel> getSuppliers()
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var suppliersCollection = db.GetCollection<SupplierDataModel>(Constants.SUPPLIERS_TABLE_NAME);
                try
                {
                    return suppliersCollection.Find(Query.All("name", Query.Ascending));
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addPurchases(PurchaseDataModel purchase)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseDataModel>(Constants.PURCHASE_TABLE_NAME);
                var productCollections = db.GetCollection<PurchaseDataModel.Product>(Constants.PRODUCTS_TABLE_NAME);
                try
                {
                    int index = purchaseCollections.Count() + 1;
                    purchase.id = index.ToString();
                    purchaseCollections.EnsureIndex(x => x.id, true);
                    purchaseCollections.Insert(purchase);
                    foreach (var data in purchase.productsList)
                    {
                        data.id = (productCollections.Count() + 1).ToString();
                        data.purchaseId = index.ToString();
                        productCollections.Insert(data);

                    }
                } catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<PurchaseDataModel> getPurchases()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseDataModel>(Constants.PURCHASE_TABLE_NAME);
                var productCollections = db.GetCollection<PurchaseDataModel.Product>(Constants.PRODUCTS_TABLE_NAME);
                try
                {
                    var data = purchaseCollections.Find(Query.All("date", Query.Descending));
                    if (!data.Any())
                        return null;
                    for (int i = 0; i < data.Count(); i++)
                    {
                        var product = productCollections.Find(x => x.purchaseId == data.ElementAt(i).id);
                        if (product.Any())
                            data.ElementAt(i).productsList = product.ToList();
                    }
                    return data;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addCustomers(CustomerDataModel customers)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    int index = customerCollections.Count() + 1;
                    customers.id = index.ToString();
                    customerCollections.Insert(customers);

                    VoucherDataModel voucher = new VoucherDataModel()
                    {
                        id = (voucherCollections.Count() + 1).ToString(),
                        code = customers.voucherCode,
                        customerId = index.ToString(),
                        usedCount = 0
                    };
                    voucherCollections.Insert(voucher);

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<CustomerDataModel> getCustomers()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    return customerCollections.Find(Query.All("customerName", Query.Ascending));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static IEnumerable<CustomerDataModel> getCustomers(bool value)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    return customerCollections.Find(x => x.isVoucherAvailable == value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static string getCustomerName(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    var data = customerCollections.FindOne(x => x.id == id);
                    if (data != null)
                        return data.customerName;
                    else return "";
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }

        public static void addVoucher(VoucherDataModel voucher)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    int index = voucherCollections.Count() + 1;
                    voucher.id = index.ToString();
                    voucherCollections.Insert(voucher);
                    var data = customerCollections.FindOne(x => x.id == voucher.customerId);
                    if (data != null)
                    {
                        data.isVoucherAvailable = true;
                        data.voucherCode = voucher.code;
                        customerCollections.Update(data);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<VoucherDataModel> getVouchers()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    return voucherCollections.Find(Query.All());
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addSalesRep(SalesRepDataModel salesRep)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesRepCollections = db.GetCollection<SalesRepDataModel>(Constants.SALES_REP_TABLE_NAME);
                try
                {
                    int index = salesRepCollections.Count() + 1;
                    salesRep.id = index.ToString();
                    salesRepCollections.Insert(salesRep);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<SalesRepDataModel> getSalesReps()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesRepCollections = db.GetCollection<SalesRepDataModel>(Constants.SALES_REP_TABLE_NAME);
                try
                {
                    return salesRepCollections.Find(Query.All("name", Query.Ascending));
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addVendors(VendorDataModel vendor)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var vendorCollections = db.GetCollection<VendorDataModel>(Constants.VENDOR_TABLE_NAME);

                try
                {
                    int index = vendorCollections.Count() + 1;
                    vendor.id = index.ToString();
                    vendorCollections.Insert(vendor);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<VendorDataModel> getVendors()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var vendorCollections = db.GetCollection<VendorDataModel>(Constants.VENDOR_TABLE_NAME);

                try
                {
                    return vendorCollections.Find(Query.All("name", Query.Ascending));
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addExpenses(ExpensesDataModel expense)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var expenseCollections = db.GetCollection<ExpensesDataModel>(Constants.EXPENSES_TABLE_NAME);
                try
                {
                    int index = expenseCollections.Count() + 1;
                    expense.id = index.ToString();
                    expenseCollections.Insert(expense);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<ExpensesDataModel> getExpenses()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var expenseCollections = db.GetCollection<ExpensesDataModel>(Constants.EXPENSES_TABLE_NAME);
                try
                {
                    //TODO Add sorting order in the query
                    return expenseCollections.Find(Query.All());
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addReceipt(ReceiptDataModel receipt)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var receiptCollections = db.GetCollection<ReceiptDataModel>(Constants.RECEIPT_TABLE_NAME);
                var soldItemsCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    int index = receiptCollections.Count() + 1, index2;
                    receipt.id = index.ToString();
                    receiptCollections.Insert(receipt);

                    if (receipt.soldItems != null && receipt.soldItems.Count > 0)
                        foreach (var data in receipt.soldItems)
                        {
                            index2 = soldItemsCollection.Count() + 1;
                            data.id = index2.ToString();
                            data.receiptId = index.ToString();
                            soldItemsCollection.Insert(data);
                        }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public static IEnumerable<ReceiptDataModel> getReceipts()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var receiptCollections = db.GetCollection<ReceiptDataModel>(Constants.RECEIPT_TABLE_NAME);
                var soldItemsCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    var receipts = new List<ReceiptDataModel>(receiptCollections.Find(Query.All()).ToList());
                    if (receipts != null && receipts.Any())
                        for (int i = 0; i < receipts.Count(); i++)
                        {
                            var soldItem = soldItemsCollection.Find(x => x.receiptId == receipts.ElementAt(i).id);
                            if (soldItem != null && soldItem.Any())
                                receipts.ElementAt(i).soldItems = soldItem.ToList();
                        }
                    return receipts;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addStocks(StockDataModel stock)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    int index = stockCollections.Count() + 1;
                    stock.id = index.ToString();
                    stockCollections.Insert(stock);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<StockDataModel> getStocks()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    return stockCollections.Find(Query.All("name", Query.Ascending));
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<StockDataModel> getStockById(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    return stockCollections.FindOne(x => x.id == id);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void addCategory(CategoryDataModel category)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    int index = categoryCollections.Count() + 1;
                    category.id = index.ToString();
                    categoryCollections.Insert(category);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public static IEnumerable<CategoryDataModel> getCategory()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    return categoryCollections.Find(Query.All("name", Query.Ascending));
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}
