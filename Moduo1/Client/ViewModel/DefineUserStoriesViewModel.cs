using Client.Command;
using Client.ViewModelInterfaces;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.ViewModel
{
    public class DefineUserStoriesViewModel : INotifyPropertyChanged, IDefineUserStoriesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

       
        private Project project;
        private UserStory userStory;
        private List<UserStory> userStories;

        private string description;

        public AcceptUserStoryCommand AcceptUserStoryCommand { get; set; }
        public RejectUserStoryCommand RejectUserStoryCommand { get; set; }

        private static IDefineUserStoriesViewModel _defineUserStoriesViewModel;

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

        public List<UserStory> UserStories
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

        public Project Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
                if (Project.Name != null)
                {
                    try
                    {
                        ClientProxy.Instance.GetUserStories(Project.Name);
                    }
                    catch (Exception e)
                    {

                    }
                }
               
               
                try
                {
                    
                    UserStories = ClientProxy.Instance.GetProjectPendingUserStory(Project.Name);
                }
                catch (Exception e)
                {
                    UserStories = null;
                }

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
                try
                {
                    Description = UserStory.Description;

                }
                catch (Exception e)
                {
                    Description = "";
                }

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

        List<UserStory> IDefineUserStoriesViewModel.UserStories()
        {
            return UserStories;
        }

        void IDefineUserStoriesViewModel.UserStories(List<UserStory> stories)
        {
            UserStories = stories;
        }
    }
}