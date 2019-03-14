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

        public void addBillable(Item newItem)
        {
        }

        public void addBillable(Service newService)
        {
        }

        public void addSymptom(string newSymptom)
        {
        }

        public void changeDiagnosis(string newDiagnosis)
        {

        }

        public decimal computeBill()
        {

            return 0; // placeholder
        }
    }
}
