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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IOCompanyDB myDB;

        public static IOCompanyDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new OCompanyDB();
                }
                return myDB;
            }

            set
            {
                if (myDB == null)
                {
                    myDB = value;
                }
            }
        }

        public bool AddOutsourcingCompany(HiringCompanyData.OutsourcingCompany oCompany)
        {
            using (var access = new AccessDB())
            {
                HiringCompanyData.OutsourcingCompany oc = access.OcActions.FirstOrDefault(f => f.Name.Equals(oCompany.Name));
                if (oc == null)
                {
                    access.OcActions.Add(oCompany);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully added outsourcing company into DB");
                        return true;
                    }
                    return false;
                }
                else
                {
                    Log.Warn("Outsourcing company already exists in DB");
                    return false;
                }
            }
        }

        public List<OutsourcingCompany> GetOutsourcingCompanies()
        {
            using (var access = new AccessDB())
            {
                List<OutsourcingCompany> ret = new List<OutsourcingCompany>();

                foreach (var oc in access.OcActions)
                {
                    ret.Add(oc);
                }

                if (ret != null)
                {
                    Log.Info("Successfully returned list of outsourcing companies.");
                }
                else
                {
                    Log.Warn("No outsourcing company to show.");
                }
                

                return ret;
            }
        }

        public OutsourcingCompany GetOutsourcingCompany(string name)
        {
            using (var access = new AccessDB())
            {
                HiringCompanyData.OutsourcingCompany oc = access.OcActions.FirstOrDefault(f => f.Name.Equals(name));

                if (oc == null)
                {
                    Log.Warn("Requestet Outsourcing company doesn't exists in DB.");
                }
                else
                {
                    Log.Info("Successfully returned Outsourcing company with specified name.");
                }

                return oc;
            }
        }
    }
}
