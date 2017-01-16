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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Info("Employee saved new project definition.");
            Project project = new Project();
            project.Name = CreateProjectViewModel.Instance.NewProjectDefinition().Name;
            project.Description = CreateProjectViewModel.Instance.NewProjectDefinition().Description;
            project.StartDate = CreateProjectViewModel.Instance.NewProjectDefinition().StartDate;
            project.EndDate = CreateProjectViewModel.Instance.NewProjectDefinition().EndDate;

            LogInUser logInUser = ClientDialogViewModel.Instance.LogInUser();

            Log.Debug("proxy poziv - GetEmployee ");
            Employee productOwner = ClientProxy.Instance.GetEmployee(logInUser.Username, logInUser.Password);
            Log.Info("Successfully returned employee.");

            project.ProductOwner = productOwner;

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            Log.Debug("proxy poziv - GetHcIdForUser ");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned hiring company id.");

            Log.Debug("proxy poziv - GetHiringCompany ");
            HiringCompany hc = ClientProxy.Instance.GetHiringCompany(hiringCompanyId);
            Log.Info("Successfully returned hiring company.");
            project.HiringCompany = hc;

            Log.Debug("proxy poziv - AddProjectDefinition ");
            ClientProxy.Instance.AddProjectDefinition(project);
            Log.Info("Successfully added project definition.");
        }
    }
}