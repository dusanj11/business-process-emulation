using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using Client.ViewModelInterfaces;
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
    public class AddEmployeeCommandTest
    {
        #region Declarations

        private AddEmployeeCommand addEmployeeUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.addEmployeeUnderTest = new AddEmployeeCommand();
            this.addEmployeeUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            AddNewEmployeeViewModel.Instance = Substitute.For<IAddNewEmployeeViewModel>();

            AddNewEmployeeViewModel.Instance.NewEmployee().Returns(new NewEmployee());

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();

    
        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new AddEmployeeCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {
           
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}