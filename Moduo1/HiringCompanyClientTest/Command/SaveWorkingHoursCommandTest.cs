using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SaveWorkingHoursCommandTest
    {
        #region Declarations

        private SaveWorkingHoursCommand saveWorkingHoursCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.saveWorkingHoursCommandUnderTest = new SaveWorkingHoursCommand();
            this.saveWorkingHoursCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();



        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveWorkingHoursCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveWorkingHoursCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
