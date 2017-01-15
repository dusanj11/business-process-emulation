using Client.Command;
using Client.Model;
using Client.ViewModel;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Model
{
    [TestFixture]
    public class AddNewEmployeeViewModelTest
    {
        #region Declarations
        private SaveNewEmployeeCommand saveNewEmployeeUnderTest = new SaveNewEmployeeCommand();
        private AddNewEmployeeViewModel addNewEmployeeViewModelUnderTest = new AddNewEmployeeViewModel();
        private NewEmployee ne = new NewEmployee();
        private PropertyChangedEventArgs pce = new PropertyChangedEventArgs("lol");
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            ne = new NewEmployee() { Name= "Dulo"};
            addNewEmployeeViewModelUnderTest.NewEmployee = ne;
            NewEmployee em = addNewEmployeeViewModelUnderTest.NewEmployee;
            NewEmployee pm = em;
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new NewEmployee());
        }

        [Test]
        public void ConstructorTest2()
        {
            AddNewEmployeeViewModel.Instance.ToString();
            NewEmployee pm = AddNewEmployeeViewModel.Instance.NewEmployee();
            Assert.DoesNotThrow(() => new AddNewEmployeeViewModel());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => addNewEmployeeViewModelUnderTest.OnPropertyChanged(null));
        }
        public void ChangedCall2()
        {
            Assert.DoesNotThrow(() => addNewEmployeeViewModelUnderTest.OnPropertyChanged(pce));
        }

        #endregion Tests


    }
}
