using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyService.Access
{
    public interface IHiringCompanyDB
    {
        bool AddCompany(HiringCompany company);

        HiringCompany GetCompany(int id);

        HiringCompany GetHiringCompanyFromThr(int hiringCompanyThr);
    }
}
