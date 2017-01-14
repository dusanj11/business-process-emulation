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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.Command
{
    [TestFixture]
    public class EditPositionCommandTest
    {
        #region Declarations

        private EditPositionCommand editPositionCommandUnderTest;
        private ObservableCollection<Employee> res = new ObservableCollection<Employee>();

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        public void SetupTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Employee p = new Employee();
                p.Name = i.ToString();
                res.Add(p);
            }

            this.editPositionCommandUnderTest = new EditPositionCommand();
            this.editPositionCommandUnderTest.CanExecuteChanged += (object sender, EventArgs e) => { Console.WriteLine("CanExecuteChanged"); };

            ClientProxy.Instance = Substitute.For<IHiringCompany>();
            ClientProxy.Instance.GetAllEmployees().Returns(new List<Employee>()
                {
                    new Employee(){}
                });
            ClientProxy.Instance.GetAllNotSignedInEmployees().Returns(new List<Employee>()
                {
                    new Employee(){}
                });
            ClientDialogViewModel.Instance = Substitute.For<IClientDialogViewModel>();
            
        }

        #endregion setup


        #region Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new SaveWorkingHoursCommand());
        }

        [Test]
        public void CanExecuteTest()
        {
            Assert.DoesNotThrow(() => { editPositionCommandUnderTest.CanExecute(new System.Object()); });
        }

        [Test]
        public void CanExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { editPositionCommandUnderTest.CanExecute(null); });
        }


        [Test]
        public void ExecuteTest()
        {
            Assert.DoesNotThrow(() => { editPositionCommandUnderTest.Execute(new object()); });
        }

        [Test]
        public void ExecuteNullParametersTest()
        {
            Assert.DoesNotThrow(() => { editPositionCommandUnderTest.Execute(null); });
        }
        #endregion Tests
    }
}
