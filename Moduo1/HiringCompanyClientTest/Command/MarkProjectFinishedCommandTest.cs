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
    public class MarkProjectFinishedCommandTest
    {
        #region Declarations

        private MarkProjectFinishedCommand markProjectFinishedCommandunderTest;
        private ObservableCollection<Project> resources = new ObservableCollection<Project>();

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Project p = new Project();
                p.Name = i.ToString();
                resources.Add(p);
            }

            this.markProjectFinishedCommandunderTest = new MarkProjectFinishedCommand();
            this.markProjectFinishedCommandunderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            ClientDialogViewModel.Instance.LogInUser().Returns(new LogInUser("dule", "dule"));

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetHcIdForUser("").ReturnsForAnyArgs(7);
            ClientProxy.Instance.GetHiringCompany(7).ReturnsForAnyArgs(new HiringCompany());
            ClientProxy.Instance.GetProjectsForHc(7).ReturnsForAnyArgs(new List<Project>() { 
                new Project() {},
                new Project() { Progress = 100},
                new Project() {}
            });

            ClientDialogViewModel.Instance.PrResources(null);
            ClientDialogViewModel.Instance.ShowEndProjectView();


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new MarkProjectFinishedCommand());
        }

        [Test]
        public void ConstructorObsColTest()
        {
            Assert.DoesNotThrow(() => new ObservableCollection<Project>());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { markProjectFinishedCommandunderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { markProjectFinishedCommandunderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { markProjectFinishedCommandunderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { markProjectFinishedCommandunderTest.Execute(null); });
        }

        #endregion Tests
    }
}
