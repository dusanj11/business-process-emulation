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

namespace HiringCompanyServiceTest
{
    [TestFixture]
    public class HiringCompanyServiceTest
    {
        #region Declaration
        private HiringCompanyService.HiringCompanyService HirignCompanyServiceUnderTest;
        private bool IsCalled = false;
        private Employee EmployeeTest;
        private string UsernameTest = "Dule";
        private string PasswordTest = "Dukica";
        #endregion Declaration

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            HirignCompanyServiceUnderTest = new HiringCompanyService.HiringCompanyService();

            EmployeeTest = new Employee
            {
                Username = "Dule",
                Password = "Dulisa",
                Name = "Dusan",
                Surname = "Jeftic",
                Position = Employee.PositionEnum.CEO.ToString(),
                StartTime = "9",
                EndTime = "17",
                Login = false
               // HiringCompanyId = 


            };



            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            EmployeeDB.Instance.AddEmployee(null).ReturnsForAnyArgs(true);

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.AddEmployee(null))
                .Do(p =>
                {
                    IsCalled = true;
                });

            EmployeeDB.Instance.GetEmployee(null, null).ReturnsForAnyArgs(new Employee());

            EmployeeDB.Instance
                .WhenForAnyArgs(p => p.GetEmployee(null, null))
                .Do(p =>
                {
                    IsCalled = true;
                });

            //EmployeeDB.Instance.ChangeEmployeePosition(null, ).ReturnsForAnyArgs(true);

            //EmployeeDB.Instance
            //    .When(p => p.ChangeEmployeePosition())
            //    .Do(p =>
            //    {
            //        isCalled = true;
            //    });

            EmployeeDB.Instance.GetEmployees().Returns(new List<Employee>());

            EmployeeDB.Instance
                .When(p => p.GetEmployees())
                .Do(p =>
                {
                    IsCalled = true;
                });
            
        }

        #endregion setup

        #region test

        [Test]
        public void GetAllEmployeesTest()
        {
            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.GetAllEmployees(); });
        }

        [Test]
        public void AddEmployeeTest()
        {
            IsCalled = false;

            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.AddEmployee(EmployeeTest); });

            Assert.IsTrue(IsCalled);
        }

        [Test]
        public void AddEmployeeNullParameterTest()
        {
            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.AddEmployee(null); });
        }

        [Test]
        public void GetEmployeeTest()
        {
            IsCalled = false;

            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.GetEmployee(UsernameTest, PasswordTest); });

            Assert.IsTrue(IsCalled);
        }

        [Test]
        public void GetEmployeeNullParametersTest()
        {
            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.GetEmployee(null, null); });
        }

        [Test]
        public void ChangeEmployeePositionTest()
        {
            IsCalled = false;

            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.ChangeEmployeePostition(UsernameTest, Employee.PositionEnum.HR); });

            Assert.IsTrue(IsCalled);
        }

        /// <summary>
        /// null paramtere set only for username
        /// </summary>
        [Test]
        public void ChangeEmployeePositionNullParametersTest()
        {
            Assert.DoesNotThrow(() => { HirignCompanyServiceUnderTest.ChangeEmployeePostition(null, Employee.PositionEnum.CEO); });
        }

   

        #endregion test
    }
}
