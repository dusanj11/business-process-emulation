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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            log.Info("Employee saved new project definition.");
            Project project = new Project();
            project.Name = CreateProjectViewModel.Instance.NewProjectDefinition().Name;
            project.Description = CreateProjectViewModel.Instance.NewProjectDefinition().Description;
            project.StartDate = CreateProjectViewModel.Instance.NewProjectDefinition().StartDate;
            project.EndDate = CreateProjectViewModel.Instance.NewProjectDefinition().EndDate;

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            log.Debug("proxy poziv - GetEmployee ");
            Employee productOwner = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);
            log.Info("Successfully returned employee.");

            project.ProductOwner = productOwner;

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            log.Debug("proxy poziv - GetHcIdForUser ");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            log.Info("Successfully returned hiring company id.");

            log.Debug("proxy poziv - GetHiringCompany ");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            log.Info("Successfully returned hiring company.");
            project.HiringCompany = hc;

            log.Debug("proxy poziv - AddProjectDefinition ");
            ClientProxy.Instance.AddProjectDefinition(project);
            log.Info("Successfully added project definition.");
        }
    }
}