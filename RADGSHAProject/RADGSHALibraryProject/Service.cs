using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Service : Inventory
    {
        public Service(string setStockID, string setDescription, decimal setCost) : base(setStockID, setStockID, setCost)
        {
            
        }
    }
}