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
    public class SendRequestProjectViewCommandTest
    {
        #region Declarations

        private SendRequestProjectViewCommand sendRequestProjectViewCommandUnderTest;
        private ObservableCollection<OutsourcingCompany> res = new ObservableCollection<OutsourcingCompany>();
        private ObservableCollection<Project> res2 = new ObservableCollection<Project>();

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.sendRequestProjectViewCommandUnderTest = new SendRequestProjectViewCommand();
            this.sendRequestProjectViewCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new LogInUser());

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser("").ReturnsForAnyArgs(7);
            ClientProxy.Instance.GetPartnershipOc(7).ReturnsForAnyArgs(new List<OutsourcingCompany>()
            {
                new OutsourcingCompany() {Name = "lol"}
            });
            ClientProxy.Instance.GetProjects(7).ReturnsForAnyArgs(new List<Project>()
            {
                new Project() { Name = "lol" }
            });

            ClientDialogViewModel.Instance.PrResources(res2);
            ClientDialogViewModel.Instance.OcResources(res);
            ClientDialogViewModel.Instance.ShowSendRequestProjectView();


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SendRequestProjectViewCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { sendRequestProjectViewCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestProjectViewCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { sendRequestProjectViewCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestProjectViewCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
