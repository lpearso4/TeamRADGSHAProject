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
        static AddPatient addPatientInstance;
        static ImportTool importToolInstance;
        public static LoginPage loginPage;


        TimeSpan time;
        
        public NavigationPage()
        {
            time = TimeSpan.Zero;
           
            InitializeComponent();
            autoLogout.Enabled = true;
        }

        public void getSearchPatientInstance()
        {
            if(searchPatientInstance == null)
            {
                searchPatientInstance = new SearchPatient();
            }
            //searchPatientInstance.Closed += (s, args) => this.Close();
        }

        public void getAddPatientInstance()
        {
            if (addPatientInstance == null)
            {
                addPatientInstance = new AddPatient();
            }
            //addPatientInstance.Closed += (s, args) => this.Close();
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

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            getAddPatientInstance();

            addPatientInstance.Show();
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

        private void NavigationPage_MouseMove(object sender, MouseEventArgs e)
        {
            time = TimeSpan.Zero;
            labelTimeout.Text = "";
        }

        private void autoLogout_Tick(object sender, EventArgs e)
        {
            time = time + new TimeSpan(0, 0, 1);

            if (time.TotalMinutes>4)
            {
                labelTimeout.Text = "Auto-logout in " + ((5 * 60) - time.TotalSeconds) + " seconds"; 
            }
            
            if (time.TotalMinutes>=5)
            {
                logOutButton_Click(sender, e);
            }
        }
    }
}
