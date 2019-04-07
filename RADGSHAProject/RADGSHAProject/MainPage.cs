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
    public partial class MainPage : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public MainPage()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public MainPage(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void FormClose(object sender, FormClosedEventArgs e)//displays Login page after closing Main Page
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }
    }
}
