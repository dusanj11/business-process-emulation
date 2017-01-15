using Client;
using Client.Command;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Windows;
using System.Windows.Controls;


namespace HiringCompanyClientTest.Command
{
    [Apartment(System.Threading.ApartmentState.STA)]
    [TestFixture]
    public class SignInCommandTest
    {
        #region Declarations

        private SignInCommand signInCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
   

            this.signInCommandUnderTest = new SignInCommand();
            this.signInCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new Client.Model.LogInUser()
            {
                Username = "naci",
                Password = "naci"
            });
            ClientDialogViewModel.Instance.ErrorMessage("");
            ClientProxy.Instance.GetEmployee("dule", "dule").ReturnsForAnyArgs(new Employee()
            {
                Username = " dule", Password = "dule", Login = false, Position = "PO", PasswordUpadateDate = new DateTime(2014, 5, 5)
            });
            ClientProxy.Instance.EmployeeLogIn("dule").ReturnsForAnyArgs(true);


        }

        #endregion setup


        #region Tests
        [Test]
        public void ExecuteTestPO()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestHR()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "HR", PasswordUpadateDate = new DateTime(2014, 5, 5) });

            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestCEO()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "CEO", PasswordUpadateDate = new DateTime(2014, 5, 5) });

            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestSM()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "SM", PasswordUpadateDate = new DateTime(2014, 5, 5) });

            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SignInCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.CanExecute(null); });
        }

    
        [Test]
        public void ExecuteTest()
        {         
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}