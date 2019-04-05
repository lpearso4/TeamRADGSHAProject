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
    

    public partial class Patient : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        RADGSHALibrary.Patient selectedPatient;

        public Patient()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        //This constructor is obsolete, and should only be used for testing purposes
        public Patient(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        public Patient(Form previousForm, RADGSHALibrary.Patient selectedPatient)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            this.selectedPatient = selectedPatient;
            //set the patient passed to this form as the active patient
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void useInventoryButton_Click(object sender, EventArgs e)
        {
            UseInventory U = new UseInventory(this);
            U.Show();
            Hide();
        }

        private void changeRoomButton_Click(object sender, EventArgs e)
        {
            ChangeRoom C = new ChangeRoom(this);
            C.Show();
            Hide();
        }

        private void diagnosisWizardButton_Click(object sender, EventArgs e)
        {
            // Open diagnosis wizard
            DiagnosisWizard D = new DiagnosisWizard(this);
            D.Show();
            Hide();
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous form after closing this one
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }
    }
}
