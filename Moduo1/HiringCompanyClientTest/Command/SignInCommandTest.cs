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
        private string username = "Naci";
        private PasswordBox password = new PasswordBox();
        
     
        private bool isCalled = false;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            password.Password = "Dule";

            this.signInCommandUnderTest = new SignInCommand();
            this.signInCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            EmployeeDB.Instance.AddEmployee(null).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.AddEmployee(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            
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

        //[Ignore("ExecuteTest")]
        [Test]
        public void ExecuteTest()
        {
            isCalled = false;
            //password.Password = "Dule";
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(new object[] { username, password }); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { signInCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}