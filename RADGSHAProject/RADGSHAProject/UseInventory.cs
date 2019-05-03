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
    public partial class UseInventory : NavigationPage
    {
        
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.Visit selectedVisit;

        public UseInventory()//this constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public UseInventory(RADGSHALibrary.Patient selectedPatient, RADGSHALibrary.Visit selectedVisit)
        {
            InitializeComponent();
            this.selectedPatient = selectedPatient;
            this.selectedVisit = selectedVisit;
        }


        private void addFieldButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UseInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Close();
        }

        private void returnToPatientButton_Click(object sender, EventArgs e)
        {
            returnToPatient();
        }

        private void returnToPatient()
        {
            this.Hide();
            Patient P = new Patient(this, selectedPatient);
            P.Closed += (s, args) => this.Close();
            P.Show();
        }
    }
}
