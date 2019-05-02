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
        TimeSpan time;
        
        public NavigationPage()
        {
            time = TimeSpan.Zero;
            InitializeComponent();
        }

        private void searchPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchPatient S = new SearchPatient();
            S.Closed += (s, args) => this.Close();
            S.Show();
        }

        private void importToolButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportTool I = new ImportTool();
            I.Closed += (s, args) => this.Close();
            I.Show();
        }

        private void NavigationPage_Load(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage L = new LoginPage();
            L.Closed += (s, args) => this.Close();
            this.Dispose();
            L.Show();
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
