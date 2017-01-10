using Client.Model;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IClientDialogViewModel
    {
        MainWindow Main();

        void Main(MainWindow main);

        ClientDialog CDialog();

        void CDialog(ClientDialog clientDialog);
        string ErrorMessage();

        void ErrorMessage(string message);

        LogInUser LogInUser();

        void LogInUser(LogInUser logInUser);

        ObservableCollection<Employee> Resources();

        void Resources(ObservableCollection<Employee> resources);

        ObservableCollection<Project> PrResources();

        void PrResources(ObservableCollection<Project> prResources);

        ObservableCollection<Employee> EmpResources();

        void EmpResources(ObservableCollection<Employee> empResources);

        void ShowEditPositionView();

        void ShowAddEmployeeView();

        void ShowChangePasswordView();

        void ShowCreateProjectView();

        void ShowDefineUserStoriesView();

        void ShowEditPersonalDataView();

        void ShowSendRequestCompanyView();

        void ShowSendRequestProjectView();

        void ShowShowCompaniesView();

        void ShowShowProjectsView();

        void ShowWorkingHoursView();

        void ShowEmployeeView();


    }
}
