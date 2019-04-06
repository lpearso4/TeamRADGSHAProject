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
        private decimal cost;

        public Inventory(string newStockID, string newDescription, decimal newCost)
        {
            stockID = newStockID;
            description = newDescription;
            cost = newCost;
        }
        public string getDescription()
        {
            return description;
        }
        public decimal getCost()
        {
            return cost;
        }
        public string getStockID()
        {
            return stockID;
        }
        public void useQuantity(int amountUsed)
        {
        }

        public void addToLog(Inventory entry, string username, DateTime dateAndTime) // strays from design doc (there aren't separate date and time classes in C#)
        {
        }
    }
}
