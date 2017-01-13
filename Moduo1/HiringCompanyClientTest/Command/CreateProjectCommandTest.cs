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
    public class CreateProjectCommandTest
    {
        #region Declarations

        private CreateProjectCommand createProjectUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTests()
        {
            this.createProjectUnderTest = new CreateProjectCommand();
            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.ShowCreateProjectView();
        
        }

        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new CreateProjectCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { createProjectUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { createProjectUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { createProjectUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { createProjectUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
