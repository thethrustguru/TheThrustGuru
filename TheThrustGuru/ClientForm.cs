using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheThrustGuru.DataModels;

namespace TheThrustGuru
{
    public partial class ClientForm : Form
    {
        private LoginCredentials login;
        public ClientForm(LoginCredentials login)
        {
            InitializeComponent();
            this.login = login;
            if(login.role.ToLower() == "audit")
            {
                extrasToolStripMenuItem.Visible = true;
            }

            changeColorMainForm();

            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

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

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenSalesReport(login.storeLocation).Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salesInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new SalesForm().Show();
        }

        private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new ReceiptForm().Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PointOfSaleForm(login.storeLocation).Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PurchaseOrderForm().Show();
        }

        private void receivedNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GoodRecievedNotes().Show();
        }
    }
}
