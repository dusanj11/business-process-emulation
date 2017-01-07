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
    public class Task
    {
        private int id;
        private String name;
        private float progress;
        private String description;
        private TaskState taskState;
        private Employee developmentEngineer;
        private UserStory userStory;

        public Task()
        {
        }

        public Task(String name, String description, UserStory userStory, Employee developmentEngineer)
        {
            this.name = name;
            this.description = description;
            this.userStory = userStory;
            this.developmentEngineer = developmentEngineer;
            this.progress = 0;
            this.taskState = TaskState.New;
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
        public float Progress
        {
            get { return this.progress; }
            set { this.progress = value; }
        }

        [DataMember]
        public TaskState TaskState
        {
            get { return this.taskState; }
            set { this.taskState = value; }
        }

        [DataMember]
        public Employee DevelopmentEngineer
        {
            get { return this.developmentEngineer; }
            set { this.developmentEngineer = value; }
        }

        [DataMember]
        public UserStory UserStory
        {
            get { return this.userStory; }
            set { this.userStory = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id +
                   " Name: " + this.name +
                   " Description: " + this.description +
                   " Progress: " + this.progress.ToString() +
                   " State: " + this.taskState.ToString();
        }
    }
}
