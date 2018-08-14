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
    public partial class ManageAccountForm : Form
    {
        SuppliersForm sForm = new SuppliersForm();
        public ManageAccountForm()
        {
            InitializeComponent();
            changeColorMainForm();
        }

        private void allItemsButton_Click(object sender, EventArgs e)
        {
            this.suppliersButton.BackColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            if (!sForm.Visible)
            {

                changeColorPanel(this.buttonsPanel, this.suppliersButton);
                sForm = new SuppliersForm();
                sForm.MdiParent = this;
                sForm.Show();
                DisposeAllButThis(sForm);
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

        private void ManageAccountForm_Load(object sender, EventArgs e)
        {
            this.suppliersButton.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
            sForm.MdiParent = this;
            sForm.Show();
        }
    }
}
