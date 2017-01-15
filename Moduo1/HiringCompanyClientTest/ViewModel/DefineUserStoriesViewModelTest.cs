using Client.Command;
using Client.ViewModel;
using HiringCompanyData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class DefineUserStoriesViewModelTest
    {
        #region Declarations
        private DefineUserStoriesViewModel defineUserStoriesViewModel;
        private AcceptUserStoryCommand acceptUserStoryCommand;
        private RejectUserStoryCommand rejectedUserStoryCommand;
        #endregion Declarations

        #region Setup
        [OneTimeSetUp]
        public void SetUp()
        {
            defineUserStoriesViewModel = new DefineUserStoriesViewModel();
            acceptUserStoryCommand = new AcceptUserStoryCommand();
            rejectedUserStoryCommand = new RejectUserStoryCommand();
            string descr = defineUserStoriesViewModel.Description;
            List<UserStory> uss = defineUserStoriesViewModel.UserStories;
            Project pr = defineUserStoriesViewModel.Project;
            UserStory us = defineUserStoriesViewModel.UserStory;
        }
        #endregion Setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new DefineUserStoriesViewModel());
        }

        [Test]
        public void ConstructorTest2()
        {
            Assert.DoesNotThrow(() => new AcceptUserStoryCommand());
        }

        [Test]
        public void ConstructorTest3()
        {
            Assert.DoesNotThrow(() => new RejectUserStoryCommand());
        }


        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => defineUserStoriesViewModel.OnPropertyChanged(null));
        }

        [Test]
        public void Call1()
        {
            Assert.DoesNotThrow(() => DefineUserStoriesViewModel.Instance.UserStory());
        }
        [Test]
        public void Call2()
        {
            Assert.DoesNotThrow(() => DefineUserStoriesViewModel.Instance.UserStories());
        }
        [Test]
        public void Call3()
        {
            Assert.DoesNotThrow(() => DefineUserStoriesViewModel.Instance.Project());
        }
        #endregion Tests
    }
}
