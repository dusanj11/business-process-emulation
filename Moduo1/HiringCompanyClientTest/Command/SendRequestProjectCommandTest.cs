using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyData;
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
    public class SendRequestProjectCommandTest
    {
        #region Declarations

        private SendRequestProjectCommand sendRequestProjectCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.sendRequestProjectCommandUnderTest = new SendRequestProjectCommand();
            this.sendRequestProjectCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            SendRequestProjectViewModel.Instance = Substitute.For<ISendRequestProjectViewModel>();
            SendRequestProjectViewModel.Instance.Project().ReturnsForAnyArgs(new Project());

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new LogInUser("dule", "dule"));

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser("").ReturnsForAnyArgs(7);
            ClientProxy.Instance.GetHiringCompany(7).ReturnsForAnyArgs(new HiringCompany());
            ClientProxy.Instance.SendProjectRequest(7, 7, new Project()).ReturnsForAnyArgs(true);

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
            Assert.DoesNotThrow(() => { sendRequestProjectCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestProjectCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { sendRequestProjectCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestProjectCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
