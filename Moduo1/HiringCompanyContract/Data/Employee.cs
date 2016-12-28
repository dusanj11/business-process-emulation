using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiringCompanyContract.Data
{
    public class Employee
    {

        public enum PositionEnum : int { CEO = 0, HR = 1, PO, SM};

        private String username;
        private String password;
        private String name;
        private String surname;
        private String position;
        private String startTime;
        private String endTime;
        private bool login;
        private String hiringCompanyId;
        private DateTime passwordUpadateDate;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDtmp { get; set; }

       
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

        public String Position
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

        public bool Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string HiringCompanyId
        {
            get
            {
                return hiringCompanyId;
            }

            set
            {
                hiringCompanyId = value;
            }
        }

        public DateTime PasswordUpadateDate
        {
            get
            {
                return passwordUpadateDate;
            }

            set
            {
                passwordUpadateDate = value;
            }
        }

        public override string ToString()
        {
            return "Name " + Name + " Surname " + Surname;
        }
    }
}
