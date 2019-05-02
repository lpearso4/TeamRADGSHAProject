using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RADGSHALibrary;

namespace RADGSHAProject
{
    public partial class DiagnosisWizard : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        Visit selectedVisit;
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.DiagnosisWizard wizard;
        string currentSymptom = "Lack there of";
        public DiagnosisWizard(RADGSHALibrary.Patient p, Visit v)
        {
            selectedVisit = v;
            selectedPatient = p;
            InitializeComponent();
            wizard = new RADGSHALibrary.DiagnosisWizard(ref selectedVisit, ref selectedPatient);
            currentSymptom = wizard.getNextSymptom();
            QuestionLabel.Text = "Does " + selectedPatient.getFirstName() + " have " + currentSymptom;
        }

        public DiagnosisWizard(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }

        private void SymptomListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReturnToPatient_Click(object sender, EventArgs e)
        {
            returnToPatient();
        }

        private void AddResultsToPatientButton_Click(object sender, EventArgs e)
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

        private void PatientHasSymptomButton_Click(object sender, EventArgs e)
        {
            wizard.clickedYes();
            currentSymptom = wizard.getNextSymptom();
            QuestionLabel.Text = "Does " + selectedPatient.getFirstName() + " have " + currentSymptom;
        }

        private void PatientDoesNotHaveSymptomButton_Click(object sender, EventArgs e)
        {
            wizard.clickedNo();
            currentSymptom = wizard.getNextSymptom();
            QuestionLabel.Text = "Does " + selectedPatient.getFirstName() + " have " + currentSymptom;
        }
    }
}
