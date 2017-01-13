using Client.Command;
using Client.ViewModelInterfaces;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class SendRequestCompanyViewModel : INotifyPropertyChanged, ISendRequestCompanyViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static SendRequestCompanyViewModel model;
        private OutsourcingCompany company;

        public SendRequestCompanyCommand SendRequestCompanyCommand { get; set; }

        public static ISendRequestCompanyViewModel _sendRequestCompanyViewModel;

        public static ISendRequestCompanyViewModel Instance
        {
            get
            {
                if (_sendRequestCompanyViewModel == null)
                {
                    _sendRequestCompanyViewModel = new SendRequestCompanyViewModel();
                }

                return _sendRequestCompanyViewModel;
            }
            set
            {
                if (_sendRequestCompanyViewModel == null)
                {
                    _sendRequestCompanyViewModel = value;
                }
            }
        }

        //public static SendRequestCompanyViewModel Instance
        //{
        //    get
        //    {
        //        if (model == null)
        //        {
        //            model = new SendRequestCompanyViewModel();
        //        }

        //        return model;
        //    }
        //}

        public OutsourcingCompany Company
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
            this.Company = new OutsourcingCompany();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        OutsourcingCompany ISendRequestCompanyViewModel.Company()
        {
            return Company;
        }
    }
}
