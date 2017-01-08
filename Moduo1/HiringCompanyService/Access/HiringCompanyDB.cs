using HiringCompanyData;
using System.Linq;

namespace HiringCompanyService.Access
{
    public class HiringCompanyDB : IHiringCompanyDB
    {
        private static IHiringCompanyDB myDB;

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
            using (var access = new AccessDB())
            {
                HiringCompany cm = access.HcActions.FirstOrDefault(f => f.CompanyIdThr.Equals(company.CompanyIdThr));
                if (cm == null)
                {
                    access.HcActions.Add(company);

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

        public HiringCompany GetCompany(int id)
        {
            using (var acces = new AccessDB())
            {
                HiringCompany cm = acces.HcActions.FirstOrDefault(f => f.CompanyIdThr == id);

                return cm;
            }
        }
    }
}