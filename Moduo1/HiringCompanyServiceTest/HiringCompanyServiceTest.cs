using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NUnit.Framework;
using NSubstitute;
using HiringCompanyService.Access;
using HiringCompanyData;
using HiringCompanyService;
using Client.ViewModel;

namespace HiringCompanyServiceTest
{
    [TestFixture]
    public class HiringCompanyServiceTest
    {
        #region Declaration
        private HiringCompanyService.HiringCompanyService hirignCompanyServiceUnderTest;
        private bool isCalled = false;
        private Employee employeeTest;
        private string usernameTest = "Dule";
        private string passwordTest = "Dukica";
        #endregion Declaration

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            hirignCompanyServiceUnderTest = new HiringCompanyService.HiringCompanyService();

            employeeTest = new Employee
            {
                Username = "Dule",
                Password = "Dulisa",
                Name = "Dusan",
                Surname = "Jeftic",
                Position = PositionEnum.CEO.ToString(),
                StartTime = "9",
                EndTime = "17",
                Login = false

            };

  

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            EmployeeDB.Instance.AddEmployee(null).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.AddEmployee(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee());

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.GetEmployee(null, null))
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.ChangeEmployeePosition(usernameTest, PositionEnum.CEO).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .When(p => p.ChangeEmployeePosition(usernameTest, PositionEnum.CEO))
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.GetEmployees().Returns(new List<Employee>());

            EmployeeDB.Instance
                .When(p => p.GetEmployees())
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.UpdateEmployee(null).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .When(p => p.UpdateEmployee(employeeTest))
                .Do(p =>
                {
                    isCalled = true;
                });
            
        }

        #endregion setup

        #region test

        [Test]
        public void GetAllEmployeesTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetAllEmployees(); });
        }

        [Test]
        public void AddEmployeeTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddEmployee(employeeTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void AddEmployeeNullParameterTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddEmployee(null); });
        }

        [Test]
        public void GetEmployeeTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetEmployee(usernameTest, passwordTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetEmployeeNullParametersTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetEmployee(null, null); });
        }

        [Test]
        public void ChangeEmployeePositionTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeEmployeePosition(usernameTest, PositionEnum.CEO); });

            Assert.IsTrue(isCalled);
        }

        /// <summary>
        /// null paramtere set only for username
        /// </summary>
        [Test]
        public void ChangeEmployeePositionNullParametersTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeEmployeePosition(null, PositionEnum.CEO); });
        }

        [Test]
        public void UpdateEmployeeTest()
        {
            isCalled = false;
            
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.UpdateEmployee(employeeTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void UpdateEmployeeNullParameterTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.UpdateEmployee(null); });
        }
        
        [Test]
        public void UpdateNotExistingEmployeeTest()
        {
            bool result = hirignCompanyServiceUnderTest.UpdateEmployee(employeeTest);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateEmployeeExistingUserTest()
        {
            employeeTest.Username = "marko";
            employeeTest.Password = "marko";

            bool result = hirignCompanyServiceUnderTest.UpdateEmployee(employeeTest);

            Assert.IsTrue(isCalled);
            Assert.IsTrue(result);
        }
        #endregion test
    }
}
