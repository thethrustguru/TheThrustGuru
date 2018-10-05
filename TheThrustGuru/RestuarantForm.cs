using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheThrustGuru
{
    public partial class RestuarantForm : Form
    {

        private FoodItems foodItems = new FoodItems();
        private Recipes recipes = new Recipes();
        private Foods fForm = new Foods();

        public RestuarantForm()
        {
            InitializeComponent();
            //Left = Top = 0;
            //Width = Screen.PrimaryScreen.WorkingArea.Width;
            //Height = Screen.PrimaryScreen.WorkingArea.Height;
            buttonsPanel.Height = Screen.PrimaryScreen.WorkingArea.Height;

            changeColorMainForm();
        }

        private void RestuarantForm_Load(object sender, EventArgs e)
        {            
            this.foodsButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            fForm.MdiParent = this;
            fForm.Show();
        }

        private void changeColorMainForm()
        {
            //#1
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.Lavender;
                    // 4#
                    break;
                }
            }
        }

        private void changeColorPanel(Panel panel, Button button)
        {
            foreach (Control control in panel.Controls)
            {
                Button btn = control as Button;
                if (btn != null)
                {
                    if (btn != button)
                        btn.BackColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
                }
            }
        }
        private void DisposeAllButThis(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != form)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }

        private void foodItemsButton_Click(object sender, EventArgs e)
        {
            this.foodItemsButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            //check that form is not already showing then show it
            if (!foodItems.Visible)
            {

                changeColorPanel(this.buttonsPanel, this.foodItemsButton);
                foodItems = new FoodItems();
                foodItems.MdiParent = this;
                foodItems.Show();
                DisposeAllButThis(foodItems);
            }
        }

        private void recipesButton_Click(object sender, EventArgs e)
        {
            //check if form is not already showing then show it 
            if (!recipes.Visible)
            {
                this.recipesButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
                changeColorPanel(this.buttonsPanel, this.recipesButton);
                recipes = new Recipes();
                recipes.MdiParent = this;
                recipes.Show();
                DisposeAllButThis(recipes);
            }
        }

        private void foodsButton_Click(object sender, EventArgs e)
        {
            if (!fForm.Visible)
            {
                this.foodsButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
                changeColorPanel(this.buttonsPanel, this.foodsButton);
                fForm = new Foods();
                fForm.MdiParent = this;
                fForm.Show();
                DisposeAllButThis(fForm);
            }
        }
    }
}
