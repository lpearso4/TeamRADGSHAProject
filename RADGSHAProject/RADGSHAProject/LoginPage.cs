using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MainPage M = new MainPage(this);
            M.Show();
            Hide();
        }


    }
}
