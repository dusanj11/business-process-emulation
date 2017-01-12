using Client.Command;
using Client.ViewModelInterfaces;
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

        private string project;
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

        public string Project
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
            this.Project = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        string IEndProjectViewModel.Project()
        {
            return Project;
        }
    }
}
