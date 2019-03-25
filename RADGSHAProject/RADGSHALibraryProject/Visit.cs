using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Visit
    {
        private DateTime entryDate;
        private DateTime exitDate;
        private List<Room> rooms;
        private string attendingPhysician;
        private List<string> symptoms;
        private string diagnosis;
        private List<Inventory> billables;
        private string note;

        public Visit()
        {
            billables = new List<Inventory>();
            symptoms = new List<string>();
            rooms = new List<Room>();
        }
        public void setEntryDate(DateTime newEntryDate)
        {
            entryDate = newEntryDate;
        }
        public DateTime getEntryDate()
        {
            return entryDate;
        }
        public void setExitDate(DateTime newExitDate)
        {
            exitDate = newExitDate;
        }
        public DateTime getExitDate()
        {
            return exitDate;
        }
        public void addBillable(Inventory newItem)
        {
            billables.Add(newItem);
        }
        public List<Inventory> getBillableList()
        {
            return billables;
        }
        /*public void addBillable(Item newItem)
        {
            billables.Add(newItem);
        }

        public void addBillable(Service newService)
        {
            billables.Add(newService);
        }*/
        public void addRoom(Room newRoom)
        {
            rooms.Add(newRoom);
        }
        public List<Room> getRoomList()
        {
            return rooms;
        }
        public void addSymptom(string newSymptom)
        {
            symptoms.Add(newSymptom);
        }
        public List<string> getSymptomList()
        {
            return symptoms;
        }
        public void changeDiagnosis(string newDiagnosis)
        {
            diagnosis = newDiagnosis;
        }
        public string getDiagnosis()
        {
            return diagnosis;
        }
        public void setAttendingPhysician(string newAttendingPhysician)
        {
            attendingPhysician = newAttendingPhysician;
        }
        public string getAttendingPhysician()
        {
            return attendingPhysician;
        }
        public void setNote(string newNote)
        {
            note = newNote;
        }
        public string getNote()
        {
            return note;
        }
        public decimal computeBill()
        {
            
            return 0; // placeholder
        }
    } 
}
