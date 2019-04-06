using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RADGSHALibrary;

namespace ImportToolLibrary
{
    public class ImportTool
    {
        private DBConnectionObject conn;

        public ImportTool()
        {
            conn = DBConnectionObject.getInstance();
        }

        public async void importPatientData(string url)
        {
            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            int outputPercentTimer = 0;
            string line;
            Char[] prohibitedChars = { ' ', '*', '.' };
            System.IO.StreamReader file =
                new System.IO.StreamReader(url);
            while ((line = file.ReadLine()) != null)
            {
                // This "await Task.Delay(0);" line may look useless, but it allows the form to act asynchronous.
                await Task.Delay(1);    

                string patientLastName = line.Substring(0, 50).Trim(prohibitedChars).Replace("'", "’");
                string patientFirstName = line.Substring(50, 25).Trim(prohibitedChars).Replace("'", "’");

                Char patientMiddleInitial = line.Substring(75, 1).Trim(prohibitedChars).Replace("'", "’").ToCharArray().First();
                Char patientGender = line.Substring(76, 1).Trim(prohibitedChars).Replace("'", "’").ToCharArray().First();
                string patientSSN = line.Substring(77, 9).Trim(prohibitedChars).Replace("'", "’");

                int birthDate_month = Int32.Parse(line.Substring(86, 2).Trim(prohibitedChars).Replace("'", "’"));
                int birthDate_day = Int32.Parse(line.Substring(88, 2).Trim(prohibitedChars).Replace("'", "’"));
                int birthDate_year = Int32.Parse(line.Substring(90, 4).Trim(prohibitedChars).Replace("'", "’"));
                DateTime birthDate = new DateTime(birthDate_year, birthDate_month, birthDate_day);

                string patientZipcode = line.Substring(559, 5).Trim(prohibitedChars).Replace("'", "’");
                string patientState = line.Substring(557, 2).Trim(prohibitedChars).Replace("'", "’");
                string patientCity = line.Substring(532, 25).Trim(prohibitedChars).Replace("'", "’");
                string patientAddressLine1 = line.Substring(462, 35).Trim(prohibitedChars).Replace("'", "’");
                string patientAddressLine2 = line.Substring(497, 35).Trim(prohibitedChars).Replace("'", "’");
                string patientInsurer = line.Substring(457, 5).Trim(prohibitedChars).Replace("'", "’");

                string DnrStatusString = line.Substring(564, 1).Trim(prohibitedChars).Replace("'", "’");
                Boolean patientDnrStatus = (DnrStatusString == "Y");
                string OrganDonorString = line.Substring(565, 1).Trim(prohibitedChars).Replace("'", "’");
                Boolean patientOrganDonor = (OrganDonorString == "Y");

                Patient p = new Patient(patientSSN);
                p.setFirstName(patientFirstName);
                p.setMiddleInitial(patientMiddleInitial);
                p.setLastName(patientLastName);
                p.setGender(patientGender);
                p.setZipcode(patientZipcode);
                p.setState(patientState);
                p.setCity(patientCity);
                p.setAddressLine1(patientAddressLine1);
                p.setAddressLine2(patientAddressLine2);
                p.setBirthDate(birthDate);
                p.setInsurer(patientInsurer);
                p.setDoNotResuscitateStatus(patientDnrStatus);
                p.setOrganDonorStatus(patientOrganDonor);

                if (conn.queryPatient(patientSSN, "", "").Count >= 1)
                {
                    conn.updatePatient(p);
                }
                else
                {
                    conn.addPatient(p);
                }

                currentLineNumber++;
                outputPercentTimer++;
                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                }
            }
            file.Close();
        }
        public async void importRoomData(string url)
        {
            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            int outputPercentTimer = 0;
            string line;
            Char[] prohibitedChars = { ' ', '*', '.' };
            System.IO.StreamReader file =
                new System.IO.StreamReader(url);
            while ((line = file.ReadLine()) != null)
            {

                await Task.Delay(1);

                const int ROOM_START_CHAR = 0;
                const int ROOM_LEN = 9;
                const int HOURLY_RATE_START = 9;
                const int HOURLY_RATE_LEN = 5;
                const int EFFECTIVE_DATETIME_START_CHAR = 14;
                const int EFFECTIVE_DATETIME_LEN = 12;

                string roomNumber = line.Substring(ROOM_START_CHAR, ROOM_LEN).Trim(prohibitedChars).Replace("'", "’"); ;

                string hourlyRateString = line.Substring(HOURLY_RATE_START, HOURLY_RATE_LEN) ;
                decimal hourlyRate = Decimal.Parse(hourlyRateString);
                decimal hourlyCents = .01M;
                hourlyRate *= hourlyCents; // convert from $$$$$ to $$$.cc as desired

                string dateString = line.Substring(EFFECTIVE_DATETIME_START_CHAR, EFFECTIVE_DATETIME_LEN);
                int month = Int32.Parse(dateString.Substring(0, 2));
                int day = Int32.Parse(dateString.Substring(2, 2));
                int year = Int32.Parse(dateString.Substring(4, 4));
                int hour = Int32.Parse(dateString.Substring(8, 2));
                int minute = Int32.Parse(dateString.Substring(10, 2));
                const int SECOND = 0;
                DateTime effectiveDate = new DateTime(year, month, day, hour, minute, SECOND);

                Room r = new Room(roomNumber, hourlyRate, effectiveDate);
               
                conn.addRoom(r); // this will fail if room is already present

                currentLineNumber++;
                outputPercentTimer++;
                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                }
            }
            file.Close();
        }



    public int getFileLineLength(string url)
        {
            int numberOfLines = 0;
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(url);

            while ((line = file.ReadLine()) != null)
            {
                numberOfLines++;
            }

            return numberOfLines;
        }
    }
}
