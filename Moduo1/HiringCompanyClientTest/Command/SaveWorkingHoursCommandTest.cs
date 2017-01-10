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
    [TestFixture]
    public class SaveWorkingHoursCommandTest
    {
        #region Declarations

        private SaveWorkingHoursCommand saveWorkingHoursCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.saveWorkingHoursCommandUnderTest = new SaveWorkingHoursCommand();
            this.saveWorkingHoursCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new Client.Model.LogInUser()
            {
                Username = "naci",
                Password = "naci"
            });


            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee());
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveWorkingHoursCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
