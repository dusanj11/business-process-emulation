﻿using Client.Command;
using Client.ViewModelInterfaces;
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
        private string project;
        private string userStories;
        private string description;



        public DefineUserStoriesCommand DefineUserStoriesCommand { get; set; }
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
            this.RejectUserStoryCommand = new RejectUserStoryCommand();
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

        string IDefineUserStoriesViewModel.Project()
        {
            return Project;
        }

        string IDefineUserStoriesViewModel.UserStories()
        {
            return UserStories;
        }


        string IDefineUserStoriesViewModel.Description()
        {
            return Description;
        }

        void IDefineUserStoriesViewModel.Description(string tekst)
        {
            Description = tekst;
        }
    }
}
