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
using TheThrustGuru.DataModels;
using TheThrustGuru.Logics;

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

            //AddRecipes addRecipes = new AddRecipes();
            //DialogResult result = addRecipes.ShowDialog();

            ////check if result is ok
            //if(result == DialogResult.OK)
            //{
            //    List<RecipeDataModel.RecipeData> recipeData = addRecipes.recipeDataList;
            //    foreach(var data in recipeData)
            //    {
            //        Button button = new Button();
            //        button.Click += new EventHandler(ItemClicked);
            //        button.ContextMenuStrip = this.ContextMenuStrip;
            //        this.flowLayoutPanel1.Controls.Add(new RecipeItemPanel(data.recipeName, data.id, button));
            //    }
                
            //}

            for (int i = 0; i <= 10; i++)
            {
                Button button = new Button();
                button.Click += new EventHandler(ItemClicked);
                button.ContextMenuStrip = this.contextMenuStrip;
                RecipeItemPanel rip = new RecipeItemPanel("Egusi melon", "23.34", button);
                this.flowLayoutPanel1.Controls.Add(rip);
            }
            //this.flowLayoutPanel1.Controls.Add(new RecipeItemPanel("Egusi melon", "23.34", count));
            //count++;
        }

        private void ItemClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn == null)
            {
                this.searchRTextBox.Text = "null";
                return;
            }
            this.searchRTextBox.Text = btn.Tag.ToString();
            new UpdateDataGridView().updateSelectedRecipeDataGrid(btn.Name, this.cartDataGridView);
        }

        private void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //get the clicked toolstrip item of the contextMenu
            ToolStripItem item = e.ClickedItem;            
            MessageBox.Show(this.contextMenuStrip.SourceControl.Tag.ToString());
            // your code here
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            new UpdateDataGridView().clearDataInDataGridView(this.cartDataGridView);
        }

        private void Recipes_Load(object sender, EventArgs e)
        {
            this.ExportRButton.ContextMenuStrip = this.contextMenuStrip;
            
            //set clicked event of contextMenu to a function
            this.contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
        }


    }
}
