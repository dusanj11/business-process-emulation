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
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            Employee emp = EditPositionViewModel.Instance.Employee();
            string position = Parser.Parse(EditPositionViewModel.Instance.Position());

            ClientProxy.Instance.ChangeEmployeePosition(emp.Username, position);
        }
    }
}
