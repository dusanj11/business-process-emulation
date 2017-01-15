using Client.Command;
using Client.ViewModel;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class EditPositionViewModelTest
    {
        #region Declarations
        private EditPositionViewModel editPositionViewModelUnderTest;
        private EditPositionCommand editPositionCommandUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetUp()
        {
            editPositionViewModelUnderTest = new EditPositionViewModel();
            editPositionCommandUnderTest = new EditPositionCommand();
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new EditPositionCommand());
        }

        [Test]
        public void ConstructorTest2()
        {

            Employee em = editPositionViewModelUnderTest.Employee;
            string pos = editPositionViewModelUnderTest.Position;
            Assert.DoesNotThrow(() => new EditPositionViewModel());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => editPositionViewModelUnderTest.OnPropertyChanged(null));
        }

        [Test]
        public void Call1()
        {
            Assert.DoesNotThrow(() => EditPositionViewModel.Instance.Employee());
        }
        [Test]
        public void Call2()
        {
            Assert.DoesNotThrow(() => EditPositionViewModel.Instance.Position());
        }
        #endregion Tests
    }
}
