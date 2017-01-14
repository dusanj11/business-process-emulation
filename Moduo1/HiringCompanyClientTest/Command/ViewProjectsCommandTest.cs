using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Command;
using HiringCompanyService.Access;
using NSubstitute;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using Client;
using HiringCompanyContract;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class ViewProjectsCommandTest
    {
        #region Declarations

        private ViewProjectsCommand viewProjectsCommandUnderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {


            this.viewProjectsCommandUnderTest = new ViewProjectsCommand();
            this.viewProjectsCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetProjects(1).Returns(new List<HiringCompanyData.Project>() {
                new HiringCompanyData.Project() {
                    Name = "P1",
                    Description = "Desc",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            });

            
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ViewProjectsCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { viewProjectsCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { viewProjectsCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { viewProjectsCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { viewProjectsCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
