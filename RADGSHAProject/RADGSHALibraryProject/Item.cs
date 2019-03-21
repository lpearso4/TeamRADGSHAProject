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

        public Item(string newStockID, string newDescription, decimal newCost) : base(newStockID, newDescription, newCost)
        {

        }
        public void setSize(int newSize)
        {
            if (size < 0) throw new Exception("Item Error: Size can't be negative!");
            size = newSize;
        }
        public int getSize()
        {
            return size;
        }
        public void setQuantity(int newQuantity)
        {
            if (quantity < 0) throw new Exception("Item Error: Quantity can't be negative!");
            quantity = newQuantity;
        }
        public int getQuantity()
        {
            return quantity;
        }
       
        public void useQuantity(int amountUsed)
        {
            if (amountUsed <= 0) throw new Exception("Item Error: Must use a positive quantity of an item!");
            int result = quantity - amountUsed;
            if (result < 0) throw new Exception("Item Error: Can't use more quantity than exists!");
            quantity = result;
        }

        public void addQuantity(int amountAdded)
        {
            if (amountAdded <= 0) throw new Exception("Item Error: Must add a positive quantity of an item!");
            quantity += amountAdded;
        }
    }

}
