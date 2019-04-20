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
    public partial class ChangeRoom : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.Visit selectedVisit;

        public ChangeRoom()
        {
            InitializeComponent();
        }
        public ChangeRoom(RADGSHALibrary.Patient p, RADGSHALibrary.Visit v)
        {
            selectedPatient = p;
            selectedVisit = v;
        }

        public ChangeRoom(Form previousForm)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
