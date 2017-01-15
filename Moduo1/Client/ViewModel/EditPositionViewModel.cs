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
    public class EditPositionViewModel : INotifyPropertyChanged, IEditPositionViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

    
        private Employee employee;
        private string position;

        public SaveEditPositionCommand SaveEditPositionCommand { get; set; }


        public static IEditPositionViewModel _editPositionViewModel;

        public static IEditPositionViewModel Instance
        {
            get
            {
                if (_editPositionViewModel == null)
                {
                    _editPositionViewModel = new EditPositionViewModel();
                }

                return _editPositionViewModel;
            }
            set
            {
                if (_editPositionViewModel == null)
                {
                    _editPositionViewModel = value;
                }
            }
        }

        //public static EditPositionViewModel Instance
        //{
        //    get
        //    {
        //        return model;
        //    }

        //    set
        //    {
        //        model = value;
        //    }
        //}

        public Employee Employee
        {
            get
            {
                return employee;
            }

            set
            {
                employee = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Employee"));
            }
        }

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Position"));
            }
        }

        public EditPositionViewModel()
        {
            this.SaveEditPositionCommand = new SaveEditPositionCommand();
            this.Employee = new Employee();
            this.Position = "";
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        Employee IEditPositionViewModel.Employee()
        {
            return Employee;
        }

        string IEditPositionViewModel.Position()
        {
            return Position;
        }
    }
}
