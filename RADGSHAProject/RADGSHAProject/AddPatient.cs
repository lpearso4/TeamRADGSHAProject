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
            SearchPatient sp = new SearchPatient();
            sp.Closed += (s, args) => this.Close();
            sp.Show();
        }
    }
}
