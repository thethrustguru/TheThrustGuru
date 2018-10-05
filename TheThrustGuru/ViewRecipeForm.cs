using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Logics;

namespace TheThrustGuru
{
    public partial class ViewRecipeForm : Form
    {
        List<RecipesDataModel> recipesData;
        UpdateDataGridView updateDatagridview = new UpdateDataGridView();
        public ViewRecipeForm()
        {
            InitializeComponent();
        }

        private void AllRecipeFrom_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            recipesData = DatabaseOperations.getRecipes().ToList();
            if(recipesData != null && recipesData.Any())
            {
                updateDatagridview.addRecipeToDataGridView(recipesData, dataGridView1);
            }
        }

        private async void getDataAndDisplay(int index)
        {
            var data = recipesData.ElementAt(index);
            if(data != null && data.recipeItems != null && data.recipeItems.Any())
            {
                progressBar1.Visible = true;
                var stocksList = new List<StockDataModel>();
                var quantityList = new List<int>();
                foreach(var datum in data.recipeItems)
                {
                    quantityList.Add(datum.quantity);
                    stocksList.Add(await DatabaseOperations.getStockById(datum.stockId));
                }

                updateDatagridview.addRecipeItemsToDataGridView(stocksList, quantityList, dataGridView2);
                progressBar1.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                getDataAndDisplay(dataGridView1.CurrentCell.RowIndex);
            }
        }
    }
}
