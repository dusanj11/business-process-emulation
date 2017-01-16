using Client;
using Client.Command;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyContract;
using NSubstitute;
using Client.ViewModelInterfaces;
using Client.ViewModel;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SendRequestCompanyViewCommandTest
    {
        #region Declarations

        private SendRequestCompanyViewCommand sendRequestCompanyViewCommandUnderTest;
        private ObservableCollection<OutsourcingCompany> res = new ObservableCollection<OutsourcingCompany>();
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            for (int i = 0; i < 3; i++)
            {
                OutsourcingCompany oc = new OutsourcingCompany();
                oc.Id = 7;
                res.Add(oc);
            }

            this.sendRequestCompanyViewCommandUnderTest = new SendRequestCompanyViewCommand();
            this.sendRequestCompanyViewCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetOutsourcingCompanies().Returns(new List<OutsourcingCompany>()
            {
                new OutsourcingCompany() { Name = "ns" }
            });

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.OcResources(res);
            ClientDialogViewModel.Instance.ShowSendRequestCompanyView();


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SendRequestCompanyViewCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyViewCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyViewCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { sendRequestCompanyViewCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { sendRequestCompanyViewCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}
