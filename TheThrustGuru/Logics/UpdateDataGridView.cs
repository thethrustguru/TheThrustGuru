using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TheThrustGuru.DataModels;
using TheThrustGuru.Utils;
using System.Linq;
using System;

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
                    
        public void clearDataInDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public void addSuppliersToDataGrid(IEnumerable<SupplierDataModel> suppliers, DataGridView datagridview)
        {
            foreach(var data in suppliers)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(),data.name,data.phone,data.company,data.address, 
                    data.email, data.other);
            }
        }

        public void addClientsToDataGrid(List<ClientDataModel> clientModels, DataGridView datagridview)
        {
            foreach(var data in clientModels)
            {
                datagridview.Rows.Add(datagridview.RowCount + 1, data.name, data.phone, data.address, data.username, 
                    data.password, data.role, data.storeLocation, data.other);
            }
        }

        public void addProductsToDataGridView(StockDataModel stock, int quantityToSupply, DataGridView datagridview)
        {
            decimal totalPrice = stock.lastCostPrice * quantityToSupply;
            datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), stock.name, FormatPrice.format(stock.lastCostPrice),
                FormatPrice.format(stock.highestCostPrice), FormatPrice.format(stock.lowestCostPrice),quantityToSupply,
                FormatPrice.format(totalPrice), stock.quantity);
        }

        public void addProductsToDataGridView(List<StockDataModel> stock, List<int> quantityToSupply, DataGridView datagridview)
        {
            decimal totalPrice = 0;
            for(int i = 0; i < stock.Count(); i++)
            {
                totalPrice = stock.ElementAt(i).lastCostPrice * quantityToSupply.ElementAt(i);
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), stock.ElementAt(i).name, 
                    FormatPrice.format(stock.ElementAt(i).lastCostPrice), FormatPrice.format(stock.ElementAt(i).highestCostPrice), 
                    FormatPrice.format(stock.ElementAt(i).lowestCostPrice), quantityToSupply.ElementAt(i),
                    FormatPrice.format(totalPrice), stock.ElementAt(i).quantity);            
            }

        }

        public void addPurchaseToDataGrid(List<StockDataModel> stocks, List<int> Quantity, DataGridView datagridview)
        {
            for(int i = 0; i < stocks.Count(); i++)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), stocks.ElementAt(i).name,
                    FormatPrice.format(stocks.ElementAt(i).highestCostPrice),FormatPrice.format(stocks.ElementAt(i).lowestCostPrice),
                    FormatPrice.format(stocks.ElementAt(i).lastCostPrice),FormatPrice.format(stocks.ElementAt(i).unitPrice),
                    Quantity.ElementAt(i) );
            }
        }

        public void addPurcharseOrderToDataGridView(IEnumerable<PurchaseOrderDataModel> purchase, DataGridView datagridview)
        {
            foreach(var data in purchase)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), data.dateCreated, data.orderNo, data.supplierName,
                    data.staffName, data.status, data.deliveryDate,FormatPrice.format(data.grandTotalPrice));
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
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.customerName,FormatPrice.format(data.balance),
                    data.phone, code, data.address, data.other);
            }
        }

        public void addSalesRepToDataGridView(IEnumerable<SalesRepDataModel> salesReps, DataGridView dataGridView)
        {
            foreach(var data in salesReps)
            {
                dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(),data.name, data.repId,data.username,data.password, data.phone, data.address, data.other);
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
                datagridView.Rows.Add((datagridView.RowCount + 1), data.name, FormatPrice.format(data.amount), data.desc, data.date);
            }
        }
        public void addExpensesToDataGridView(ExpensesDataModel data, DataGridView datagridView)
        {
            datagridView.Rows.Add((datagridView.RowCount + 1), data.name, FormatPrice.format(data.amount), data.desc, data.date);
        }

        public void addReceiptsToDataGridView(IEnumerable<ReceiptDataModel> receipts, DataGridView datagridView)
        {
           foreach(var data in receipts)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(),data.salesRep,data.repId,data.invoiceNo,
                    FormatPrice.format(data.totalPrice), FormatPrice.format(data.discount), FormatPrice.format(data.amountPayable),
                    FormatPrice.format(data.totalAmtPaid), data.salesType, FormatPrice.format(data.serviceCharge),data.date);
            }
            
        }

        public void addCategoriesToDataGridView(IEnumerable<CategoryDataModel> categories, DataGridView datagridview)
        {
            foreach(var data in categories)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), data.name, data.others);
            }
        }

        public void addStocksToDataGridView(IEnumerable<StockDataModel> stocks, List<string> categoryNames,List<string> storeNames, 
            DataGridView datagridView)
        {            
            for(int i = 0; i < stocks.Count(); i++)
            {                
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), stocks.ElementAt(i).name,
                    FormatPrice.format(stocks.ElementAt(i).highestCostPrice), FormatPrice.format(stocks.ElementAt(i).lowestCostPrice),
                    FormatPrice.format(stocks.ElementAt(i).lastCostPrice), FormatPrice.format(stocks.ElementAt(i).unitPrice),
                    stocks.ElementAt(i).quantity, categoryNames.ElementAt(i), storeNames.ElementAt(i),stocks.ElementAt(i).date);
            }
        }

        public void addReceiptSoldItemsToDataGridView(IEnumerable<StockDataModel> stocks, List<SalesDataModel> soldItems, List<string> categoryNames, 
            DataGridView datagridView)
        {
            datagridView.Rows.Clear();
            for (int i = 0; i < stocks.Count(); i++)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), stocks.ElementAt(i).name,
                   FormatPrice.format(stocks.ElementAt(i).highestCostPrice), FormatPrice.format(stocks.ElementAt(i).lowestCostPrice),
                   FormatPrice.format(soldItems.ElementAt(i).lastCostPrice), FormatPrice.format(soldItems.ElementAt(i).soldPrice),
                   categoryNames.ElementAt(i));
            }
        }

        public void addServiceChargeToDataGridView(IEnumerable<ServiceChargeDataModel> serviceCharge, DataGridView datagridview)
        {
            foreach(var data in serviceCharge)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1).ToString(), data.title,FormatPrice.format(data.discount), data.percent + "%");
            }
        }

        public void addStoresToDataGrid(IEnumerable<StoreLocationDataModel> stores, DataGridView datagridView)
        {
            foreach(var data in stores)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), data.name, data.show.ToString());
            }
        }

        public void addStocksToPOSDataGridView(IEnumerable<StockDataModel> stocks, List<string> categoryNames,
            List<string> storeName, DataGridView datagridView)
        {           
            for (int i = 0; i < stocks.Count(); i++)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1).ToString(), stocks.ElementAt(i).name, categoryNames.ElementAt(i),
                    FormatPrice.format(stocks.ElementAt(i).highestCostPrice), FormatPrice.format(stocks.ElementAt(i).lowestCostPrice),
                    FormatPrice.format(stocks.ElementAt(i).lastCostPrice), FormatPrice.format(stocks.ElementAt(i).unitPrice),
                    stocks.ElementAt(i).quantity,stocks.ElementAt(i).unit,storeName.ElementAt(i));
            }
        }

        public void addSelectedStockToDataGridView(StockDataModel stock, DataGridView datagridView)
        {
            int index = datagridView.RowCount + 1;
            datagridView.Rows.Add(index, stock.name, FormatPrice.format(stock.highestCostPrice),
                FormatPrice.format(stock.lowestCostPrice),FormatPrice.format(stock.lastCostPrice),FormatPrice.format(stock.unitPrice),"Remove");           
        }

        public void removeStockFromDataGridView(List<StockDataModel> stocks, DataGridView datagridview)
        {
            datagridview.Rows.Clear();
            foreach(var stock in stocks)
            {
                datagridview.Rows.Add(datagridview.RowCount + 1, stock.name, FormatPrice.format(stock.highestCostPrice),
                FormatPrice.format(stock.lowestCostPrice), FormatPrice.format(stock.lastCostPrice), FormatPrice.format(stock.unitPrice), "Remove");
            }
        }

        public void addSoldItemsToDataGridView(IEnumerable<StockDataModel> stocks, List<string> categoryNames, 
            List<string> storeName,List<DateTime> dates, DataGridView datagridView)
        {
            for (int i = 0; i < stocks.Count(); i++)
            {
                datagridView.Rows.Add((datagridView.RowCount + 1), stocks.ElementAt(i).name,FormatPrice.format(stocks.ElementAt(i).highestCostPrice),
                    FormatPrice.format(stocks.ElementAt(i).lowestCostPrice),FormatPrice.format(stocks.ElementAt(i).lastCostPrice),
                    FormatPrice.format(stocks.ElementAt(i).unitPrice), dates.ElementAt(i),categoryNames.ElementAt(i), storeName.ElementAt(i));
            }
        }

        public void salesReportAddItemToDataGridView(List<StockDataModel> availableStocks, List<StockDataModel>soldStocks, 
            List<SalesDataModel> sales, DataGridView avStockDg, DataGridView soldStockDg)
        {
            avStockDg.Rows.Clear();
            soldStockDg.Rows.Clear();
            foreach(var data in availableStocks)
            {
                avStockDg.Rows.Add((avStockDg.RowCount + 1), data.name, FormatPrice.format(data.highestCostPrice), 
                    FormatPrice.format(data.lowestCostPrice),FormatPrice.format(data.lastCostPrice),FormatPrice.format(data.unitPrice),
                    data.quantity);
            }
            for(int i = 0; i < soldStocks.Count(); i++)
            {
                soldStockDg.Rows.Add(i + 1, soldStocks.ElementAt(i).name, FormatPrice.format(soldStocks.ElementAt(i).highestCostPrice),
                    FormatPrice.format(soldStocks.ElementAt(i).lowestCostPrice), FormatPrice.format(sales.ElementAt(i).lastCostPrice),
                    FormatPrice.format(sales.ElementAt(i).soldPrice));
            }
        }

        public void addTransferRecordToDataGridView(List<StockTransferRecordDataModel> transferRecords, DataGridView datagridview)
        {
            foreach(var data in transferRecords)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1), data.transferId, data.fromStoreName, data.toStoreName, 
                    data.dateCreated);
            }
        }

        public void addTransferedItemsToDataGridView(List<StockDataModel> data, List<int> quantity, DataGridView datagridview)
        {
            for(int i = 0; i < data.Count(); i++)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1),data.ElementAt(i).name, FormatPrice.format(data.ElementAt(i).highestCostPrice),
                    FormatPrice.format(data.ElementAt(i).lowestCostPrice), FormatPrice.format(data.ElementAt(i).lastCostPrice), 
                    FormatPrice.format(data.ElementAt(i).unitPrice),quantity.ElementAt(i));
            }
        }
        public void addIssuedStockToDataGridView(StockDataModel stock, int quantity, DataGridView datagridview)
        {
            datagridview.Rows.Add((datagridview.RowCount + 1),stock.name,FormatPrice.format(stock.lastCostPrice),
                FormatPrice.format(stock.unitPrice),quantity);
        }        

        public void addReceivedNotesToDataGridView(List<ReceivedNotesDataModel> receivedNotes, DataGridView datagridview)
        {
            foreach(var data in receivedNotes)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1), data.grnId, data.orderId, data.dateReceived,
                    FormatPrice.format( data.amount));
            }
            
        }

        public void addReceivedNotesItemsToDataGridView(List<StockDataModel> stocks, List<ReceivedNotesDataModel.GoodsReceived> notes,
            DataGridView datagridview)
        {
            decimal amt = 0;
            for(int i = 0; i < stocks.Count(); i++)
            {
                amt = stocks.ElementAt(i).lastCostPrice * notes.ElementAt(i).quantity;
                datagridview.Rows.Add((datagridview.RowCount + 1), stocks.ElementAt(i).name, 
                    FormatPrice.format(stocks.ElementAt(i).lastCostPrice),
                    notes.ElementAt(i).quantity, amt);
            }
        }

        public void addSelectedNoteToDataGridView(StockDataModel stocks, int quantity, DataGridView datagridview)
        {
            decimal amt = quantity * stocks.lastCostPrice;
                datagridview.Rows.Add((datagridview.RowCount + 1), stocks.name,FormatPrice.format(stocks.lastCostPrice),
                    quantity,FormatPrice.format(amt),"Edit","Delete");
            
        }

        public void addSelectedNoteToDataGridView(List<StockDataModel> stocks, List<int> quantity, DataGridView datagridview)
        {
            decimal amt = 0;
            datagridview.Rows.Clear();
            for(int i = 0; i < stocks.Count(); i++)
            {
                amt = quantity.ElementAt(i) * stocks.ElementAt(i).lastCostPrice;
                datagridview.Rows.Add((datagridview.RowCount + 1), stocks.ElementAt(i).name,
                    FormatPrice.format(stocks.ElementAt(i).lastCostPrice), quantity.ElementAt(i), FormatPrice.format(amt), "Edit", "Delete");
            }           
        }

        public void addRecipeItemsToDataGridView(List<StockDataModel> stocks, List<int> quantity, DataGridView datagridview)
        {
            datagridview.Rows.Clear();
            for (int i = 0; i < stocks.Count(); i++)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1), stocks.ElementAt(i).name, FormatPrice.format(stocks.ElementAt(i).lastCostPrice),
                FormatPrice.format(stocks.ElementAt(i).unitPrice), quantity.ElementAt(i));
            }
        }

        public void addRecipeToDataGridView(List<RecipesDataModel> recipes, DataGridView datagridview)
        {
            foreach(var data in recipes)
            {
                datagridview.Rows.Add((datagridview.RowCount + 1), data.name, FormatPrice.format(data.price), data.desc, 
                    data.dateCreated);
            }
        }

        public void addStocksToRecipeDataGridView(StockDataModel stock,int qty, DataGridView dataGridView)
        {
            dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(),stock.name,qty,stock.unitPrice, stock.lastCostPrice);
        }

        public void addStocksToRecipeDataGridView(List<StockDataModel> stock, List<int> qty, DataGridView dataGridView)
        {
            for(int i = 0; i < stock.Count(); i++)
            {
                dataGridView.Rows.Add((dataGridView.RowCount + 1), stock.ElementAt(i).name, qty.ElementAt(i),
                    FormatPrice.format(stock.ElementAt(i).unitPrice),FormatPrice.format(stock.ElementAt(i).lastCostPrice));
            }            
        }

        public void updateSelectedRecipeDataGrid(RecipesDataModel recipe, DataGridView dataGridView)
        {
            dataGridView.Rows.Add((dataGridView.RowCount + 1).ToString(),recipe.name,FormatPrice.format(recipe.price));
        }     
        
        public void addStockAdjustmentToDataGridView(List<StockAdjustmentDataModel> stockAdjustsments, DataGridView datagridview)
        {
            foreach(var data in stockAdjustsments)
            {
                datagridview.Rows.Add(datagridview.RowCount + 1, data.stockName, data.initialQuantity, data.newQuantity,
                    data.adjustedQuantity, data.categoryName, data.storeName, data.description, data.date);
            }
        }
    }
}
