using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class EditPositionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static EditPositionViewModel model;
        private string employee;
        private string position;

        public EditPositionCommand EditPositionCommand { get; set; }

        public static EditPositionViewModel Instance
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Employee
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
            this.EditPositionCommand = new EditPositionCommand();
            this.Employee = "";
            this.Position = "";
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
