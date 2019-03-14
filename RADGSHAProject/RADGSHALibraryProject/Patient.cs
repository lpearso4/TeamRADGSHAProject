using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class Patient
    {
        private string firstName;
        private string middleInitial;
        private string lastName;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string state;
        private ushort zipcode;
        private string ssn;
        private char gender;
        private DateTime birthDate;
        private string insurer;
        private bool doNotResuscitate;
        private bool organDonor;

        public Patient(string ssn)
        {
        }

        public void checkIn()
        {
        }

        public void checkOut()
        {
        }

        public bool isPatientCheckedIn()
        {

            return true; // placeholder
        }
    }
}
