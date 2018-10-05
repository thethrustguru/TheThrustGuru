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
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class Foods : Form
    {
        public Foods()
        {
            InitializeComponent();
            // set search texbox to gray state
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Text = "Search...";

            this.contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
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
        private void waterMarkOnTextBoxEnter(TextBox textbox)
        {
            textbox.Text = String.Empty;
            textbox.ForeColor = Color.Black;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            waterMarkOnTextBoxLeave(this.searchTextBox, "Search...");
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            waterMarkOnTextBoxEnter(this.searchTextBox);
        }

        private void isBusy(bool value)
        {
            this.progressBar.Visible = value;
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
            displayFoods(DatabaseOperations.getFoods());
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            new UpdateDataGridView().clearDataInDataGridView(this.cartDataGridView);
        }

        private void ItemClicked(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //if (btn != null)
               // new UpdateDataGridView().updateSelectedRecipeDataGrid(btn.Name, this.cartDataGridView);
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
                            this.foodFlowLayoutPanel.Controls.Remove(p);
                            //TODO delete recipe from db and server
                        }
                        break;
                    }
            }

        }

        private void displayFoods(IEnumerable<FoodsDataModel> foods)
        {
            if (foods != null && foods.Any())
            {
                this.foodFlowLayoutPanel.Controls.Clear();
                foreach (var data in foods)
                {
                    Button button = new Button();
                    button.Click += new EventHandler(ItemClicked);
                    button.ContextMenuStrip = this.contextMenuStrip;
                    //this.foodFlowLayoutPanel.Controls.Add(new RecipeItemPanel(data.name, data.id,FormatPrice.format(data.price), button));
                }
            }
                
        }

        private void AddRButton_Click(object sender, EventArgs e)
        {
            new AddFood().ShowDialog();           
            displayFoods(DatabaseOperations.getFoods());
        }
    }
}
