using Client.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyClientTest.ViewModel
{
    [TestFixture]
    public class WorkingHoursViewModelTest
    {
        #region Declarations
        #endregion Declarations

        #region setup
        #endregion setup

        #region Tests
        [Test]
        public void ConstructorTest()
        {
            WorkingHoursViewModel.Instance.ToString();
            Assert.That(WorkingHoursViewModel.Instance != null, Is.True);
        }
        [Test]
        public void ChangedCall()
        {
            Assert.DoesNotThrow(() => new WorkingHoursViewModel().OnPropertyChanged(null));
        }
        #endregion Tests
    }
}
