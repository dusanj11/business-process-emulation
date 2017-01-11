using Client;
using Client.Command;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyService.Access;
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
    public class SaveEditPositionCommandTest
    {
        #region Declarations

        private SaveEditPositionCommand saveEditPositionCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.saveEditPositionCommandUnderTest = new SaveEditPositionCommand();
            this.saveEditPositionCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            EditPositionViewModel.Instance = Substitute.For<IEditPositionViewModel>();

            ClientProxy.Instance = Substitute.For<IHiringCompany>();


        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveEditPositionCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveEditPositionCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {

            Assert.DoesNotThrow(() => { saveEditPositionCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveEditPositionCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
           
            Assert.DoesNotThrow(() => { saveEditPositionCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
