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
    public partial class ExpensesForm : Form
    {
        private string oldText = string.Empty;
        private decimal totalAmount = 0;
        private List<ExpensesDataModel> expensesList;
        private ExpensesDataModel expense;
        public ExpensesForm()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text.ToLower() == "edit")
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (expensesList != null && expensesList.Any())
                    {
                        expense = expensesList.ElementAt(index);
                        nametextBox.Text = expense.name;
                        amtTextBox.Text = expense.amount.ToString();
                        dateTimePicker1.Value = expense.date;
                        descTextBox.Text = expense.desc;

                        editButton.Enabled = true;
                        deleteButton.Enabled = true;
                        saveButton.Enabled = false;                
                    }
                }
            }
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            loadDataFromDb();
        }

        private void loadDataFromDb()
        {
            dataGridView1.Rows.Clear();
            totalAmount = 0;
            expensesList = DatabaseOperations.getExpenses().ToList();
            if (expensesList != null && expensesList.Any())
            {
                new UpdateDataGridView().addExpensesToDataGridView(expensesList, dataGridView1);
                foreach (var datum in expensesList)
                {
                    totalAmount += datum.amount;
                }
            }
            totalAmtTextBox.Text = FormatPrice.format(totalAmount);
        }

        private void validateControls(bool isEdit)
        {
            if (string.IsNullOrWhiteSpace(nametextBox.Text) && string.IsNullOrEmpty(nametextBox.Text))
            {
                errorProvider1.SetError(nametextBox, "Please provide a valid name for expense");
                return;
            }
            else errorProvider1.Clear();
            if(!string.IsNullOrEmpty(amtTextBox.Text) && !string.IsNullOrWhiteSpace(amtTextBox.Text))
            {
                try
                {
                    decimal amt = decimal.Parse(amtTextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(amtTextBox, "Please provide a valid ammout for the expense. Amount must be numeric");
                    return;
                }
            }else
            {
                errorProvider1.SetError(amtTextBox, "Please provide a valid ammout for the expense. Amount must be numeric");
                return;
            }

            processData(isEdit);

        }

        private async void processData(bool isEdit)
        {
            string name = nametextBox.Text;
            decimal amt = decimal.Parse(amtTextBox.Text);
            DateTime date = dateTimePicker1.Value;
            string desc = descTextBox.Text;
            decimal amt_ = 0;
            if (isEdit)
            {

                if(expense != null)
                {
                    amt_ = expense.amount;
                    expense.name = name;
                    expense.amount = amt;
                    expense.date = date;
                    expense.desc = desc;

                    if (!MessagePrompt.displayPrompt("Edit", "edit this expense"))
                        return;

                    bool success = await DatabaseOperations.editExpenses(expense);
                    if (success)
                    {
                        MessageBox.Show("Data updated successfully");
                        totalAmount -= amt_;
                        totalAmount += amt;
                        totalAmtTextBox.Text = FormatPrice.format(totalAmount);
                    }else
                    {
                        MessageBox.Show("Data updating failed");
                    }
                }

            }else
            {
                ExpensesDataModel expense = new ExpensesDataModel
                {
                    name = name,
                    amount = amt,
                    date = date,
                    desc = desc
                };

                if (!MessagePrompt.displayPrompt("Create new expense", "create new expense"))
                    return;

                DatabaseOperations.addExpenses(expense);

                MessageBox.Show("Expenses created successfully");

                loadDataFromDb();

                nametextBox.Clear();
                amtTextBox.Clear();
                descTextBox.Clear();

                totalAmount += amt;
                totalAmtTextBox.Text = FormatPrice.format(totalAmount);
            }

            

        }

        private void clear()
        {
            nametextBox.Clear();
            amtTextBox.Clear();
            descTextBox.Clear();
            saveButton.Enabled = true;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            validateControls(false);
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nametextBox.Text.All(chr => char.IsLetter(chr) || char.IsWhiteSpace(chr) || char.IsPunctuation(chr)))
            {
                oldText = nametextBox.Text;
                nametextBox.Text = oldText;
            }
            else
            {
                nametextBox.Text = oldText;
            }
            nametextBox.SelectionStart = nametextBox.Text.Length;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            validateControls(true);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if(expense != null)
            {
                if (!MessagePrompt.displayPrompt("Delete", "delete this expense"))
                    return;
                bool success = await DatabaseOperations.deleteExpense(expense.id);
                if (success)
                {
                    MessageBox.Show("Data deleted successfully");
                    clear();
                    loadDataFromDb();
                }else
                {
                    MessageBox.Show("Data deletion failed");
                }
            }
        }
    }
}
