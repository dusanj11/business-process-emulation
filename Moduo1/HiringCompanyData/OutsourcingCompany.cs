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
    public class OutsourcingCompany
    {
        private int id;
        private String name;
        private List<Project> projects;
        private CompanyState companyState;

        public OutsourcingCompany()
        {
            projects = new List<Project>();
            companyState = CompanyState.Requested;
        }

        public OutsourcingCompany(String name)
        {
            this.name = name;
            this.projects = new List<Project>();
            companyState = CompanyState.Requested;

        }

        public OutsourcingCompany(String name, List<Project> projects)
        {
            this.name = name;
            this.projects = projects;
            companyState = CompanyState.Requested;

        }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [DataMember]
        public List<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        [DataMember]
        public CompanyState CompanyState
        {
            get { return this.companyState; }
            set { this.companyState = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id +
                   " Name: " + this.name;
        }
    }
}
