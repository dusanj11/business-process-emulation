using Client.Model;
using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Threading;
using System.Windows.Input;

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
            project.Name = CreateProjectViewModel.Instance.NewProjectDefinition().Name;
            project.Description = CreateProjectViewModel.Instance.NewProjectDefinition().Description;
            project.StartDate = CreateProjectViewModel.Instance.NewProjectDefinition().StartDate;
            project.EndDate = CreateProjectViewModel.Instance.NewProjectDefinition().EndDate;

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            Employee productOwner = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);

            project.ProductOwner = productOwner;

            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(Thread.CurrentThread.ManagedThreadId);
            project.HiringCompany = hc;
            ClientProxy.Instance.AddProjectDefinition(project);
        }
    }
}