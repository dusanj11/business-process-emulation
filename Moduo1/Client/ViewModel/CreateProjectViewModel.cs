using Client.Command;
using Client.Model;
using Client.ViewModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class CreateProjectViewModel : INotifyPropertyChanged, ICreateProjectViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

      
        private NewProjectDefinition newProjectDefinition;

        public SaveNewProjectDefinition SaveNewProjectDefinition { get; set; }


        public static ICreateProjectViewModel _createProjectViewModel;

        public static ICreateProjectViewModel Instance
        {
            get
            {
                if (_createProjectViewModel == null)
                {
                    _createProjectViewModel = new CreateProjectViewModel();
                }

                return _createProjectViewModel;
            }
            set
            {
                if (_createProjectViewModel == null)
                {
                    _createProjectViewModel = value;
                }
            }
        }

        //public static CreateProjectViewModel Instance
        //{
        //    get
        //    {
        //        if (model == null)
        //        {
        //            model = new CreateProjectViewModel();
        //        }

        //        return model;
        //    }
        //}

        public NewProjectDefinition NewProjectDefinition
        {
            get
            {
                return newProjectDefinition;
            }

            set
            {
                newProjectDefinition = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("NewProjectDefinition"));
            }
        }

        public CreateProjectViewModel()
        {
            this.SaveNewProjectDefinition = new SaveNewProjectDefinition();
            this.NewProjectDefinition = new NewProjectDefinition();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        NewProjectDefinition ICreateProjectViewModel.NewProjectDefinition()
        {
            return NewProjectDefinition;
        }
    }
}
