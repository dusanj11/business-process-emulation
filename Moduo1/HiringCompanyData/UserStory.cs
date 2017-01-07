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
    public class UserStory
    {
        private int id;
        private String name;
        private String description;
        private float progress;
        private int weightOfUserStory;
        private UserStoryState userStoryState;
        private List<Task> tasks;
        private Project project;

        public UserStory()
        {
            tasks = new List<Task>();
        }

        public UserStory(String name, String description, Project project)
        {
            this.name = name;
            this.project = project;
            this.description = description;
            this.progress = 0;
            this.userStoryState = UserStoryState.New;
            this.tasks = new List<Task>();
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
        public UserStoryState UserStoryState
        {
            get { return this.userStoryState; }
            set { this.userStoryState = value; }
        }

        [DataMember]
        public List<Task> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }

        [DataMember]
        public Project Project
        {
            get { return this.project; }
            set { this.project = value; }
        }

        [DataMember]
        public int WeightOfUserStory
        {
            get { return this.weightOfUserStory; }
            set { this.weightOfUserStory = value; }
        }

        public override string ToString()
        {
            return "ID: " + this.id +
                   " Name: " + this.name +
                   " Progress: " + this.progress.ToString() +
                   " Description: " + this.description +
                   " Weight: " + this.weightOfUserStory.ToString() +
                   " State: " + this.userStoryState.ToString();
        }
    }
}
