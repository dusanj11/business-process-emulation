using Client.Command;
using Client.ViewModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class SendRequestProjectViewModel : INotifyPropertyChanged, ISendRequestProjectViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static SendRequestProjectViewModel model;
        private string partnerCompany;
        private string project;

        public SendRequestProjectCommand SendRequestProjectCommand { get; set; }

        public static ISendRequestProjectViewModel _sendRequestProjectViewModel;

        public static ISendRequestProjectViewModel Instance
        {
            get
            {
                if (_sendRequestProjectViewModel == null)
                {
                    _sendRequestProjectViewModel = new SendRequestProjectViewModel();
                }

                return _sendRequestProjectViewModel;
            }
            set
            {
                if (_sendRequestProjectViewModel == null)
                {
                    _sendRequestProjectViewModel = value;
                }
            }
        }


        //public static SendRequestProjectViewModel Instance
        //{
        //    get
        //    {
        //        if (model == null)
        //        {
        //            model = new SendRequestProjectViewModel();
        //        }

        //        return model;
        //    }
        //}

        public string PartnerCompany
        {
            get
            {
                return partnerCompany;
            }

            set
            {
                partnerCompany = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("PartnerCompany"));
            }
        }

        public string Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Project"));
            }
        }

        public SendRequestProjectViewModel()
        {
            this.SendRequestProjectCommand = new SendRequestProjectCommand();
            this.PartnerCompany = "";
            this.Project = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        string ISendRequestProjectViewModel.PartnerCompany()
        {
            return PartnerCompany;
        }

        string ISendRequestProjectViewModel.Project()
        {
            return Project;
        }
    }
}
