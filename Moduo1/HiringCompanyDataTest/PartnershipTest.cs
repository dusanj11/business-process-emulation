using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyDataTest
{
    [TestFixture]
    public class PartnershipTest
    {

        #region Declaration
        private Partnership prUnderTest; 
        private HiringCompany hiringCompany;
 		private OutsourcingCompany outsourcingCompany;

        #endregion Declaration

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.prUnderTest = new Partnership();
            hiringCompany = new HiringCompany();
            outsourcingCompany = new OutsourcingCompany();
        }

        #endregion setup


        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(()  => new Partnership());
        }

        [Test]
        public void HiringCompanyTest()
        {
            prUnderTest.HiringCompany = hiringCompany;

            Assert.AreEqual(hiringCompany, prUnderTest.HiringCompany);
        }

        [Test]
        public void OutsourcingCompanyTest()
        {
            prUnderTest.OutsourcingCompany = outsourcingCompany;

            Assert.AreEqual(outsourcingCompany, prUnderTest.OutsourcingCompany);
        }

        [Test]
        public void IdTest()
        {
            int id = 1;
            prUnderTest.Id = id;

            Assert.AreEqual(id, prUnderTest.Id);
        }


        #endregion tests
    }
}
