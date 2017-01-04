﻿using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class SendRequestCompanyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static SendRequestCompanyViewModel model;
        private string company;

        public SendRequestCompanyCommand SendRequestCompanyCommand { get; set; }

        public static SendRequestCompanyViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new SendRequestCompanyViewModel();
                }

                return model;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Company"));
            }
        }

        public SendRequestCompanyViewModel()
        {
            this.SendRequestCompanyCommand = new SendRequestCompanyCommand();
            this.Company = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}