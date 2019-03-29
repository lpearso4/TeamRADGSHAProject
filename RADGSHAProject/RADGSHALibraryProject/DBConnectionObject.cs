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
            //private const string DATASOURCE = "DESKTOP-54U85N3\\SQLEXPRESS"; // change to your server name
            const string DATASOURCE = "database\\csci3400011030"; // school computer

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
            //conn.Close();// add error checking
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
        public void addRoom (Room room)
        {
            /* Change to stored procedure version */
            string addString = "Room (HourlyRate, EffectiveDate, RoomNumber) VALUES ('" + room.getHourlyRate() + "','" + room.getEffectiveDate() + "','" + room.getRoomNumber() + "')";
            add(addString);
        }


        public void addPatient(Patient patient)
        {
            /* Change to stored procedure version */
       
            string addString = "Patient (Gender, SSN, BirthDate, FirstName, MiddleInitial, LastName, AddressLine1, AddressLine2, State, City, Zipcode, InsurerId, DoNotResuscitate, OrganDonor) " +
                                "VALUES ('" + patient.getGender() + "','" + patient.getSSN() + "','" + patient.getBirthDate() +"','" + patient.getFirstName() 
                                 + "','" + patient.getMiddleInitial() + "','" + patient.getLastName() +"','" + patient.getAddressLine1() +"','" + patient.getAddressLine2() +"','" + patient.getState() 
                                 +"','" + patient.getCity() +"','" + patient.getZipcode() + "','" + patient.getInsurer() + "','" + patient.getDoNotResuscitateStatus() + "','" + patient.getOrganDonorStatus() +"')";
          
            add(addString);
        }
        private void add(string addString)
        {
            string insertString = "INSERT INTO ";
            addString = insertString + addString;
            SqlCommand command = new SqlCommand(addString);
            command.Connection = conn;
            
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
        public void updatePatient(Patient patient)
        {
             string updateString = "UPDATE Patient SET LastName='" + patient.getLastName() + "', " +
                                      "FirstName='" + patient.getFirstName() + "', " +
                                      "MiddleInitial='" + patient.getMiddleInitial() + "', " +
                                      "AddressLine1='" + patient.getAddressLine1() + "', " +
                                      "AddressLine2='" + patient.getAddressLine2() + "', " +
                                      "State='" + patient.getState() + "', " +
                                      "City='" + patient.getCity() + "', " +
                                      "Zipcode='" + patient.getZipcode() + "', " +
                                      "InsurerId='" + patient.getInsurer() + "', " +
                                      "DoNotResuscitate='" + patient.getDoNotResuscitateStatus() + "', " +
                                      "OrganDonor='" + patient.getOrganDonorStatus() + "', " +
                                      "BirthDate='" + patient.getBirthDate() + "', " +
                                      "Gender='" + patient.getGender() + "' " +

                                  "WHERE SSN='" + patient.getSSN() + "'";
            SqlCommand command = new SqlCommand(updateString);

            /* Change above to stored procedure version below (and finish stored procedure version below)
           string queryString = "updatePatient";
           SqlCommand command = new SqlCommand(queryString, conn);
           command.CommandType = System.Data.CommandType.StoredProcedure;
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           command.Parameters.Add(new SqlParameter("@ssn", ssn));
           */

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
            // Query patient only returns the three fields we are looking for (firstname, lastname, ssn) You have to get patient to get the rest of the fields
            string queryString = "SELECT * FROM Patient WHERE SSN LIKE '%" + ssn + "%' AND LastName LIKE '%" + lastName + "%' AND "
                                 + " FirstName LIKE '%" + firstName + "%'";
            SqlCommand command = new SqlCommand(queryString);
           
            /* We will replace the above with the stored procedure version below: (may have to be modified)
            string queryString = "queryPatient";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ssn", ssn));
            command.Parameters.Add(new SqlParameter("@lastName", lastName));
            command.Parameters.Add(new SqlParameter("@firstName", firstName));
            */

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

        private SqlDataReader getItem(string table, string fieldName, string query)
        {
            string queryString = "SELECT * FROM " + table + " WHERE " + fieldName + "='" + query + "'";
            SqlCommand command = new SqlCommand(queryString);
            command.Connection = conn;
           
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
