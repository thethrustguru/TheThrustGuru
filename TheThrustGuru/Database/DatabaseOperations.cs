
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static void showMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
                }
                catch (LiteException ex)
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

                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }

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
                }
                catch (LiteException ex)
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
                }
                catch (LiteException ex)
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
                    suppliersCollection.Insert(suppliers);
                }
                catch (LiteException ex)
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
                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> editSupplier(SupplierDataModel supplier)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var suppliersCollection = db.GetCollection<SupplierDataModel>(Constants.SUPPLIERS_TABLE_NAME);
                try
                {
                    return suppliersCollection.Update(supplier);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteSupplier(string id)
        {
            using (var db = new LiteDatabase(@Constants.DB_NAME))
            {
                var suppliersCollection = db.GetCollection<SupplierDataModel>(Constants.SUPPLIERS_TABLE_NAME);
                try
                {
                    return suppliersCollection.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> addClient(ClientDataModel client)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var clientCollections = db.GetCollection<ClientDataModel>(Constants.CLIENT_TABLE_NAME);
                var loginCollections = db.GetCollection<LoginCredentials>(Constants.LOGIN_CREDENTIALS_TABLE_NAME);
                try
                {
                    var data = clientCollections.FindOne(x => x.name == client.name);
                    if(data != null)
                    {
                        MessageBox.Show("Client Name already exists");
                        return false;
                    }
                    int index = clientCollections.Count() + 1;
                    int index2 = loginCollections.Count() + 1;
                    client.id = index.ToString();
                    clientCollections.Insert(client);
                    clientCollections.EnsureIndex(x => x.name);
                    var dt = new LoginCredentials
                    {
                        id = index2.ToString(),
                        username = client.username,
                        password = client.password,
                        isAdmin = false,
                        role = client.role,
                        storeLocation = client.storeLocation

                    };             
                    var dr = loginCollections.Insert(dt);
                    return true;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<List<ClientDataModel>> getClients()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var clientCollections = db.GetCollection<ClientDataModel>(Constants.CLIENT_TABLE_NAME);
                try
                {
                    return clientCollections.Find(Query.All()).ToList();
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
        }
        }

        public static async Task<bool> editClient(ClientDataModel client)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var clientCollections = db.GetCollection<ClientDataModel>(Constants.CLIENT_TABLE_NAME);
                try
                {
                    return clientCollections.Update(client);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteClient(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var clientCollections = db.GetCollection<ClientDataModel>(Constants.CLIENT_TABLE_NAME);
                try
                {
                    return clientCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static void addPurchases(PurchaseOrderDataModel purchase)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                var productCollections = db.GetCollection<PurchaseOrderDataModel.PurchasedStock>(Constants.PRODUCTS_TABLE_NAME);
                try
                {
                    int index = purchaseCollections.Count() + 1;
                    purchase.id = index.ToString();
                    purchaseCollections.Insert(purchase);
                    foreach (var data in purchase.productsList)
                    {
                        data.id = (productCollections.Count() + 1).ToString();
                        data.purchaseId = index.ToString();
                        data.dateCreated = DateTime.Now;
                        productCollections.Insert(data);

                    }
                }
                catch (LiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static IEnumerable<PurchaseOrderDataModel> getPurchases()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    return purchaseCollections.Find(Query.All());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<PurchaseOrderDataModel> getPurchaseOrderById(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    return purchaseCollections.FindOne(x => x.id == id);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<PurchaseOrderDataModel> getPurchaseOderByOrderId(string orderid)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    return purchaseCollections.FindOne(x => x.orderNo == orderid);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editpurchases(PurchaseOrderDataModel purchases)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    return purchaseCollections.Update(purchases);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deletePurchase(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    return purchaseCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        //public static async Task<IEnumerable<PurchaseOrderDataModel>> getPurchasesByDate(DateTime dateFrom, DateTime dateTo)
        //{
        //    using (var db = new LiteDatabase(Constants.DB_NAME))
        //    {
        //        var purchaseCollections = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
        //        try
        //        {
        //            var data = purchaseCollections.Find(x => x.dat)
        //        }catch(Exception ex)
        //        {
        //            showMessage(ex);
        //            return null;
        //        }
        //    }
        //}

        public static async Task<List<PurchaseOrderDataModel.PurchasedStock>> getPurchasedStocksByDate(DateTime dateFrom, DateTime dateTo)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var productCollections = db.GetCollection<PurchaseOrderDataModel.PurchasedStock>(Constants.PRODUCTS_TABLE_NAME);
                try
                {
                    var data = productCollections.Find(x => x.dateCreated >= dateFrom && x.dateCreated <= dateTo);
                    return data.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> addCustomers(CustomerDataModel customers)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    var data = customerCollections.Find(x => x.customerName == customers.customerName);
                    if (data != null && data.Any())
                    {
                        MessageBox.Show("Customer already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }                       

                    int index = customerCollections.Count() + 1;
                    customers.id = index.ToString();
                    customerCollections.Insert(customers);

                    if (!string.IsNullOrEmpty(customers.voucherCode))
                    {
                        VoucherDataModel voucher = new VoucherDataModel()
                        {
                            id = (voucherCollections.Count() + 1).ToString(),
                            code = customers.voucherCode,
                            customerId = index.ToString(),
                            usedCount = 0
                        };
                        voucherCollections.Insert(voucher);
                    }                    
                    return true;

                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
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

        public static IEnumerable<CustomerDataModel> getCustomers(bool isVoucherAvailable)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    return customerCollections.Find(x => x.isVoucherAvailable == isVoucherAvailable);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }

        public static async Task<bool> editCustomers(CustomerDataModel customers)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    return customerCollections.Update(customers);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteCustomers(CustomerDataModel customer)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                try
                {
                    return customerCollections.Delete(customer.id);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
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
                }
                catch (Exception ex)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> editVoucher(VoucherDataModel voucher)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    return voucherCollections.Update(voucher);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteVoucher(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    return voucherCollections.Delete(id);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static void addSalesRep(SalesRepDataModel salesRep)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesRepCollections = db.GetCollection<SalesRepDataModel>(Constants.SALES_REP_TABLE_NAME);
                var loginCollections = db.GetCollection<LoginCredentials>(Constants.LOGIN_CREDENTIALS_TABLE_NAME);
                try
                {
                    int index = salesRepCollections.Count() + 1;
                    int index2 = loginCollections.Count() + 1;
                    salesRep.id = index.ToString();
                    salesRepCollections.Insert(salesRep);
                    loginCollections.Insert(new LoginCredentials
                    {
                        id = index2.ToString(),
                        username = salesRep.username,
                        password = salesRep.password,
                        isAdmin = false,
                        role = Constants.ROLE_SALES_REP,
                        storeLocation = salesRep.storeLocation,
                        salesRepId = index.ToString()
                    });
                }
                catch (Exception ex)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> editSalesRep(SalesRepDataModel salesRep)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesRepCollections = db.GetCollection<SalesRepDataModel>(Constants.SALES_REP_TABLE_NAME);
                try
                {
                    return salesRepCollections.Update(salesRep);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteSalesRep(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesRepCollections = db.GetCollection<SalesRepDataModel>(Constants.SALES_REP_TABLE_NAME);
                try
                {
                    return salesRepCollections.Delete(id);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static IEnumerable<LoginCredentials> getLoginDetails()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var loginCollections = db.GetCollection<LoginCredentials>(Constants.LOGIN_CREDENTIALS_TABLE_NAME);
                try
                {
                    return loginCollections.Find(Query.All());
                }
                catch (Exception ex)
                {
                    showMessage(ex);
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
                }
                catch (Exception ex)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> editVendors(VendorDataModel vendor)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var vendorCollections = db.GetCollection<VendorDataModel>(Constants.VENDOR_TABLE_NAME);

                try
                {
                    return vendorCollections.Update(vendor);
                } catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }

        }

        public static async Task<bool> deleteVendor(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var vendorCollections = db.GetCollection<VendorDataModel>(Constants.VENDOR_TABLE_NAME);

                try
                {
                    return vendorCollections.Delete(id);
                } catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
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

        public static async Task<IEnumerable<ExpensesDataModel>> getExpensesByDate(DateTime dateFrom, DateTime dateTo)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var expenseCollections = db.GetCollection<ExpensesDataModel>(Constants.EXPENSES_TABLE_NAME);
                try
                {
                    var data = expenseCollections.Find(x => x.date >= dateFrom && x.date <= dateTo);
                    return data;
                } catch (Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editExpenses(ExpensesDataModel expenses)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var expenseCollections = db.GetCollection<ExpensesDataModel>(Constants.EXPENSES_TABLE_NAME);
                try
                {
                    return expenseCollections.Update(expenses);
                } catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteExpense(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var expenseCollections = db.GetCollection<ExpensesDataModel>(Constants.EXPENSES_TABLE_NAME);
                try
                {
                    return expenseCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        } 

        public static async Task addReceipt(ReceiptDataModel receipt)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var receiptCollections = db.GetCollection<ReceiptDataModel>(Constants.RECEIPT_TABLE_NAME);
                var soldItemsCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                var customerCollections = db.GetCollection<CustomerDataModel>(Constants.CUSTOMER_TABLE_NAME);
                var voucherCollections = db.GetCollection<VoucherDataModel>(Constants.VOUCHER_TABLE_NAME);
                try
                {
                    int index = receiptCollections.Count() + 1, index2;
                    receipt.id = index.ToString();
                    receiptCollections.Insert(receipt);

                    if(receipt.customerId != null)
                    {
                        var customer = customerCollections.FindOne(x => x.id == receipt.customerId);
                        if(customer != null)
                        {
                            decimal bal = receipt.amountPayable - receipt.totalAmtPaid;
                            customer.balance += bal;
                            customerCollections.Update(customer);
                            var voucher = voucherCollections.FindOne(x => x.customerId == customer.id);
                            if(voucher != null)
                            {
                                voucher.usedCount += 1;
                                voucherCollections.Update(voucher);
                            }
                        }
                    }

                    if (receipt.soldItems != null && receipt.soldItems.Count > 0)
                        foreach (var data in receipt.soldItems)
                        {
                            index2 = soldItemsCollection.Count() + 1;
                            data.id = index2.ToString();
                            data.receiptId = index.ToString();
                            soldItemsCollection.Insert(data);

                            var stock = stockCollections.FindOne(x => x.id == data.stockId);
                            if (stock != null && stock.quantity >= 0)
                            {
                                stock.quantity -= 1;
                                stockCollections.Update(stock);
                            }
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
                    //if (receipts != null && receipts.Any())
                    //    for (int i = 0; i < receipts.Count(); i++)
                    //    {
                    //        var soldItem = soldItemsCollection.Find(x => x.receiptId == receipts.ElementAt(i).id);
                    //        if (soldItem != null && soldItem.Any())
                    //            receipts.ElementAt(i).soldItems = soldItem.ToList();
                    //    }
                    return receipts;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static async Task<bool> editReceipts(ReceiptDataModel receipt)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var receiptCollections = db.GetCollection<ReceiptDataModel>(Constants.RECEIPT_TABLE_NAME);               
                try
                {
                    return receiptCollections.Update(receipt);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteReceipt(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var receiptCollections = db.GetCollection<ReceiptDataModel>(Constants.RECEIPT_TABLE_NAME);
                try
                {
                    return receiptCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static IEnumerable<SalesDataModel> getSoldStocks()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var soldStocksCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    return soldStocksCollection.Find(Query.All());
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<IEnumerable<SalesDataModel>> getSoldStocksByDate(DateTime dateFrom, DateTime dateTo)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var soldStocksCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    var data = soldStocksCollection.Find(x => x.date >= dateFrom && x.date <= dateTo);
                    return data;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editSoldStocks(SalesDataModel sales)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var soldStocksCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    return soldStocksCollection.Update(sales);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }

        }

        public static async Task<bool> deleteSoldItems(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var soldStocksCollection = db.GetCollection<SalesDataModel>(Constants.SALES_TABLE_NAME);
                try
                {
                    return soldStocksCollection.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
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

        public static async Task<IEnumerable<StockDataModel>> getStocksByCategoryId(string categoryId)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    return stockCollections.Find(x => x.categoryId == categoryId);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<IEnumerable<StockDataModel>> getStocksByCategoryAndStore(string categoryId, string storeName)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    return stockCollections.Find(x => x.categoryId == categoryId && x.storeLocation == storeName);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }


        public static async Task<List<StockDataModel>> getStocksAvailableByDateCreated(DateTime dateCreated)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    var availableStocks = new List<StockDataModel>();
                    availableStocks = stockCollections.Find(x => x.date <= dateCreated).ToList();
                    return availableStocks;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<List<StockDataModel>> getAvailableStocks()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stocksCollection = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    var availableStocks = new List<StockDataModel>();
                    var data = stocksCollection.Find(Query.All());
                    if(data != null && data.Any())
                    {
                        foreach(var datum in data)
                        {
                            if (datum.quantity > 0)
                                availableStocks.Add(datum);
                        }
                    }
                    return availableStocks;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static void updateStock(StockDataModel stock)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    stockCollections.Update(stock);
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static async Task<bool> deleteStock(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    return stockCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }

        }

        public static async Task<bool> addCategory(CategoryDataModel category)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    var data = categoryCollections.FindOne(x => x.name == category.name);
                    if (data != null)
                        return false;

                    int index = categoryCollections.Count() + 1;
                    category.id = index.ToString();
                    categoryCollections.Insert(category);

                    return true;
                } catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
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

        public static string getCategoryName(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    return categoryCollections.FindOne(x => x.id == id).name;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }

        public static async Task<bool> updateCategory(CategoryDataModel category)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    return categoryCollections.Update(category);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteCategory(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var categoryCollections = db.GetCollection<CategoryDataModel>(Constants.CATEGORY_TABLE_NAME);
                try
                {
                    return categoryCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static void addServiceCharge(ServiceChargeDataModel serviceCharge)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var serviceChargeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SERVICE_CHARGE_TABLE_NAME);
                try
                {
                    int index = serviceChargeCollections.Count() + 1;
                    serviceCharge.id = index.ToString();
                    serviceChargeCollections.Insert(serviceCharge);
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static IEnumerable<ServiceChargeDataModel> getServiceCharge()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var serviceChargeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SERVICE_CHARGE_TABLE_NAME);
                try
                {
                    return serviceChargeCollections.Find(Query.All());
                }
                catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editServiceCharge(ServiceChargeDataModel serviceCharge)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var serviceChargeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SERVICE_CHARGE_TABLE_NAME);
                try
                {
                    return serviceChargeCollections.Update(serviceCharge);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }

        }

        public static async Task<bool> deleteServiceCharge(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var serviceChargeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SERVICE_CHARGE_TABLE_NAME);
                try
                {
                    return serviceChargeCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static void addSalesType(ServiceChargeDataModel salesType)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesTypeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SALES_TYPE_TABLE_NAME);
                try
                {
                    int index = salesTypeCollections.Count() + 1;
                    salesType.id = index.ToString();
                    salesTypeCollections.Insert(salesType);
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static IEnumerable<ServiceChargeDataModel> getSalesType()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesTypeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SALES_TYPE_TABLE_NAME);
                try
                {
                    return salesTypeCollections.Find(Query.All());
                }
                catch (Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editSalesType(ServiceChargeDataModel serviceCharge)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesTypeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SALES_TYPE_TABLE_NAME);
                try
                {
                    return salesTypeCollections.Update(serviceCharge);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteSalesType(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var salesTypeCollections = db.GetCollection<ServiceChargeDataModel>(Constants.SALES_TYPE_TABLE_NAME);
                try
                {
                    return salesTypeCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static void addStoreLocation(StoreLocationDataModel storeLocation)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var storeCollections = db.GetCollection<StoreLocationDataModel>(Constants.STORE_LOCATION_TABLE_NAME);
                try
                {
                    int index = storeCollections.Count() + 1;
                    storeLocation.id = index.ToString();
                    storeCollections.Insert(storeLocation);
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static IEnumerable<StoreLocationDataModel> getStores()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var storeCollections = db.GetCollection<StoreLocationDataModel>(Constants.STORE_LOCATION_TABLE_NAME);
                try
                {
                    return storeCollections.Find(Query.All());
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public async static Task<StoreLocationDataModel> getStoreById(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var storeCollections = db.GetCollection<StoreLocationDataModel>(Constants.STORE_LOCATION_TABLE_NAME);
                try
                {
                    return storeCollections.FindOne(x => x.id == id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public async static Task<bool> editStoreLocation(StoreLocationDataModel storeLocation)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var storeCollections = db.GetCollection<StoreLocationDataModel>(Constants.STORE_LOCATION_TABLE_NAME);
                try
                {
                    return storeCollections.Update(storeLocation);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public async static Task<bool> deleteStoreLocation(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var storeCollections = db.GetCollection<StoreLocationDataModel>(Constants.STORE_LOCATION_TABLE_NAME);
                try
                {
                    return storeCollections.Delete(id);
                }catch (Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static void addRecipes(RecipesDataModel recipe)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollections = db.GetCollection<RecipesDataModel>(Constants.RECIPE_TABLE_NAME);
                //var recipeItemsCollection = db.GetCollection<RecipesDataModel.RecipeItems>(Constants.RECIPE_ITEMS_TABLE_NAME);
                try
                {
                    int index = recipeCollections.Count() + 1;                   
                    recipe.id = index.ToString();
                    recipeCollections.Insert(recipe);
                    //if(recipe.recipeItems != null && recipe.recipeItems.Any())
                    //{
                    //    foreach(var data in recipe.recipeItems)
                    //    {
                    //        index2 = recipeItemsCollection.Count() + 1;
                    //        data.id = index2.ToString();
                    //        data.recipeId = index.ToString();
                    //        recipeItemsCollection.Insert(data);
                    //    }
                    //}
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static IEnumerable<RecipesDataModel> getRecipes()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollections = db.GetCollection<RecipesDataModel>(Constants.RECIPE_TABLE_NAME);
                var recipeItemsCollection = db.GetCollection<RecipesDataModel.RecipeItems>(Constants.RECIPE_ITEMS_TABLE_NAME);
                try
                {
                    var recipes = new List<RecipesDataModel>();
                        recipes = recipeCollections.Find(Query.All()).ToList();
                    return recipes;
                    //var recipeItems = new List<RecipesDataModel.RecipeItems>();
                    //if (recipes != null && recipes.Any())
                    //{
                    //    foreach (var data in recipes)
                    //    {
                    //        recipeItems = recipeItemsCollection.Find(x => x.recipeId == data.id).ToList();
                    //        data.recipeItems = recipeItems;
                    //    }
                    //    return recipes;
                    //}
                    //else return null;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editRecipe(RecipesDataModel recipe)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollections = db.GetCollection<RecipesDataModel>(Constants.RECIPE_TABLE_NAME);               
                try
                {
                    return recipeCollections.Update(recipe);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteRecipe(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollections = db.GetCollection<RecipesDataModel>(Constants.RECIPE_TABLE_NAME);                
                try
                {
                    return recipeCollections.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task addSoldRecipes(List<RecipesDataModel> recipes)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollection = db.GetCollection<RecipesDataModel>(Constants.SOLD_RECIPES);
                try
                { int index = recipeCollection.Count();
                    foreach (var data in recipes)
                    {
                        data.id = (index + 1).ToString();
                        recipeCollection.Insert(data);
                        index++;
                    }                  
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static async Task<List<RecipesDataModel>> getSoldRecipes()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollections = db.GetCollection<RecipesDataModel>(Constants.SOLD_RECIPES);
                try
                {
                    return recipeCollections.Find(Query.All()).ToList();
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editSoldRecipes(RecipesDataModel recipe)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollection = db.GetCollection<RecipesDataModel>(Constants.SOLD_RECIPES);
                try
                {
                    return recipeCollection.Update(recipe);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteSoldRecipes(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var recipeCollection = db.GetCollection<RecipesDataModel>(Constants.SOLD_RECIPES);
                try
                {
                    return recipeCollection.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<string> exportDB()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                try
                {
                    string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.DB_NAME);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filePath;
                    var dbTables = db.GetCollectionNames();
                    foreach(var tableName in dbTables)
                    {
                        filePath = Path.Combine(folderPath, tableName);
                        if (!File.Exists(filePath))
                        {
                            using(var myFile = File.Create(filePath))
                            {
                                using (var tw = new StreamWriter(myFile))
                                {
                                    var json = JsonSerializer.Serialize(new BsonArray(db.Engine.Find(tableName, Query.All())));
                                    tw.WriteLine(json);
                                }
                            }
                        }else
                        {
                            using (var tw = new StreamWriter(filePath, false))
                            {
                                var json = JsonSerializer.Serialize(new BsonArray(db.Engine.Find(tableName, Query.All())));
                                tw.WriteLine(json);
                            }
                        }                                                                                               
                        //File.WriteAllText(filePath, json);
                    }
                    return "DB exported successfully.";
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return ex.Message; ;
                }
            }
        }

        public static async Task addTransferRecord(StockTransferRecordDataModel stockTransfer)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var transferRecordCollection = db.GetCollection<StockTransferRecordDataModel>(Constants.STOCK_RECORD_TABLE_NAME);
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    int index = transferRecordCollection.Count() + 1;
                    stockTransfer.id = index.ToString();
                    transferRecordCollection.Insert(stockTransfer);

                    if(stockTransfer.stockItems != null && stockTransfer.stockItems.Any())
                    {
                        foreach(var data in stockTransfer.stockItems)
                        {
                            var stock = stockCollections.FindOne(x => x.id == data.stockId);
                            if(stock != null && stock.quantity > 0)
                            {
                                stock.quantity -= data.quantity;
                                stockCollections.Update(stock);
                            }
                        }
                    }
                    
                }catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static async Task<IEnumerable<StockTransferRecordDataModel>> getStockTransfer()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var transferRecordCollection = db.GetCollection<StockTransferRecordDataModel>(Constants.STOCK_RECORD_TABLE_NAME);
                try
                {
                    return transferRecordCollection.Find(Query.All());
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editTransferRecord(StockTransferRecordDataModel transferRecord)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var transferRecordCollection = db.GetCollection<StockTransferRecordDataModel>(Constants.STOCK_RECORD_TABLE_NAME);
                try
                {
                    return transferRecordCollection.Update(transferRecord);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteTransferRecord(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var transferRecordCollection = db.GetCollection<StockTransferRecordDataModel>(Constants.STOCK_RECORD_TABLE_NAME);
                try
                {
                    return transferRecordCollection.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task addReceivedNotes(ReceivedNotesDataModel receivedNotes)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var notesCollection = db.GetCollection<ReceivedNotesDataModel>(Constants.RECEIVED_NOTES_TABLE_NAME);
                var purchaseCollection = db.GetCollection<PurchaseOrderDataModel>(Constants.PURCHASE_TABLE_NAME);
                try
                {
                    int index = notesCollection.Count() + 1;
                    receivedNotes.id = index.ToString();
                    notesCollection.Insert(receivedNotes);
                    if (!string.IsNullOrEmpty(receivedNotes.purchaseId))
                    {
                        var purchase = purchaseCollection.FindOne(x => x.id == receivedNotes.purchaseId);
                        if(purchase != null)
                        {
                            purchase.status = "Closed";
                            purchaseCollection.Update(purchase);
                        }
                    }
                }
                catch(Exception ex)
                {
                    showMessage(ex);
                }
            }
        }

        public static async Task<IEnumerable<ReceivedNotesDataModel>> getReceivedNotes()
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var notesCollection = db.GetCollection<ReceivedNotesDataModel>(Constants.RECEIVED_NOTES_TABLE_NAME);
                try
                {
                    return notesCollection.Find(Query.All());
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editReceivedNotes(ReceivedNotesDataModel receivedNotes)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var notesCollection = db.GetCollection<ReceivedNotesDataModel>(Constants.RECEIVED_NOTES_TABLE_NAME);
                try
                {
                    return notesCollection.Update(receivedNotes);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> deleteReceivedNotes(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var notesCollection = db.GetCollection<ReceivedNotesDataModel>(Constants.RECEIVED_NOTES_TABLE_NAME);
                try
                {
                    return notesCollection.Delete(id);
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
        }
        }

        public static async Task<bool> addAdjustments(StockAdjustmentDataModel adjustments)
        {
            using(var db = new LiteDatabase(Constants.DB_NAME))
            {
                var adjustmentCollections = db.GetCollection<StockAdjustmentDataModel>(Constants.STOCK_ADJUSTMENT_TABLE);
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    int index = adjustmentCollections.Count() + 1;
                    adjustments.id = index.ToString();
                    adjustmentCollections.Insert(adjustments);
                    adjustmentCollections.EnsureIndex(x => x.id);

                    var data = stockCollections.FindOne(x => x.id == adjustments.stockId);
                    if(data != null)
                    {
                        data.quantity = adjustments.newQuantity;
                        stockCollections.Update(data);
                    }

                    return true;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<List<StockAdjustmentDataModel>> getAdjustments()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var adjustmentCollections = db.GetCollection<StockAdjustmentDataModel>(Constants.STOCK_ADJUSTMENT_TABLE);
                try
                {
                    return adjustmentCollections.Find(Query.All()).ToList();
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return null;
                }
            }
        }

        public static async Task<bool> editAdjustment(StockAdjustmentDataModel adjustment)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var adjustmentCollections = db.GetCollection<StockAdjustmentDataModel>(Constants.STOCK_ADJUSTMENT_TABLE);
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    var oldAdjustment = adjustmentCollections.FindOne(x => x.id == adjustment.id);
                    bool success = adjustmentCollections.Update(adjustment);
                    if (success)
                    {
                        var st = stockCollections.FindOne(x => x.id == oldAdjustment.stockId);
                        if(st != null)
                        {
                            st.quantity = oldAdjustment.initialQuantity;
                            stockCollections.Update(st);
                        }
                        var st2 = stockCollections.FindOne(x => x.id == adjustment.stockId);
                        if(st2 != null)
                        {
                            st2.quantity = adjustment.newQuantity;
                            stockCollections.Update(st2);
                        }
                    }
                    return success;
                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }

        public static async Task<bool> deleteAdjustment(string id)
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                var adjustmentCollections = db.GetCollection<StockAdjustmentDataModel>(Constants.STOCK_ADJUSTMENT_TABLE);
                var stockCollections = db.GetCollection<StockDataModel>(Constants.STOCK_TABLE_NAME);
                try
                {
                    var adjustment = adjustmentCollections.FindOne(x => x.id == id);

                    bool success = adjustmentCollections.Delete(id);

                    if (success)
                    {
                        var stock = stockCollections.FindOne(x => x.id == adjustment.stockId);
                        stock.quantity = adjustment.initialQuantity;
                        stockCollections.Update(stock);
                    }
                    return success;

                }catch(Exception ex)
                {
                    showMessage(ex);
                    return false;
                }
            }
        }
        
    }
}


//var json = JsonSerializer.Serialize(new BsonArray(db.Engine.Find("mycol")));

//db.Engine.Insert("mycol", JsonSerializer.Deserialize(json).AsArray.ToArray());