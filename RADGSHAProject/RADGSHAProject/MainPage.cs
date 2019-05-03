using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RADGSHALibrary;

namespace RADGSHAProject
{
    public partial class MainPage : NavigationPage
    {
        
        User user;



        public MainPage()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }
        public MainPage(User newUser, LoginPage loginPage)
        {
            InitializeComponent();
            user = newUser;
            if (user.isAdmin())
            {
                importToolButton.Visible = true;
            }
            else
            {
                importToolButton.Visible = false;
            }
            lblUser.Text = user.getUsername();
            NavigationPage.loginPage = loginPage;
        }
        public MainPage(LoginPage loginPage)
        {
            InitializeComponent();
            NavigationPage.loginPage = loginPage;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Close();
        }
    }
}
