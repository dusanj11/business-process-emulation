using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class ClientDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewProjectsCommand ViewProjectsCommand { get; set; }
        public AddEmployeeCommand AddEmployeeCommand { get; set; }
        public ChangePasswordCommand ChangePasswordCommand { get; set; }
        public EditPersonalDataCommand EditPersonalDataCommand { get; set; }
        public SendRequestCommand SendRequestCommand { get; set; }
        public ViewWorkersCommand ViewWorkersCommand { get; set; }
        public WorkingHoursCommand WorkingHoursCommand { get; set; }

        /// <summary>
        /// private constructor
        /// </summary>
        public ClientDialogViewModel()
        {
            this.ViewProjectsCommand = new ViewProjectsCommand();
            this.AddEmployeeCommand = new AddEmployeeCommand();
            this.ChangePasswordCommand = new ChangePasswordCommand();
            this.EditPersonalDataCommand = new EditPersonalDataCommand();
            this.SendRequestCommand = new SendRequestCommand();
            this.ViewWorkersCommand = new ViewWorkersCommand();
            this.WorkingHoursCommand = new WorkingHoursCommand();
        }
    }
}
