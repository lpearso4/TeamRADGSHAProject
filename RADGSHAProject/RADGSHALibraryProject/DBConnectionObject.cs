using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RADGSHALibrary
{
    public class DBConnectionObject
    {

        private int QUERY_LIMIT = RADGSHALibraryProject.Properties.db.Default.query_limit; // Pull query limit for queries from properties file

        /* These just make it easier to find the column number for each attribute when using SqlDataReader */
        private enum PCol : int { Gender, SSN, BirthDate, FirstName, MiddleInitial, LastName, AddressLine1, AddressLine2, State, City, ZipCode, InsurerID, DnrStatus, OrganDonor };
        private enum RoomCol : int { HourlyRate, EffectiveDate, RoomNumber };
        private enum LogCol : int { StockID, UserName, Date, QuantityUsed };
        private enum ItemCol : int { StockID, Size, Quantity };
        private enum InvCol : int { StockID, Description, Cost };
        private enum ServiceCol : int { StockID };
        private enum staysInCol : int { RoomNumber, RoomEffectiveDate, PatientId, VisitEntryDate, RoomEntryDateTime, RoomExitDateTime };
        private enum UserCol : int { Username, Password, UserType }; 
        private enum VisCol : int { PatientId, EntryDate, ExitDate, AttendingPhysician, Diagnosis };
        private enum SymCol : int { PatientId, EntryDate, SymptomName };
        private enum UsesCol : int { StockId, PatientId, EntryDateTime, amount };

        private SqlConnection conn;
        private static DBConnectionObject instance;

        
        protected DBConnectionObject()
        {

            // Get connection details from properties file
            string dbuser = RADGSHALibraryProject.Properties.db.Default.dbuser;
            string dbpass = RADGSHALibraryProject.Properties.db.Default.dbpass;
            string dbname = RADGSHALibraryProject.Properties.db.Default.dbname;
            string datasource = RADGSHALibraryProject.Properties.db.Default.datasource;

            // On Creation of DBConnectionObject, connect to MSSQL Server   
            string connectionString = "Initial Catalog=" + dbname + "; Data Source=" + datasource + "; Integrated Security=False; User Id=" + dbuser + "; Password=" + dbpass + ";";
        
            conn = new SqlConnection(connectionString);

            bool success_connecting = true;
            try
            {
                conn.Open();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                success_connecting = false;
            }
            if (!success_connecting) throw new Exception("Error: Unable to connect to database!");
        }
        ~DBConnectionObject()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                //Handle error
            }
        }

        public static DBConnectionObject getInstance()
        {
            if (instance == null) instance = new DBConnectionObject();
           
            return instance;
        }

        private SqlDataReader executeStoredProcedure(string procedureName, List<SqlParameter> parameterList)
        {
            string queryString = procedureName;
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameterList)
            {
                command.Parameters.Add(parameter);
            }
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void getVisits(ref Patient patient)
        {
            /* This attaches a list of visits to patient. 
             * Symptoms are pulled from the symptoms table and attached to visits
             * Rooms are attached to visits
             * TODO: Items and Services still need to be attached to the visit! 
             *   
             */
            
            patient.getVisitList().Clear(); // should probably clear the list so as not to duplicate?

            string queryString = "getVisits";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ssn", patient.getSSN()));
           
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                Visit visit = new Visit();

                if (!reader.IsDBNull((int)VisCol.EntryDate)) visit.setEntryDate(reader.GetDateTime((int)VisCol.EntryDate));

                if (!reader.IsDBNull((int)VisCol.ExitDate)) visit.setExitDate(reader.GetDateTime((int)VisCol.ExitDate));
                else patient.setCurrentVisit(ref visit);

                if (!reader.IsDBNull((int)VisCol.AttendingPhysician)) visit.setAttendingPhysician(reader.GetString((int)VisCol.AttendingPhysician));
                if (!reader.IsDBNull((int)VisCol.Diagnosis)) visit.changeDiagnosis(reader.GetString((int)VisCol.Diagnosis));

                patient.addVisit(visit);
                             
            }
            reader.Close();

            // while we are getting patient visits, we might as well populate patient symptoms

            List<Visit> visits = patient.getVisitList();
            Console.WriteLine("Visits: " + visits.Count); 
            for (int i = 0; i<visits.Count;i++)
            {
                
                List<string> symptoms = querySymptoms(patient, visits[i]);
                Console.WriteLine("Symptoms: " + symptoms.Count);
                
                foreach (string s in symptoms) // add symptoms
                {
                    Console.WriteLine(s);
                    visits[i].addSymptom(s);
                    Console.WriteLine("Symptoms LIst: " + patient.getVisitList()[i].getSymptomList().Count);
                }
                Visit v = visits[i];
                
                getRoomList(ref patient, ref v);

                foreach (Room r in visits[i].getRoomList()) // add rooms
                {
                    Console.WriteLine("Patient " + patient.getFirstName() + " " + patient.getLastName() + " stayed in room " + r.getRoomNumber() + " which has an hourly rate of " + r.getHourlyRate());
                    getRoomEntryExitDates(patient, visits[i], r, out DateTime entryDate, out DateTime exitDate, out bool stillInroom);
                    Console.WriteLine("Patient stayed in room from " + entryDate + " to " + exitDate);
                }
            }



        }
        
        public void addVisit(Visit visit, Patient patient)
        {
            bool update = false;
            alterVisit(update, visit, patient);
        }
        public void updateVisit(Visit visit, Patient patient)
        {
            bool update = true;
            alterVisit(update, visit, patient);
        }
        public void alterVisit(bool update, Visit visit, Patient patient)
        {
            string queryString = "addVisit";
            if (update) queryString = "updateVisit";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@patientID", patient.getSSN()));
            command.Parameters.Add(new SqlParameter("@entryDate", visit.getEntryDate()));
            command.Parameters.Add(new SqlParameter("@attendingPhysician", visit.getAttendingPhysician()));
                                                  //  '@attendingPhysician
            command.Parameters.Add(new SqlParameter("@diagnosis", visit.getDiagnosis()));
   
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        /// <summary>
        /// Service DB methods below
        /// </summary>
        /// <param name="service"></param>
        public void addService(Service service)
        {
            bool update = false; // add service
            alterService(update, service);
        }
        public void updateService(Service service)
        {
            bool update = true; // update service
            alterService(update, service);
        }
        private void alterService(bool update, Service service)
        {
            alterInventory(update, service);

            string queryString = "addService";
            if (!update)
            {
                SqlCommand command = new SqlCommand(queryString, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StockID", service.getStockID()));

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
        }
        /// <summary>
        /// Item DB methods below
        /// </summary>
        /// <param name="item"></param>
        public void addItem(Item item)
        {
            bool update = false; // add item
            alterItem(update, item);
        }
        public void updateItem(Item item)
        {
            bool update = true; // update item
            alterItem(update, item);
        }
        private void alterItem(bool update, Item item)
        {
            alterInventory(update, item);

            string queryString = "addItem";
            if (update) queryString = "updateItem";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@stockId", item.getStockID()));
            command.Parameters.Add(new SqlParameter("@Size", item.getSize()));
            command.Parameters.Add(new SqlParameter("@Quantity", item.getQuantity()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();                      
        }
            /// <summary>
            /// Inventory DB methods below
            /// </summary>
            /// <param name="inventory"></param>
        /* I don't think that we'll need add or update inventory methods, it'll be through add or update item or service
         * private void addInventory(Inventory inventory)
        {
            bool update = false; // add inventory
            alterInventory(update, inventory);
        }
        private void updateInventory(Inventory inventory)
        {
            bool update = true; // update the inventory
            alterInventory(update, inventory);
        }*/
        private void alterInventory(bool update, Inventory inventory)
        {
            string queryString = "addInventory";
            if (update) queryString = "updateInventory";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@stockId", inventory.getStockID() ));          
            command.Parameters.Add(new SqlParameter("@description",inventory.getDescription()));
            command.Parameters.Add(new SqlParameter("@cost",inventory.getCost()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        public Inventory getInventory(string stockID)
        {
            string queryString = "getInventory";
            SqlCommand command = new SqlCommand(queryString, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@stockID", stockID));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            string sstockID = reader.GetString((int)InvCol.StockID);
            string description = reader.GetString((int)InvCol.Description);
            decimal cost = reader.GetDecimal((int)InvCol.Cost);
            Inventory result = new Inventory(sstockID,description,cost);

            reader.Close();

            return result;

        }
        public List<Inventory> queryInventory(string queryDescription)
        {
            string queryString = "queryInventory";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@description", queryDescription));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            List<Inventory> results = new List<Inventory>();

            int count = 0;
            while (reader.Read() && count < QUERY_LIMIT)
            {
                string stockID = reader.GetString((int)InvCol.StockID);
                string description = reader.GetString((int)InvCol.Description);
                decimal cost = reader.GetDecimal((int)InvCol.Cost);
                Inventory inv = new Inventory(stockID,description,cost);

                results.Add(inv);
                count++;
            }
            reader.Close();

            return results;
        }

        /// <summary>
        /// Room DB methods below
        /// </summary>
        /// <param name="room"></param>
        public void addRoom (Room room)
        {
            bool update = false; // add room
            alterRoom(update, room);
        }
        public void updateRoom(Room room)
        {
            bool update = true; // update the room
            alterRoom(update, room);
        }
        private void alterRoom(bool update, Room room)
        {
            string queryString = "addRoom";
            if (update) queryString = "updateRoom";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@hourlyRate", room.getHourlyRate()));

            if (update)
                command.Parameters.Add(new SqlParameter("@dateTime", room.getEffectiveDate()));
            else
                command.Parameters.Add(new SqlParameter("@effectiveDate", room.getEffectiveDate()));

            command.Parameters.Add(new SqlParameter("@roomNumber", room.getRoomNumber()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public Room getRoom(string roomNumber, DateTime effectiveDate)
        {         
            string queryString = "getRoom";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@effectiveDate", effectiveDate));
            command.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
            
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            string rNumber = reader.GetString((int)RoomCol.RoomNumber);
            if (rNumber != roomNumber) throw new Exception("Exception: Room not found!");
            DateTime eDate = reader.GetDateTime((int)RoomCol.EffectiveDate);
            if (eDate != effectiveDate) throw new Exception("Exception: Room with given effective date not found!");
            decimal hourlyRate=0;
            if (!reader.IsDBNull((int)RoomCol.HourlyRate)) hourlyRate = reader.GetDecimal((int)RoomCol.HourlyRate);

            Room room = new Room(rNumber,hourlyRate,eDate);

            reader.Close();

            return room;
        }
        public List<Room> queryRoom(string roomNumber)
        {

            string queryString = "queryRoom";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
          
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            List<Room> results = new List<Room>();

            int count = 0;
            while (reader.Read() && count < QUERY_LIMIT)
            {
                string roomNum = reader.GetString((int)RoomCol.RoomNumber);
                DateTime effectiveDate = reader.GetDateTime((int)RoomCol.EffectiveDate);
                decimal hourlyRate = reader.GetDecimal((int)RoomCol.HourlyRate);
                Room room = new Room(roomNum, hourlyRate, effectiveDate);

                results.Add(room);
                count++;
            }
            reader.Close();

            return results;
        }

        /// <summary>
        /// Patient DB methods below
        /// </summary>
        /// <param name="patient"></param>
        public void addPatient(Patient patient)
        {
            bool update = false; // we are adding a patient, not updating
            alterPatient(update, patient); 
        }
        public void updatePatient(Patient patient)
        {
            bool update = true; // update the patient
            alterPatient(update, patient);
        }
        private void alterPatient(bool update, Patient patient)
        {
            string queryString = "addPatient";
            if (update) queryString = "updatePatient";
       
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@gender", patient.getGender()));
            command.Parameters.Add(new SqlParameter("@ssn", patient.getSSN()));
            command.Parameters.Add(new SqlParameter("@birthDate", patient.getBirthDate()));
            command.Parameters.Add(new SqlParameter("@firstName", patient.getFirstName()));
            command.Parameters.Add(new SqlParameter("@middleInitial", patient.getMiddleInitial()));
            command.Parameters.Add(new SqlParameter("@lastName", patient.getLastName()));
            command.Parameters.Add(new SqlParameter("@addressLine1", patient.getAddressLine1()));
            command.Parameters.Add(new SqlParameter("@addressLine2", patient.getAddressLine2()));
            command.Parameters.Add(new SqlParameter("@state", patient.getState()));
            command.Parameters.Add(new SqlParameter("@city", patient.getCity()));
            command.Parameters.Add(new SqlParameter("@zipcode", patient.getZipcode()));
            command.Parameters.Add(new SqlParameter("@insurerId", patient.getInsurer()));
            command.Parameters.Add(new SqlParameter("@doNotResuscitate", patient.getDoNotResuscitateStatus()));
            command.Parameters.Add(new SqlParameter("@organDonor", patient.getOrganDonorStatus()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public Patient getPatient(string ssn)
        {
            string queryString = "getPatient";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ssn", ssn));
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            
            reader.Read();
            string patientSSN = reader.GetString((int)PCol.SSN);
            if (patientSSN != ssn) throw new Exception("Exception: Patient not found!");
            Patient patient = new Patient(patientSSN);

            if (!reader.IsDBNull((int)PCol.LastName)) patient.setLastName(reader.GetString((int)PCol.LastName));
            if (!reader.IsDBNull((int)PCol.FirstName)) patient.setFirstName(reader.GetString((int)PCol.FirstName));
            if (!reader.IsDBNull((int)PCol.MiddleInitial)) patient.setMiddleInitial(reader.GetString((int)PCol.MiddleInitial)[0]);
            if (!reader.IsDBNull((int)PCol.AddressLine1)) patient.setAddressLine1(reader.GetString((int)PCol.AddressLine1));
            if (!reader.IsDBNull((int)PCol.AddressLine2)) patient.setAddressLine2(reader.GetString((int)PCol.AddressLine2));
            if (!reader.IsDBNull((int)PCol.City)) patient.setCity(reader.GetString((int)PCol.City));
            if (!reader.IsDBNull((int)PCol.State)) patient.setState(reader.GetString((int)PCol.State));
            if (!reader.IsDBNull((int)PCol.ZipCode)) patient.setZipcode(reader.GetString((int)PCol.ZipCode));
            if (!reader.IsDBNull((int)PCol.Gender)) patient.setGender(reader.GetString((int)PCol.Gender)[0]);
            if (!reader.IsDBNull((int)PCol.BirthDate)) patient.setBirthDate(reader.GetDateTime((int)PCol.BirthDate));
            if (!reader.IsDBNull((int)PCol.InsurerID)) patient.setInsurer(reader.GetString((int)PCol.InsurerID));
            if (!reader.IsDBNull((int)PCol.DnrStatus)) patient.setDoNotResuscitateStatus(reader.GetBoolean((int)PCol.DnrStatus));
            if (!reader.IsDBNull((int)PCol.OrganDonor)) patient.setOrganDonorStatus(reader.GetBoolean((int)PCol.OrganDonor));
            
            reader.Close();

            getVisits(ref patient);

            return patient;

        }
   
        public List<Patient> queryPatient(string ssn, string lastName, string firstName)
        {

            string procedureName = "queryPatient";
                     
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ssn", ssn));
            parameters.Add(new SqlParameter("@lastName", lastName));
            parameters.Add(new SqlParameter("@firstName", firstName));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            List<Patient> results = new List<Patient>();
            
            int count = 0;
            while (reader.Read() && count < QUERY_LIMIT)
            {
                Patient patient = new Patient(reader.GetString((int)PCol.SSN)); // ssn
                patient.setLastName(reader.GetString((int)PCol.LastName));
                patient.setFirstName(reader.GetString((int)PCol.FirstName));
                results.Add(patient);
                count++;
            }

            closeReader(ref reader);

            return results;
        }

        public void addUser(User user)
        {
            string queryString = "addUser";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", user.getUsername()));
            command.Parameters.Add(new SqlParameter("@password", user.getPassword()));
            command.Parameters.Add(new SqlParameter("@userType", user.isAdmin()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public void addUses(Inventory inventory, Patient patient, Visit v)
        {
            string queryString = "addUses";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@stockId", inventory.getStockID()));
            command.Parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            command.Parameters.Add(new SqlParameter("@entryDate", v.getEntryDate()));
           
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public void addToLog(Inventory inventory, User user, decimal quantityUsed)
        {
            string queryString = "addToLog";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@stockId", inventory.getStockID()));
            command.Parameters.Add(new SqlParameter("@userName", user.getUsername()));
            command.Parameters.Add(new SqlParameter("@quantityUsed", quantityUsed));
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        public void addSymptom(Patient patient, Visit v, string symptom)
        {
            string queryString = "addSymptom";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            command.Parameters.Add(new SqlParameter("@entryDate", v.getEntryDate()));
            command.Parameters.Add(new SqlParameter("@symptomName", symptom));
            

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public List<string> querySymptoms (string patientSSN="", string symptomName="")
        {
            string procedureName = "querySymptoms";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@patientId", patientSSN));
            parameters.Add(new SqlParameter("@entryDate", ""));
            parameters.Add(new SqlParameter("@symptomName", symptomName));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            List<string> results = new List<string>();

            while (reader.Read()) // no query limit on symptoms
            {
                results.Add(reader.GetString((int)SymCol.SymptomName));
            }
            closeReader(ref reader);

            return results;
        }
        public List<string> querySymptoms(Patient patient, Visit visit, string symptomName="")
        {

            string procedureName = "querySymptoms";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            parameters.Add(new SqlParameter("@entryDate", visit.getEntryDate()));
            parameters.Add(new SqlParameter("@symptomName", symptomName));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            List<string> results = new List<string>();

            while (reader.Read()) // no query limit on symptoms
            {
                results.Add(reader.GetString((int)SymCol.SymptomName));
            }
            closeReader(ref reader);

            return results;
        }

        public void addStaysIn(Room room, Patient patient, Visit v)
        {
            string queryString = "addStaysIn";
            
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            command.Parameters.Add(new SqlParameter("@roomNumber", room.getRoomNumber()));
            command.Parameters.Add(new SqlParameter("@roomEffectiveDate", room.getEffectiveDate()));
            command.Parameters.Add(new SqlParameter("@visitEntrydate", v.getEntryDate()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        public bool validateLogin(User user)
        {
            string queryString = "validateLogin";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", user.getUsername()));
            command.Parameters.Add(new SqlParameter("@givenPW", user.getPassword()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            bool isValid = reader.GetBoolean(0);

            reader.Close();

            return isValid;
        }
        public bool validateUserType(User user)
        {
            string queryString = "validateUserType";

            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserName", user.getUsername()));

            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            bool isAdmin = reader.GetBoolean(0);

            reader.Close();

            return isAdmin;
        }

        public void closeVisit(Patient patient, Visit v)
        {
        
            string procedureName = "closeVisit";

            List<SqlParameter> parameters = new List<SqlParameter>();           
            parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            parameters.Add(new SqlParameter("@entryDate", v.getEntryDate()));
            parameters.Add(new SqlParameter("@exitDate", v.getExitDate()));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            closeReader(ref reader);

        }

        /*
        // Possibly won't use "getStaysIn methods but specialized versions that I'm writing below, such as getRoomList, and getRoomEntryExitDate
        public void getStaysIn(string patientSSN, string roomNumber) 
        {
            getStaysIn(patientSSN, roomNumber, DateTime.MinValue, DateTime.MinValue);
        }
        public void getStaysIn(string patientSSN, string roomNumber, DateTime visitEntryDate) 
        {
            getStaysIn(patientSSN, roomNumber, visitEntryDate, DateTime.MinValue);
        }

 
        public void getStaysIn(string patientSSN, string roomNumber, DateTime visitEntryDate, DateTime roomEffectiveDate) // I'm not sure exactly what this will look like yet
        // This will probably return something at some point. The other methods send DateTime.MinValue as an argument as a way of saying, we don't want to use that as a parameter
        // Yeah, I know that's a bad hack
        {
            string procedureName = "getStaysIn";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@roomNumber", roomNumber));
            if (roomEffectiveDate == DateTime.MinValue)
                parameters.Add(new SqlParameter("@roomEffectiveDate", ""));
            else
                parameters.Add(new SqlParameter("@roomEffectiveDate", roomEffectiveDate));
            parameters.Add(new SqlParameter("@patientId", patientSSN));
            if (visitEntryDate == DateTime.MinValue)
                parameters.Add(new SqlParameter("@visitEntryDate", ""));
            else
                parameters.Add(new SqlParameter("@visitEntryDate", visitEntryDate));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            // Now we need to do something with the values that we retreive...
            // private enum staysInCol : int { RoomNumber, RoomEffectiveDate, PatientId, VisitEntryDate, RoomEntryDateTime, RoomExitDateTime };
            int count = 0;
            while (reader.Read() && count < QUERY_LIMIT)
            { */
               /* Console.WriteLine("Room Number: " + reader.GetString((int)staysInCol.RoomNumber)
                                + "Room Effective Date: " + reader.GetDateTime((int)staysInCol.RoomEffectiveDate)
                                + "Patient SSN: " + reader.GetString((int)staysInCol.PatientId));
                Console.WriteLine("\tVisit Entry Date: " + reader.GetDateTime((int)staysInCol.VisitEntryDate)
                                + "Room Entry Date: " + reader.GetDateTime((int)staysInCol.RoomEntryDateTime)
                                + "Room Exit Date: " + reader.GetDateTime((int)staysInCol.RoomExitDateTime)); */
             /*   
                count++;
            }
            closeReader(ref reader);
        }*/

        public void getRoomEntryExitDates(Patient patient, Visit visit, Room room, out DateTime roomEntryDate, out DateTime roomExitDate, out bool stillInRoom)
        {
            // When you are calculating a bill, and you know that a patient stayed in "room", call this method to return the dates the patient entered and exited the room
            string procedureName = "getStaysIn";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@roomNumber", room.getRoomNumber()));
           
            parameters.Add(new SqlParameter("@roomEffectiveDate", room.getEffectiveDate()));

            parameters.Add(new SqlParameter("@visitEntryDate", visit.getEntryDate()));
            parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            roomEntryDate = DateTime.MinValue;
            roomExitDate = DateTime.MinValue;
            stillInRoom = false;
            while (reader.Read())
            {
                Console.WriteLine("Reading entry and exit date values");
                roomEntryDate = reader.GetDateTime((int)staysInCol.RoomEntryDateTime);
                      
         
               if (!reader.IsDBNull((int)staysInCol.RoomExitDateTime))
               {
                   roomExitDate = reader.GetDateTime((int)staysInCol.RoomExitDateTime);
               }
               else
               {
                   stillInRoom = true;
               }

            }
            closeReader(ref reader);
        }

        public void getRoomList(ref Patient patient, ref Visit visit) 
        // Attaches the room(s) associated with this patient visit
        {
            string procedureName = "getStaysIn";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@roomNumber", ""));
            parameters.Add(new SqlParameter("@patientId", patient.getSSN()));
            parameters.Add(new SqlParameter("@visitEntryDate", visit.getEntryDate()));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            int count = 0;
            List<Room> rooms = visit.getRoomList();
            rooms.Clear(); // make sure we clear the room list, as we are adding room(s) back on

            SortedList<string, DateTime> roomDataHolder = new SortedList<string, DateTime>();
            while (reader.Read() && count < QUERY_LIMIT)
            {
                string roomNum = reader.GetString((int)staysInCol.RoomNumber);
                DateTime roomEffectiveDate = reader.GetDateTime((int)staysInCol.RoomEffectiveDate);

                roomDataHolder.Add(roomNum, roomEffectiveDate);

               
                /* Console.WriteLine("Room Number: " + reader.GetString((int)staysInCol.RoomNumber)
                                 + "Room Effective Date: " + reader.GetDateTime((int)staysInCol.RoomEffectiveDate)
                                 + "Patient SSN: " + reader.GetString((int)staysInCol.PatientId));
                 Console.WriteLine("\tVisit Entry Date: " + reader.GetDateTime((int)staysInCol.VisitEntryDate)
                                 + "Room Entry Date: " + reader.GetDateTime((int)staysInCol.RoomEntryDateTime)
                                 + "Room Exit Date: " + reader.GetDateTime((int)staysInCol.RoomExitDateTime)); */

                count++;
            }
            closeReader(ref reader);

            foreach (KeyValuePair<string,DateTime> kvp in roomDataHolder)
            {
                Room room = getRoom(kvp.Key, kvp.Value);

                visit.addRoom(room);
            }
             
        }

        public void closeStaysIn(Patient patient, Visit visit, Room room, DateTime roomExitDate)
        {        
            string procedureName = "closeStaysIn";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PatientId", patient.getSSN()));
            parameters.Add(new SqlParameter("@visitEntryDate", visit.getEntryDate()));
            parameters.Add(new SqlParameter("@roomNumber", room.getRoomNumber()));
            parameters.Add(new SqlParameter("@roomEffectiveDate", room.getEffectiveDate()));
            parameters.Add(new SqlParameter("@roomExitDate", roomExitDate));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);
                      
            closeReader(ref reader);
        }
        public bool isService(Inventory stock)
        {
            string procedureName = "isService";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@stockId", stock.getStockID()));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            reader.Read();
            bool service = reader.GetBoolean(0);

            closeReader(ref reader);

            return service;
        }
        public bool isItem(Inventory stock)
        {
            string procedureName = "isItem";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@stockId", stock.getStockID()));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);
            reader.Read();
            bool item = reader.GetBoolean(0);

            closeReader(ref reader);

            return item;
        }
        public List<string> queryUses(Patient p, Visit v)
        {
            string procedureName = "queryUses";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@patientId", p.getSSN()));
            parameters.Add(new SqlParameter("@entryDateTime", v.getEntryDate()));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);
            List<string> ids = new List<string>();
            while(reader.Read())
            {
                ids.Add(reader.GetString((int)UsesCol.StockId));
            }

            closeReader(ref reader);

            return ids;
        }
        public int getUses(Patient p, Visit v, string stockID) // returns the quantity of the item used
        {
            string procedureName = "getUses";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@patientId", p.getSSN()));
            parameters.Add(new SqlParameter("@entryDateTime", v.getEntryDate()));
            parameters.Add(new SqlParameter("@stockID", stockID));
            SqlDataReader reader = executeStoredProcedure(procedureName, parameters);

            reader.Read();
            
            int quantity = reader.GetInt32((int)UsesCol.amount);

            closeReader(ref reader);

            return quantity;
        }

        public void closeReader(ref SqlDataReader reader)
        {
            try
            {
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error closing reader: " + e.Message); // it's not crucial to do anything... usually when there is an error closing reader
                                                                         // it means it didn't open correctly in the first place
            }
        }

    }
}
