using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Room
        /* I'm not sure if room needs set methods. We can add them later, if necessary. */
    {
        private string roomNumber;
        private decimal hourlyRate;
        private DateTime effectiveDate;

        public Room(string newRoomNumber, decimal newHourlyRate, DateTime newEffectiveDate)
        {
            roomNumber = newRoomNumber;
            hourlyRate = newHourlyRate;
            effectiveDate = newEffectiveDate;
        }
        public string getRoomNumber()
        {
            return roomNumber;
        }
        public decimal getHourlyRate()
        {
            return hourlyRate;
        }
        public DateTime getEffectiveDate()
        {
            return effectiveDate;
        }
    }
}
