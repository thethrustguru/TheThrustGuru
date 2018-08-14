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
    }
}
