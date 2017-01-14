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
    public class EditPersonalDataCommandTest
    {
        #region Declarations
        private EditPersonalDataCommand editPersonalDataCommandUnderTest;
        string password = "dule";
        string username = "dule";
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.editPersonalDataCommandUnderTest = new EditPersonalDataCommand();
            this.editPersonalDataCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };
            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new LogInUser() { Username = username, Password = password });

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetEmployee("", "").ReturnsForAnyArgs(new Employee());

            EditPersonalDataViewModel.Instance = Substitute.For<IEditPersonalDataViewModel>();
            EditPersonalDataViewModel.Instance.Name("");
            EditPersonalDataViewModel.Instance.Surname("");
            EditPersonalDataViewModel.Instance.Username("");

            ClientDialogViewModel.Instance.ShowEditPersonalDataView();

        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new EditPersonalDataCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { editPersonalDataCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { editPersonalDataCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { editPersonalDataCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { editPersonalDataCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
