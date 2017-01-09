using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Windows;
using System.Windows.Controls;


namespace HiringCompanyClientTest.Command
{
    [Apartment(System.Threading.ApartmentState.STA)]
    [TestFixture]
    public class SignInCommandTest
    {
        #region Declarations

        private SignInCommand signInCommandUnderTest;
        private string username = "naci";
        private PasswordBox password = new PasswordBox();
        
     
        private bool isCalled = false;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            password.Password = "naci";

            this.signInCommandUnderTest = new SignInCommand();
            this.signInCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
           
            
            
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SignInCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.CanExecute(null); });
        }

    
        [Test]
        public void ExecuteTest()
        {         
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}