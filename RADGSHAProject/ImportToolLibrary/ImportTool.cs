using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RADGSHALibrary;
using System.Security.Cryptography;

namespace ImportToolLibrary
{
    public class ImportStatus
    {
        
        private int imported;
        private int total;

        public ImportStatus()
        {
           
            imported = 0;
            total = 0;
        }
        public double PercentDone
        {
            get
            {
                return (double)imported / total * 100;
            }
           
        }
        public int Imported
        {
            get
            {
                return imported;
            }
            set
            {
                imported = value;
            }
        }
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
    }
    public class ImportTool
    {
        private DBConnectionObject conn;
        private ImportStatus status;
        public ImportTool()
        {
            conn = DBConnectionObject.getInstance();
            status = new ImportStatus();
        }
        public ImportStatus getStatus()
        {
            return status;
        }
        public async void importPatientData(string url)
        {
            int numErrors = 0;

            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            int outputPercentTimer = 0;

            status.Imported = 0;
            status.Total = numberOfLines;

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

                if (conn.queryPatient(patientSSN, "", "", "").Count >= 1)
                {
                    conn.updatePatient(p);
                }
                else
                {
                    conn.addPatient(p);
                }

                string[] symptom = new string[6];
                symptom[0] = line.Substring(132, 25).Trim();
                symptom[1] = line.Substring(157, 25).Trim();
                symptom[2] = line.Substring(182, 25).Trim();
                symptom[3] = line.Substring(207, 25).Trim();
                symptom[4] = line.Substring(232, 25).Trim();
                symptom[5] = line.Substring(257, 25).Trim();
                string diagnosis = line.Substring(282, 75).Trim();
                string attendingPhys = line.Substring(118, 5).Trim(prohibitedChars);
                string note = line.Substring(357, 100).Trim();
                DateTime entryDate;

                string entryMonth = line.Substring(94,2);
                string entryDay = line.Substring(96, 2);
                string entryYear = line.Substring(98, 4);
                string entryHour = line.Substring(102, 2);
                string entryMinute = line.Substring(104, 2);
                entryDate = DateTime.Parse(entryMonth + "/" + entryDay + "/" + entryYear + " " + entryHour + ":" + entryMinute);

                DateTime exitDate;
                string exitMonth = line.Substring(106, 2);
                string exitDay = line.Substring(108, 2);
                string exitYear = line.Substring(110, 4);
                string exitHour = line.Substring(114, 2);
                string exitMinute = line.Substring(116, 2);
                exitDate = DateTime.Parse(exitMonth + "/" + exitDay + "/" + exitYear + " " + exitHour + ":" + exitMinute);

                string roomNumber = line.Substring(123, 9);

                Visit v = new Visit();
                v.setEntryDate(entryDate);
                v.setExitDate(exitDate);
                v.setAttendingPhysician(attendingPhys);
                v.setNote(note);
       
                v.changeDiagnosis(diagnosis);

                try
                {
                    conn.addVisit(v, p);



                    for (int i = 0; i < 6; i++)
                    {
                        List<string> l = conn.querySymptoms(p, v, symptom[i]);
                        //Console.WriteLine("Matching symptoms for " + symptom[i] +" : " + l.Count());
                        if (l.Count == 0) conn.addSymptom(p, v, symptom[i]); // if this patient doesn't have the symptom, add it
                    }
                    conn.closeVisit(p, v);

                    List<Room> rooms = conn.queryRoom(roomNumber);

                    int bestIndex = -1;
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (v.getEntryDate() < rooms[i].getEffectiveDate())
                        {
                            bestIndex = i;
                        }
                    }
                    if (bestIndex != -1) conn.addStaysIn(rooms[bestIndex], p, v);

                    conn.closeStaysIn(p, v, rooms[bestIndex], v.getExitDate());
                }
                catch (Exception e)
                {
                    numErrors++;
                }
                currentLineNumber++;
                outputPercentTimer++;

                status.Imported = currentLineNumber;
                

                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                   // status.PercentDone = (currentLineNumber * 100) / (numberOfLines);
                }
            }
            //status.PercentDone = 100;
            status.Imported = status.Total;
            Console.WriteLine("Import Completed.");
            file.Close();
            Console.WriteLine("Import Completed with " + numErrors + " errors. If errors occurred, it's possible user is already imported.");
        }
        public async void importRoomData(string url)
        {
            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            int outputPercentTimer = 0;

            status.Imported = 0;
            status.Total = numberOfLines;

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

                if (conn.queryRoom(roomNumber).Count >= 1)
                {
                    conn.updateRoom(r);
                }
                else
                {
                    conn.addRoom(r);
                }

             


            currentLineNumber++;
            status.Imported = currentLineNumber;
                outputPercentTimer++;
                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                 
                 }
            }
            status.Imported = status.Total;
            Console.WriteLine("Import Completed.");
            file.Close();
        }
        string CreateHash(string password)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                string hashedPassword = "";
                foreach (byte i in bytes)
                {
                    hashedPassword += i.ToString("x2");
                }

                return hashedPassword;
            }
        }
        public async void importUserData(string url)
        {
            /*
             * ALTER PROCEDURE addUser
	            -- Add the parameters for the stored procedure here
	            @userName nvarchar(50), @password varchar(64),
	            @userType bit
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                -- Insert statements for procedure here

	            INSERT INTO [User] (Username, Password, UserType) VALUES (@userName, @password, @userType)

            END
            */
            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            int outputPercentTimer = 0;

            status.Imported = 0;
            status.Total = numberOfLines;

            string line;
            Char[] prohibitedChars = { '*', '.',' ' };
            Char[] prohibitdPassChars = { ' ' };
            System.IO.StreamReader file =
                new System.IO.StreamReader(url);
            while ((line = file.ReadLine()) != null)
            { 
                await Task.Delay(1);

                const int USERNAME_START = 0;
                const int USERNAME_LEN = 25;
                const int PASSWORD_START = 25;
                const int PASSWORD_LEN = 50;
                const int USERTYPE_START = 75;
                const int USERTYPE_LEN = 1;


                string username;
                string password;
                string usertype;
                try
                {
                     username = line.Substring(USERNAME_START, USERNAME_LEN).Trim(prohibitedChars);
                     password = line.Substring(PASSWORD_START, PASSWORD_LEN).Trim(prohibitdPassChars);
                     usertype = line.Substring(USERTYPE_START, USERTYPE_LEN);
                }
                catch (Exception e)
                {
                    throw new Exception("User input file error: Formatting error in file!");
                }

                bool isAdmin;
                if (usertype=="R")
                {
                    isAdmin = false;
                }
                else if (usertype=="A")
                {
                    isAdmin = true;
                }
                else
                {
                    throw new Exception("User input file error: Invalid user type!");
                }

                string hashedPassword = CreateHash(password);

                User user = new User(username, hashedPassword, isAdmin);

                // if user is already in database, this will fail
                try
                {
                    conn.addUser(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

           
            

                currentLineNumber++;
                status.Imported = currentLineNumber;
                outputPercentTimer++;
                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                }
            }
            status.Imported = status.Total;
            Console.WriteLine("Import Completed.");
            file.Close();
        }

        public async void importInventoryData(string url)
        {
            // currently throws an error if you attempt to add the same data twice
            int numberOfLines = getFileLineLength(url);
            int currentLineNumber = 0;

            status.Imported = 0;
            status.Total = numberOfLines;

            int outputPercentTimer = 0;
            string line;
            Char[] prohibitedChars = { '*', '.' };
            System.IO.StreamReader file =
                new System.IO.StreamReader(url);
            while ((line = file.ReadLine()) != null)
            {

                await Task.Delay(1);

                const int STOCKID_START_CHAR = 0;
                const int STOCKID_LEN = 5;
                const int QUANTITY_START_CHAR = 5;
                const int QUANTITY_LEN = 5;
                const int DESCRIPTION_START_CHAR = 10;
                const int DESCRIPTION_LEN = 35;
                const int SIZE_START_CHAR = 45;
                const int SIZE_LEN = 3;
                const int COST_START_CHAR = 48;
                const int COST_LEN = 8;

                string stockID = line.Substring(STOCKID_START_CHAR, STOCKID_LEN).Trim(prohibitedChars).Replace("'", "’");
                string quantity = line.Substring(QUANTITY_START_CHAR, QUANTITY_LEN).Trim(prohibitedChars).Replace("'", "’");
                string description = line.Substring(DESCRIPTION_START_CHAR, DESCRIPTION_LEN).Trim(prohibitedChars).Replace("'", "’");
                string size = line.Substring(SIZE_START_CHAR, SIZE_LEN).Trim(prohibitedChars).Replace("'", "’");
                string stringCost = line.Substring(COST_START_CHAR, COST_LEN).Trim(prohibitedChars).Replace("'", "’");

                decimal cost = Decimal.Parse(stringCost);
                decimal addCents = .01M;
                cost *= addCents; // shift values 2 below the decimal $$$$$$$$ to $$$$$$.cc

                bool update = false;
                if (conn.queryInventory(description).Count >= 1)
                {
                    update = true;
                }
         
                if (quantity=="VIRTL") // create a new service
                {
                    Service service = new Service(stockID, description, cost);

                    if (update) conn.updateService(service);
                    else conn.addService(service);
                }
                else // create a new item
                {
                    Item item = new Item(stockID, description, cost);

                    int intQuantity = Int32.Parse(quantity);
                    item.setQuantity(intQuantity);
                    int intSize = Int32.Parse(size);
                    item.setSize(intSize);
                    if (update) conn.updateItem(item);
                    else conn.addItem(item);
                }

                currentLineNumber++;
                status.Imported = currentLineNumber;
                outputPercentTimer++;
                if (outputPercentTimer > 1000)
                {
                    outputPercentTimer = 0;
                    Console.WriteLine(((currentLineNumber * 100) / (numberOfLines)).ToString() + "% complete");
                }
            }
            status.Imported = status.Total;
            Console.WriteLine("Import Completed.");
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
