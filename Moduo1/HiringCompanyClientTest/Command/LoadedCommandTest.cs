using Client;
using Client.Command;
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
    public class LoadedCommandTest
    {
        #region Declarations

        private LoadedCommand loadedCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.loadedCommandUnderTest = new LoadedCommand();
            this.loadedCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            ClientProxy.Instance = Substitute.For<IHiringCompany>();

            ClientProxy.Instance.AddHiringCompany(null).ReturnsForAnyArgs(true);


        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new LoadedCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { loadedCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { loadedCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { loadedCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { loadedCommandUnderTest.Execute(null); });
        }

        [Test]
        public void ClientProxyNullTest()
        {
            
            Assert.DoesNotThrow(() => { loadedCommandUnderTest.Execute(new object()); });
        }
        #endregion Tests
    }
}
