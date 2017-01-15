using Client.Command;
using Client.Model;
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
    public class ClientDialogViewModel : INotifyPropertyChanged, IClientDialogViewModel
    {
        

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

        public static IClientDialogViewModel _clientDialogViewModel;

        public static IClientDialogViewModel Instance
        {
            get
            {
                if (_clientDialogViewModel == null)
                {
                    _clientDialogViewModel = new ClientDialogViewModel();
                }

                return _clientDialogViewModel;
            }
            set
            {
                if (_clientDialogViewModel == null)
                {
                    _clientDialogViewModel = value;
                }
            }
        }

        //public static ClientDialogViewModel Instance
        //{
        //    get
        //    {
        //        if (model == null)
        //        {
        //            model = new ClientDialogViewModel();
        //        }

        //        return model;
        //    }
        //}
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

        private ObservableCollection<Project> prResources;

        public ObservableCollection<Project> PrResources
        {
            get
            {
                return prResources;
            }
            set
            {
                prResources = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrResources"));
            }
        }

        private ObservableCollection<Employee> empResource = new ObservableCollection<Employee>();

        public ObservableCollection<Employee> EmpResource
        {
            get
            {
                return empResource;
            }

            set
            {
                empResource = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EmpResources"));
            }
        }

        private ObservableCollection<HiringCompanyData.OutsourcingCompany> ocResources = new ObservableCollection<HiringCompanyData.OutsourcingCompany>();

        public ObservableCollection<HiringCompanyData.OutsourcingCompany> OcResources
        {
            get
            {
                return ocResources;
            }

            set
            {
                ocResources = value;
                OnPropertyChanged(new PropertyChangedEventArgs("OcResources"));
            }
        }

        private ObservableCollection<UserStory> usResources = new ObservableCollection<UserStory>();

        public ObservableCollection<UserStory> UsResources
        {
            get
            {
                return usResources;
            }

            set
            {
                usResources = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UsResources"));
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
                if (selectedProject != value)
                {
                    selectedProject = value;
                    List<UserStory> list = ClientProxy.Instance.GetProjectUserStory(SelectedProject.Name);
                    foreach (UserStory l in list)
                    {
                        UsResources.Add(l);
                    }
                    //UsResources = new ObservableCollection<UserStory>(list);
                    OnPropertyChanged(new PropertyChangedEventArgs("SelectedProject"));
                }
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
        public MarkProjectFinishedCommand MarkProjectFinishedCommand { get; set; }

        public LoadedCommand LoadedCommand { get; set; }
        public EditPositionCommand EditPositionCommand { get; set; }

       

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
            this.EditPositionCommand = new EditPositionCommand();
            this.MarkProjectFinishedCommand = new MarkProjectFinishedCommand();
       
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }


        public void ShowEditPositionView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            View.EditPositionView editPositionView = new View.EditPositionView();
            editPositionView.chosEmployeeCompanyTxt.ItemsSource = EmpResource;

            CDialog.MainWindowDockPanel.Children.Add(editPositionView);
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

        public void ShowEndProjectView()
        {
            try
            {
                CDialog.MainWindowDockPanel.Children.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e.Message);
            }

            View.EndProjectView endProjectView = new View.EndProjectView();
            endProjectView.choseProjTxt.ItemsSource = PrResources;

            CDialog.MainWindowDockPanel.Children.Add(endProjectView);
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

            View.DefineUserStoriesView defineUserStoryView = new View.DefineUserStoriesView();
            defineUserStoryView.chosProjectTxt.ItemsSource = PrResources;

            CDialog.MainWindowDockPanel.Children.Add(defineUserStoryView);
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

            View.SendRequestCompanyView sendRequestCompanyView = new View.SendRequestCompanyView();
            sendRequestCompanyView.choseCompanyTxt.ItemsSource = OcResources;

            CDialog.MainWindowDockPanel.Children.Add(sendRequestCompanyView);
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

            View.SendRequestProjectView sendRequestProjectView = new View.SendRequestProjectView();
            sendRequestProjectView.chosePartnCompanyTxt.ItemsSource = OcResources;
            sendRequestProjectView.choseProjTxt.ItemsSource = PrResources;
            CDialog.MainWindowDockPanel.Children.Add(sendRequestProjectView);
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

            View.ShowCompaniesView showCompaniesView = new View.ShowCompaniesView();
            showCompaniesView.companiesDataGrid.ItemsSource = OcResources;

            CDialog.MainWindowDockPanel.Children.Add(showCompaniesView);
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
            View.ShowProjectsView showProjectView = new View.ShowProjectsView();
            showProjectView.projectsDataGrid.ItemsSource = PrResources;
            showProjectView.userStoriesProjectsDataGrid.ItemsSource = UsResources;
            CDialog.MainWindowDockPanel.Children.Add(showProjectView);
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

        MainWindow IClientDialogViewModel.Main()
        {
            return Main;
        }

        ClientDialog IClientDialogViewModel.CDialog()
        {
            return CDialog;
        }

        string IClientDialogViewModel.ErrorMessage()
        {
            return ErrorMessage;
        }

        void IClientDialogViewModel.ErrorMessage(string message)
        {
            ErrorMessage = message;
        }

        LogInUser IClientDialogViewModel.LogInUser()
        {
            return LogInUser;
        }

        void IClientDialogViewModel.LogInUser(LogInUser logInUser)
        {
            LogInUser = logInUser;
        }

        ObservableCollection<Employee> IClientDialogViewModel.Resources()
        {
            return Resources;
        }

        void IClientDialogViewModel.Resources(ObservableCollection<Employee> resources)
        {
            Resources = resources;
        }

        ObservableCollection<Project> IClientDialogViewModel.PrResources()
        {
            return PrResources;
        }

        void IClientDialogViewModel.PrResources(ObservableCollection<Project> prResources)
        {
            PrResources = prResources;
        }

         ObservableCollection<Employee> IClientDialogViewModel.EmpResources()
        {
            return EmpResource;
        }

        void IClientDialogViewModel.EmpResources(ObservableCollection<Employee> empResources)
        {
            EmpResource = empResources;
        }

        void IClientDialogViewModel.Main(MainWindow main)
        {
            Main = main;
        }

        void IClientDialogViewModel.CDialog(ClientDialog clientDialog)
        {
            CDialog = clientDialog;
        }

        ObservableCollection<HiringCompanyData.OutsourcingCompany> IClientDialogViewModel.OcResources()
        {
            return OcResources;
        }

        void IClientDialogViewModel.OcResources(ObservableCollection<HiringCompanyData.OutsourcingCompany> ocResources)
        {
            OcResources = ocResources;
        }
    }
}
