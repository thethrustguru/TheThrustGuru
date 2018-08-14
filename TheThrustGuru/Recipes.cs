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
        private string placeHolder = "Search...";
        Color DefaultColor; int count;

        public Recipes()
        {
            InitializeComponent();

            // get default color of text
            DefaultColor = searchRTextBox.ForeColor;

            // set search texbox to gray state
            searchRTextBox.ForeColor = Color.Gray;
            searchRTextBox.Text = placeHolder;

        }

        private void searchRTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchRTextBox.Text) || searchRTextBox.Text == placeHolder)
            {
                searchRTextBox.ForeColor = Color.Gray;
                searchRTextBox.Text = placeHolder;
            }
            else
            {
                searchRTextBox.ForeColor = DefaultColor;
            }
        }

        private void searchRTextBox_Enter(object sender, EventArgs e)
        {
            searchRTextBox.Text = String.Empty;
            searchRTextBox.ForeColor = DefaultColor;
        }

        private void AddRButton_Click(object sender, EventArgs e)
        {

            AddRecipes addRecipes = new AddRecipes();
            DialogResult result = addRecipes.ShowDialog();

            //check if result is ok
            if (result == DialogResult.OK)
                displayRecipe(addRecipes.recipeDataList);

            //for (int i = 0; i <= 10; i++)
            //{
            //    Button button = new Button();
            //    button.Click += new EventHandler(ItemClicked);
            //    button.ContextMenuStrip = this.contextMenuStrip;
            //    RecipeItemPanel rip = new RecipeItemPanel("Egusi melon", "23.34", button);
            //    this.RecipeFlowLayoutPanel.Controls.Add(rip);
            //}
            //this.flowLayoutPanel1.Controls.Add(new RecipeItemPanel("Egusi melon", "23.34", count));
            //count++;
        }

        private void displayRecipe(List<RecipeDataModel.RecipeData> recipeData)
        {            
            if(recipeData != null && recipeData.Any())
                foreach (var data in recipeData)
                {
                    Button button = new Button();
                    button.Click += new EventHandler(ItemClicked);
                    button.ContextMenuStrip = this.ContextMenuStrip;
                    this.RecipeFlowLayoutPanel.Controls.Add(new RecipeItemPanel(data.recipeName, data.id, button));
                }
        }

        private void displayRecipe(IEnumerable<RecipeDataModel.RecipeData> recipeData)
        {
            if(recipeData != null && recipeData.Any())//
                foreach (var data in recipeData)
                {
                    Button button = new Button();
                    button.Click += new EventHandler(ItemClicked);
                    button.ContextMenuStrip = this.ContextMenuStrip;
                    this.RecipeFlowLayoutPanel.Controls.Add(new RecipeItemPanel(data.recipeName, data.id, button));
                }   
        }

        private void isBusy(bool value)
        {
            this.progressBar.Visible = value;
        }
        private void ItemClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)            
                new UpdateDataGridView().updateSelectedRecipeDataGrid(btn.Name, this.cartDataGridView);
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //get the clicked toolstrip item of the contextMenu
            ToolStripItem item = e.ClickedItem;
            switch (item.Text.ToLower())
            {
                case "edit":
                    {
                        //TODO edit recipe and update server and db
                        break;
                    }
                case "delete":
                    {
                        Control c = this.contextMenuStrip.SourceControl;
                        if (c != null)
                        {
                            Control p = c.Parent;
                            this.RecipeFlowLayoutPanel.Controls.Remove(p);
                            //TODO delete recipe from db and server
                        }
                        break;
                    }
            }           
           
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            new UpdateDataGridView().clearDataInDataGridView(this.cartDataGridView);
        }

        private void Recipes_Load(object sender, EventArgs e)
        {                      
            //set clicked event of contextMenu to a function
            this.contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);

            //get recipes from db
            //displayRecipe(DatabaseOperations.getRecipe());
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            if (NetworkConnectivity.DnsTest())
            {
                AppRepo repo = new AppRepo();
                isBusy(true);
                var data = DatabaseOperations.getToken();
                RecipeDataModel recipeDataModel = await repo.getAllRecipe(data.token);
                isBusy(false);
                if(recipeDataModel != null && recipeDataModel.status && recipeDataModel.results != null)
                {
                    displayRecipe(recipeDataModel.results);
                    DatabaseOperations.addRecipe(recipeDataModel);
                }
            }
        }
    }
}
