using Refit;
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
using TheThrustGuru.Repository;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class AddRecipes : Form
    {
        private string name = "Recipe name";
        private string desc = "Description";
        private string price = "Price";
        private string selectFood = "Select food items...";
        private IEnumerable<CategoryDataModel> categories;
        private IEnumerable<StockDataModel> stocks;
        private List<StockDataModel> selectedStocksList = new List<StockDataModel>();
        private List<int> selectedQuantityList = new List<int>();
        private RecipesDataModel recipeModel;

        public AddRecipes()
        {
            InitializeComponent();

            waterMarkOnTextBoxLeave(this.nameTextBox, name);
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
            waterMarkOnTextBoxLeave(this.priceTextBox, price);

        }

        public AddRecipes(RecipesDataModel recipe)
        {
            InitializeComponent();
                        
            nameTextBox.Text = recipe.name;
            descTextBox.Text = recipe.desc;
            priceTextBox.Text = recipe.price.ToString();            
            populateStockList(recipe.recipeItems);

            editButton.Visible = true;
            deleteButton.Visible = true;
            okButton.Enabled = false;       

        }

        private async void populateStockList(List<RecipesDataModel.RecipeItems> recipeItems)
        {
            foreach(var dt in recipeItems)
            {
                selectedQuantityList.Add(dt.quantity);
                selectedStocksList.Add(await DatabaseOperations.getStockById(dt.stockId));                
            }
            new UpdateDataGridView().addStocksToRecipeDataGridView(selectedStocksList, selectedQuantityList, itemsDataGridView);
        }

        private void waterMarkOnTextBoxLeave(TextBox textbox, string placeHolder)
        {
            if (String.IsNullOrEmpty(textbox.Text) || textbox.Text == placeHolder)
            {
                textbox.ForeColor = Color.Gray;
                textbox.Text = placeHolder;
            }
            else
            {
                textbox.ForeColor = Color.Black;
            }
        }

        private void waterMarkOnTextBoxEnter(TextBox textbox, String placeholder)
        {
            if (textbox.Text == placeholder)
            {
                textbox.Text = String.Empty;
                textbox.ForeColor = Color.Black;
            }

        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.nameTextBox, name);
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.nameTextBox, name);
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
        }

        private void descTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.descTextBox, desc);
        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.priceTextBox, price);
        }

        private void priceTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.priceTextBox, price);
        }

        private void AddRecipes_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            categories = DatabaseOperations.getCategory();
            if (categories != null && categories.Any())
            {
                foreach (var data in categories)
                {
                    categoryComboBox.Items.Add(data.name);
                }
            }

            //stocks = DatabaseOperations.getStocks();
            //if(stocks != null && stocks.Any())
            //{
            //    foreach(var data in stocks)
            //    {
            //        foodStocksComboBox.Items.Add(data.name);
            //    }
            //}

            if (!foodStocksComboBox.Items.Contains(selectFood))
                foodStocksComboBox.Items.Add(selectFood);
            foodStocksComboBox.Text = selectFood;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateControl();
        }

        private void validateData(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(this.nameTextBox.Text) || this.nameTextBox.Text == name)
            {
                errorProvider.SetError(this.nameTextBox, "Please enter valid name for recipe");
                return;
            }
            else errorProvider.Clear();
            if (this.itemsDataGridView.RowCount < 1)
            {
                errorProvider.SetError(this.itemsDataGridView, "Please add valid stocks to recipe");
                return;
            }
            else errorProvider.Clear();
            if(!string.IsNullOrEmpty(priceTextBox.Text) && !string.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                try
                {
                    decimal value = decimal.Parse(priceTextBox.Text);
                    errorProvider.Clear();
                }catch(Exception ex)
                {
                    errorProvider.SetError(priceTextBox,"Please provide a valid price");
                    return;
                }
            }else
            {
                errorProvider.SetError(priceTextBox, "Please provide a valid price");
                return;
            }

            processData(isEdit);
        }

        private async void processData(bool isEdit)
        {
            string name = nameTextBox.Text;
            decimal price = decimal.Parse(priceTextBox.Text);                                
            string nDesc = this.descTextBox.Text;
            List<RecipesDataModel.RecipeItems> recipeItems = new List<RecipesDataModel.RecipeItems>();
            if (string.IsNullOrWhiteSpace(nDesc))
                nDesc = " ";
                    
          
            for(int i = 0; i < selectedStocksList.Count(); i++)
            {
                recipeItems.Add(new RecipesDataModel.RecipeItems
                {
                    stockId = selectedStocksList.ElementAt(i).id,
                    quantity = selectedQuantityList.ElementAt(i)
                });
            }

            if (isEdit)
            {
                if (!MessagePrompt.displayPrompt("Edit", "edit this recipe"))
                    return;

                recipeModel.name = name;
                recipeModel.price = price;
                recipeModel.desc = desc;                
                recipeModel.recipeItems = recipeItems;

                bool success = await DatabaseOperations.editRecipe(this.recipeModel);
                if (!success)
                {
                    MessageBox.Show("Data updating not successful");
                    return;
                }

                MessageBox.Show("Recipe updated successfully");

            }else
            {
                if (!MessagePrompt.displayPrompt("Create New", "create new recipe"))
                    return;

                DatabaseOperations.addRecipes(new RecipesDataModel
                {
                    name = name,
                    price = price,
                    desc = nDesc,
                    dateCreated = DateTime.Now,
                    recipeItems = recipeItems

                });

                MessageBox.Show("New Recipe created successfully");
                clearControls();
            }                                             
        }

        private void validateControl()
        {
            if (notValidQuantity(this.quantityTextBox))
            {
                errorProvider.SetError(this.quantityTextBox, "Please provide a valid quantity");
                return;
            }
            else errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(this.foodStocksComboBox.Text) || foodStocksComboBox.Text == selectFood)
            {
                errorProvider.SetError(this.foodStocksComboBox, "Please select an item");
                return;
            }
            else errorProvider.Clear();

            addSelectedItem();
        }
        private bool notValidQuantity(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text))
                return true;
            else
                try
                {
                    int quantity = int.Parse(textbox.Text);
                    return false;
                }
                catch (Exception ex)
                {
                    return true;
                }

        }

        private void addSelectedItem()
        {
            int index = this.foodStocksComboBox.SelectedIndex;
            int quantity = int.Parse(this.quantityTextBox.Text);

            //use index to find the fooditem
            var item = stocks.ElementAt(index);            

            new UpdateDataGridView().addStocksToRecipeDataGridView(item, quantity, itemsDataGridView);

            //add the item to new list of foods
            selectedStocksList.Add(item);
            selectedQuantityList.Add(quantity);
        }

        private void clearControls()
        {
            this.nameTextBox.Clear();
            this.descTextBox.Clear();
            itemsDataGridView.Rows.Clear(); 
            this.quantityTextBox.Clear();
            this.priceTextBox.Clear();
            selectedStocksList.Clear();
            selectedQuantityList.Clear();

            waterMarkOnTextBoxLeave(this.nameTextBox, name);
            waterMarkOnTextBoxLeave(this.descTextBox, desc);
            waterMarkOnTextBoxLeave(this.priceTextBox, price);

        }

        private async void loadStocksByCategory(string categoryId)
        {
            progressBar1.Visible = true;
            noDataLabel.Visible = false;
            foodStocksComboBox.Items.Clear();
            stocks = await DatabaseOperations.getStocksByCategoryId(categoryId);
            if (stocks != null && stocks.Any())
            {
                foreach(var data in stocks)
                {
                    foodStocksComboBox.Items.Add(data.name);
                }

            }
            else noDataLabel.Visible = true;
            progressBar1.Visible = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            validateData(false);            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void foodItemsComboBox_DropDown(object sender, EventArgs e)
        {
            if (foodStocksComboBox.Items.Contains(selectFood))
                foodStocksComboBox.Items.Remove(selectFood);
        }

        private void foodItemsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(foodStocksComboBox.SelectedIndex == -1)
            {
                if (!foodStocksComboBox.Items.Contains(selectFood))
                    foodStocksComboBox.Items.Add(selectFood);
                foodStocksComboBox.Text = selectFood;
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(categoryComboBox.SelectedIndex >= 0)
            {
                var category = categories.ElementAt(categoryComboBox.SelectedIndex);
                loadStocksByCategory(category.id);
            }
           
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateData(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this recipe"))
                return;

            bool success = await DatabaseOperations.deleteRecipe(this.recipeModel.id);
            if (!success)
            {
                MessageBox.Show("Data deletion failed");
                return;
            }
            Close();
        }
    }
}
