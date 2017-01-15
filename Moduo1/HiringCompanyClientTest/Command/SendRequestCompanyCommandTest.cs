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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SendRequestCompanyCommandTest
    {
        #region Declarations

        private SendRequestCompanyCommand sendRequestCompanyCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.sendRequestCompanyCommandUnderTest = new SendRequestCompanyCommand();
            this.sendRequestCompanyCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            SendRequestCompanyViewModel.Instance = Substitute.For<ISendRequestCompanyViewModel>();
            SendRequestCompanyViewModel.Instance.Company().ReturnsForAnyArgs(new OutsourcingCompany());

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().ReturnsForAnyArgs(new LogInUser("dule", "dule"));

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser("").ReturnsForAnyArgs(7);
            ClientProxy.Instance.GetHiringCompany(7).ReturnsForAnyArgs(new HiringCompany());
            ClientProxy.Instance.SendPartnershipRequest(1, new HiringCompany()).ReturnsForAnyArgs(true);


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SendRequestCompanyCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { sendRequestCompanyCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
