﻿using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyService.Access
{
    public interface IOCompanyDB
    {
        bool AddOutsourcingCompany(OutsourcingCompany oCompany);

        OutsourcingCompany GetOutsourcingCompany(string name);

        List<OutsourcingCompany> GetOutsourcingCompanies();
    }
}
