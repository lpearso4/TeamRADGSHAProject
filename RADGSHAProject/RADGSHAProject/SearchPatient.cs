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
            string firstName = "";
            string lastName = "";
            int indexOfFirstSpace = PatientNameField.Text.IndexOf(' ');
            Char[] prohibitedChars = { ' ', '*', '.', char.Parse("'") };
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();

            if (indexOfFirstSpace > 0)
            {
                firstName = PatientNameField.Text.Substring(0, indexOfFirstSpace);
                lastName = PatientNameField.Text.Substring(indexOfFirstSpace, PatientNameField.Text.Length - indexOfFirstSpace);
            }
            else { firstName = PatientNameField.Text; }

            List<RADGSHALibrary.Patient> ResultingPatientList = DBconnection.queryPatient(PatientSSNField.Text.Trim(prohibitedChars), lastName.Trim(prohibitedChars), firstName.Trim(prohibitedChars));
            PatientListView.Items.Clear();

            foreach (RADGSHALibrary.Patient p in ResultingPatientList)
            {
                ListViewItem patientResult = new ListViewItem(p.getFirstName());

                patientResult.SubItems.Add(p.getLastName());
                patientResult.SubItems.Add(p.getSSN());
                PatientListView.Items.Add(patientResult);
            }
        }
    }
}
