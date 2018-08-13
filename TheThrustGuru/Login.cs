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
using TheThrustGuru.Repository;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void validateData()
        {
            if (string.IsNullOrWhiteSpace(this.UsernameTextBox.Text))
            {
                errorProvider1.SetError(this.UsernameTextBox, "Please enter a valid username");
                return;
            }
            else errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(this.passwordTextBox.Text))
            {
                errorProvider1.SetError(this.passwordTextBox, "Please enter a valid password");
                return;
            }
            else errorProvider1.Clear();

            processData();
        }

        private async void processData()
        {
            string username = this.UsernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            AppRepo repo = new AppRepo();

            if (NetworkConnectivity.DnsTest())
            {
                isBusy(true);
                var data = await repo.loginUser(new LoginDataModel { email = username, password = password });

                if (data != null && data.status)
                {
                    DatabaseOperations.saveToken(data);
                    this.Hide();
                    var mainform = new MainForm();
                    mainform.Closed += (s, args) => this.Close();
                    mainform.Show();
                }
                else
                {
                    isBusy(false);
                    errorProvider1.SetError(this.UsernameTextBox, "Login was not successful. Try again later");
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constants.INTERNET_CONNECTION_ERR_MSG,Constants.INTERNET_CONNECTION_ERROR);
                return;
            }

                                    
            
        }

        private void isBusy(bool value)
        {
            this.progressBar1.Visible = value;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            validateData();            
        }
    }
}
