using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Windows.Input;
using System.Threading;

namespace Client.Command
{
    public class SaveNewProjectDefinition : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Project project = new Project();
            project.Name = CreateProjectViewModel.Instance.NewProjectDefinition.Name;
            project.Description = CreateProjectViewModel.Instance.NewProjectDefinition.Description;
            project.StartDate = CreateProjectViewModel.Instance.NewProjectDefinition.StartDate;
            project.EndDate = CreateProjectViewModel.Instance.NewProjectDefinition.EndDate;
            

            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {

                HiringCompany hc = proxy.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);
                project.HiringCompany = hc;
                proxy.AddProjectDefinition(project);
            }
        }
    }
}