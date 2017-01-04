using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static ChangePasswordViewModel model;
        private string oldPassword;
        private string newPassword;

        public SaveNewPasswordCommand SaveNewPasswordCommand { get; set; }

        public static ChangePasswordViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new ChangePasswordViewModel();
                }

                return model;
            }
        }

        public string OldPassword
        {
            get
            {
                return oldPassword;
            }

            set
            {
                oldPassword = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("OldPassword"));
            }
        }

        public string NewPassword
        {
            get
            {
                return newPassword;
            }

            set
            {
                newPassword = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("NewPassword"));
            }
        }

        public ChangePasswordViewModel()
        {
            this.SaveNewPasswordCommand = new SaveNewPasswordCommand();
            this.NewPassword = "";
            this.OldPassword = "";
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
