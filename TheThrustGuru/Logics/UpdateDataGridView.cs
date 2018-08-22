using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;

namespace TheThrustGuru.Logics
{
    class UpdateDataGridView
    {
        public UpdateDataGridView()
        {

        }

        public void updateDataFromServer(List<DataModels.FoodItemsDataModel.FoodItemModel> foodItems, DataGridView dataGridView)
        {
            int count;
            //loop through all the data
            foreach (DataModels.FoodItemsDataModel.FoodItemModel items in foodItems)
            {                
                count = dataGridView.RowCount + 1;
                //add items as new row 
                dataGridView.Rows.Add(count.ToString(), items.name, items.price.ToString(),
                    items.count.ToString(), items.total_price.ToString(), DateTimeUtils.date(items.date_added), DateTimeUtils.date(items.date_lastmodified));
            }

        }

        public void updateDataFromDB(IEnumerable<DataModels.FoodItemsDataModel.FoodItemModel> foodItems, DataGridView dataGridView)
        {
            int count;
            foreach (DataModels.FoodItemsDataModel.FoodItemModel items in foodItems)
            {
                count = dataGridView.RowCount + 1;
                dataGridView.Rows.Add(count.ToString(), items.name, items.price.ToString(),
                    items.count.ToString(), items.total_price.ToString(), DateTimeUtils.date(items.date_added), DateTimeUtils.date(items.date_lastmodified));
            }
        }

        public void updateData(DataModels.FoodItemsDataModel.FoodItemModel items, DataGridView dataGridView)
        {
            int count = dataGridView.RowCount + 1;
            dataGridView.Rows.Add(count.ToString(), items.name, items.price.ToString(),
                items.count.ToString(), items.total_price.ToString(), DateTimeUtils.date(items.date_added), DateTimeUtils.date(items.date_lastmodified));

        }

        public void updateAddRecipeDataGrid(RecipeItems items, DataGridView dataGridView)
        {
            dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(), items.itemName, items.totalPrice.ToString(), items.quantity.ToString());
        }

        public void updateSelectedRecipeDataGrid(string name,DataGridView dataGridView)
        {
            dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(), name);
        }

        public void clearDataInDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public void addItemsToDataGrid(IEnumerable<ItemsDataModel> itemModel, DataGridView datagridView)
        {
            decimal total_price = 0;
            foreach(var items in itemModel)
            {
                total_price = items.itemSellingPrice * items.itemQuantity;
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), items.itemName, items.itemCostPrice, items.itemSellingPrice, items.itemQuantity,total_price, items.itemCategory, items.dateCreated);
            }
            
        }
        public void addItemsToDataGrid(ItemsDataModel items, DataGridView datagridView)
        {
            decimal total_price = items.itemSellingPrice * items.itemQuantity;
            datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), items.itemName, items.itemCostPrice, items.itemSellingPrice, items.itemQuantity, total_price, items.itemCategory, items.dateCreated);
        }

        public void addSuppliersToDataGrid(IEnumerable<SupplierDataModel> suppliers, DataGridView datagridview)
        {
            foreach(var data in suppliers)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(),data.name,data.phone,data.company,data.address,data.category,data.other);
            }
        }

        public void addProductsToDataGridView(PurchaseDataModel.Product product, DataGridView datagridview)
        {
            decimal totalPrice = product.productPrice * product.quantityToSupply;
            datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), product.productName, product.productPrice.ToString("C3"), product.quantityToSupply,totalPrice.ToString("C3") , product.quantityRemaining);
        }

        public void addPurchaseToDataGrid(IEnumerable<PurchaseDataModel> purchase, DataGridView datagridview)
        {
            foreach(var data in purchase)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), data.supplierName.ToString(), data.status.ToString(), data.invoiceNo.ToString(), data.grandTotalPrice, data.grandTotalQuantity);
            }
        }

        public void addVouchers(List<VoucherDataGridModel> vouchers,DataGridView datagridView)
        {
            foreach(var data in vouchers)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(),data.code,data.name,data.count);
            }
        }
        public void addVoucher(VoucherDataModel voucher, string name,DataGridView datagridView)
        {
            datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), voucher.code, name, voucher.usedCount);
        }

        public void addCustomerToDataGridView(List<CustomerDataModel> customers, DataGridView datagridView)
        {
            string code = "";
            foreach(var data in customers)
            {
                if (data.isVoucherAvailable)
                    code = data.voucherCode;
                else code = "";
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.customerName, data.phone, code, data.address, data.other);
            }
        }

        public void addSalesRepToDataGridView(IEnumerable<SalesRepDataModel> salesReps, DataGridView dataGridView)
        {
            foreach(var data in salesReps)
            {
                dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(), data.repId, data.phone, data.address, data.other);
            }
        }

        public void addVendorsToDatagridView(IEnumerable<VendorDataModel> vendors, DataGridView datagridView)
        {
            foreach(var data in vendors)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.name, data.phone, data.address, data.other);
            }
        }

        public void addExpensesToDataGridView(IEnumerable<ExpensesDataModel> Expenses,DataGridView datagridView)
        {
            foreach(var data in Expenses)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.name, data.amount.ToString(), data.desc, data.date);
            }
        }
        public void addExpensesToDataGridView(ExpensesDataModel data, DataGridView datagridView)
        {
            datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.name, data.amount.ToString(), data.desc, data.date);
        }

        public void addReceiptsToDataGridView(IEnumerable<ReceiptDataModel> receipts, DataGridView datagridView)
        {
           foreach(var data in receipts)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(),data.salesRep,data.repId,data.invoiceNo,
                    data.totalPrice.ToString(),data.discount,data.totalAmtPaid.ToString(),data.salesType,data.serviceCharge,data.date);
            }
            
        }

        public void addCategoriesToDataGridView(IEnumerable<CategoryDataModel> categories, DataGridView datagridview)
        {
            foreach(var data in categories)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), data.name, data.others);
            }
        }
    }
}
