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
using TheThrustGuru.Logics;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class stockCategoryForm : Form
    {
        private IEnumerable<CategoryDataModel> categories;
        private int index;
        public stockCategoryForm()
        {
            InitializeComponent();
        }

        private async void validateControls()
        {
            if(string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrEmpty(nameTextBox.Text))
            {
                errorProvider1.SetError(nameTextBox, "Please enter a valid name");
                return;
            }
            {
                errorProvider1.Clear();
                if (!MessagePrompt.displayPrompt("Create New", "create new stock category"))
                    return;

               bool success = await DatabaseOperations.addCategory(new CategoryDataModel
                {
                    name = nameTextBox.Text,
                    others = othersTextBox.Text
                });
                if (success)
                {
                    MessageBox.Show("Category created successfully");
                    nameTextBox.Clear();
                    nameTextBox.Focus();
                    othersTextBox.Clear();

                    loadData();
                }else
                {
                    MessageBox.Show("Category creation failed");
                }
                
            }
           
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            validateControls();
        }

        private void loadData()
        {
            categories = DatabaseOperations.getCategory();
            if(categories != null && categories.Any())
            {
                dataGridView1.Rows.Clear();
                new UpdateDataGridView().addCategoriesToDataGridView(categories, dataGridView1);
            }
        }

        private void stockCategoryForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void editCategory()
        {
            var data = categories.ElementAt(index);
            nameTextBox.Text = data.name;
            othersTextBox.Text = data.others;
            editButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            editCategory();
        }

        private async void editButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrEmpty(nameTextBox.Text))
            {
                errorProvider1.SetError(nameTextBox, "Please enter a valid name");
                return;
            }
            {
                errorProvider1.Clear();

                var data = categories.ElementAt(index);
                data.name = nameTextBox.Text;
                data.others = othersTextBox.Text;

                if (!MessagePrompt.displayPrompt("Edit", "edit this stock category"))
                    return;
                bool success = await DatabaseOperations.updateCategory(data);
                if (!success)
                {
                    MessageBox.Show("Data updating failed");
                    return;
                }
                MessageBox.Show("Data updated successfully");

                loadData();              
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!MessagePrompt.displayPrompt("Delete", "delete this stock category"))
                return;

            var data = categories.ElementAt(index);
            if(data != null)
            {
                bool success = await DatabaseOperations.deleteCategory(data.id);
                if (!success)
                {
                    MessageBox.Show("Data deletion failed");
                    return;
                }

                loadData();

                nameTextBox.Clear();
                othersTextBox.Clear();
                editButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }
    }
}
