using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace HiringCompanyData
{
    
    [DataContract]
    public class Employee
    {

        private String username;
        private String password;
        private String name;
        private String surname;
        private String position;
        private String startTime;
        private String endTime;
        private String email;


        private bool login;
        private HiringCompany hiringCompanyId;
        private DateTime passwordUpadateDate;

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDtmp { get; set; }

        [DataMember]
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

        [DataMember]
        public String Email
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public HiringCompany HiringCompanyId
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

        public override string ToString()
        {
            return  Name + " " + Surname;
        }
    }
}