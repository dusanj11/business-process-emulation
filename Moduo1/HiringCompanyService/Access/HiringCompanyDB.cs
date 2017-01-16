using HiringCompanyData;
using System.Linq;
using System;

namespace HiringCompanyService.Access
{
    public class HiringCompanyDB : IHiringCompanyDB
    {
        private static IHiringCompanyDB myDB;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            Log.Debug("Enter AddCompany method.");
            using (var access = new AccessDB())
            {
                HiringCompany cm = access.HcActions.FirstOrDefault(f => f.CompanyIdThr.Equals(company.CompanyIdThr));
                if (cm == null)
                {
                    access.HcActions.Add(company);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully updated DB.");
                        return true;
                    }
                    Log.Warn("Failed to update DB.");
                    return false;
                }
                else
                {
                    Log.Warn("Company already exists in DB");
                    return false;
                }
                
            }
        }

        public HiringCompany GetCompany(int id)
        {
            Log.Debug("Enter GetCompany method.");
            using (var acces = new AccessDB())
            {
                HiringCompany cm = acces.HcActions.FirstOrDefault(f => f.IDHc == id);

                if (cm != null)
                {
                    Log.Info("Successfully returned hiring company data.");
                }
                else
                {
                    Log.Warn("Company with thad id doesn't exists in DB");
                }
                return cm;
            }
        }

        public HiringCompany GetHiringCompanyFromThr(int hiringCompanyThr)
        {
            Log.Debug("Enter GetCompany method.");
            using (var acces = new AccessDB())
            {
                HiringCompany cm = acces.HcActions.FirstOrDefault(f => f.CompanyIdThr == hiringCompanyThr);

                if (cm != null)
                {
                    Log.Info("Successfully returned hiring company data.");
                }
                else
                {
                    Log.Warn("Company with thad id doesn't exists in DB");
                }
                return cm;
            }
        }
    }
}