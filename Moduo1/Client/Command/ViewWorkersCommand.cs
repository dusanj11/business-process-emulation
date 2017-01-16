using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Client.Command
{
    public class ViewWorkersCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Collection for mapping items to DataGrid
        /// </summary>
        private ObservableCollection<Employee> resources = new ObservableCollection<Employee>();

        private List<Employee> employees = new List<Employee>();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee started viewing all employees.");
            if (resources.Count != 0)
            {
                resources.Clear();
            }

            Log.Debug("proxy poziv - GetAllEmployees");
            employees = ClientProxy.Instance.GetAllEmployees();
            Log.Info("Successfully returned logged users.");

            foreach (Employee em in employees)
            {
                resources.Add(em);
            }

            ClientDialogViewModel.Instance.Resources(resources);
            ClientDialogViewModel.Instance.ShowEmployeeView();
        }
    }
}