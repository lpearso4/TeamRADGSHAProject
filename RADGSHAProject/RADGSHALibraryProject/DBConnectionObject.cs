using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RADGSHALibrary
{
    class DBConnectionObject
    {
        // move some of these to properties file
        private const string DBUSER = "teamRADGSHAUser";
        private const string DBPASS = "123";
        private const string DBNAME = "HRAS_RAD";
        private const string DATASOURCE = "DESKTOP-54U85N3\\SQLEXPRESS"; // change to your server name

        private const int QUERY_LIMIT = 100; // set limit of search results

        private enum PCol : int { Gender, SSN, BirthDate, FirstName, MiddleInitial, LastName, AddressLine1, AddressLine2, State, City, ZipCode, InsurerID, DnrStatus, OrganDonor };
        private enum RoomCol : int { HourlyRate, EffectiveDate, RoomNumber };
        private enum LogCol : int { StockID, UserID, Date, QuantityUsed };
        private enum ItemCol : int { Size, Quantity, StockId };
        private enum staysInCol : int { RoomNumber, RoomEffectiveDate, PatientId, VisitEntryDate, RoomEntryDateTime, RoomExitDateTime };
        private enum UserCol : int { Username, Password, UserType, UserID }; // if we use UserID
        private enum VisCol : int { PatientId, EntryDate, ExitDate, AttendingPhysician, Diagnosis };
        private enum SymCol : int { PatientId, EntryDate, SymptomName };
        
        private SqlConnection conn;
        private static DBConnectionObject instance;
        
        protected DBConnectionObject()
        {
            // On Creation of DBConnectionObject, connect to MSSQL Server   
            string connectionString = "Initial Catalog=" + DBNAME + "; Data Source=" + DATASOURCE + "; Integrated Security=False; User Id=" + DBUSER + "; Password=" + DBPASS + ";";
            conn = new SqlConnection(connectionString);
          
        }
        public static DBConnectionObject getInstance()
        {
            if (instance == null) instance = new DBConnectionObject();

            return instance;
        }

        public List<Visit> getVisits(Patient patient)
        {
            // TODO: everything
            // WHAT: this will return a list of visits attached to 'patient'
            List<Visit> visits = new List<Visit>();

            return visits; // PLACEHOLDER
        }
        public void addVisit(Visit visit, Patient patient)
        {
            // TODO: EVERYTHING
            // WHAT: this will add a visit to the database attached to the visit
        }
        public void addPatient(Patient patient)
        {
            // TODO: everything
            // WHAT: this will add a patient to the database
        }
        public void updatePatient(Patient patient)
        {
            string queryString = "UPDATE Patient SET LastName='" + patient.getLastName() +"', " +
                                  "FirstName='" + patient.getFirstName() + "' " +
                                  //  middleInitial, addressLine1, addressLine2, city, state, zipcode, gender, birthDate, insurer, dnrStatus, organDonor 
                                  "WHERE SSN='" + patient.getSSN() + "'";
            SqlCommand command = new SqlCommand(queryString);
            command.Connection = conn;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

        public Patient getPatient(string ssn)
        {
            SqlDataReader reader = getItem("Patient", "SSN", ssn);

            reader.Read();
            string patientSSN = reader.GetString((int)PCol.SSN);
            if (patientSSN != ssn) throw new Exception("Exception: Patient not found!");
            Patient patient = new Patient(patientSSN);
            patient.setLastName(reader.GetString((int)PCol.LastName));
            patient.setFirstName(reader.GetString((int)PCol.FirstName));
            patient.setMiddleInitial(reader.GetString((int)PCol.MiddleInitial)[0]);
            patient.setAddressLine1(reader.GetString((int)PCol.AddressLine1));
            if (!reader.IsDBNull((int)PCol.AddressLine2)) patient.setAddressLine2(reader.GetString((int)PCol.AddressLine2));
            patient.setCity(reader.GetString((int)PCol.City));
            patient.setState(reader.GetString((int)PCol.State));
            int zip = reader.GetInt32((int)PCol.ZipCode);
            patient.setZipcode((ushort)zip);
            patient.setGender(reader.GetString((int)PCol.Gender)[0]);
            if (!reader.IsDBNull((int)PCol.BirthDate)) patient.setBirthDate(reader.GetDateTime((int)PCol.BirthDate));
            if (!reader.IsDBNull((int)PCol.InsurerID)) patient.setInsurer(reader.GetString((int)PCol.InsurerID));
            if (!reader.IsDBNull((int)PCol.DnrStatus)) patient.setDoNotResuscitateStatus(reader.GetBoolean((int)PCol.DnrStatus));
            if (!reader.IsDBNull((int)PCol.OrganDonor)) patient.setOrganDonorStatus(reader.GetBoolean((int)PCol.OrganDonor));
            
            conn.Close();
            return patient;

        }
        private SqlDataReader getItem(string table, string fieldName, string query)
        {
            string queryString = "SELECT * FROM " + table + " WHERE " + fieldName + "='" + query + "'";
            SqlCommand command = new SqlCommand(queryString);
            command.Connection = conn;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public List<Patient> queryPatient(string ssn, string lastName, string firstName)
        {
            string queryString = "SELECT * FROM Patient WHERE SSN LIKE '%" + ssn + "%' AND LastName LIKE '%" + lastName + "%' AND "
                                 + " FirstName LIKE '%" + firstName + "%'";
            SqlCommand command = new SqlCommand(queryString);
            command.Connection = conn;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<RADGSHALibrary.Patient> results = new List<RADGSHALibrary.Patient>();
            
            int count = 0;
            while (reader.Read() && count < QUERY_LIMIT)
            {
                RADGSHALibrary.Patient patient = new RADGSHALibrary.Patient(reader.GetString((int)PCol.SSN)); // ssn
                patient.setLastName(reader.GetString((int)PCol.LastName));
                patient.setFirstName(reader.GetString((int)PCol.FirstName));
                results.Add(patient);
                count++;
            }
            conn.Close();
            return results;
        }

   
    
    }
}
