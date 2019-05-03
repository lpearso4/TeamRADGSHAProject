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

        public Patient()
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
            selectedVisit = selectedPatient.getCurrentVisit();
            editingPatient = false;
            InitializeComponent();
            this.previousForm = previousForm;
            this.selectedPatient = selectedPatient;
            //set the patient passed to this form as the active patient
            displayPatient();
            disableCurrentPatientTextBoxes();

            
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
            patientSSN.Text = selectedPatient.getSSN();
            patientInsurerID.Text = selectedPatient.getInsurer();
            
            if (selectedPatient.getDoNotResuscitateStatus())
            {
                patientDNR.Text = "True";
            }
            else
            {
                patientDNR.Text = "False";
            }
            if (selectedPatient.getOrganDonorStatus())
            {
                patientOrganDonor.Text = "True";
            }
            else
            {
                patientOrganDonor.Text = "False";
            }


            //patientBirthdateTextBox.Text = selectedPatient.getBirthDate().ToString("MM/dd/yyyy");
            dateBirthdate.Value = selectedPatient.getBirthDate();
            if (selectedVisit==null)
            {
                EntryDatePicker.Visible = false;
                changeRoomButton.Enabled = false;
                diagnosisWizardButton.Enabled = false;
                useInventoryButton.Enabled = false;
            }
            else
            {
                EntryDatePicker.Visible = true;
                EntryDatePicker.Value = selectedVisit.getEntryDate();

                if (selectedVisit.getRoomList().Count>0) visitRoomNumber.Text = selectedVisit.getRoomList()[selectedVisit.getRoomList().Count-1].getRoomNumber();
                textSymptoms.Text = "";
                foreach (string s in selectedVisit.getSymptomList())
                {
                    textSymptoms.Text += s + "\r\n";
                }
                VisitDiagnosisTextBox.Text = selectedVisit.getDiagnosis();
                textAttendingPhy.Text = selectedVisit.getAttendingPhysician();
                visitNotes.Text = selectedVisit.getNote();
                changeRoomButton.Enabled = true;
                diagnosisWizardButton.Enabled = true;
                useInventoryButton.Enabled = true;
                //roomNumber.Items = selectedVisit.getRoomList()
            }
            listPreviousVisits.Items.Clear();
            
       
            for (int i = selectedPatient.getVisitList().Count-1; i >=0; i--) // selectedPatient.getVisitList.Count Visit v in selectedPatient.getVisitList())
            {
                Visit v = selectedPatient.getVisitList()[i];
                if (selectedVisit != null && selectedVisit.getEntryDate() == v.getEntryDate()) continue; // we don't want to display current visit in previous visit list 
                Console.WriteLine("Adding previous visit at date: " + v.getEntryDate().ToShortDateString());

                ListViewItem previousVisit = new ListViewItem(v.getEntryDate().ToString());
                previousVisit.SubItems.Add(v.getAttendingPhysician());
                previousVisit.SubItems.Add(v.getDiagnosis());
               
               // previousVisitList.Items.Add(previousVisit);
                listPreviousVisits.Items.Add(previousVisit);
            }

            if (selectedVisit == null)
            {
                textSymptoms.Enabled = true;
                VisitDiagnosisTextBox.Enabled = true;
                textAttendingPhy.Enabled = true;
                visitNotes.Enabled = true;
            }
            else
            {
                textSymptoms.Enabled = false;
                VisitDiagnosisTextBox.Enabled = false;
                textAttendingPhy.Enabled = false;
                visitNotes.Enabled = false;
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
            //patientBirthdateTextBox.Enabled = true;
            dateBirthdate.Enabled = true;

            patientDNR.Enabled = true;
            patientOrganDonor.Enabled = true;
            patientInsurerID.Enabled = true;

            textSymptoms.Enabled = true;
            VisitDiagnosisTextBox.Enabled = true;
            textAttendingPhy.Enabled = true;
            visitNotes.Enabled = true;
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

            patientDNR.Enabled = false;
            patientOrganDonor.Enabled = false;
            patientInsurerID.Enabled = false;

            dateBirthdate.Enabled = false;
            if (selectedVisit != null)
            {
                textSymptoms.Enabled = false;
                VisitDiagnosisTextBox.Enabled = false;
                textAttendingPhy.Enabled = false;
                visitNotes.Enabled = false;
            }
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
            selectedPatient.setInsurer(patientInsurerID.Text);

            if (patientDNR.Text=="True")
            {
                selectedPatient.setDoNotResuscitateStatus(true);
            }
            else if (patientDNR.Text=="False")
            {
                selectedPatient.setDoNotResuscitateStatus(false);
            }

            if (patientOrganDonor.Text == "True")
            {
                selectedPatient.setOrganDonorStatus(true);
            }
            else if (patientOrganDonor.Text == "False")
            {
                selectedPatient.setOrganDonorStatus(false);
            }



            selectedPatient.setBirthDate(dateBirthdate.Value);

            conn.updatePatient(selectedPatient);

            if (selectedVisit!=null)
            {
                selectedVisit.setEntryDate(EntryDatePicker.Value);
                selectedVisit.setAttendingPhysician(textAttendingPhy.Text);
                selectedVisit.changeDiagnosis(VisitDiagnosisTextBox.Text);
                selectedVisit.setNote(visitNotes.Text);
                
                for(int i = 0; i<textSymptoms.Lines.Length;i++)
                {
                    bool hasSymptom = false; ;
                    foreach(string s in selectedVisit.getSymptomList())
                    {
                        if (textSymptoms.Lines[i].Trim() == s) hasSymptom = true;
                    }
                    if (hasSymptom==false)
                    {
                        conn.addSymptom(selectedPatient, selectedVisit, textSymptoms.Lines[i].Trim());
                        
                    }
                }
                
                conn.updateVisit(selectedVisit, selectedPatient);
            }
            
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void useInventoryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UseInventory U = new UseInventory(selectedPatient, selectedVisit);
            this.Closed += (s, args) => U.Close();
            U.Show();
        }

        private void changeRoomButton_Click(object sender, EventArgs e)
        {
            ChangeRoom C = new ChangeRoom(this, ref selectedPatient, ref selectedVisit);
            C.ShowDialog();
            displayPatient();
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
                selectedVisit.setNote(visitNotes.Text);
                ChangeRoom C = new ChangeRoom(this,ref selectedPatient, ref selectedVisit);

               // C.Closed += (s, args) => this.Close();
                C.ShowDialog();
                conn.addVisit(selectedVisit, selectedPatient);
                for (int i = 0; i < textSymptoms.Lines.Length; i++)
                {
                        selectedVisit.addSymptom(textSymptoms.Lines[i].Trim());
                        conn.addSymptom(selectedPatient, selectedVisit, textSymptoms.Lines[i].Trim());
                }
                        // if (selectedVisit.getRoomList()[0]!=null) conn.addStaysIn(selectedVisit.getRoomList()[0], selectedPatient, selectedVisit);
                checkInOutButton.Text = "Check Out";
                displayPatient();
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

        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Close();
        }

        private void listPreviousVisits_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listPreviousVisits_Click(object sender, EventArgs e)
        {
            if (listPreviousVisits.SelectedItems.Count == 0)
            {
                previousEntryDate.Text = "";
                previousExitDate.Text = "";
                prevAttendingPhys.Text = "";
                prevDiagnosis.Text = "";
                prevNotes.Text = "";
                prevSymptoms.Text = "";
                return;
            }

            bool success = DateTime.TryParse(listPreviousVisits.SelectedItems[0].SubItems[0].Text, out DateTime date);
            if (success)
            {
                Console.WriteLine("Starting click action:");
                Console.WriteLine("Selected date: " + date);
                foreach (Visit v in selectedPatient.getVisitList())
                {
                    Console.WriteLine(v.getEntryDate());
                    if (v.getEntryDate().Date == date.Date && v.getEntryDate().Hour==date.Hour && v.getEntryDate().Minute==date.Minute)// && v.getEntryDate().TimeOfDay == date.TimeOfDay)
                    {
                        previousEntryDate.Text = v.getEntryDate().ToString();
                        previousExitDate.Text = v.getExitDate().ToString();
                        prevAttendingPhys.Text = v.getAttendingPhysician();
                        prevDiagnosis.Text = v.getDiagnosis();
                        prevNotes.Text = v.getNote();
                        string previousSymptoms = "";
                        foreach(string s in v.getSymptomList())
                        {
                            previousSymptoms += s + ", ";
                        }
                        previousSymptoms = previousSymptoms.Trim(',', ' ');
                        prevSymptoms.Text = previousSymptoms;
                        break;
                    }
                }
            }
        }
    }
}
