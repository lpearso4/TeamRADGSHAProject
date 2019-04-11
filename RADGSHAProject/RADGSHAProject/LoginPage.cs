using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using RADGSHALibrary;

namespace RADGSHAProject
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login(usernameTextBox.Text, passwordTextBox.Text);
        }

        private void Login(string username, string password)//Update for actual security checking
        {

            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);
            string hashedPassword = Convert.ToBase64String(hash);
            Console.WriteLine(hashedPassword);

            RADGSHALibrary.User user = new RADGSHALibrary.User(username, hashedPassword);
            DBConnectionObject db = DBConnectionObject.getInstance();

            bool valid = db.validateLogin(user);

            if (valid)
            Console.WriteLine("validated successfully");
            else Console.WriteLine("invalid login attempt");

            this.Hide();
            MainPage M = new MainPage();
            M.Closed += (s, args) => this.Close();
            M.Show();
        }

        private void usernameTextBox_Clicked(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Username") usernameTextBox.Text = "";
        }

        private void passwordTextBox_Clicked(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password") passwordTextBox.Text = "";
        }
    }
}
