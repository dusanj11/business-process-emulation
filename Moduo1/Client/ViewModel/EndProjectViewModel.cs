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
    public class EndProjectViewModel : INotifyPropertyChanged, IEndProjectViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Project project;
        private static IEndProjectViewModel model;

        public EndProjectCommand EndProjectCommand { get; set; }

        public static IEndProjectViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new EndProjectViewModel();
                }

                return model;
            }
            set
            {
                if (model == null)
                {
                    model = value;
                }
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
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Company"));
            }
        }

        public EndProjectViewModel()
        {
            this.EndProjectCommand = new EndProjectCommand();
            this.Project = new Project();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        Project IEndProjectViewModel.Project()
        {
            return Project;
        }
    }
}
