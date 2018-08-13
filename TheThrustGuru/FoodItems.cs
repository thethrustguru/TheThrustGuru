using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Interfaces;
using TheThrustGuru.Logics;
using TheThrustGuru.Repository;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class FoodItems : Form
    {
      
        public FoodItems()
        {
            InitializeComponent();        

            // set search texbox to gray state
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Text = "Search...";
        }

        private void FoodItems_Load(object sender, EventArgs e)
        {
            var datum = getDataFromDb();
            if (datum != null && datum.Any())
            {
                populateDataFromDB(datum);
            }
            else
            {
                loadDataFromServer();                
            }
        }

        private async void loadDataFromServer() {
            if (NetworkConnectivity.DnsTest())
            {
                isBusy(true);
                FoodItemsDataModel data = await getDatafromServerAsync();
                isBusy(false);
                if (data != null && data.status && data.results != null)
                {
                    populateDataFromServer(data.results);
                    DatabaseOperations.addData(data.results);
                }
            }
            else
            {
                MessageBox.Show(Constants.INTERNET_CONNECTION_ERR_MSG, Constants.INTERNET_CONNECTION_ERROR);
            }
        }


        private IEnumerable<FoodItemsDataModel.FoodItemModel> getDataFromDb()
        {
            return DatabaseOperations.getData();
        }

        private async Task<FoodItemsDataModel> getDatafromServerAsync()
        {
            AppRepo appRepo = new AppRepo();
            var data = DatabaseOperations.getToken();
            return await appRepo.getFoodItemsFromServer(data.token);
        }

        private async Task postDataToServerAsync(FoodItemsDataModel.FoodItemModel foodItem)
        {
            AppRepo appRepo = new AppRepo();
            var data = DatabaseOperations.getToken();
            await appRepo.postFoodItemToServer(data.token,foodItem);
        }

        public void createDummyData()
        {
            List<FoodItemsDataModel.FoodItemModel> fooditemsArray = new List<FoodItemsDataModel.FoodItemModel>();
            for (int i = 0; i <= 100; i++)
            {
                FoodItemsDataModel.FoodItemModel item = new FoodItemsDataModel.FoodItemModel
                {
                  
                    name = "Onion",
                    price = 5,
                    count = 30,
                    total_price = 150,
                    date_added = "today",
                    date_lastmodified = "now",
                    _v = 12                   
                };
                fooditemsArray.Add(item);              
            }
            UpdateDataGridView updateDataGrid = new UpdateDataGridView();
            updateDataGrid.updateDataFromServer(fooditemsArray, this.dataGridView1);

           updateDataGrid.updateDataFromDB(DatabaseOperations.getData(), this.dataGridView1);
        }

        private void isBusy(bool value)
        {
            this.progressBar.Visible = value;
        }

        public void populateDataFromDB(IEnumerable<FoodItemsDataModel.FoodItemModel> data)
        {
            if (data != null)
                new UpdateDataGridView().updateDataFromDB(data,this.dataGridView1);
        }

       public void populateDataFromServer(List<FoodItemsDataModel.FoodItemModel> data)
        {
            if(data != null)
            {
                UpdateDataGridView updateDataGrid = new UpdateDataGridView();
                updateDataGrid.updateDataFromServer(data, this.dataGridView1);
            }
        }

        private void loadFromDb()
        {
            UpdateDataGridView updateDataGrid = new UpdateDataGridView();           

            updateDataGrid.updateDataFromDB(DatabaseOperations.getData(), this.dataGridView1);
        }

        private void waterMarkOnTextBoxLeave(TextBox textbox, string placeHolder, Color DefaultColor)
        {
            if (String.IsNullOrEmpty(textbox.Text) || textbox.Text == placeHolder)
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeHolder;
            }
            else
            {
                textbox.ForeColor = DefaultColor;
            }
        }
        private void waterMarkOnTextBoxEnter(TextBox textbox,Color DefaultColor)
        {
            textbox.Text = String.Empty;
            textbox.ForeColor = DefaultColor;
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.searchTextBox, Color.Black);

        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.searchTextBox, "Search...",Color.Black);
        }

        private async void addFoodButton_Click(object sender, EventArgs e)
        {
            AddFoodItems addItems = new AddFoodItems();
            DialogResult result  = addItems.ShowDialog();
            if(result == DialogResult.OK && addItems.foodItems != null)
            {
                new UpdateDataGridView().updateData(addItems.foodItems, this.dataGridView1);
                DatabaseOperations.addSingleData(addItems.foodItems);
                await postDataToServerAsync(addItems.foodItems);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadDataFromServer();
        }
    }
}
