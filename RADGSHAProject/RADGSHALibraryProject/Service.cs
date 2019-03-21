using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Service : Inventory
    {
        public Service(string newStockID, string newDescription, decimal newCost) : base(newStockID, newStockID, newCost)
        {
            
        }
    }
}