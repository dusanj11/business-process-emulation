using Client.Command;
using Client.ViewModel;
using Client.ViewModelInterfaces;
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
    public class ChangePasswordCommandTest
    {
        #region Declarations
        private ChangePasswordCommand changePasswordUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetUpTest()
        {
            this.changePasswordUnderTest = new ChangePasswordCommand();
            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.ShowChangePasswordView();
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ChangePasswordCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { changePasswordUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { changePasswordUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { changePasswordUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { changePasswordUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
