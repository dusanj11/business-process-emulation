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
using Client.Model;

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

            ChangePasswordViewModel.Instance = Substitute.For<IChangePasswordViewModel>();
            ChangePasswordViewModel.Instance.OldPassword().ReturnsForAnyArgs("dule");
            ChangePasswordViewModel.Instance.NewPassword().ReturnsForAnyArgs("dule");

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>(); ChangePasswordViewModel.Instance.NewPassword().ReturnsForAnyArgs("");
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new LogInUser());

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.ChangePassword(null, null, null).ReturnsForAnyArgs(true);
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee() { Position = "PO" });
            ClientProxy.Instance.UpdateEmployee(null).ReturnsForAnyArgs(true);
  
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
            Assert.DoesNotThrow(() => { saveNewPasswordCommandUnderTest.CanExecute(new System.Object()); });
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
