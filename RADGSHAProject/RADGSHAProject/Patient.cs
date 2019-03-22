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
    

    public partial class Patient : Form
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public Patient()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public Patient(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void useInventoryButton_Click(object sender, EventArgs e)
        {
            UseInventory U = new UseInventory(this);
            U.Show();
            Hide();
        }

        private void changeRoomButton_Click(object sender, EventArgs e)
        {
            ChangeRoom C = new ChangeRoom(this);
            C.Show();
            Hide();
        }

        private void diagnosisWizardButton_Click(object sender, EventArgs e)
        {
            DiagnosisWizard D = new DiagnosisWizard(this);
            D.Show();
            Hide();
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous form after closing this one
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }
    }
}
