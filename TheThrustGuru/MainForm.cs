using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.Database;
using TheThrustGuru.DataModels;
using TheThrustGuru.Repository;
using TheThrustGuru.Stores;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class MainForm : Form
    {

       
      
        public MainForm()
        {
            InitializeComponent();

            changeColorMainForm();
                      
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
           
            //if (NetworkInterface.GetIsNetworkAvailable())
            //{
            //    this.networkLabel.Text = "Internet Available";
            //    this.networkLabel.ForeColor = Color.DarkGreen;
            //}
            //else
            //{
            //    this.networkLabel.Text = "Internet not Available";
            //    this.networkLabel.ForeColor = Color.DarkRed;
            //}

        }

        public MainForm(string role)
        {
            InitializeComponent();

            changeColorMainForm();

            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            switch (role.ToLower())
            {
                case "manager":
                    {
                        manageAccountToolStripMenuItem.Enabled = false;
                        break;
                    }
                case "staff":
                    {
                        analysisToolStripMenuItem.Enabled = false;
                        receiptsToolStripMenuItem.Enabled = false;
                        expensesToolStripMenuItem.Enabled = false;
                        break;
                    }
            }
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {                            

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

        private void restuarantToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }      

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageAccountForm().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PointOfSaleForm("admin").Show();
        }
       
        private void setupStoreLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StoreLocationForm().Show();
        }

        private void allStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stocksToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void purchaseInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchasesForm().Show();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void salesInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SalesForm().Show();
        }

        private void setUpSalesTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetupSalesTypeForm().Show();
        }

        private void setupServiceChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetupServiceChargeForm().Show();
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            new ChangePassword().Show();
        }

        private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReceiptForm().Show();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExpensesForm().Show();
        }

        private void vouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Vouchers().Show();
        }

        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void purchaseOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchaseOrderForm().Show();
        }

        private void setUnitPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private async void backupDbButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await DatabaseOperations.exportDB());
        }

        private void profitLossAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProfitLossForm().Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SalesReportForm().Show();
        }

        private void addNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(new PasscodeForm().ShowDialog() == DialogResult.OK)
                new AddReceivedGoods().Show();
        }

        private void viewGoodsReceivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GoodRecievedNotes().Show();
        }

        private void viewRecipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addNewRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void purchaseAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchasesForm().Show();
        }

        private void soldREcipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewRecipeForm().Show();
        }

        private void stockRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Stocks().Show();
        }

        private void setUnitPriceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SetStockUnitPriceForm().Show();
        }

        private void stockTransferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new StockTransferForm().Show();
        }

        private void recipeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewRecipeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AddRecipes().Show();
        }

        private void soldRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SoldRecipes().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restuarantToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new RestuarantMainForm().Show();
        }
    }
}
