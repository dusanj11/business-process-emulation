﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class OCompanyDB : IOCompanyDB
    {

        private static IOCompanyDB myDB;

        public static IOCompanyDB Instance
        {
            get
            {
                if(myDB == null)
                {
                    myDB = new OCompanyDB();
                }
                return myDB;
            }

            set
            {
                if(myDB == null)
                {
                    myDB = value;
                }
            }
        }

        public bool AddOutsourcingCompany(OutsourcingCompany oCompany)
        {
            using (var access = new AccessDB())
            {
                OutsourcingCompany oc = access.OcActions.FirstOrDefault(f => f.Id.Equals(oCompany.Id));
                if (oc == null)
                {
                    access.OcActions.Add(oCompany);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
