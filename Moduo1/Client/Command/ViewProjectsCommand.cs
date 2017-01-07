using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class ViewProjectsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public ObservableCollection<Project> resources = new ObservableCollection<Project>();

        public void Execute(object parameter)
        {
            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {
                

                if (resources.Count != 0)
                {
                    resources.Clear();
                }

                List<Project> projects = proxy.GetProjects();

                foreach (Project p in projects)
                {
                    resources.Add(p);
                }
            }


            ClientDialogViewModel.Instance.PrResources = resources;
            ClientDialogViewModel.Instance.ShowShowProjectsView();
          
        }
    }
}
