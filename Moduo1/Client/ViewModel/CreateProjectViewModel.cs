using Client.Command;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class CreateProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static CreateProjectViewModel model;
        private NewProjectDefinition newProjectDefinition;

        public SaveNewProjectDefinition SaveNewProjectDefinition { get; set; }

        public static CreateProjectViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new CreateProjectViewModel();
                }

                return model;
            }
        }

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

    }
}
