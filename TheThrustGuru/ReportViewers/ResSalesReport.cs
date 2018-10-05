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

namespace TheThrustGuru.ReportViewers
{
    public partial class ResSalesReport : Form
    {
        private List<RecipesDataModel> recipes;
        private DateTime dateTime = DateTime.Now;
        public ResSalesReport()
        {
            InitializeComponent();
        }

        public ResSalesReport(List<RecipesDataModel> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void loadRecipes(DateTime dateTime)
        {
            dateLabel.Text = dateTime.ToString();
            var newRecipe = recipes.Where(x => x.dateCreated == dateTime);
            if(newRecipe != null && newRecipe.Any())
            {
                RecipesDataModelBindingSource.DataSource = newRecipe;
                reportViewer1.RefreshReport();
            }else
            {
                MessageBox.Show("No sales report on this day");
            }
            
        }

        private void ResSalesReport_Load(object sender, EventArgs e)
        {
            loadRecipes(dateTime);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            try
            {
                dateTime = dateTime.AddDays(-1);
                loadRecipes(dateTime);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                dateTime = dateTime.AddDays(1);
                loadRecipes(dateTime);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
