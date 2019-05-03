using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class DiagnosisWizard
    {
        private Visit currentVisit;
        private Patient currentPatient;
        private string previousResponses;
        private RADGSHALibraryProject.DiagnosisWizardResults CurrentResults;

        public DiagnosisWizard(ref Visit setCurrentVisit, ref Patient setCurrentPatient)
        {
            currentVisit = setCurrentVisit;
            currentPatient = setCurrentPatient;
            CurrentResults = new RADGSHALibraryProject.DiagnosisWizardResults();
            CurrentResults.PreviousResponses = "";
        }

        public void clickedYes()
        {
            // this will add a "yes" to the current set of previousResponses.
            
            CurrentResults.PreviousResponses += "1," + CurrentResults.CurrentBestSymptom;
        }

        public void clickedNo()
        {
            // this will add a "yes" to the current set of previousResponses.
            CurrentResults.PreviousResponses += "0," + CurrentResults.CurrentBestSymptom;
        }

        public string getNextSymptom()
        {
            // this will take the current visits symptoms, and decide what next symptom should be asked.
            DBConnectionObject conn = DBConnectionObject.getInstance();
            string suggestedNextSymptom = conn.getDiagnosisWizardSymptomByPreviousResponses(CurrentResults.PreviousResponses);
            CurrentResults.CurrentBestSymptom = suggestedNextSymptom;
            return suggestedNextSymptom;
        }

        public void applyDiagnosisToVisit()
        {
            /*DBConnectionObject conn = DBConnectionObject.getInstance();
            string mostProbableDiagnosis = conn.getDiagnosisWizardResultingDiagnosis(CurrentResults.PreviousResponses);
            currentVisit.changeDiagnosis(mostProbableDiagnosis);
            conn.updateVisit(currentVisit, currentPatient);*/
        }
    }
}
