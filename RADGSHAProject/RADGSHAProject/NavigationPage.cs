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
    public partial class NavigationPage : Form
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void searchPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchPatient S = new SearchPatient();
            S.Closed += (s, args) => this.Close();
            S.Show();
        }

        private void importToolButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportTool I = new ImportTool();
            I.Closed += (s, args) => this.Close();
            I.Show();
        }

        private void NavigationPage_Load(object sender, EventArgs e)
        {

        }
    }
}
