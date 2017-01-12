using Client.Command;
using Client.ViewModelInterfaces;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class DefineUserStoriesViewModel : INotifyPropertyChanged, IDefineUserStoriesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static DefineUserStoriesViewModel model;
        private Project project;
        private UserStory userStory;
        private string description;



        public AcceptUserStoryCommand AcceptUserStoryCommand { get; set; }
        public RejectUserStoryCommand RejectUserStoryCommand { get; set; }

        public static IDefineUserStoriesViewModel _defineUserStoriesViewModel;

        public static IDefineUserStoriesViewModel Instance
        {
            get
            {
                if (_defineUserStoriesViewModel == null)
                {
                    _defineUserStoriesViewModel = new DefineUserStoriesViewModel();
                }

                return _defineUserStoriesViewModel;
            }
            set
            {
                if (_defineUserStoriesViewModel == null)
                {
                    _defineUserStoriesViewModel = value;
                }
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
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Description"));
            }
        }

        //public static DefineUserStoriesViewModel Instance
        //{
        //    get
        //    {
        //        return model;
        //    }

        //    set
        //    {
        //        model = value;
        //    }
        //}

        public Project Project
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

        public UserStory UserStory
        {
            get
            {
                return userStory;
            }

            set
            {
                userStory = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("UserStory"));
            }
        }

        public DefineUserStoriesViewModel()
        {
            this.AcceptUserStoryCommand = new AcceptUserStoryCommand();
            this.RejectUserStoryCommand = new RejectUserStoryCommand();
            this.Project = new Project();
            this.UserStory = new UserStory();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

      


        string IDefineUserStoriesViewModel.Description()
        {
            return Description;
        }

        void IDefineUserStoriesViewModel.Description(string tekst)
        {
            Description = tekst;
        }

        Project IDefineUserStoriesViewModel.Project()
        {
            return Project;
        }

        UserStory IDefineUserStoriesViewModel.UserStory()
        {
            return UserStory;
        }
    }
}
