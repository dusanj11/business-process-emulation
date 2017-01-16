using Client.Command;
using Client.ViewModelInterfaces;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class ViewProjectsViewModel : INotifyPropertyChanged, IViewProjectsViewModel
    {

       

        public event PropertyChangedEventHandler PropertyChanged;

        private static IViewProjectsViewModel model;

        public static IViewProjectsViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new ViewProjectsViewModel();
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

        private ObservableCollection<UserStory> usResources;

        public ObservableCollection<UserStory> UsResources
        {
            get
            {
                return usResources;
            }

            set
            {
                usResources = value;
            }

        }
        private Project selectedProject;

        public Project SelectedProject
        {
            get
            {
                return selectedProject;
            }

            set
            {
                selectedProject = value;
                Console.WriteLine("SelectedProject");
                List<UserStory> list = ClientProxy.Instance.GetProjectUserStory(SelectedProject.Name);
                foreach (UserStory l in list)
                {
                    UsResources.Add(l);
                }

                OnPropertyChanged(new PropertyChangedEventArgs("SelectedProject"));
            }
        }

      
        

        public ViewProjectsViewModel()
        {
            SelectedProject = new Project();
            UsResources = new ObservableCollection<UserStory>();
         
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
