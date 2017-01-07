using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyData
{
    [DataContract]
    public class Team
    {
        private int id;
        private String name;
        private Employee teamLead;
        private List<Project> projects;
        private List<Employee> developmentEngineers;
        private Employee scrumMaster;

        public Team()
        {
            projects = new List<Project>();
            developmentEngineers = new List<Employee>();
        }

        public Team(String Name)
        {
            this.Name = Name;
            this.projects = new List<Project>();
            this.developmentEngineers = new List<Employee>();
        }

        public Team(String name, Employee teamLead, Employee scrumMaster)
        {
            this.name = name;
            this.teamLead = teamLead;
            this.scrumMaster = scrumMaster;
            this.projects = new List<Project>();
            this.developmentEngineers = new List<Employee>();
        }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        [DataMember]
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [DataMember]
        public Employee TeamLead
        {
            get { return this.teamLead; }
            set { this.teamLead = value; }
        }

        [DataMember]
        public List<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        [DataMember]
        public List<Employee> DevelopmentEngineers
        {
            get { return this.developmentEngineers; }
            set { this.developmentEngineers = value; }
        }

        [DataMember]
        public Employee ScrumMaster
        {
            get { return this.scrumMaster; }
            set { this.scrumMaster = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
