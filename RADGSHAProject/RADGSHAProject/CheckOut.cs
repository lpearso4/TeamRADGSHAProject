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
    public partial class CheckOut : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one
        RADGSHALibrary.Patient selectedPatient;
        RADGSHALibrary.Visit selectedVisit;
        DateTime exit; // keep track of when we brought up this form
        decimal roomSubtotal;
        decimal inventorySubtotal;
        decimal serviceSubtotal;
        decimal total;

        public CheckOut()
        {
            InitializeComponent();
        }
        public CheckOut(Form newPreviousForm, ref RADGSHALibrary.Patient newSelectedPatient, ref RADGSHALibrary.Visit newSelectedVisit )
        {
            RADGSHALibrary.DBConnectionObject conn = RADGSHALibrary.DBConnectionObject.getInstance();
            InitializeComponent();
            previousForm = newPreviousForm;
            selectedPatient = newSelectedPatient;
            selectedVisit = newSelectedVisit;
            roomSubtotal = inventorySubtotal = serviceSubtotal = 0;
            exit = DateTime.Now; // keep track of when we bring up this form

            patientName.Text = selectedPatient.getLastName() + ", " + selectedPatient.getFirstName();

            foreach (RADGSHALibrary.Room r in selectedVisit.getRoomList())
            {
                // Room number
                ListViewItem roomNumber = new ListViewItem(r.getRoomNumber());
                // Rate
                roomNumber.SubItems.Add(r.getHourlyRate().ToString());
                // Length of stay
                DateTime entry; DateTime roomExit; bool stillInRoom;
                conn.getRoomEntryExitDates(selectedPatient, selectedVisit, r, out entry, out roomExit, out stillInRoom);
                if (stillInRoom) roomExit = DateTime.Now;
                TimeSpan length = roomExit - entry;
               
                roomNumber.SubItems.Add(length.ToString());
                // Charge
                decimal amnt = (decimal)length.TotalHours * r.getHourlyRate();
                roomNumber.SubItems.Add(amnt.ToString());

                roomListView.Items.Add(roomNumber);
                roomSubtotal += amnt;
            }

            textRoomSub.Text = roomSubtotal.ToString();
            textServicesSub.Text = serviceSubtotal.ToString();
            textSuppliesSub.Text = inventorySubtotal.ToString();
            total = roomSubtotal + serviceSubtotal + inventorySubtotal;
            totalDue.Text = total.ToString() ;
        }
        private void goBack()
        {
            this.Hide();
            Patient P = new Patient(this, selectedPatient);
            P.Closed += (s, args) => this.Close();
            P.Show();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            RADGSHALibrary.DBConnectionObject conn = RADGSHALibrary.DBConnectionObject.getInstance();
            selectedVisit.setExitDate(exit);
            conn.closeVisit(selectedPatient, selectedVisit);

            foreach (RADGSHALibrary.Room r in selectedVisit.getRoomList())
            {
                DateTime date; bool stillInRoom;
                conn.getRoomEntryExitDates(selectedPatient, selectedVisit, r, out date, out date, out stillInRoom);
                if (stillInRoom) conn.closeStaysIn(selectedPatient, selectedVisit, r, exit);
            }
               
            goBack();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }
    }
}
