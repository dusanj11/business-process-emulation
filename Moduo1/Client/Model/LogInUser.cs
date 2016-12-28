using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class LogInUser
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public LogInUser()
        {
            this.username = "";
            this.password = "";
        }

        public LogInUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
