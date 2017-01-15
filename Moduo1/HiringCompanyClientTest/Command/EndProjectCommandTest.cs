using Client;
using Client.Command;
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
    public class EndProjectCommandTest
    {
        #region Declarations

        private EndProjectCommand endProjectCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.endProjectCommandUnderTest = new EndProjectCommand();
            this.endProjectCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EndProjectViewModel.Instance = Substitute.For<IEndProjectViewModel>();
            EndProjectViewModel.Instance.Project().ReturnsForAnyArgs(new Project() { });

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.MarkProjectEnded(null).ReturnsForAnyArgs(true);


        }

        #endregion setup
        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new EndProjectCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { endProjectCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { endProjectCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { endProjectCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { endProjectCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
