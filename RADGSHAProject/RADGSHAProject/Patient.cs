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
        RADGSHALibrary.Visit selectedVisit;

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
            displayPatient();

            //selectedVisit = selectedPatient.getCurrentVisit();
            selectedVisit = new RADGSHALibrary.Visit();
            //selectedVisit.setPatientId(selectedPatient.getSSN());

            checkInOutButton.Text = (selectedVisit.getExitDate() == null) ? "Check Out" : "Check In";
        }

        private void displayPatient()
        {
            patientFirstNameTextBox.Text = selectedPatient.getFirstName();
            PatientMiddleInitialTextBox.Text = selectedPatient.getMiddleInitial().ToString();
            patientLastNameTextBox.Text = selectedPatient.getLastName();
            patientAddressLine1TextBox.Text = selectedPatient.getAddressLine1();
            patientAddressLine2TextBox.Text = selectedPatient.getAddressLine2();
            patientCityTextBox.Text = selectedPatient.getCity();
            patientStateTextBox.Text = selectedPatient.getState();
            patientZipTextBox.Text = selectedPatient.getZipcode();
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void useInventoryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UseInventory U = new UseInventory();
            U.Closed += (s, args) => this.Close();
            U.Show();
        }

        private void changeRoomButton_Click(object sender, EventArgs e)
        {
            ChangeRoom C = new ChangeRoom();
            C.Show();
        }

        private void diagnosisWizardButton_Click(object sender, EventArgs e)
        {
            // Open diagnosis wizard
            this.Hide();
            DiagnosisWizard D = new DiagnosisWizard(selectedPatient, selectedVisit);
            D.Closed += (s, args) => this.Close();
            D.Show();
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous form after closing this one
        {
            Dispose();
        }

        private void checkInOutButton_Click(object sender, EventArgs e)
        {
            if (selectedVisit.getExitDate() == null)
            {
                //the patient must be checking out, as they never exited their last visit.
                selectedVisit.setExitDate(DateTime.Now);
                RADGSHALibrary.DBConnectionObject conn = RADGSHALibrary.DBConnectionObject.getInstance();
                conn.addVisit(selectedVisit, selectedPatient);
                checkInOutButton.Text = "Check In";
            }
            else
            {
                //The patient has already finished their last visit, must be checking into a new visit.
                this.Hide();
                ChangeRoom C = new ChangeRoom(ref selectedPatient, ref selectedVisit);
                C.Closed += (s, args) => this.Close();
                C.Show();
                checkInOutButton.Text = "Check Out";
            }
        }
    }
}
