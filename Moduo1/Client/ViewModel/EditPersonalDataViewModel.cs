using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class EditPersonalDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static EditPersonalDataViewModel model;
        private string name;
        private string surname;
        private string username;

        public SavePersonalDataCommand SavePersonalDataCommand { get; set; }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Name"));
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Surname"));
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Username"));
            }
        }

        public static EditPersonalDataViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new EditPersonalDataViewModel();
                }

                return model;
            }
        }

        public EditPersonalDataViewModel()
        {
            this.SavePersonalDataCommand = new SavePersonalDataCommand();
            this.Username = "";
            this.Name = "";
            this.Surname = "";
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
