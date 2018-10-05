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
using TheThrustGuru.DataModels;

namespace TheThrustGuru
{
    public partial class RestuarantSalesReport : Form
    {
        private List<RecipesDataModel> soldRecipes;
        public RestuarantSalesReport()
        {
            InitializeComponent();
        }

        private async void loadData()
        {
            soldRecipes = await DatabaseOperations.getSoldRecipes();
        } 

        private void RestuarantSalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
