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

       
      
        public MainForm()
        {
            InitializeComponent();

            changeColorMainForm();
                      
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            //buttonsPanel.Height = Screen.PrimaryScreen.WorkingArea.Height;

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
            new ManageAccountForm().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PointOfSaleForm().ShowDialog();
        }
       
        private void setupStoreLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StoreLocationForm().ShowDialog();
        }

        private void allStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Stocks().ShowDialog();
        }

        private void stocksToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void purchaseInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchasesForm().ShowDialog();
        }

        private void recipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Recipes().ShowDialog();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void salesInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SalesForm().ShowDialog();
        }

        private void setUpSalesTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetupSalesTypeForm().ShowDialog();
        }

        private void setupServiceChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetupSalesTypeForm(true).ShowDialog();
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReceiptForm().ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExpensesForm().ShowDialog();
        }

        private void vouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Vouchers().ShowDialog();
        }

        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new StockTransferForm().ShowDialog();
        }
    }
}
