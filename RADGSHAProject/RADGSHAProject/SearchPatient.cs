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
    public partial class SearchPatient : Form
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
            if (PatientListView.SelectedIndices.Count > 0)
            {
                RADGSHALibrary.Patient p;// = new RADGSHALibrary.Patient(PatientListView.SelectedItems[0].SubItems[2].Text);
                // stored procedure test
                DBConnectionObject DBconnection = DBConnectionObject.getInstance();
                p = DBconnection.getPatient(PatientListView.SelectedItems[0].SubItems[2].Text);
                Console.WriteLine(p.getAddressLine1());

            }

            //This should return the selected Patient,
            //If no selected patient, have this button disabled, and greyed out.
            Patient P = new Patient(this);
            P.Show();
            Hide();
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
            //string firstName = "";
            //string lastName = "";
            //int indexOfFirstSpace = PatientFirstNameField.Text.IndexOf(' ');
            Char[] prohibitedChars = { ' ', '*', '.', '\'' };
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();
            /*
            if (indexOfFirstSpace > 0)
            {
                firstName = PatientFirstNameField.Text.Substring(0, indexOfFirstSpace);
                lastName = PatientFirstNameField.Text.Substring(indexOfFirstSpace, PatientFirstNameField.Text.Length - indexOfFirstSpace);
            }
            else { lastName = PatientFirstNameField.Text; }

            List<RADGSHALibrary.Patient> ResultingPatientList = DBconnection.queryPatient(PatientSSNField.Text.Trim(prohibitedChars), lastName.Trim(prohibitedChars), firstName.Trim(prohibitedChars));
            */
            List<RADGSHALibrary.Patient> ResultingPatientList = DBconnection.queryPatient(PatientSSNField.Text.Trim(prohibitedChars), PatientLastNameField.Text.Trim(prohibitedChars), PatientFirstNameField.Text.Trim(prohibitedChars));

            PatientListView.Items.Clear();

            foreach (RADGSHALibrary.Patient p in ResultingPatientList)
            {
                ListViewItem patientResult = new ListViewItem(p.getFirstName());

                patientResult.SubItems.Add(p.getLastName());
                patientResult.SubItems.Add(p.getSSN());
                PatientListView.Items.Add(patientResult);
            }
        }

        private void PatientLastNameField_TextChanged(object sender, EventArgs e)
        {
            UpdatePatientList();
        }
    }
}
