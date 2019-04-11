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
    public partial class SearchPatient : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public SearchPatient()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public SearchPatient(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void viewPatientButton_Click(object sender, EventArgs e)
        {
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();
            RADGSHALibrary.Patient p = DBconnection.getPatient(PatientListView.SelectedItems[0].SubItems[2].Text);

            //This should return the selected Patient
            this.Hide();
            Patient P = new Patient(this, p);
            P.Closed += (s, args) => this.Close();
            P.Show();
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous Form when closing this one
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewPatientButton.Enabled = true;
            if (PatientListView.SelectedItems.Count != 1)
                viewPatientButton.Enabled = false;
        }

        private void PatientNameField_TextChanged(object sender, EventArgs e)
        {
            UpdatePatientList();
        }

        private void PatientSSNField_TextChanged(object sender, EventArgs e)
        {
            UpdatePatientList();
        }

        private void VisitRoomNumberField_TextChanged(object sender, EventArgs e)
        {
            UpdatePatientList();
        }

        private void UpdatePatientList()
        {
            Char[] prohibitedChars = { ' ', '*', '.', '\'' };
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();

            string patientSSN = PatientSSNField.Text.Trim(prohibitedChars).Replace("'", "’");
            string patientLastName = PatientLastNameField.Text.Trim(prohibitedChars).Replace("'", "’");
            string patientFirstName = PatientFirstNameField.Text.Trim(prohibitedChars).Replace("'", "’");

            List<RADGSHALibrary.Patient> ResultingPatientList = new List<RADGSHALibrary.Patient>();

            if (patientSSN != "" || patientLastName!="" || patientFirstName!= "")
            {
                ResultingPatientList = DBconnection.queryPatient(patientSSN, patientLastName, patientFirstName);
            }

            PatientListView.Items.Clear();

            foreach (RADGSHALibrary.Patient p in ResultingPatientList)
            {
                ListViewItem patientResult = new ListViewItem(p.getFirstName());

                patientResult.SubItems.Add(p.getLastName());
                patientResult.SubItems.Add(p.getSSN());
                PatientListView.Items.Add(patientResult);
            }

            if (PatientListView.SelectedItems.Count != 1)
                viewPatientButton.Enabled = false;
        }

        private void PatientLastNameField_TextChanged(object sender, EventArgs e)
        {
            UpdatePatientList();
        }

        private void PatientListView_Leave(object sender, EventArgs e)
        {
            if (PatientListView.SelectedItems.Count != 1)
                viewPatientButton.Enabled = false;
        }
    }
}
