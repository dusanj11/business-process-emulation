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
    public class ClientDialogViewModel : INotifyPropertyChanged
    {
        private static ClientDialogViewModel model;

        public static ClientDialogViewModel Instance
        {
            get
            {
                if (model == null)
                    model = new ClientDialogViewModel();

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

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewProjectsCommand ViewProjectsCommand { get; set; }
        public AddEmployeeCommand AddEmployeeCommand { get; set; }
        public ChangePasswordCommand ChangePasswordCommand { get; set; }
        public EditPersonalDataCommand EditPersonalDataCommand { get; set; }
        public SendRequestCompanyCommand SendRequestCompanyCommand { get; set; }
        public ViewWorkersCommand ViewWorkersCommand { get; set; }
        public WorkingHoursCommand WorkingHoursCommand { get; set; }
        public LogOutCommand LogOutCommand { get; set; }
        public SignInCommand SignInCommand { get; set; }
        public DefineUserStoriesCommand DefineUserStoriesCommand { get; set; }
        public CreateProjectCommand CreateProjectCommand { get; set; }
        public ShowCompaniesCommand ShowCompaniesCommand { get; set; }
        public SendRequestProjectCommand SendRequestProjectCommand { get; set; }



        /// <summary>
        /// private constructor
        /// </summary>
        public ClientDialogViewModel()
        {
            this.ViewProjectsCommand = new ViewProjectsCommand();
            this.AddEmployeeCommand = new AddEmployeeCommand();
            this.ChangePasswordCommand = new ChangePasswordCommand();
            this.EditPersonalDataCommand = new EditPersonalDataCommand();
            this.SendRequestCompanyCommand = new SendRequestCompanyCommand();
            this.ViewWorkersCommand = new ViewWorkersCommand();
            this.WorkingHoursCommand = new WorkingHoursCommand();
            this.LogOutCommand = new LogOutCommand();
            this.SignInCommand = new SignInCommand();
            this.DefineUserStoriesCommand = new DefineUserStoriesCommand();
            this.CreateProjectCommand = new CreateProjectCommand();
            this.ShowCompaniesCommand = new ShowCompaniesCommand();
            this.SendRequestProjectCommand = new SendRequestProjectCommand();
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
    }
}
