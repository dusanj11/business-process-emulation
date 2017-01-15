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
    public class DefineUserStoriesCommandTest
    {
        #region Declarations

        private DefineUserStoriesCommand defineUserStoriesCommandUnderTest;
        private ObservableCollection<Project> resTest = new ObservableCollection<Project>();
        private List<Project> projListTest = new List<Project>();
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Project p = new Project();
                p.Name = i.ToString();
                resTest.Add(p);
            }

            for (int i = 0; i < 3; i++)
            {
                Project p = new Project();
                p.Name = i.ToString();
                p.HiringCompany = new HiringCompany() { IDHc = 7, CompanyIdThr = 7 };
                projListTest.Add(p);
            }

            this.defineUserStoriesCommandUnderTest = new DefineUserStoriesCommand();
            this.defineUserStoriesCommandUnderTest.Resources = resTest;
            this.defineUserStoriesCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            
            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser(null).Returns(1);
            ClientProxy.Instance.GetPartnershipProjects(7).Returns(new List<Project>() {
                new Project() {
                    Name = "P1",
                    Description = "Desc",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            });

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new LogInUser("dule", "dule"));
            ClientDialogViewModel.Instance.PrResources(defineUserStoriesCommandUnderTest.Resources);
            ClientDialogViewModel.Instance.ShowDefineUserStoriesView();
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new DefineUserStoriesCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { defineUserStoriesCommandUnderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { defineUserStoriesCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { defineUserStoriesCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { defineUserStoriesCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
