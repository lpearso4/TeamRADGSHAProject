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
    public partial class AddPatient : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public AddPatient()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            clearForm();
            SearchPatient sp = new SearchPatient();
            sp.Closed += (s, args) => this.Close();
            sp.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            RADGSHALibrary.Patient patient;
            // Sanitize SSN
            string patientSSNSanitized = patientSSN.Text.Trim();
            patientSSNSanitized = patientSSNSanitized.Replace("-", "");
            string errorMessage = "";
            bool success = int.TryParse(patientSSNSanitized, out int notUsing);
            if (!success) errorMessage = "Error: SSN is not in proper format!";
            if (patientSSNSanitized.Length!=9)
            {
                success = false;
                errorMessage = "Error: SSN is not proper length!";
            }
            if (success)
            {
                try
                {
                    patient = new RADGSHALibrary.Patient(patientSSNSanitized);

                    patient.setAddressLine1(patientAddressLine1TextBox.Text.Trim());
                    patient.setAddressLine2(patientAddressLine2TextBox.Text.Trim());

                    // check insurer format
                    if (patientInsurer.Text.Trim().Length > 0) // patient might not have an insurer
                    {
                        bool tryInsurer = int.TryParse(patientInsurer.Text.Trim(), out notUsing);
                        if (!tryInsurer)
                        {
                            success = false;
                            errorMessage = "Error: Insurer ID must be numerical!";
                        }

                        patient.setInsurer(patientInsurer.Text.Trim());
                    }
                    patient.setBirthDate(birthDate.Value);
                    patient.setCity(patientCityTextBox.Text.Trim());
                    // check zipcode value and format
                    string zipcodeSanitized = patientZipTextBox.Text.Trim().Replace("-", "");
                    bool tryZipCode = int.TryParse(zipcodeSanitized, out notUsing);
                    if (!tryZipCode)
                    {
                        success = false;
                        errorMessage = "Error: Zip code must be numerical!";
                    }
                    if (zipcodeSanitized.Length!=5 && zipcodeSanitized.Length!=9)
                    {
                        success = false;
                        errorMessage = "Error: Zip code must be five or nine digits!";
                    }
                    patient.setZipcode(zipcodeSanitized);
                    //check state formatting
                    string stateSanitized = patientStateTextBox.Text.Trim();
                    if (stateSanitized.Length!=2)
                    {
                        success = false;
                        errorMessage = "Error: Please use two digit state codes for states!";
                    }
                    patient.setState(stateSanitized);
                    patient.setFirstName(patientFirstNameTextBox.Text.Trim());
                    // make sure middle initial is one initial
                    string middleInitial = PatientMiddleInitialTextBox.Text.Trim();
                    if (middleInitial.Length > 1)
                    {
                        success = false;
                        errorMessage = "Error: Patient's middle initial must be one character!";
                    }
                    else if (middleInitial.Length == 1) patient.setMiddleInitial(middleInitial[0]);

                    patient.setLastName(patientLastNameTextBox.Text.Trim());

                    string gender = genderBox.Text.Trim();
                    if (gender.Length != 1)
                    {
                        success = false;
                        errorMessage = "Error: Patient's gender must be one character!";
                    }
                    else patient.setGender(gender[0]);

                    if (comboDonorStatus.Text=="True")
                    {
                        patient.setOrganDonorStatus(true);
                    } 
                    else if (comboDonorStatus.Text=="False")
                    {
                        patient.setOrganDonorStatus(false);
                    }
                    else
                    {
                        success = false;
                        errorMessage = "Error: Please select a donor status!";
                    }

                    if (comboDNR.Text == "True")
                    {
                        patient.setDoNotResuscitateStatus(true);
                    }
                    else if (comboDNR.Text == "False")
                    {
                        patient.setDoNotResuscitateStatus(false);
                    }
                    else
                    {
                        success = false;
                        errorMessage = "Error: Please select a DNR status!";
                    }

                    if (success) createPatient(patient); // we have been successful, create the patient and leave this form

                }
                catch (Exception ee)
                {
                    errorMessage = ee.Message;
                    success = false;
                }
            }
            
            if (!success)
            {
                string message = errorMessage;
                string caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            
        }
        private void createPatient(RADGSHALibrary.Patient patient)
        {
            RADGSHALibrary.DBConnectionObject conn = RADGSHALibrary.DBConnectionObject.getInstance();

            List<RADGSHALibrary.Patient> checkForSSN = conn.queryPatient(patient.getSSN(),"","","");
            if (checkForSSN.Count > 0)
            {
                string message = "Error! A patient with that SSN already exists! Is this patient already in the database?";
                string caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                conn.addPatient(patient);
                this.Hide();
                clearForm();
                Patient p = new Patient(this, patient);
                p.Closed += (s, args) => this.Close();
                p.Show();
            }
            
        }
        private void clearForm()
        {
            patientFirstNameTextBox.Text = "";
            PatientMiddleInitialTextBox.Text = "";
            patientLastNameTextBox.Text = "";
            patientAddressLine1TextBox.Text = "";
            patientAddressLine2TextBox.Text = "";
            patientZipTextBox.Text = "";
            patientStateTextBox.Text = "";
            patientSSN.Text = "";
            comboDNR.Text = " ";
            comboDonorStatus.Text = " ";
            patientCityTextBox.Text = "";
            patientInsurer.Text = "";
            genderBox.Text = "";
            birthDate.Value = DateTime.Now;


        }
        private void comboDNR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
