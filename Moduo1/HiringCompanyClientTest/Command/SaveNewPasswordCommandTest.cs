using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using Client;
using HiringCompanyContract;
using HiringCompanyData;

namespace HiringCompanyClientTest.Command
{
    [Apartment(System.Threading.ApartmentState.STA)]
    [TestFixture]
    public class SaveNewPasswordCommandTest
    {
        #region Declarations

        private SaveNewPasswordCommand saveNewPasswordCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.saveNewPasswordCommandUnderTest = new SaveNewPasswordCommand();
            this.saveNewPasswordCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ChangePasswordViewModel.Instance = Substitute.For<IChangePasswordViewModel>();

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position="PO"});
            ClientProxy.Instance.ChangePassword(null, null, null).ReturnsForAnyArgs(true);

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new Client.Model.LogInUser("mici", "mici"));
            //ClientDialogViewModel.Instance.CDialog().ReturnsForAnyArgs(new ClientDialog() {
                  
            //});

            ChangePasswordViewModel.Instance = Substitute.For<IChangePasswordViewModel>();
            ChangePasswordViewModel.Instance.OldPassword().Returns("mici");
            ChangePasswordViewModel.Instance.NewPassword().Returns("milica");


        
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveNewPasswordCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTestPO()
        {
            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestHR()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "HR" });

            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestCEO()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "CEO" });

            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteTestSM()
        {
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "SM" });

            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
