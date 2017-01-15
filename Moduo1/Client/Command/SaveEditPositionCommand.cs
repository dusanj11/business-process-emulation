using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveEditPositionCommand : ICommand

    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            log.Info("Employee saved chaged position");
            Employee emp = EditPositionViewModel.Instance.Employee();
            string position = Parser.Parse(EditPositionViewModel.Instance.Position());

            log.Debug("proxy poziv - ChangeEmployeePosition ");
            ClientProxy.Instance.ChangeEmployeePosition(emp.Username, position);
            log.Info("Successfully changed employees position");
        }
    }
}
