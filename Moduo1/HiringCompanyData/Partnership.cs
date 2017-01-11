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
    public class Partnership
    {
        private HiringCompany hiringCompany;
        private OutsourcingCompany outsourcingCompany;

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public HiringCompany HiringCompany
        {
            get
            {
                return hiringCompany;
            }

            set
            {
                hiringCompany = value;
            }
        }

        [DataMember]
        public OutsourcingCompany OutsourcingCompany
        {
            get
            {
                return outsourcingCompany;
            }

            set
            {
                outsourcingCompany = value;
            }
        }
    }
}
