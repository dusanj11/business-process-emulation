using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class ClientDialogViewModelTest
    {
        #region Declarations
        private ViewProjectsCommand viewProjectsCommand;
        private AddEmployeeCommand addEmployeeCommand;
        private ChangePasswordCommand changePasswordCommand;
        private EditPersonalDataCommand editPersonalDataCommand;
        private SendRequestCompanyViewCommand sendRequestCompanyViewCommand;
        private ViewWorkersCommand viewWorkersCommand;
        private WorkingHoursCommand workingHoursCommand;
        private LogOutCommand logOutCommand;
        private SignInCommand signInCommand;
        private DefineUserStoriesCommand defineUserStoriesCommand;
        private CreateProjectCommand createProjectCommand;
        private ShowCompaniesCommand showCompaniesCommand;
        private SendRequestProjectViewCommand sendRequestProjectViewCommand;
        private MarkProjectFinishedCommand markProjectFinishedCommand;
        private LoadedCommand loadedCommand;
        private EditPositionCommand editPositionCommand;
        private ClientDialogViewModel clientDialogViewModelUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void OneSetUp()
        {
            viewProjectsCommand = new ViewProjectsCommand();
            addEmployeeCommand = new AddEmployeeCommand();
            changePasswordCommand = new ChangePasswordCommand();
            editPersonalDataCommand = new EditPersonalDataCommand();
            sendRequestCompanyViewCommand = new SendRequestCompanyViewCommand();
            viewWorkersCommand = new ViewWorkersCommand();
            workingHoursCommand = new WorkingHoursCommand();
            logOutCommand = new LogOutCommand();
            signInCommand = new SignInCommand();
            defineUserStoriesCommand = new DefineUserStoriesCommand();
            createProjectCommand = new CreateProjectCommand();
            showCompaniesCommand = new ShowCompaniesCommand();
            sendRequestProjectViewCommand = new SendRequestProjectViewCommand();
            markProjectFinishedCommand = new MarkProjectFinishedCommand();
            loadedCommand = new LoadedCommand();
            editPositionCommand = new EditPositionCommand();
            clientDialogViewModelUnderTest = new ClientDialogViewModel();

            clientDialogViewModelUnderTest.AddEmployeeCommand = addEmployeeCommand;
            clientDialogViewModelUnderTest.ChangePasswordCommand = changePasswordCommand;
            clientDialogViewModelUnderTest.CreateProjectCommand = createProjectCommand;
            clientDialogViewModelUnderTest.DefineUserStoriesCommand = defineUserStoriesCommand;
            clientDialogViewModelUnderTest.EditPersonalDataCommand = editPersonalDataCommand;
            clientDialogViewModelUnderTest.EditPositionCommand = editPositionCommand;
            clientDialogViewModelUnderTest.ErrorMessage = "";
            clientDialogViewModelUnderTest.LoadedCommand = loadedCommand;
            clientDialogViewModelUnderTest.LogInUser = new LogInUser();
            clientDialogViewModelUnderTest.LogOutCommand = logOutCommand;
            clientDialogViewModelUnderTest.MarkProjectFinishedCommand = markProjectFinishedCommand;
            clientDialogViewModelUnderTest.SendRequestCompanyViewCommand = sendRequestCompanyViewCommand;
            clientDialogViewModelUnderTest.SendRequestProjectViewCommand = sendRequestProjectViewCommand;
            clientDialogViewModelUnderTest.ShowCompaniesCommand = showCompaniesCommand;
            clientDialogViewModelUnderTest.SignInCommand = signInCommand;
            clientDialogViewModelUnderTest.ViewProjectsCommand = viewProjectsCommand;
            clientDialogViewModelUnderTest.ViewWorkersCommand = viewWorkersCommand;
            clientDialogViewModelUnderTest.Resources = new ObservableCollection<Employee>();
            clientDialogViewModelUnderTest.PrResources = new ObservableCollection<Project>();
            clientDialogViewModelUnderTest.EmpResource = new ObservableCollection<Employee>();
            clientDialogViewModelUnderTest.OcResources = new ObservableCollection<OutsourcingCompany>();
            clientDialogViewModelUnderTest.UsResources = new ObservableCollection<UserStory>();


            LogInUser nov = clientDialogViewModelUnderTest.LogInUser;
            string str = clientDialogViewModelUnderTest.ErrorMessage;
            ObservableCollection<Employee> res1 = clientDialogViewModelUnderTest.Resources;
            ObservableCollection<Project> res2 = clientDialogViewModelUnderTest.PrResources;
            ObservableCollection<Employee> res3 = clientDialogViewModelUnderTest.EmpResource;
            ObservableCollection<OutsourcingCompany> res4 = clientDialogViewModelUnderTest.OcResources;
            ObservableCollection<UserStory> res5 = clientDialogViewModelUnderTest.UsResources;

        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ClientDialogViewModel());
        }
        [Test]
        public void ConstructorTest1()
        {
            Assert.DoesNotThrow(() => new ViewProjectsCommand());
        }
        [Test]
        public void ConstructorTest2()
        {
            Assert.DoesNotThrow(() => new AddEmployeeCommand());
        }
        [Test]
        public void ConstructorTest3()
        {
            Assert.DoesNotThrow(() => new ChangePasswordCommand());
        }
        [Test]
        public void ConstructorTest4()
        {
            Assert.DoesNotThrow(() => new EditPersonalDataCommand());
        }
        [Test]
        public void ConstructorTest5()
        {
            Assert.DoesNotThrow(() => new SendRequestCompanyViewCommand());
        }
        [Test]
        public void ConstructorTest6()
        {
            Assert.DoesNotThrow(() => new ViewWorkersCommand());
        }
        [Test]
        public void ConstructorTest7()
        {
            Assert.DoesNotThrow(() => new WorkingHoursCommand());
        }
        [Test]
        public void ConstructorTest8()
        {
            Assert.DoesNotThrow(() => new LogOutCommand());
        }
        [Test]
        public void ConstructorTest9()
        {
            Assert.DoesNotThrow(() => new SignInCommand());
        }
        [Test]
        public void ConstructorTest10()
        {
            Assert.DoesNotThrow(() => new DefineUserStoriesCommand());
        }
        [Test]
        public void ConstructorTest11()
        {
            Assert.DoesNotThrow(() => new CreateProjectCommand());
        }
        [Test]
        public void ConstructorTest12()
        {
            Assert.DoesNotThrow(() => new ShowCompaniesCommand());
        }
        [Test]
        public void ConstructorTest13()
        {
            Assert.DoesNotThrow(() => new SendRequestProjectViewCommand());
        }
        [Test]
        public void ConstructorTest14()
        {
            Assert.DoesNotThrow(() => new MarkProjectFinishedCommand());
        }
        [Test]
        public void ConstructorTest15()
        {
            Assert.DoesNotThrow(() => new LoadedCommand());
        }
        [Test]
        public void ConstructorTest16()
        {
            Assert.DoesNotThrow(() => new EditPositionCommand());
        }
        [Test]
        public void CallTest0()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowAddEmployeeView());
        }
        [Test]
        public void CallTest1()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowChangePasswordView());
        }
        [Test]
        public void CallTest2()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowDefineUserStoriesView());
        }
        [Test]
        public void CallTest3()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowEditPersonalDataView());
        }
        [Test]
        public void CallTest4()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowEditPositionView());
        }
        [Test]
        public void CallTest5()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowEmployeeView());
        }
        [Test]
        public void CallTest6()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowEndProjectView());
        }
        [Test]
        public void CallTest7()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowSendRequestCompanyView());
        }
        [Test]
        public void CallTest8()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowSendRequestProjectView());
        }
        [Test]
        public void CallTest9()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowShowCompaniesView());
        }
        [Test]
        public void CallTest10()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowShowProjectsView());
        }
        [Test]
        public void CallTest11()
        {
            Assert.DoesNotThrow(() => ClientDialogViewModel.Instance.ShowWorkingHoursView());
        }
        

        #endregion Tests
    }
}
