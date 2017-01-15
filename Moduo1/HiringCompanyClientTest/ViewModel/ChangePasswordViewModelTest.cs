using Client.Command;
using Client.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class ChangePasswordViewModelTest
    {
        #region Declarations
        private SaveNewPasswordCommand saveNewPasswordCommandUnderTest = new SaveNewPasswordCommand();
        private ChangePasswordViewModel changePasswordCommandUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            changePasswordCommandUnderTest = new ChangePasswordViewModel();
            changePasswordCommandUnderTest.NewPassword = "";
            changePasswordCommandUnderTest.SaveNewPasswordCommand = saveNewPasswordCommandUnderTest;
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            string newpassword = changePasswordCommandUnderTest.NewPassword;
            string oldpassword = changePasswordCommandUnderTest.OldPassword;
            Assert.DoesNotThrow(() => new ChangePasswordViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {
            string newpassword = ChangePasswordViewModel.Instance.NewPassword();
            string oldpassword = ChangePasswordViewModel.Instance.OldPassword();
            ChangePasswordViewModel.Instance.ToString();
            Assert.DoesNotThrow(() => new SaveNewPasswordCommand());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => changePasswordCommandUnderTest.OnPropertyChanged(null));
        }
        #endregion Tests
    }
}
