using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SaveNewEmployeeCommandTest
    {
        #region Declarations

        private SaveNewEmployeeCommand saveNewEmployeeCommandUnderTest;
        private Employee employeeTest;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            employeeTest = new Employee();
            employeeTest.Name = "Milica";
            employeeTest.Surname = "Kapetina";
            employeeTest.Username = "mica";
            employeeTest.Password = "mica";
            employeeTest.Position = PositionEnum.CEO.ToString();
            employeeTest.StartTime = "10.00";
            employeeTest.EndTime = "17.00";
            employeeTest.Login = false;
            employeeTest.Email = "marko.jelaca@gmail.com";
            employeeTest.PasswordUpadateDate = DateTime.Now;
            

            this.saveNewEmployeeCommandUnderTest = new SaveNewEmployeeCommand();
            this.saveNewEmployeeCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            AddNewEmployeeViewModel.Instance = Substitute.For<IAddNewEmployeeViewModel>();
            AddNewEmployeeViewModel.Instance.NewEmployee().ReturnsForAnyArgs(new NewEmployee());

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.AddEmployee(employeeTest).ReturnsForAnyArgs(true);    
           

        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveNewEmployeeCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveNewEmployeeCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewEmployeeCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveNewEmployeeCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewEmployeeCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
