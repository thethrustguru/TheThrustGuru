using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Custom_Controls;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Logics;
using TheThrustGuru.Repository;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class Recipes : Form
    {
        private List<RecipesDataModel> recipeData = new List<RecipesDataModel>();
        private List<RecipesDataModel> selectedRecipes = new List<RecipesDataModel>();
        private decimal totalPrice = 0;

        public Recipes()
        {
            InitializeComponent();

           
        }     

        private void displayRecipe()
        {
            recipeData = DatabaseOperations.getRecipes().ToList();
            if(recipeData != null && recipeData.Any())
                for (int i = 0; i < recipeData.Count(); i++ )
                {
                    Button button = new Button();
                    button.Click += new EventHandler(ItemClicked);                    
                    this.RecipeFlowLayoutPanel.Controls.Add(new RecipeItemPanel(recipeData.ElementAt(i).name, i,
                        FormatPrice.format(recipeData.ElementAt(i).price), button));
                }
        }       

       
        private void ItemClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                try
                {
                    int index = int.Parse(btn.Tag.ToString());
                    var data = recipeData.ElementAt(index);
                    data.dateCreated = DateTime.Now;
                    data.soldBy = "Cashier 1";
                    new UpdateDataGridView().updateSelectedRecipeDataGrid(data, cartDataGridView);
                    selectedRecipes.Add(data);
                    totalPrice += data.price;
                    totalPriceTextBox.Text = FormatPrice.format(totalPrice);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
                
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            cartDataGridView.Rows.Clear();
            selectedRecipes.Clear();
            totalPrice = 0;
            totalPriceTextBox.Text = FormatPrice.format(totalPrice);
        }

        private void Recipes_Load(object sender, EventArgs e)
        {                                 
            //get recipes from db
            displayRecipe();
            totalPriceTextBox.Text = FormatPrice.format(totalPrice);
            receiptNoTextBox.Text = GenerateIDs.invoiceId();
        }

        private async void validateControls()
        {
            if(cartDataGridView.RowCount < 1)
            {
                MessageBox.Show("Invalid Items selected","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            await DatabaseOperations.addSoldRecipes(selectedRecipes);

            //TODO print receipt
            try
            {
                Ticket ticket = new Ticket
                {
                    receiptDate = DateTime.Now,
                    amountPayable = totalPrice,
                    totalPrice = totalPrice,
                    recipes = selectedRecipes
                };
                await ticket.printRecipe();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            

            cartDataGridView.Rows.Clear();
            selectedRecipes.Clear();
            totalPrice = 0;
            totalPriceTextBox.Text = FormatPrice.format(totalPrice);            
        }

        private void processData()
        {
           
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            validateControls();
        }
    }
}
