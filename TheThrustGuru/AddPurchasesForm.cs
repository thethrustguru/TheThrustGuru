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
    public partial class AddPurchasesForm : Form
    {
        private IEnumerable<ItemsDataModel> itemsData;
        private int mQuantityRemaining;
        private decimal mProductPrice;
        private decimal grandTotalPrice = 0;
        private int grandTotalQuantity = 0;
        private string supplierId;
        private string itemId;
        private IEnumerable<SupplierDataModel> supplierData;
        private List<PurchaseDataModel.Product> products = new List<PurchaseDataModel.Product>();
        public AddPurchasesForm()
        {
            InitializeComponent();
        }

        private void AddPurchasesForm_Load(object sender, EventArgs e)
        {
            supplierData = DatabaseOperations.getSuppliers();
            if(supplierData != null && supplierData.Any())
            {
                foreach(var datum in supplierData)
                {
                    this.supplierNameComboBox.Items.Add(datum.name);
                }
            }

            itemsData = DatabaseOperations.getItems();
            if(itemsData != null && itemsData.Any())
            {
                foreach(var item in itemsData)
                {
                    this.productcomboBox.Items.Add(item.itemName);
                }
            }

            this.invoicetextBox.Text = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            
        }

        private void productcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.productcomboBox.SelectedIndex;
            var data = itemsData.ElementAt(index);
            pricetextBox.Text = data.itemCostPrice.ToString("C3");
            this.quantityRemainingtextBox.Text = data.itemQuantity.ToString();
            mQuantityRemaining = data.itemQuantity;
            mProductPrice = data.itemCostPrice;
            itemId = data.id;

            grandTotalPricetextBox.Text = (grandTotalPrice + getTotalPrice(quantityToSupplytextBox.Text)).ToString("C3");
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");
        }

        private string getTotalQuantity(string text)
        {
            try
            {
                int quantity = int.Parse(text);
                return (grandTotalQuantity + quantity).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private decimal getTotalPrice(string text)
        {
            try
            {
                int quantity = int.Parse(text);
                return (quantity * mProductPrice);
            }
            catch (Exception ex)
            {
                return mProductPrice;
            }
        }

        private void validateControl()
        {
            if (string.IsNullOrWhiteSpace(productcomboBox.Text))
            {
                errorProvider1.SetError(this.productcomboBox, "Please select a valid product");
                return;
            }
            else errorProvider1.Clear();
            if (!string.IsNullOrWhiteSpace(quantityToSupplytextBox.Text))
            {
                try
                {
                    int q = int.Parse(quantityToSupplytextBox.Text);
                    errorProvider1.Clear();
                }catch(Exception ex)
                {
                    errorProvider1.SetError(quantityToSupplytextBox, "Please enter a valid quantity to supply. Quantity must be numeric");
                    return;
                }
            }else
            {
                errorProvider1.SetError(quantityToSupplytextBox, "Please enter a valid quantity to supply. Quantity must be numeric");
                return;
            }

            addproductToDatagridView();
        }
        private void validateAllControls()
        {
            if (string.IsNullOrWhiteSpace(supplierNameComboBox.Text))
            {
                errorProvider1.SetError(supplierNameComboBox, "Please select a valid supplier");
                return;
            }
            else errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(statusComboBox.Text))
            {
                errorProvider1.SetError(statusComboBox, "Please select a valid status");
                return;
            }
            else errorProvider1.Clear();
            if (dataGridView1.RowCount == 0)
            {
                errorProvider1.SetError(dataGridView1, "Please add items to supply");
                return;
            }
            else errorProvider1.Clear();

            processData();
        }

        private void processData()
        {
            string supplierName = supplierNameComboBox.Text;
            string status = statusComboBox.Text;
            string date = dateTimePicker1.Value.ToString();
            string invoice = invoicetextBox.Text;

            DatabaseOperations.addPurchases(new PurchaseDataModel
            {
                supplierId = supplierId,
                supplierName = supplierName,
                status = status,
                date = date,
                invoiceNo = invoice,
                grandTotalPrice = grandTotalPrice,
                grandTotalQuantity = grandTotalQuantity,
                productsList = products
            });
            MessageBox.Show("Purchase saved successfull");

            this.invoicetextBox.Text = RandomIDGenerator.randomInt(Constants.INVOICE_NO_LENGTH);
            this.dataGridView1.Rows.Clear();
            grandTotalPrice = 0;
            grandTotalQuantity = 0;
            totalPriceTextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            grandTotalPricetextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");



        }
        private void addproductToDatagridView()
        {
            string productName = productcomboBox.Text;            
            int quantityToSupply = int.Parse(quantityToSupplytextBox.Text);

            PurchaseDataModel.Product product = new PurchaseDataModel.Product
            {
                itemId = itemId,
                productName = productName,
                productPrice = mProductPrice,
                quantityToSupply = quantityToSupply,
                quantityRemaining = mQuantityRemaining
            };
            new UpdateDataGridView().addProductsToDataGridView(product, this.dataGridView1);
            products.Add(product);

            grandTotalPrice += getTotalPrice(quantityToSupplytextBox.Text);
            grandTotalQuantity += quantityToSupply;
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            validateControl();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            grandTotalPrice = 0;
            grandTotalQuantity = 0;
            totalPriceTextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            grandTotalPricetextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");
        }

        private void quantityToSupplytextBox_TextChanged(object sender, EventArgs e)
        {
            grandTotalQuantitytextBox.Text = getTotalQuantity(quantityToSupplytextBox.Text);
            totalPriceTextBox.Text = getTotalPrice(quantityToSupplytextBox.Text).ToString("C3");
            grandTotalPricetextBox.Text = (grandTotalPrice + getTotalPrice(quantityToSupplytextBox.Text)).ToString("C3");
        }

        private void supplierNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = supplierNameComboBox.SelectedIndex;
            var supplier = supplierData.ElementAt(index);
            supplierId = supplier.id;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            processData();
        }
    }
}
