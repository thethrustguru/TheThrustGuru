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
using TheThrustGuru.ReportViewers;
//using TheThrustGuru.DataModels;

namespace TheThrustGuru.Stores
{
    public partial class RestuarantMainForm : Form
    {
        public RestuarantMainForm()
        {
            InitializeComponent();

            changeColorMainForm();

            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Recipes().Show(); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new RestuarantSalesReport().Show();
            loadSalesReport();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddRecipes().Show();
        }

        private async void loadSalesReport()
        {
            var report = await DatabaseOperations.getSoldRecipes();
            if(report != null && report.Any())
            {
                new ResSalesReport(report).Show();
            }else
            {
                MessageBox.Show("No reports to display");
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

        private void RestuarantMainForm_Load(object sender, EventArgs e)
        {

        }       

        private void viewToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            new ViewRecipeForm().Show();
        }
    }
}
