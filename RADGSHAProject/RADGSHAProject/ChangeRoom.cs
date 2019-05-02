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
    public partial class ChangeRoom : Form
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.Visit selectedVisit;
        Room newRoom;

        public ChangeRoom()
        {
            InitializeComponent();
        }
        public ChangeRoom(Form previousForm, ref RADGSHALibrary.Patient p, ref RADGSHALibrary.Visit v)
        {
            InitializeComponent();
            selectedPatient = p;
            selectedVisit = v;
            this.previousForm = previousForm;
        }
        
        /*
        public ChangeRoom(Form previousForm)//obsolete
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }
        */
        
        private void FormClose(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Patient P = new Patient(this, selectedPatient);
            P.Closed += (s, args) => this.Close();
            P.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            selectedVisit.addRoom(newRoom);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Close();
        }

        private void UpdateRoomList()
        {
            Char[] prohibitedChars = { ' ', '*', '.', '\'' };
            DBConnectionObject DBconnection = DBConnectionObject.getInstance();

            string room = roomField.Text.Trim(prohibitedChars).Replace("'", "’");

            List<RADGSHALibrary.Room> ResultingRoomList = new List<RADGSHALibrary.Room>();

            if (room != "")
            {
                ResultingRoomList = DBconnection.queryRoom(room);
            }

            RoomListView.Items.Clear();

            foreach (RADGSHALibrary.Room r in ResultingRoomList)
            {
                ListViewItem roomResult = new ListViewItem(r.getRoomNumber());
            }

            if (RoomListView.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }

        private void roomField_TextChanged(object sender, EventArgs e)
        {
            UpdateRoomList();
        }

        private void RoomListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
            if (RoomListView.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }

        private void RoomListView_Leave(object sender, EventArgs e)
        {
            if (RoomListView.SelectedItems.Count != 1)
                submitButton.Enabled = false;
        }


        private void ChangeRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
