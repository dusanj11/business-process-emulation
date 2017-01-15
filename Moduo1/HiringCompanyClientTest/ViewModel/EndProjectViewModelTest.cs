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
    public class EndProjectViewModelTest
    {

        #region Declarations
        private EndProjectViewModel endProjectViewModelUnderTest;
        private EndProjectCommand endProjectCommandUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetUp()
        {
            endProjectViewModelUnderTest = new EndProjectViewModel();
            endProjectCommandUnderTest = new EndProjectCommand();
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new EndProjectViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {

            Project pr = endProjectViewModelUnderTest.Project;
            
            Assert.DoesNotThrow(() => new EndProjectViewModel());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => endProjectViewModelUnderTest.OnPropertyChanged(null));
        }
        #endregion Tests
    }
}
