using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheThrustGuru
{
    public partial class Stocks : Form
    {
               
        private StocksRecordForm aForm = new StocksRecordForm();
        public Stocks()
        {
            InitializeComponent();
            changeColorMainForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }       

        private void Stocks_Load(object sender, EventArgs e)
        {
            this.allItemsButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            aForm.MdiParent = this;
            aForm.Show();
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
            foreach (Control control in panel.Controls)
            {
                Button btn = control as Button;
                if (btn != null)
                {
                    if (btn != button)
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

        private void AllItemsbutton_Click(object sender, EventArgs e)
        {
            this.allItemsButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            if (!aForm.Visible)
            {

                changeColorPanel(this.buttonsPanel, this.allItemsButton);
                aForm = new StocksRecordForm();
                aForm.MdiParent = this;
                aForm.Show();
                DisposeAllButThis(aForm);
            }

        }

        private void setUpStockbutton_Click(object sender, EventArgs e)
        {             
            new stockCategoryForm().ShowDialog();
        }
    }
}
