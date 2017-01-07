﻿using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows.Input;

namespace Client.Command
{
    public class ViewWorkersCommand : ICommand
    {
    

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
            using (ClientProxy proxy = new ClientProxy(WcfCommon.WcfAttributes.binding, WcfCommon.WcfAttributes.address))
            {

                if (resources.Count != 0)
                {
                    resources.Clear();
                }
                employees = proxy.GetAllEmployees();

                foreach (Employee em in employees)
                {
                    resources.Add(em);
                }
                    

                ClientDialogViewModel.Instance.Resources = resources;
                ClientDialogViewModel.Instance.ShowEmployeeView();
            }
        }
    }
}
