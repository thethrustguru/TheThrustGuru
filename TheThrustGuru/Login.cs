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
using TheThrustGuru.Stores;
using TheThrustGuru.Utils;

namespace TheThrustGuru
{
    public partial class Login : Form
    {
        private string username = "admin";
        private string password = "AZ18E5";
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
            if(UsernameTextBox.Text == username && passwordTextBox.Text == password)
            {
                loginAdmin();
            }
            //else if(UsernameTextBox.Text == Constants.CLIENT_USERNAME && passwordTextBox.Text == Constants.CLIENT_PASSWORD)
            //{
            //    loginClient();
            //}
            else
            {               
                var loginDetails = DatabaseOperations.getLoginDetails();
                if (loginDetails != null && loginDetails.Any())
                {
                    foreach(var data in loginDetails)
                    {
                        if(UsernameTextBox.Text == data.username && passwordTextBox.Text == data.password)
                        {
                            login(data);
                            break;
                        }
                    }
                }else
                {                    
                    errorProvider1.SetError(this.UsernameTextBox, "Login was not successful. Try again later");
                    return;
                }
            }           
        }

        private void loginClient(LoginCredentials login)
        {
            this.Hide();
            var clientForm = new ClientForm(login);
            clientForm.Closed += (s, args) => this.Close();
            clientForm.Show();
        }

        private void openRes()
        {
            this.Hide();
            var resForm = new RestuarantMainForm();
            resForm.Closed += (s, args) => this.Close();
            resForm.Show();
        }

        private void loginManager()
        {
            this.Hide();
            var mainform = new MainForm("manager");
            mainform.Closed += (s, args) => this.Close();
            mainform.Show();
        }

        private void loginAdmin()
        {
            this.Hide();
            var mainform = new MainForm();
            mainform.Closed += (s, args) => this.Close();
            mainform.Show();
        }

        private void login(LoginCredentials login)
        {
            //"Admin","Supervisor","Audit","Manager","Staff"
            // "Bar", "Bakery", "Hotel", "Laundry", "Restuarant", "Park"

            switch (login.role.ToLower())
            {
                case "supervisor":
                    {
                        switch (login.storeLocation.ToLower())
                        {
                            case "restuarant":
                                {
                                    openRes();
                                }
                                break;
                            default:
                                {
                                    loginClient(login);
                                    break;
                                }
                        }
                        break;
                    }
                case "manager":
                    {
                        loginManager();                        
                        break;
                    }
                case "audit":
                    {
                        switch (login.storeLocation.ToLower())
                        {
                            case "restuarant":
                                {
                                    openRes();
                                }
                                break;
                            default:
                                {
                                    loginClient(login);
                                    break;
                                }
                        }
                        break;
                    }
                case "staff":
                    {
                        switch (login.storeLocation.ToLower())
                        {
                            case "restuarant":
                                {
                                    openRes();
                                }
                                break;
                            default:
                                {
                                    loginClient(login);
                                    break;
                                }
                        }
                        break;
                    }
            }
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
