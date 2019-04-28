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
        private char middleInitial;
        private string lastName;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string state;
        private string zipcode;             
        private string ssn;
        private char gender;

        private DateTime birthDate;
        private string insurer;
        private bool doNotResuscitate;
        private bool organDonor;
         
        private List<Visit> visits;         // we forgot patient visits in the design doc as patient has visits
        private Visit curVisit;             // another new variable   
        
        public Patient(string newSSN)
        {
           const int SSN_LENGTH = 9;
           if (!Int32.TryParse(newSSN, out int i))
           {
                throw new Exception("Patient error: SSN must be numerical!");
           }
           else if (newSSN.Length!=SSN_LENGTH)
           {
                throw new Exception("Patient error: SSN must be nine digits!");
           }

            ssn = newSSN;
            visits = new List<Visit>();
        }
       
        public string getSSN()
        {
            return ssn;
        }
        public void setFirstName(string newFirstName)
        {
            if (newFirstName == "") throw new Exception("Patient Error: Patient must have first name.");
            firstName = newFirstName;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public void setLastName(string newLastName)
        {
            if (newLastName == "") throw new Exception("Patient Error: Patient must have last name.");
            lastName = newLastName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public void setMiddleInitial(char newMiddleInitial)
        {
            middleInitial = newMiddleInitial;
        }
        public char getMiddleInitial()
        {
            return middleInitial;
        }

        public void checkIn()
        {
            if (curVisit != null) throw new Exception("Patient error: Patient is already checked in!");
            curVisit = new Visit();
            curVisit.setEntryDate(DateTime.Now);
            visits.Add(curVisit);
            // and some other stuff?
        }

        public void checkOut()
        {
            if (curVisit == null) throw new Exception("Patient error: Can't check out patient! Patient is not checked in!");
            curVisit.setExitDate(DateTime.Now);
            curVisit = null;
            // what else?
        }

        public bool isPatientCheckedIn()
        {
            // if curVisit is set to an instance, we are checked in, or else we are checked out. At least that's how it works at the moment
            if (curVisit == null) return false;
            return true; 
        }
        public void addVisit(Visit newVisit) // add missing function for adding a new visit (not in design document)
        {
            visits.Add(newVisit);
        }
        public void modifyAddress(string newAddressLine1, string newAddressLine2, string newCity, string newState, string newZipcode)
        {
            setAddressLine1(newAddressLine1);
            setAddressLine2(newAddressLine2);
            setCity(newCity);
            setState(newState);
            setZipcode(newZipcode);
        }
        public void setAddressLine1(string newAddressLine1)
        {
            addressLine1 = newAddressLine1;
        }
        public string getAddressLine1()
        {
            return addressLine1;
        }
        public void setAddressLine2(string newAddressLine2)
        {
            addressLine2 = newAddressLine2;
        }
        public string getAddressLine2()
        {
            return addressLine2;
        }
        public void setCity(string newCity)
        {
            city = newCity;
        }
        public string getCity()
        {
            return city;
        }
        public void setState(string newState)
        {
            const int STATE_LEN = 2; // state codes are 2 digits (e.g. WI, MN, NY)
            if (newState.Length != STATE_LEN) throw new Exception("Patient Error: State codes must be two characters!");
            state = newState;
        }
        public string getState()
        {
            return state;
        }
        public void setZipcode(string newZipcode)
        {
            // possible error checking goes here
            zipcode = newZipcode;
        }
        public string getZipcode()
        {
            return zipcode;
        }
        public void setGender(char newGender)
        {
            gender = newGender;
        }
        public char getGender()
        {
            return gender;
        }
        public void setBirthDate(DateTime newBirthDate)
        {   // probably shouldn't be able to change this once it is set...
            birthDate = newBirthDate; 
        }
        public DateTime getBirthDate()
        {
            return birthDate;
        }
        public void setInsurer(string newInsurer)
        {
            insurer = newInsurer;
        }
        public string getInsurer()
        {
            return insurer;
        }
        public void setDoNotResuscitateStatus(bool newDoNotResuscitate)
        {
            doNotResuscitate = newDoNotResuscitate;
        }
        public bool getDoNotResuscitateStatus()
        {
            return doNotResuscitate;
        }
        public void setOrganDonorStatus(bool newOrganDonor)
        {
            organDonor = newOrganDonor;
        }
        public bool getOrganDonorStatus()
        {
            return organDonor;
        }
        public Visit getCurrentVisit() // gives access to current visit
        {
            return curVisit;
        }
        public void setCurrentVisit(ref Visit visit)
        {
            curVisit = visit;
        }
        public List<Visit> getVisitList() // gives others access to patient visits (why not?)
        {
            return visits;
        }
            

    }
}
