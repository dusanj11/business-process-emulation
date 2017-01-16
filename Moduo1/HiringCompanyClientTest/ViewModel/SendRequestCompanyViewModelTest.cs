using Client.Command;
using Client.ViewModel;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class SendRequestCompanyViewModelTest
    {

        #region Declarations
        private SendRequestCompanyViewModel sendRequestCompanyViewModelUnderTest;
        private SendRequestCompanyCommand sendRequestCompanyCommandUnderTest;
        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetUp()
        {
            sendRequestCompanyViewModelUnderTest = new SendRequestCompanyViewModel();
            sendRequestCompanyCommandUnderTest = new SendRequestCompanyCommand();
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SendRequestCompanyViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {

            SendRequestCompanyViewModel.Instance.ToString();
            Assert.DoesNotThrow(() => new SendRequestCompanyCommand());
        }

        [Test]
        public void CompanyTest()
        {
            OutsourcingCompany oc = sendRequestCompanyViewModelUnderTest.Company;
            sendRequestCompanyViewModelUnderTest.Company = new OutsourcingCompany("lol");
            Assert.That(oc == null, Is.False);
        }
        [Test]
        public void CompanyTest2()
        {
            
            //sendRequestCompanyViewModelUnderTest.Company = new OutsourcingCompany("lol");
            Assert.That(SendRequestCompanyViewModel.Instance.Company() != null, Is.False);
        }
        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => sendRequestCompanyViewModelUnderTest.OnPropertyChanged(null));
        }
        #endregion Tests

    }
}
