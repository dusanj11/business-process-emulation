using Client;
using Client.Command;
using Client.ViewModel;
using Client.ViewModelInterfaces;
using HiringCompanyContract;
using HiringCompanyData;
using HiringCompanyService.Access;
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
    public class AcceptUserStoryCommandTest
    {
        #region Declarations

        private AcceptUserStoryCommand acceptUserStoryUnderTest;

        #endregion Declarations

        #region setup
        [OneTimeSetUp]
        public void SetupTest()
        {
            this.acceptUserStoryUnderTest = new AcceptUserStoryCommand();
            this.acceptUserStoryUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            EmployeeDB.Instance = Substitute.For<IEmployeeDB>();
            DefineUserStoriesViewModel.Instance = Substitute.For<IDefineUserStoriesViewModel>();

            DefineUserStoriesViewModel.Instance.Project().Returns(new Project());
            DefineUserStoriesViewModel.Instance.UserStory().Returns(new UserStory() { Id=1 });

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.ChangeUserStoryState(1, UserStoryState.Approved).Returns(true);
        }
        #endregion setup

        #region Tests
        [Test]
        public void EmptyObject()
        {
            Assert.DoesNotThrow(() => { acceptUserStoryUnderTest.CanExecute(new object()); });
        }

        [Test]
        public void NUllSent()
        {
            Assert.DoesNotThrow(() => { acceptUserStoryUnderTest.CanExecute(null); });
        }

        [Test]
        public void  ConstructorTest()
        {
            Assert.DoesNotThrow(() => new AcceptUserStoryCommand());
        }
        [Test]
        public void ExecuteTest()
        {

            Assert.DoesNotThrow(() => { acceptUserStoryUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { acceptUserStoryUnderTest.Execute(null); });
        }
        #endregion Tests

    }
}
