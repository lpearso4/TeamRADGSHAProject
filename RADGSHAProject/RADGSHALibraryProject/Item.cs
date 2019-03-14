using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Item : Inventory
    {
        private int size;
        private int quantity;

        public Item(string setStockID, string setDescription, decimal setCost) : base(setStockID, setStockID, setCost)
        {
        }

        public void useQuantity(int amountUsed)
        {
        }

        public void addQuantity(int amountAdded)
        {
        }
    }

}
