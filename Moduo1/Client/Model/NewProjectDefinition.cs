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
        private string startDate;
        private string endDate;
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

        public string StartDate
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

        public string EndDate
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
            this.EndDate = "";
            this.StartDate = "";
            this.Name = "";
        }

        public NewProjectDefinition(string name, string startDate, string endDate, string description)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
    }
}
