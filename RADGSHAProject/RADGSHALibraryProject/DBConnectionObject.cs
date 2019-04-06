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
     
        private const int QUERY_LIMIT = 100; // set limit of search results ( move to properties file later )

        /* These just make it easier to find the column number for each attribute when using SqlDataReader */
        private enum PCol : int { Gender, SSN, BirthDate, FirstName, MiddleInitial, LastName, AddressLine1, AddressLine2, State, City, ZipCode, InsurerID, DnrStatus, OrganDonor };
        private enum RoomCol : int { HourlyRate, EffectiveDate, RoomNumber };
        private enum LogCol : int { StockID, UserName, Date, QuantityUsed };
        private enum ItemCol : int { StockID, Size, Quantity };
        private enum ServiceCol : int { StockID };
        private enum staysInCol : int { RoomNumber, RoomEffectiveDate, PatientId, VisitEntryDate, RoomEntryDateTime, RoomExitDateTime };
        private enum UserCol : int { Username, Password, UserType }; 
        private enum VisCol : int { PatientId, EntryDate, ExitDate, AttendingPhysician, Diagnosis };
        private enum SymCol : int { PatientId, EntryDate, SymptomName };
        private enum UsesCol : int { StockId, PatientId, EntryDateTime };

        private SqlConnection conn;
        private static DBConnectionObject instance;

        
        protected DBConnectionObject()
        {
            // move some of these to properties file
            const string DBUSER = "teamRADGSHAUser";
            const string DBPASS = "123";
            const string DBNAME = "HRAS_RAD";
            const string DATASOURCE = "DESKTOP-54U85N3\\SQLEXPRESS"; // change to your server name
            //const string DATASOURCE = "LAPTOP-CIDFKFS1"; // school computer

            // On Creation of DBConnectionObject, connect to MSSQL Server   
            string connectionString = "Initial Catalog=" + DBNAME + "; Data Source=" + DATASOURCE + "; Integrated Security=False; User Id=" + DBUSER + "; Password=" + DBPASS + ";";
            conn = new SqlConnection(connectionString);
            conn.Open(); // TODO: add error handling in case connection fails
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

        public void getVisits(ref Patient patient)
        {
            // This attaches a list of visits to patient. 
            // TODO: symptoms should be pulled from Symptom table and added to each visit
            //   and room list should be pulled from StaysIn table
            //   Items used and services should be pulled from respective tables
            //   (Or should they be added somewhere else?)

            //List<Visit> visits = patient.getVisitList();
            //visits.Clear();

            //patient.getVisitList().Clear(); // should probably clear the list so as not to duplicate?

            //Change to use stored procedures
            string queryString = "SELECT * FROM Visit WHERE PatientId = '" + patient.getSSN() + "'";

            SqlCommand command = new SqlCommand(queryString);
            command.Connection = conn;
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Visit visit = new Visit();

                if (!reader.IsDBNull((int)VisCol.EntryDate)) visit.setEntryDate(reader.GetDateTime((int)VisCol.EntryDate));
             
                if (!reader.IsDBNull((int)VisCol.ExitDate)) visit.setExitDate(reader.GetDateTime((int)VisCol.ExitDate));
                if (!reader.IsDBNull((int)VisCol.AttendingPhysician)) visit.setAttendingPhysician(reader.GetString((int)VisCol.AttendingPhysician));
                if (!reader.IsDBNull((int)VisCol.Diagnosis)) visit.changeDiagnosis(reader.GetString((int)VisCol.Diagnosis));
                //visit.addSymptom(); 
                
                patient.addVisit(visit);
              
            }
            reader.Close();
           
        }
        public void addVisit(Visit visit, Patient patient)
        {
            // NOTE: doesn't do anything yet
            // string addString = "Visit (PatientID, EntryDate, ExitDate, AttendingPhysician, Diagnosis)";
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
            if (update) queryString = "updateService";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StockID",service.getStockID()));
            
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            
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
        /*private void addInventory(Inventory inventory)
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
            // Need to rewrite getRoom
            string queryString = "getItems";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@table", "Room"));
            command.Parameters.Add(new SqlParameter("@feildName", "roomNumber"));
            command.Parameters.Add(new SqlParameter("@query", roomNumber));
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
               
            //string queryString = "addPatient";
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
            // stored procedure version
          
          
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

            // An exception will be thrown if we attempt to retrieve a null column
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

            string queryString = "queryPatient";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ssn", ssn));
            command.Parameters.Add(new SqlParameter("@lastName", lastName));
            command.Parameters.Add(new SqlParameter("@firstName", firstName));
            

            command.Connection = conn;
           
            SqlDataReader reader = command.ExecuteReader();

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
            reader.Close();
            return results;
        }

    }
}
