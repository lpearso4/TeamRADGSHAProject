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

        private void UpdateRoomList()
        {
            Char[] prohibitedChars = { ' ', '*', '.', '\'' };
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();

            string roomNum = searchRoom.Text.Trim(prohibitedChars).Replace("'", "’");

            List<RADGSHALibrary.Room> ResultingRoomList = new List<RADGSHALibrary.Room>();

            if (roomNum != "")
            {
                ResultingRoomList = DBconnection.queryRoom(roomNum);
            }

            availableRoom.Items.Clear();

            foreach (RADGSHALibrary.Room r in ResultingRoomList)
            {
                ListViewItem roomResult = new ListViewItem(r.getRoomNumber());
                
                availableRoom.Items.Add(roomResult);
            }

            if (availableRoom.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }

        private void searchRoom_TextChanged(object sender, EventArgs e)
        {
            UpdateRoomList();
        }

        private void availableRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
            if (availableRoom.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }

        private void availableRoom_Leave(object sender, EventArgs e)
        {
            if (availableRoom.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            /*
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();
            RADGSHALibrary.Room r = DBconnection.getRoom(availableRoom.SelectedItems[0].SubItems[0].Text);

            this.Hide();
            Room R = new Room(this, r);
            R.Closed += (s, args) => this.Close();
            R.Show();
            */
        }
    }
}
