using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyData;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class ShowCompaniesCommandTest
    {
        #region Declarations

        private ShowCompaniesCommand showCompaniesCommandUnderTest;
        private ObservableCollection<OutsourcingCompany> res = new ObservableCollection<OutsourcingCompany>();
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {

            this.showCompaniesCommandUnderTest = new ShowCompaniesCommand();
            this.showCompaniesCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new LogInUser());

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser("").ReturnsForAnyArgs(7);
            ClientProxy.Instance.GetPartnershipOc(7).ReturnsForAnyArgs(new List<OutsourcingCompany>()
            {
                new OutsourcingCompany() {Name = "lol" }
            });

            ClientDialogViewModel.Instance.OcResources(res);
            ClientDialogViewModel.Instance.ShowShowCompaniesView();


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ShowCompaniesCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { showCompaniesCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { showCompaniesCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { showCompaniesCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { showCompaniesCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
