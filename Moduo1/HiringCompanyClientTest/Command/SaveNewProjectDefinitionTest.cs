using Client;
using Client.Command;
using Client.Model;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyService.Access;
using NSubstitute;
using NUnit.Framework;
using System;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class SaveNewProjectDefinitionTest
    {
        #region Declarations

        private SaveNewProjectDefinition saveNewProjectDefinitionCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.saveNewProjectDefinitionCommandUnderTest = new SaveNewProjectDefinition();
            this.saveNewProjectDefinitionCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            CreateProjectViewModel.Instance = Substitute.For<ICreateProjectViewModel>();
            CreateProjectViewModel.Instance.NewProjectDefinition().ReturnsForAnyArgs(new NewProjectDefinition()
            {
                Name = "Project1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Description = "Project1 Description"
            });

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHiringCompany(1).ReturnsForAnyArgs(new HiringCompanyData.HiringCompany()
            {
                Name = "HC1",
                Ceo = "MJ",
                CompanyIdThr = 1
            });

        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveNewProjectDefinition());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveNewProjectDefinitionCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewProjectDefinitionCommandUnderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { saveNewProjectDefinitionCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { saveNewProjectDefinitionCommandUnderTest.Execute(null); });
        }

        #endregion Tests
    }
}