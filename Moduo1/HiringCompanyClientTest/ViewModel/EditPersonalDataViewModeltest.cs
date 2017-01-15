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
    public class EditPersonalDataViewModeltest
    {
        #region Declarations
        private EditPersonalDataViewModel editPersonalDataViewModelUnderTest;
        private EditPersonalDataCommand editPositionCommandUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetUp()
        {
            editPersonalDataViewModelUnderTest = new EditPersonalDataViewModel();
            editPositionCommandUnderTest = new EditPersonalDataCommand();
            string username = editPersonalDataViewModelUnderTest.Username;
            string name = editPersonalDataViewModelUnderTest.Name;
            string surname = editPersonalDataViewModelUnderTest.Surname;
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new EditPersonalDataCommand());
        }

        [Test]
        public void ConstructorTest2()
        {
            Assert.DoesNotThrow(() => new EditPersonalDataViewModel());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => editPersonalDataViewModelUnderTest.OnPropertyChanged(null));
        }

        [Test]
        public void Call1()
        {
            Assert.DoesNotThrow(() => EditPersonalDataViewModel.Instance.Name());
        }
        [Test]
        public void Call2()
        {
            Assert.DoesNotThrow(() => EditPersonalDataViewModel.Instance.Surname());
        }
        [Test]
        public void Call3()
        {
            Assert.DoesNotThrow(() => EditPersonalDataViewModel.Instance.Username());
        }
        #endregion Tests
    }
}
