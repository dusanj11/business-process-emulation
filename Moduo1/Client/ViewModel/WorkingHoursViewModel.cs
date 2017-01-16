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
    public class WorkingHoursViewModel : INotifyPropertyChanged, IWorkingHoursViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string startTime;
        private string endTime;

        public SaveWorkingHoursCommand SaveWorkingHoursCommand { get; set; }

        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("StartTime"));
            }
        }

        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("EndTime"));
            }
        }

        private static IWorkingHoursViewModel _workingHoursViewModel;

        public static IWorkingHoursViewModel Instance
        {
            get
            {
                if (_workingHoursViewModel == null)
                {
                    _workingHoursViewModel = new WorkingHoursViewModel();
                }

                return _workingHoursViewModel;
            }
            set
            {
                if (_workingHoursViewModel == null)
                {
                    _workingHoursViewModel = value;
                }
            }
        }

        //public static WorkingHoursViewModel Instance
        //{
        //    get
        //    {
        //        if (model == null)
        //        {
        //            model = new WorkingHoursViewModel();
        //        }

        //        return model;
        //    }
        //}

        public WorkingHoursViewModel()
        {
            this.SaveWorkingHoursCommand = new SaveWorkingHoursCommand();
            this.EndTime = "";
            this.StartTime = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        string IWorkingHoursViewModel.StartTime()
        {
            return StartTime;
        }

        string IWorkingHoursViewModel.EndTime()
        {
            return EndTime;
        }
    }
}
