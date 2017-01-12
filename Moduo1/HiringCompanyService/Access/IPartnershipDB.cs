using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyService.Access
{
    public interface IPartnershipDB
    {
        List<OutsourcingCompany> GetPartnerOc(int hiringCompany);

        bool AddPartnership(HiringCompany hc, OutsourcingCompany oc);

    }
}
