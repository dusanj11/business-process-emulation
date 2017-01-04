using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NUnit.Framework;
using NSubstitute;
using HiringCompanyService.Access;
using HiringCompanyContract.Data;
using HiringCompanyService;

namespace HiringCompanyServiceTest
{
    [TestFixture]
    public class HiringCompanyServiceTest
    {
        #region Declaration
        public HiringCompanyService.HiringCompanyService hirignCompanyServiceUnderTest;
        public bool isCalled = false;
        public Employee employeeTest;
        public string UsernameTest = "Dule";
        public string PasswordTest = "Dukica";
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
                Position = Employee.PositionEnum.CEO.ToString(),
                StartTime = "9",
                EndTime = "17",
                Login = false,
                HiringCompanyId = "HC1"


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

            //EmployeeDB.Instance.ChangeEmployeePosition(null, ).ReturnsForAnyArgs(true);

            //EmployeeDB.Instance
            //    .WhenForAnyArgs(p => p.ChangeEmployeePosition(null, null))
            //    .Do(p =>
            //    {
            //        isCalled = true;
            //    });

            EmployeeDB.Instance.GetEmployees().Returns(new List<Employee>());

            EmployeeDB.Instance
                .When(p => p.GetEmployees())
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

            Assert.IsTrue(isCalled);
        }


        [Test]
        public void AddEmployeeTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.AddEmployee(employeeTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void GetEmployeeTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.GetEmployee(UsernameTest, PasswordTest); });

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void ChangeEmployeePositionTest()
        {
            Assert.DoesNotThrow(() => { hirignCompanyServiceUnderTest.ChangeEmployeePostition(UsernameTest, Employee.PositionEnum.HR); });

            Assert.IsTrue(isCalled);
        }


        [Test]
        public void GetDuleTest()
        {
            Employee employee = hirignCompanyServiceUnderTest.GetEmployee("Dule", "Dulisa");

            Assert.AreEqual(employeeTest, employee);
        }

        #endregion test
    }
}
