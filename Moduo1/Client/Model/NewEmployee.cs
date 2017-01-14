using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class NewEmployee
    {
        private string name;
        private string surname;
        private string username;
        private string password;
        private string startTime;
        private string endTime;
        private string position;
        private string email;

        public string Email
        {
            get 
            { 
                return email; 
            }
            set 
            { 
                email = value; 
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public NewEmployee()
        {
            this.Name = "";
            this.Surname = "";
            this.Username = "";
            this.Password = "";
            this.StartTime = "";
            this.EndTime = "";
            this.Position = "";
            this.email = "";
        }

        public NewEmployee(string name, string surname, string username, string password, string startTime, string endTime, string position)
        {
            this.Name = name;
            this.Surname = surname;
            this.Username = username;
            this.Password = password;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Position = position;
            this.Email = email;
        }
    }
}
