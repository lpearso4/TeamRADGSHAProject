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
    public partial class MainPage : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public MainPage()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public MainPage(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void ImportTool_Click(object sender, EventArgs e)//consider checking if the user is an admin in the method, or just hide this button from regular users
        {
            ImportTool I = new ImportTool(this);
            I.Show();
            Hide();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void SearchPatient_Click(object sender, EventArgs e)
        {
            SearchPatient S = new SearchPatient(this);
            S.Show();
            Hide();
        }

        private void addPatientButton_Click(object sender, EventArgs e)//as of right now, there is not Add Patient form in the project
        {

        }

        private void FormClose(object sender, FormClosedEventArgs e)//displays Login page after closing Main Page
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }
    }
}
