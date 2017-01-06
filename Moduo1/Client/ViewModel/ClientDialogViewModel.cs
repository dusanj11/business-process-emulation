using Client.Command;
using Client.Model;
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
    public class ClientDialogViewModel : INotifyPropertyChanged
    {
        private static ClientDialogViewModel model;

        private MainWindow main;

        public MainWindow Main
        {
            get { return main; }
            set { main = value; }
        }

        private ClientDialog cDialog;

        public ClientDialog CDialog
        {
            get { return cDialog; }
            set { cDialog = value; }
        }

        public static ClientDialogViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new ClientDialogViewModel();
                }

                return model;
            }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get 
            { 
                return errorMessage; 
            }
            set 
            { 
                errorMessage = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        private LogInUser logInUser;
       
        public LogInUser LogInUser
        {
            get
            {
                return logInUser;
            }
            set
            {
                logInUser = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("LogInUser"));
            }
        }

        private ObservableCollection<Employee> resources;

        public ObservableCollection<Employee> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Resources"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewProjectsCommand ViewProjectsCommand { get; set; }
        public AddEmployeeCommand AddEmployeeCommand { get; set; }
        public ChangePasswordCommand ChangePasswordCommand { get; set; }
        public EditPersonalDataCommand EditPersonalDataCommand { get; set; }
        public SendRequestCompanyViewCommand SendRequestCompanyViewCommand { get; set; }
        public ViewWorkersCommand ViewWorkersCommand { get; set; }
        public WorkingHoursCommand WorkingHoursCommand { get; set; }
        public LogOutCommand LogOutCommand { get; set; }
        public SignInCommand SignInCommand { get; set; }
        public DefineUserStoriesCommand DefineUserStoriesCommand { get; set; }
        public CreateProjectCommand CreateProjectCommand { get; set; }
        public ShowCompaniesCommand ShowCompaniesCommand { get; set; }
        public SendRequestProjectViewCommand SendRequestProjectViewCommand { get; set; }

        public LoadedCommand LoadedCommand { get; set; }


        /// <summary>
        /// private constructor
        /// </summary>
        public ClientDialogViewModel()
        {
            this.ViewProjectsCommand = new ViewProjectsCommand();
            this.AddEmployeeCommand = new AddEmployeeCommand();
            this.ChangePasswordCommand = new ChangePasswordCommand();
            this.EditPersonalDataCommand = new EditPersonalDataCommand();
            this.SendRequestCompanyViewCommand = new SendRequestCompanyViewCommand();
            this.ViewWorkersCommand = new ViewWorkersCommand();
            this.WorkingHoursCommand = new WorkingHoursCommand();
            this.LogOutCommand = new LogOutCommand();
            this.SignInCommand = new SignInCommand();
            this.DefineUserStoriesCommand = new DefineUserStoriesCommand();
            this.CreateProjectCommand = new CreateProjectCommand();
            this.ShowCompaniesCommand = new ShowCompaniesCommand();
            this.SendRequestProjectViewCommand = new SendRequestProjectViewCommand();
            this.LoadedCommand = new LoadedCommand();
            this.ErrorMessage = "";
            this.LogInUser = new LogInUser();
       
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public void ShowAddEmployeeView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.AddEmployeeView());
        }

        public void ShowChangePasswordView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.ChangePasswordView());
        }

        public void ShowCreateProjectView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.CreateProjectView());
        }

        public void ShowDefineUserStoriesView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.DefineUserStoriesView());
        }

        public void ShowEditPersonalDataView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.EditPersonalDataView());
        }

        public void ShowSendRequestCompanyView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.SendRequestCompanyView());
        }

        public void ShowSendRequestProjectView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.SendRequestProjectView());
        }

        public void ShowShowCompaniesView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.ShowCompaniesView());
        }

        public void ShowShowProjectsView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.ShowProjectsView());
        }

        public void ShowWorkingHoursView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            CDialog.MainWindowDockPanel.Children.Add(new View.WorkingHoursView());
        }

        public void ShowEmployeeView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }


            View.ShowEmployeeView showEmployeeView = new View.ShowEmployeeView();
            showEmployeeView.employeeDataGrid.ItemsSource = Resources;

            CDialog.MainWindowDockPanel.Children.Add(showEmployeeView);
           
        }
    }
}
