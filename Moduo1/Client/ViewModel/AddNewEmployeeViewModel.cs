﻿using Client.Command;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class AddNewEmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static AddNewEmployeeViewModel model;
        private NewEmployee newEmployee;

        public SaveNewEmployeeCommand SaveNewEmployeeCommand { get; set; }


        public static AddNewEmployeeViewModel Instance
        {
            get
            {
                if (model == null)
                {
                    model = new AddNewEmployeeViewModel();
                }

                return model;
            }
        }

        public NewEmployee NewEmployee
        {
            get
            {
                return newEmployee;
            }

            set
            {
                newEmployee = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("NewEmployee"));
            }
        }

        public AddNewEmployeeViewModel()
        {
            this.SaveNewEmployeeCommand = new SaveNewEmployeeCommand();
            this.NewEmployee = new NewEmployee();
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