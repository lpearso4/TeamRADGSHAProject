using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
   public abstract class Inventory
    {
        private string stockID;
        private string description;
 
        private string cost;

        public Inventory(string setStockID, string setDescription, decimal setCost)
        {
        }

        public void useQuantity(int amountUsed)
        {
        }

        public void addToLog(Inventory entry, string username, DateTime dateAndTime) // strays from design doc (there aren't separate date and time classes in C#)
        {
        }
    }
}
