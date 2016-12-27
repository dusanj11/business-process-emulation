using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyService.Data;

namespace HiringCompanyService.Access
{
    public interface IEmployeeDB
    {
        bool AddAction(Employee action);
    }
}
