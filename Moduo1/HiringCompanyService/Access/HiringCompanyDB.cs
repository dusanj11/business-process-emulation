using HiringCompanyData;
using System.Linq;
using System;

namespace HiringCompanyService.Access
{
    public class HiringCompanyDB : IHiringCompanyDB
    {
        private static IHiringCompanyDB myDB;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IHiringCompanyDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new HiringCompanyDB();
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

        public bool AddCompany(HiringCompany company)
        {
            log.Debug("Enter AddCompany method.");
            using (var access = new AccessDB())
            {
                HiringCompany cm = access.HcActions.FirstOrDefault(f => f.CompanyIdThr.Equals(company.CompanyIdThr));
                if (cm == null)
                {
                    access.HcActions.Add(company);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        log.Info("Successfully updated DB.");
                        return true;
                    }
                    log.Warn("Failed to update DB.");
                    return false;
                }
                else
                {
                    log.Warn("Company already exists in DB");
                    return false;
                }
                
            }
        }

        public HiringCompany GetCompany(int id)
        {
            log.Debug("Enter GetCompany method.");
            using (var acces = new AccessDB())
            {
                HiringCompany cm = acces.HcActions.FirstOrDefault(f => f.IDHc == id);

                if (cm != null)
                {
                    log.Info("Successfully returned hiring company data.");
                }
                else
                {
                    log.Warn("Company with thad id doesn't exists in DB");
                }
                return cm;
            }
        }

        public HiringCompany GetHiringCompanyFromThr(int hiringCompanyThr)
        {
            log.Debug("Enter GetCompany method.");
            using (var acces = new AccessDB())
            {
                HiringCompany cm = acces.HcActions.FirstOrDefault(f => f.CompanyIdThr == hiringCompanyThr);

                if (cm != null)
                {
                    log.Info("Successfully returned hiring company data.");
                }
                else
                {
                    log.Warn("Company with thad id doesn't exists in DB");
                }
                return cm;
            }
        }
    }
}