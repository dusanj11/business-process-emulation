using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;
using Client;
using HiringCompanyContract;
using HiringCompanyData;
using Client.ViewModel;
using Client.ViewModelInterfaces;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SavePersonalDataCommandTest
    {
        #region Declarations

        private SavePersonalDataCommand savePersonalDataCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.savePersonalDataCommandUnderTest = new SavePersonalDataCommand();
            this.savePersonalDataCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee());
            ClientProxy.Instance.UpdateEmployee(null).ReturnsForAnyArgs(true);

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new Client.Model.LogInUser());

        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SavePersonalDataCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { savePersonalDataCommandUnderTest.CanExecute(new System.Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { savePersonalDataCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { savePersonalDataCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { savePersonalDataCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
