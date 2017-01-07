using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class DefineUserStoriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static DefineUserStoriesViewModel model;
        private string project;
        private string userStories;

        public DefineUserStoriesCommand DefineUserStoriesCommand { get; set; }

        public static DefineUserStoriesViewModel Instance
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Project"));
            }
        }

        public string UserStories
        {
            get
            {
                return userStories;
            }

            set
            {
                userStories = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("UserStories"));
            }
        }

        public DefineUserStoriesViewModel()
        {
            this.DefineUserStoriesCommand = new DefineUserStoriesCommand();
            this.Project = "";
            this.UserStories = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
