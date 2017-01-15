using HiringCompanyData;
using HiringCompanyService;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WcfCommon;

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

        private WcfCommon.Data.OutsourcingCompany ocTest_common;
        private WcfCommon.Data.HiringCompany hcTest_common;

        private UserStory us;

        private OutsourcingCompany ocTestH;

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
                IDHc = 1,
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

            ocTest_common = new WcfCommon.Data.OutsourcingCompany()
            {
                Name = "OC1",
            };

            ocTestH = new OutsourcingCompany()
            {
                Name = "OC1",
                IdFromOutSourcingDB = 1
            };

            hcTest_common = new WcfCommon.Data.HiringCompany()
            {
                Name = "HC1",
                IdFromHiringCompanyDB = 1,
                Ceo = "Dusan Jeftic"
            };

            us = new UserStory()
            {
                Name = "US1",
                Id = 1,
                Progress = 80,
                UserStoryState = UserStoryState.Approved,
                WeightOfUserStory = 3,
                Description = "Opis",
                IdFromOcDB = 1
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

            EmployeeDB.Instance.GetHcIdForUser(employeeTest.Username).Returns(1);

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.GetHcIdForUser(null))
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

            ProjectDB.Instance.MarkProjectEnded(projectTest).Returns(true);

            ProjectDB.Instance.SetOcToProject(projectTest.Name, ocTestH.Id).ReturnsForAnyArgs(true);

            ProjectDB.Instance
                .WhenForAnyArgs(p => p.SetOcToProject(null, ocTestH.Id))
                .Do(p =>
                {
                    isCalled = true;
                });

            ProjectDB.Instance.GetProjectUserStory(projectTest.Name).ReturnsForAnyArgs(new List<UserStory>());

            ProjectDB.Instance
                .WhenForAnyArgs(p => p.GetProjectUserStory(projectTest.Name))
                .Do(p =>
                {
                    isCalled = true;
                });

            ProjectDB.Instance.GetProjectPendingUserStory(projectTest.Name).ReturnsForAnyArgs(new List<UserStory>());

            ProjectDB.Instance
                .WhenForAnyArgs(p => p.GetProjectPendingUserStory(projectTest.Name))
                .Do(p =>
                {
                    isCalled = true;
                });

            ProjectDB.Instance.GetProjects(hiringCompanyTest.IDHc).ReturnsForAnyArgs(new List<Project>());

            ProjectDB.Instance
                .WhenForAnyArgs(p => p.GetProjects(hiringCompanyTest.IDHc))
                .Do(p => {
                    isCalled = true;
                });


            #endregion ProjectDB

            #region OcCompanyDB

            OCompanyDB.Instance = Substitute.For<IOCompanyDB>();

            OCompanyDB.Instance.AddOutsourcingCompany(ocTestH).ReturnsForAnyArgs(true);

            OCompanyDB.Instance.AddOutsourcingCompany(null).Returns(false);

            OCompanyDB.Instance
                .WhenForAnyArgs(p => p.AddOutsourcingCompany(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            OCompanyDB.Instance.GetOutsourcingCompany(ocTest_common.Name).Returns(ocTestH);
            OCompanyDB.Instance
                .WhenForAnyArgs(p => p.GetOutsourcingCompany(null))
                .Do(p =>
                {
                    isCalled = true;
                });


            OCompanyDB.Instance.GetOutsourcingCompanies().Returns(new List<OutsourcingCompany>());

            OCompanyDB.Instance
                .When(p => p.GetOutsourcingCompanies())
                .Do(p => {
                    isCalled = true;
                });

            #endregion OcCompanyDB

            #region PartnershipDB

            PartnershipDB.Instance = Substitute.For<IPartnershipDB>();
            PartnershipDB.Instance.AddPartnership(hiringCompanyTest, ocTestH).Returns(true);

            PartnershipDB.Instance
                .WhenForAnyArgs(p => p.AddPartnership(null, null))
                .Do(p =>
                {
                    isCalled = true;
                });

            PartnershipDB.Instance.GetPartnerOc(hiringCompanyTest.IDHc).Returns(new List<OutsourcingCompany>()
            {
                ocTestH
            });

            PartnershipDB.Instance
                .WhenForAnyArgs(p => p.GetPartnerOc(hiringCompanyTest.IDHc))
                .Do(p =>
                {
                    isCalled = true;
                });

            PartnershipDB.Instance.GetPartnershipProjects(hiringCompanyTest.IDHc).Returns(new List<Project>());

            PartnershipDB.Instance
                .WhenForAnyArgs(p => p.GetPartnershipProjects(hiringCompanyTest.IDHc))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion PartnershipDB

            #region UserStoryDB

            UserStoryDB.Instance = Substitute.For<IUserStoryDB>();

            UserStoryDB.Instance.GetUserStory(null).ReturnsForAnyArgs(new List<UserStory>());

            UserStoryDB.Instance.GetUserStory(projectTest.Name).Returns(new List<UserStory>()
            {
                us
            });

            UserStoryDB.Instance
                .WhenForAnyArgs(p => p.GetUserStory(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            UserStoryDB.Instance.AddUserStory(us).ReturnsForAnyArgs(true);

            UserStoryDB.Instance
                .WhenForAnyArgs(p => p.AddUserStory(null))
                .Do(p =>
                {
                    isCalled = true;
                });

            UserStoryDB.Instance.ChangeUserStoryState(projectTest.Id, UserStoryState.Approved).ReturnsForAnyArgs(true);

            UserStoryDB.Instance
                .WhenForAnyArgs(p => p.ChangeUserStoryState(projectTest.Id, UserStoryState.Approved))
                .Do(p =>
                {
                    isCalled = true;
                });

            #endregion UserStoryDB

            #region ServiceProxy
/*
            ServiceProxy.Instance = Substitute.For<IOcContract>();

            ServiceProxy.Instance.SendOcRequest(1, null).ReturnsForAnyArgs(true);
            ServiceProxy.Instance.SendProject(hiringCompanyTest.IDHc, ocTestH.Id, null).ReturnsForAnyArgs(true);
            ServiceProxy.Instance.SendUserStory(null).ReturnsForAnyArgs(true);
            ServiceProxy.Instance.GetUserStoryes(projectTest.Name).Returns(new List<WcfCommon.Data.UserStory>()
            {
                new WcfCommon.Data.UserStory()
                {
                    Name = "us1",
                    Description = "Opis",
                    Progress = 70,
                    Id = 1,
                    UserStoryState = WcfCommon.Enums.UserStoryState.Proposed,
                    WeightOfUserStory = 5
                }
            });
            ServiceProxy.Instance.GetProjects(hiringCompanyTest.IDHc).Returns(new List<WcfCommon.Data.Project>()
            {
                new WcfCommon.Data.Project() {
                    Name = "p1",
                    Approved = true,
                    Description = "Opis",
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    Ended = false,
                    Progress = 60
            
                }
            });
*/
            #endregion ServiceProxy
        }

        #endregion setup

        #region test

        #region EmployeeTest

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

        #endregion EmployeeTest

        #region HiringCompanyTest

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

        #endregion HiringCompanyTest

        #region ProjectTest

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

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetProjects(1); });

            Assert.IsTrue(isCalled);
        }

        #endregion ProjectTest

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

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.RegisterOutsourcingCompany(ocTest_common); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void RegisterOutsourcingCompanyNullParameterTest()
        {
            isCalled = false;
            bool ret = true;

            Assert.DoesNotThrow(() => { ret = hirignCompanyServiceUnderTest.RegisterOutsourcingCompany(null); });

            Assert.IsFalse(ret);
        }

        //[Test]
        //public void GetUserStoryesTest()
        //{
        //    isCalled = false;

        //    Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStoryes(projectTest.Name); });

        //    Assert.IsTrue(isCalled);
        //}

        //[Test]
        //public void GetUserStoryesNullParameterTest()
        //{
        //    isCalled = false;

        //    Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStoryes(null); });

        //    Assert.IsTrue(isCalled);
        //}

        [Test]
        public void AcceptPartnershipTest()
        {
            isCalled = true;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AcceptPartnership(hcTest_common, ocTest_common); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetUserStoryesOcTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStoryes(projectTest.Name); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void AddPartnershipToDB()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddPartnershipToDB(hiringCompanyTest, ocTestH); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetPartnershipOc()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetPartnershipOc(hiringCompanyTest.IDHc); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void MarkProjectEndedTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.MarkProjectEnded(projectTest); });
        }

        [Test]
        public void AddOutsourcingCompanyTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddOutsourcingCompany(ocTestH); });
        }

        #region ServiceProxyTest

        [Test]
        public void SendPartnershipRequest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.SendPartnershipRequest(ocTestH.IdFromOutSourcingDB, hiringCompanyTest); });
        }

        [Test]
        public void SendProjectRequestTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.SendProjectRequest(hiringCompanyTest.IDHc, ocTestH.IdFromOutSourcingDB, projectTest); });
        }

        [Test]
        public void SendUserStoryToOcTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.SendUserStoryToOc(us); });
        }

        [Test]
        public void GetUserStoriesTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetUserStories(projectTest.Name); });
        }

        [Test]
        public void GetOutsourcingCompanyProjectsTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetOutsourcingCompanyProjects(hiringCompanyTest.IDHc); });
        }

        #endregion ServiceProxyTest

        [Test]
        public void GetHcIdForUserTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetHcIdForUser(employeeTest.Username); });
        }

        [Test]
        public void RejectProjectTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.RejectProject(projectTest.Name); });
        }

        [Test]
        public void AcceptProjectTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AcceptProject(projectTest.Name, ocTestH.Id); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void AddUserStoryTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddUserStory(us); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetPartnershipProjectsTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetPartnershipProjects(hiringCompanyTest.IDHc); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void ChangeUserStoryStateTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeUserStoryState(projectTest.Id, UserStoryState.Approved); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetProjectUserStoryTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetProjectUserStory(projectTest.Name); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetProjectPendingUserStoryTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetProjectPendingUserStory(projectTest.Name); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetOutsourcingCompaniesTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetOutsourcingCompanies(); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetProjectsForHcTest()
        {
            isCalled = false;

            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetProjectsForHc(hiringCompanyTest.IDHc); });

            Assert.IsTrue(isCalled);
        }

        #endregion test
    }
}