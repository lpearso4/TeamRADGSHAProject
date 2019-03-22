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

        
    }
}
