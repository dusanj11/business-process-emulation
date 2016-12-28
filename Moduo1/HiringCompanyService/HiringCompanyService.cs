﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HiringCompanyContract;
using HiringCompanyService.Access;

namespace HiringCompanyService
{
    public class HiringCompanyService : IHiringCompany
    {
        public string GetData(int value)
        {
            Console.WriteLine("Uspesno pozvana metoda...");
            EmployeeDB.Instance.AddAction(new Data.Employee
            {
                Username = "Maki",
                Password = "Maki",
                Name = "Marko",
                Surname = "Jelaca",
                Position = Data.Employee.PositionEnum.PO.ToString(),
                StartTime = "9",
                EndTime = "17",
                Login = false,
                HiringCompanyId = "HC1"
               
            });
            return "OK";
        }
    }
}