using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HiringCompanyData
{
    
    [DataContract]
    public class Project
    {

        private int id;
        private String name;
        private String description;
        private DateTime startDate;
        private DateTime endDate;
        private Team team;
        private float progress;
        private List<UserStory> userStories;
        private ProjectState projectState;
        private OutsourcingCompany company;
        private HiringCompany hiringCompany;
        private Employee productOwner;
        private bool approved;
        private bool ended;

        public Project()
        {
            userStories = new List<UserStory>();
            startDate = DateTime.Now;
            endDate = DateTime.Now;
        }

        public Project(String name, String description, DateTime startDate, DateTime endDate)
        {
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.userStories = new List<UserStory>();
            this.projectState = ProjectState.New;
            this.progress = 0;
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
        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        [DataMember]
        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        [DataMember]
        public OutsourcingCompany Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        [DataMember]
        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        [DataMember]
        public List<UserStory> UserStories
        {
            get { return this.userStories; }
            set { this.userStories = value; }
        }

        [DataMember]
        public Team Team
        {
            get { return this.team; }
            set { this.team = value; }
        }

        [DataMember]
        public ProjectState ProjectState
        {
            get { return this.projectState; }
            set { this.projectState = value; }
        }

        [DataMember]
        public float Progress
        {
            get { return this.progress; }
            set { this.progress = value; }
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
        public Employee ProductOwner
        {
            get
            {
                return productOwner;
            }

            set
            {
                productOwner = value;
            }
        }

        [DataMember]
        public bool Approved
        {
            get
            {
                return approved;
            }

            set
            {
                approved = value;
            }
        }

        [DataMember]
        public bool Ended
        {
            get
            {
                return ended;
            }

            set
            {
                ended = value;
            }
        }

        public override string ToString()
        {
            return  this.id +
                   " " + this.name;
                   
        }
    }
    
}
