using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

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
        private string newPasswordTest = "Dule";

        private HiringCompany hiringCompanyTest;

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

            hiringCompanyTest = new HiringCompany
            {
                Name = "HC1",
                Ceo = "Marko Jelaca",
                CompanyIdThr = 1
            };

            #region EmployeeDB

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

            EmployeeDB.Instance.ChangeEmployeePassword(usernameTest, passwordTest, newPasswordTest).Returns(true);

            EmployeeDB.Instance
                .When(p => p.ChangeEmployeePassword(usernameTest, passwordTest, newPasswordTest))
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.EmployeeLogIn(usernameTest).Returns(true);

            EmployeeDB.Instance
                .When(p => p.EmployeeLogIn(usernameTest))
                .Do(p =>
               {
                   isCalled = true;
               });

            EmployeeDB.Instance.EmployeeLogOut(usernameTest).Returns(true);

            EmployeeDB.Instance
                .When(p => p.EmployeeLogOut(usernameTest))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion EmployeeDB

            #region HiringCompanyDB

            HiringCompanyDB.Instance = Substitute.For<IHiringCompanyDB>();

            HiringCompanyDB.Instance.AddCompany(null).ReturnsForAnyArgs(true);

            HiringCompanyDB.Instance
                .When(p => p.AddCompany(hiringCompanyTest))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion HiringCompanyDB
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

        [Test]
        public void ChangePasswordTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangePassword(usernameTest, passwordTest, newPasswordTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void ChangePasswordNullParametersTest()
        {
            bool result = hirignCompanyServiceUnderTest.ChangePassword(null, null, null);

            Assert.IsFalse(result);
        }

        [Test]
        public void EmployeeLogInTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.EmployeeLogIn(usernameTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void EmployeeLogInNullParameterTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.EmployeeLogIn(null); });
        }

        [Test]
        public void EmployeeLogOutTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.EmployeeLogOut(usernameTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void EmployeeLogOutNullParameterTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.EmployeeLogOut(null); });
        }

        #endregion test
    }
}