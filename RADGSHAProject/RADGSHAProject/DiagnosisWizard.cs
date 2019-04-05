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
    public partial class DiagnosisWizard : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public DiagnosisWizard()
        {
            InitializeComponent();
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
    }
}
