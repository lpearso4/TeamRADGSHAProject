using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADGSHALibrary
{
    public class User
    {
        private string username;
        private string password; // to store hashed password
        private bool admin;

        public User(string newUserName, string newHashedPassword)
        {
            username = newUserName;
            password = newHashedPassword;
          
        }
        public User(string newUserName, string newHashedPassword, bool newIsAdmin)
        {
            username = newUserName;
            password = newHashedPassword;
            admin = newIsAdmin;
        }

        public void logIn(string setUsername, string setPassword)
        {
        }

        public void logOut()
        {

        }
        public void setAdmin(bool isAdmin)
        {
            admin = isAdmin;
        }
        public bool isAdmin()
        {
            return admin;
        }
        public string getPassword()
        {
            return password;
        }
        public string getUsername()
        {
            return username;
        }
        public void importFile(string filepath) // different from low level object model (there is no "file" object)
        {

        }
    }
}
