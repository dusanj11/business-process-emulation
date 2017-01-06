using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace HiringCompanyData
{
    [DataContract]
    public class HiringCompany
    {
        private string name;
        private string ceo;
        private int companyIdThr;
        private List<Employee> employees;

        public HiringCompany()
        {
            employees = new List<Employee>();
        }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDHc { get; set; }

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
        public string Ceo
        {
            get
            {
                return ceo;
            }

            set
            {
                ceo = value;
            }
        }

        [DataMember]
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }

            set
            {
                employees = value;
            }
        }

        [DataMember]
        public int CompanyIdThr
        {
            get
            {
                return companyIdThr;
            }

            set
            {
                companyIdThr = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + Name + " Ceo: " + Ceo;
        }
    }
}
