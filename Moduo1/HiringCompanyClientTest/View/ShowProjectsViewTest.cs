using Client;
using Client.View;
using HiringCompanyContract;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HiringCompanyClientTest.View
{
    [TestFixture]
    public class ShowProjectsViewTest
    {

        #region Declarations
        private Client.View.ShowProjectsView projectViewUnderTest;
        private object sender;
        private SelectionChangedEventArgs e;
        private bool isCalled = false;
        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            sender = new object();
            this.projectViewUnderTest = new ShowProjectsView();


            ClientProxy.Instance = Substitute.For<IHiringCompany>();

            ClientProxy.Instance.GetUserStories("").ReturnsForAnyArgs(true);

            ClientProxy.Instance
                .WhenForAnyArgs(p => p.GetUserStories(""))
                .Do(p =>
                {
                    isCalled = true;
                });

            ClientProxy.Instance.GetProjectUserStory("").ReturnsForAnyArgs(new List<HiringCompanyData.UserStory>()
            {
                new HiringCompanyData.UserStory()
                {
                    Name = "Us"
                }
            });
        }

        #endregion setup

        #region tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new ShowProjectsView());
        }

        [Test]
        public void projectsDataGrid_SelectionChangedTest()
        {

            //Assert.DoesNotThrow(() => { projectViewUnderTest.});
        }

        #endregion tests

    }
}
