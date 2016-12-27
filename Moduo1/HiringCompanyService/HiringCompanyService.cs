using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HiringCompanyContract;

namespace HiringCompanyService
{
    public class HiringCompanyService : IHiringCompany
    {
        public string GetData(int value)
        {
            Console.WriteLine("Uspesno pozvana metoda...");
            return "OK";
        }
    }
}
