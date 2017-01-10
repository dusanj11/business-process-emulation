using Client.Command;
using Client.ViewModel;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModelInterfaces;
using Client.Model;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class LogOutCommandTest
    {
        #region Declarations

        private LogOutCommand logOutCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.logOutCommandUnderTest = new LogOutCommand();
            this.logOutCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();

            ClientDialogViewModel.Instance.LogInUser().Returns(new LogInUser("mica", "mica"));
         


        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new LogOutCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { logOutCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { logOutCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { logOutCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { logOutCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
