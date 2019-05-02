using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibraryProject
{
    class DiagnosisWizardResults
    {
        public string CurrentBestSymptom { get; set; }
        public TopDiagnosis CurrentTopDiagnosis { get; set; }
        public class TopDiagnosis
        {
            public string DiagnosisName { get; set; }
            public string PercentageChance { get; set; }
        }
        public string PreviousResponses { get; set; }
    }
}
