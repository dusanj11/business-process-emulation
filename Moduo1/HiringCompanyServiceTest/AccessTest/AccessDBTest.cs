using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit;
using NUnit.Framework;
using HiringCompanyService.Access;
using System.Data.Entity;

namespace HiringCompanyServiceTest.AccessTest
{
    [TestFixture]
    public class AccessDBTest 
    {
        #region Declarations
        public AccessDB AccessDBunderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            AccessDBunderTest = new AccessDB();
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new AccessDB());
        }

        #endregion tests
    }
}
