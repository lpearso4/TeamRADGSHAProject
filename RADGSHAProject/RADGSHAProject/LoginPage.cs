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
        private int secondsLockedOut;
        private int numberOfTries;

        public LoginPage()
        {
            InitializeComponent();
            secondsLockedOut = 0;
            numberOfTries = 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login(usernameTextBox.Text, passwordTextBox.Text);
        }

        string CreateHash(string password)
        {
             
            using (SHA256 sha256Hash = SHA256.Create())
            {                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                string hashedPassword = "";
                foreach (byte i in bytes)
                {
                    hashedPassword += i.ToString("x2");
                }

                return hashedPassword;
            }
        }

        private void Login(string username, string password)//Update for actual security checking
        {
            string message;  // for any messageboxes to follow
            string caption;

            string hashedPassword = CreateHash(password); // create sha256 hash of password

            RADGSHALibrary.User user = new RADGSHALibrary.User(username, hashedPassword);

            DBConnectionObject db;
            try
            {
                db = DBConnectionObject.getInstance();
            }
            catch (Exception e)
            {
                message = e.Message;
                caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            bool valid = db.validateLogin(user);

            if (valid)
            Console.WriteLine("validated successfully");
            else Console.WriteLine("invalid login attempt");

            if (valid)
            {
                bool isAdmin = db.validateUserType(user);
                if (isAdmin) Console.Write("User is admin user");
                else Console.WriteLine("User is not admin user");
                user.setAdmin(isAdmin);
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
                this.Hide();
                RADGSHALibrary.User validatedUserNoPassword = new RADGSHALibrary.User(user.getUsername(), "", user.isAdmin());
                MainPage M = new MainPage(validatedUserNoPassword, this);
                M.Closed += (s, args) => this.Close();
                M.Show();
            }
            else
            {
                message = "Error: User name or password is not valid!";
                caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                numberOfTries++;
            }

            if (numberOfTries == 5)
            {
                message = "Error: You've unsuccessfully tried to log in five times. You've been locked out for 10 minutes.";
                caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                loginButton.Enabled = false;
                timerLogin.Enabled = true;

            }
     
           
        }

        private void usernameTextBox_Clicked(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Username") usernameTextBox.Text = "";
        }

        private void passwordTextBox_Clicked(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password") passwordTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage M = new MainPage(this);
            M.Closed += (s, args) => this.Close();
            M.Show();
        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            secondsLockedOut++;

            if (secondsLockedOut==600)
            {
                timerLogin.Enabled = false;
                secondsLockedOut = 0;
                numberOfTries = 0;
                loginButton.Enabled = true;
            }
        }
    }
}
