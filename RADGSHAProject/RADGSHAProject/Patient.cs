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
    

    public partial class Patient : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.Visit selectedVisit;
        Boolean editingPatient;

        public Patient()//This constructor can probably be safely removed
        {
            editingPatient = false;
            InitializeComponent();
            disableCurrentPatientTextBoxes();
        }

        //This constructor is obsolete, and should only be used for testing purposes
        public Patient(Form previousForm)
        {
            editingPatient = false;
            InitializeComponent();
            this.previousForm = previousForm;
            disableCurrentPatientTextBoxes();
        }

        public Patient(Form previousForm, RADGSHALibrary.Patient selectedPatient)
        {
            editingPatient = false;
            InitializeComponent();
            this.previousForm = previousForm;
            this.selectedPatient = selectedPatient;
            //set the patient passed to this form as the active patient
            displayPatient();
            disableCurrentPatientTextBoxes();

            selectedVisit = selectedPatient.getCurrentVisit();
            //selectedVisit = new RADGSHALibrary.Visit();
            //selectedVisit.setPatientId(selectedPatient.getSSN());

            checkInOutButton.Text = (selectedVisit == null) ? "Check In" : "Check Out";
            //checkInOutButton.Text = (selectedVisit.getExitDate() == null) ? "Check Out" : "Check In";
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
            patientGenderTextBox.Text = selectedPatient.getGender().ToString();
            patientBirthdateTextBox.Text = selectedPatient.getBirthDate().ToString("MM/dd/yyyy");

            if (selectedVisit==null)
            {
                EntryDatePicker.Visible = false;
              
            }
            else
            {
                EntryDatePicker.Visible = true;
                EntryDatePicker.Value = selectedVisit.getEntryDate();
                //roomNumber.Items = selectedVisit.getRoomList()
            }
        }

        private void toggleEditPatient()
        {
            if (!editingPatient)
            {
                enableCurrentPatientTextBoxes();
            }
            else
            {
                disableCurrentPatientTextBoxes();
                saveCurrentPatient();
            }

            editingPatient = !editingPatient;
        }

        private void enableCurrentPatientTextBoxes()
        {
            patientFirstNameTextBox.Enabled = true;
            PatientMiddleInitialTextBox.Enabled = true;
            patientLastNameTextBox.Enabled = true;
            patientAddressLine1TextBox.Enabled = true;
            patientAddressLine2TextBox.Enabled = true;
            patientCityTextBox.Enabled = true;
            patientStateTextBox.Enabled = true;
            patientZipTextBox.Enabled = true;
            patientGenderTextBox.Enabled = true;
            patientBirthdateTextBox.Enabled = true;
        }

        private void disableCurrentPatientTextBoxes()
        {
            patientFirstNameTextBox.Enabled = false;
            PatientMiddleInitialTextBox.Enabled = false;
            patientLastNameTextBox.Enabled = false;
            patientAddressLine1TextBox.Enabled = false;
            patientAddressLine2TextBox.Enabled = false;
            patientCityTextBox.Enabled = false;
            patientStateTextBox.Enabled = false;
            patientZipTextBox.Enabled = false;
            patientGenderTextBox.Enabled = false;
            patientBirthdateTextBox.Enabled = false;
        }

        private void saveCurrentPatient()
        {
            DBConnectionObject conn = DBConnectionObject.getInstance();
            selectedPatient.setFirstName(patientFirstNameTextBox.Text);
            selectedPatient.setMiddleInitial(PatientMiddleInitialTextBox.Text[0]);
            selectedPatient.setFirstName(patientFirstNameTextBox.Text);
            selectedPatient.setLastName(patientLastNameTextBox.Text);
            selectedPatient.setAddressLine1(patientAddressLine1TextBox.Text);
            selectedPatient.setAddressLine2(patientAddressLine2TextBox.Text);
            selectedPatient.setCity(patientCityTextBox.Text);
            selectedPatient.setState(patientStateTextBox.Text);
            selectedPatient.setZipcode(patientZipTextBox.Text);
            selectedPatient.setGender(patientGenderTextBox.Text[0]);
            selectedPatient.setBirthDate(DateTime.Parse(patientBirthdateTextBox.ToString()));

            conn.updatePatient(selectedPatient);
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
            ChangeRoom C = new ChangeRoom(this, ref selectedPatient, ref selectedVisit);
            C.ShowDialog();
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

            if (selectedVisit != null)
            {
                //the patient must be checking out, as they never exited their last visit.

                CheckOut C = new CheckOut(this, ref selectedPatient, ref selectedVisit);
                C.Closed += (s, args) => this.Close();
                C.Show();
               Hide();
                //selectedVisit.setExitDate(DateTime.Now);
                //RADGSHALibrary.DBConnectionObject conn = RADGSHALibrary.DBConnectionObject.getInstance();
                //conn.addVisit(selectedVisit, selectedPatient);
                //checkInOutButton.Text = "Check In";
                //selectedVisit = null;
            }
            else
            {
                DBConnectionObject conn = DBConnectionObject.getInstance();
                //The patient has already finished their last visit, must be checking into a new visit.
                //this.Hide();
               
                selectedPatient.checkIn();
                selectedVisit = selectedPatient.getCurrentVisit();
                selectedVisit.setEntryDate(DateTime.Now);
                selectedVisit.changeDiagnosis(VisitDiagnosisTextBox.Text);
                selectedVisit.setAttendingPhysician(textAttendingPhy.Text);
         
                ChangeRoom C = new ChangeRoom(this,ref selectedPatient, ref selectedVisit);
                C.Closed += (s, args) => this.Close();
                C.ShowDialog();
                conn.addVisit(selectedVisit, selectedPatient);
                if (selectedVisit.getRoomList()[0]!=null) conn.addStaysIn(selectedVisit.getRoomList()[0], selectedPatient, selectedVisit);
                checkInOutButton.Text = "Check Out";
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            toggleEditPatient();
            SaveButton.Text = editingPatient ? "Save" : "Edit";
        }

        private void VisitGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
