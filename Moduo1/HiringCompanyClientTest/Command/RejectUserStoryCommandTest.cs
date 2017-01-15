using Client;
using Client.Command;
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
    public class RejectUserStoryCommandTest
    {
        #region Declarations

        private RejectUserStoryCommand rejectUserStoryCommandunderTest;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.rejectUserStoryCommandunderTest = new RejectUserStoryCommand();
            this.rejectUserStoryCommandunderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            DefineUserStoriesViewModel.Instance = Substitute.For<IDefineUserStoriesViewModel>();
            DefineUserStoriesViewModel.Instance.Project().ReturnsForAnyArgs(new Project());
            DefineUserStoriesViewModel.Instance.UserStory().ReturnsForAnyArgs(new UserStory());

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.ChangeUserStoryState(1, UserStoryState.Approved).ReturnsForAnyArgs(true);
            //ClientProxy.Instance.GetUserStoryFromId(1).ReturnsForAnyArgs(new UserStory());
            ClientProxy.Instance.SendUserStoryToOc(null).ReturnsForAnyArgs(true);


        }

        #endregion setup

        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new AddEmployeeCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { rejectUserStoryCommandunderTest.CanExecute(new Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { rejectUserStoryCommandunderTest.CanExecute(null); });
        }

        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { rejectUserStoryCommandunderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { rejectUserStoryCommandunderTest.Execute(null); });
        }

        #endregion Tests
    }
}
