using HiringCompanyData;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HiringCompanyServiceTest
{
    [TestFixture]
    public class HiringCompanyServiceTest
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Declaration

        private HiringCompanyService.HiringCompanyService hirignCompanyServiceUnderTest;
        private bool isCalled = false;
        private Employee employeeTest;
        private string usernameTest = "Dule";
        private string passwordTest = "Dukica";
        private string newPasswordTest = "Dule";

        private HiringCompany hiringCompanyTest;

        private Project projectTest;

        private OutsourcingCompany ocTest;

        private bool AddOcTrue;

        private bool AddOcFalse;

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
                Name = "HC-D",
                Ceo = "Dusan Jeftic",
                CompanyIdThr = 1
            };

            projectTest = new Project()
            {
                Name = "Project1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Description = "Project1 desc"
            };

            ocTest = new OutsourcingCompany()
            {
                Name = "OC1",
                CompanyState = CompanyState.Accepted.ToString()
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

            EmployeeDB.Instance.ChangeEmployeePosition(usernameTest, null).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.ChangeEmployeePosition(usernameTest, null))
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

            EmployeeDB.Instance.GetEmployeeEmail(usernameTest).Returns("jelaca.marko@gmail.com");

            EmployeeDB.Instance
                .When(p => p.GetEmployeeEmail(usernameTest))
                .Do(p =>
                {
                    isCalled = true;
                });

            EmployeeDB.Instance.GetReallyEmployees().Returns(new List<Employee>());

            EmployeeDB.Instance
               .When(p => p.GetReallyEmployees())
               .Do(p =>
               {
                   isCalled = true;
               });

            EmployeeDB.Instance.GetAllNotSignedInEmployees().Returns(new List<Employee>());

            EmployeeDB.Instance
                .When(p => p.GetAllNotSignedInEmployees())
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

            HiringCompanyDB.Instance.GetCompany(1).Returns(hiringCompanyTest);

            HiringCompanyDB.Instance
                .When(p => p.GetCompany(1))
                .Do(p =>
               {
                   isCalled = true;
               });

            #endregion HiringCompanyDB

            #region ProjectDB

            ProjectDB.Instance = Substitute.For<IProjectDB>();

            ProjectDB.Instance.AddProject(null).ReturnsForAnyArgs(true);

            ProjectDB.Instance
                .WhenForAnyArgs(p => p.AddProject(null))
                .Do(p =>
               {
                   isCalled = true;
               });

            ProjectDB.Instance.GetProjects().Returns(new List<Project>());

            ProjectDB.Instance
                .When(p => p.GetProjects())
                .Do(p =>
               {
                   isCalled = true;
               });

            #endregion ProjectDB

            #region OcCompanyDB

            OCompanyDB.Instance = Substitute.For<IOCompanyDB>();

            OCompanyDB.Instance.AddOutsourcingCompany(ocTest).Returns(true);

            OCompanyDB.Instance.AddOutsourcingCompany(null).Returns(false);

            OCompanyDB.Instance
                .WhenForAnyArgs(p => p.AddOutsourcingCompany(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion OcCompanyDB

            #region UserStoryDB

            UserStoryDB.Instance = Substitute.For<IUserStoryDB>();

            UserStoryDB.Instance.GetUserStory(null).ReturnsForAnyArgs(new List<UserStory>());

            UserStoryDB.Instance
                .WhenForAnyArgs(p => p.GetUserStory(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion UserStoryDB
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

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeEmployeePosition(usernameTest, "CEO"); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void ChangeEmployeePositionNullParametersTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeEmployeePosition(null, "CEO"); });
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

        [Test]
        public void GetAllNotSignedInEmployeesTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetAllNotSignedInEmployees(); });

            Assert.IsTrue(isCalled);
        }


        [Test]
        public void AddHiringCompanyTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddHiringCompany(hiringCompanyTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void AddHiringCompanyNullParameterTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddHiringCompany(null); });
        }

        [Test]
        public void GetHiringCompanyTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetHiringCompany(1); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void AddProjectDefinition()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddProjectDefinition(projectTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetProjectsTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetProjects(); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void SendDelayingEmailTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.SendDelayingEmail(usernameTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetReallyAllEmployeesTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetReallyAllEmployees(); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void RegisterOutsourcingCompanyTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.RegisterOutsourcingCompany(ocTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void RegisterOutsourcingCompanyNullParameterTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.RegisterOutsourcingCompany(null); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetUserStoryesTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStoryes(projectTest.Name); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetUserStoryesNullParameterTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStoryes(null); });

            Assert.IsTrue(isCalled);
        }

        #endregion test
    }
}