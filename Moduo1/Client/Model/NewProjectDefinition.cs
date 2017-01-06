using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class NewProjectDefinition
    {
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private string description;

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

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public NewProjectDefinition()
        {
            this.Description = "";
            this.EndDate = DateTime.Now;
            this.StartDate = DateTime.Now;
            this.Name = "";
        }

        public NewProjectDefinition(string name, DateTime startDate, DateTime endDate, string description)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
    }
}
