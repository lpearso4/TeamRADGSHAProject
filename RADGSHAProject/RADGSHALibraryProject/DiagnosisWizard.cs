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

        public DiagnosisWizard(ref Visit setCurrentVisit)
        {
            currentVisit = setCurrentVisit;
        }

        public string runDiagnosisWizard()
        {
            // this will take the current visits symptoms, and decide what next symptom should be asked.
            return "Excessive reflection";
        }

        public void applyDiagnosisToVisit()
        {
            
        }
    }
}
