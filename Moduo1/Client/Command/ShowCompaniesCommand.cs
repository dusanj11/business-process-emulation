﻿using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class ShowCompaniesCommand : ICommand
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ObservableCollection<HiringCompanyData.OutsourcingCompany> resources = new ObservableCollection<HiringCompanyData.OutsourcingCompany>();

        public ObservableCollection<HiringCompanyData.OutsourcingCompany> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    


        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee started showing companies.");
            List<HiringCompanyData.OutsourcingCompany> OCResources = new List<HiringCompanyData.OutsourcingCompany>();

            if (resources.Count != 0)
            {
                resources.Clear();
            }

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            Log.Debug("proxy poziv - GetHcIdForUser");
            int hiringCompanyId = ClientProxy.Instance.GetHcIdForUser(username);
            Log.Info("Successfully returned hiring company id");

            Log.Debug("proxy poziv - GetPartnershipOc");
            OCResources = ClientProxy.Instance.GetPartnershipOc(hiringCompanyId);
            Log.Info("Successfully returned list of outsourcing companies");

            foreach (HiringCompanyData.OutsourcingCompany oc in OCResources)
            {
                Resources.Add(oc);
            }

            ClientDialogViewModel.Instance.OcResources(Resources);
            ClientDialogViewModel.Instance.ShowShowCompaniesView();
        }
    }
}
