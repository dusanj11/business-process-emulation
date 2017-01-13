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
    public class SendRequestProjectViewModel : INotifyPropertyChanged, ISendRequestProjectViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static SendRequestProjectViewModel model;
        private OutsourcingCompany partnerCompany;
        private Project project;

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

        public OutsourcingCompany PartnerCompany
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

        public Project Project
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
            this.PartnerCompany = new OutsourcingCompany();
            this.Project = new Project();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        OutsourcingCompany ISendRequestProjectViewModel.PartnerCompany()
        {
            return PartnerCompany;
        }

        Project ISendRequestProjectViewModel.Project()
        {
            return Project;
        }
    }
}
