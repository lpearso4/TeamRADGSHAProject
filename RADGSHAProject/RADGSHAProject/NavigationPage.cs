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
    public partial class NavigationPage : Form
    {
        static SearchPatient searchPatientInstance;
        static ImportTool importToolInstance;
        public static LoginPage loginPage;


        public NavigationPage()
        {
            InitializeComponent();
        }

        public void getSearchPatientInstance()
        {
            if(searchPatientInstance == null)
            {
                searchPatientInstance = new SearchPatient();
            }
            //searchPatientInstance.Closed += (s, args) => this.Close();
        }

        public void getImportToolInstance()
        {
            if(importToolInstance == null)
            {
                importToolInstance = new ImportTool();
            }
            //importToolInstance.Closed += (s, args) => this.Close();
        }

        private void searchPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            getSearchPatientInstance();
            
            searchPatientInstance.Show();
        }

        private void importToolButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            getImportToolInstance();

            importToolInstance.Show();
        }

        private void NavigationPage_Load(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //LoginPage L = new LoginPage();
            //L.Closed += (s, args) => this.Close();
            searchPatientInstance = null;
            importToolInstance = null;
            //this.Dispose();
            loginPage.Show();
            
        }

        private void NavigationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Close();
        }
    }
}
