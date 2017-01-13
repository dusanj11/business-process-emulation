using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;
using Client;
using HiringCompanyContract;
using HiringCompanyData;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class ViewWorkersCommandTest
    {
        #region Declarations

        private ViewWorkersCommand viewWorkersCommandUnderTest;

        public object CLient { get; private set; }

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.viewWorkersCommandUnderTest = new ViewWorkersCommand();
            this.viewWorkersCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetAllEmployees().Returns(new List<Employee>()
            {
                new Employee()
                {
                    
                }
            });


        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ViewWorkersCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { viewWorkersCommandUnderTest.CanExecute(new System.Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { viewWorkersCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { viewWorkersCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { viewWorkersCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
