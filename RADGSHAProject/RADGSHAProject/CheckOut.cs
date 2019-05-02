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
                TimeSpan length = (roomExit - entry);
                string lengthOfStay="";
                if (length.Days > 0) lengthOfStay += length.Days.ToString() + " Days, ";
                if (length.Hours > 0) lengthOfStay += length.Hours.ToString() + " Hours, ";
                lengthOfStay += length.Minutes.ToString() + " Minutes";
                roomNumber.SubItems.Add(lengthOfStay);
                // Charge
                //decimal lengthAdjusted = (decimal)length.TotalDays * 24;
                //Console.WriteLine(lengthAdjusted);
                decimal lengthAdjusted = (decimal)length.TotalHours;
                Console.WriteLine(lengthAdjusted);
               // lengthAdjusted += (decimal)length.TotalMinutes / 60;
                Console.WriteLine(lengthAdjusted);
                decimal amnt = lengthAdjusted * r.getHourlyRate();
                amnt = Decimal.Round(amnt, 2);

                roomNumber.SubItems.Add(amnt.ToString());

                roomListView.Items.Add(roomNumber);
                roomSubtotal += amnt;
            }

            List<string> inventoryUsed = conn.queryUses(selectedPatient, selectedVisit);
            List<int> quantityUsed = new List<int>();
            
            foreach(string s in inventoryUsed )
            {
                int quantity = conn.getUses(selectedPatient, selectedVisit, s);
                quantityUsed.Add(quantity);
                RADGSHALibrary.Inventory i = conn.getInventory(s);

                if(conn.isItem(i)) // add to items
                {
                    decimal curCost = 0;
                    ListViewItem items = new ListViewItem(i.getDescription());
                    items.SubItems.Add(quantity.ToString());
                    curCost = i.getCost();
                    items.SubItems.Add(curCost.ToString());
                    decimal itemTotal = curCost * quantity;
                    items.SubItems.Add(itemTotal.ToString());
                    inventorySubtotal += itemTotal;
                    suppliesListView.Items.Add(items);
                }
                else // add to services
                {
                    decimal curCost = 0;
                    ListViewItem items = new ListViewItem(i.getDescription());
                   // items.SubItems.Add(quantity.ToString());
                    curCost = i.getCost();
                    items.SubItems.Add(curCost.ToString());
                   // decimal itemTotal = curCost * quantity;
                   // items.SubItems.Add(itemTotal.ToString());
                    serviceSubtotal += curCost;
                    proceduresListView.Items.Add(items);
                }
            }

            roomSubtotal = Decimal.Round(roomSubtotal, 2);
           serviceSubtotal =  Decimal.Round(serviceSubtotal, 2);
           inventorySubtotal =  Decimal.Round(inventorySubtotal, 2);

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
            selectedPatient.checkOut();   
            goBack();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }

        private void proceduresListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
