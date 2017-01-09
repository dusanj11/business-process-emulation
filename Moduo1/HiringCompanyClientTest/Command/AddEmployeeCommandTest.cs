using Client.Command;
using Client.ViewModel;
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
    [Apartment(System.Threading.ApartmentState.STA)]
    [TestFixture]
    public class AddEmployeeCommandTest
    {
        #region Declarations

        private AddEmployeeCommand addEmployeeUnderTest;


        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {

            this.addEmployeeUnderTest = new AddEmployeeCommand();
            this.addEmployeeUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            //ClientDialogViewModel.Instance.CDialog = Substitute.For<Client.ClientDialog>();
           
            
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new AddEmployeeCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.CanExecute(null); });
        }

        [Ignore("UI")]    
        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.Execute(new object()); });
        }

        [Ignore("UI")]
        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { addEmployeeUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
