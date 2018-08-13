using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Repository;

namespace TheThrustGuru
{
    public partial class MainForm : Form
    {

        private FoodItems foodItems = new FoodItems();
        private Recipes recipes = new Recipes();
        private Home home  = new Home();
      
        public MainForm()
        {
            InitializeComponent();

            changeColorMainForm();
                      
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            buttonsPanel.Height = Screen.PrimaryScreen.WorkingArea.Height;

            //NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(networkChangedEvent);

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                this.networkLabel.Text = "Internet Available";
                this.networkLabel.ForeColor = Color.DarkGreen;
            }
            else
            {
                this.networkLabel.Text = "Internet not Available";
                this.networkLabel.ForeColor = Color.DarkRed;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //home = new Home();         
            this.homeButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            home.MdiParent = this;
            home.Show();                     


        }

        private void networkChangedEvent(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                this.networkLabel.Text = "Internet Available";
                this.networkLabel.ForeColor = Color.DarkGreen;
            }
            else
            {
                this.networkLabel.Text = "Internet not Available";
                this.networkLabel.ForeColor = Color.DarkRed;
            }
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
            foreach(Control control in panel.Controls)
            {
                Button btn = control as Button;
                if(btn != null)
                {
                    if(btn != button)
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void homeButton_Click(object sender, EventArgs e)
        {
            if (!home.Visible)
            {
                this.homeButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
                changeColorPanel(this.buttonsPanel, this.homeButton);
                home = new Home();
                home.MdiParent = this;
                home.Show();
                DisposeAllButThis(home);
            }
        }
    }
}
