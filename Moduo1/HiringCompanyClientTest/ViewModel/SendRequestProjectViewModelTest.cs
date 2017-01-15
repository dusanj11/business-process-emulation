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
    public class SendRequestProjectViewModelTest
    {
        #region Declarations
        private SendRequestProjectCommand saveNewProjectCommandUnderTest = new SendRequestProjectCommand();
        private SendRequestProjectViewModel sendRequestProjectViewModelUnderTest;

        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            sendRequestProjectViewModelUnderTest = new SendRequestProjectViewModel();
            sendRequestProjectViewModelUnderTest.PartnerCompany = new OutsourcingCompany() { Name = "kompanijica" };
            sendRequestProjectViewModelUnderTest.Project = new Project() { Name = "projektic" };
            SendRequestProjectViewModel.Instance.ToString();
            Project pr2 = sendRequestProjectViewModelUnderTest.Project;
            OutsourcingCompany oc2 = sendRequestProjectViewModelUnderTest.PartnerCompany;
        }
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SendRequestProjectViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {
            
            Assert.DoesNotThrow(() => new SendRequestProjectCommand());
        }

        [Test]
        public void ChangedCall()
        {
            Project pr = SendRequestProjectViewModel.Instance.Project();
            OutsourcingCompany oc = SendRequestProjectViewModel.Instance.PartnerCompany();
            Assert.DoesNotThrow(() => sendRequestProjectViewModelUnderTest.OnPropertyChanged(null));
        }
        #endregion Tests
    }
}
