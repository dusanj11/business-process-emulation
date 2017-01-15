using Client.Command;
using Client.Model;
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
    public class CreateProjectViewModelTest
    {
        #region Declarations
        private SaveNewProjectDefinition saveNewProjectCommandUnderTest = new SaveNewProjectDefinition();
        private CreateProjectViewModel createProjectViewModelUndertest;
        NewProjectDefinition npd = new NewProjectDefinition();
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            createProjectViewModelUndertest = new CreateProjectViewModel();
            createProjectViewModelUndertest.NewProjectDefinition = new NewProjectDefinition() {Name="definicijica"};
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            npd = CreateProjectViewModel.Instance.NewProjectDefinition();
            Assert.DoesNotThrow(() => new CreateProjectViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {
            CreateProjectViewModel.Instance.ToString();
            Assert.DoesNotThrow(() => new SaveNewProjectDefinition());
        }

        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => createProjectViewModelUndertest.OnPropertyChanged(null));
        }
        #endregion Tests
    }
}
