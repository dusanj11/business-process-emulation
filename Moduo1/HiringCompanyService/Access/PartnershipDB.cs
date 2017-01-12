using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class PartnershipDB : IPartnershipDB
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IPartnershipDB myDB;

        public static IPartnershipDB Instance
        {
            get
            {
                if (myDB == null)
                {
                    myDB = new PartnershipDB();
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

        public bool AddPartnership(HiringCompany hc, OutsourcingCompany oc)
        {
            using (var access = new AccessDB())
            {
                Partnership pr = access.PrartnershipAction.FirstOrDefault(f => f.HiringCompany.CompanyIdThr.Equals(hc.CompanyIdThr) && f.OutsourcingCompany.Id.Equals(oc.Id));

                if (pr == null)
                {
                    Partnership partnership = new Partnership();
                    partnership.HiringCompany = hc;
                    oc.CompanyState = CompanyState.Accepted;
                    partnership.OutsourcingCompany = oc;

                    access.HcActions.Attach(partnership.HiringCompany);
                    access.OcActions.Attach(partnership.OutsourcingCompany);
                    access.PrartnershipAction.Add(partnership);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        log.Info("Successfully added partnership.");
                        return true;
                    }

                    log.Warn("Failed to add partnership");
                    return false;
                }
                else
                {
                    log.Warn("Partnership already exists.");
                    return false;
                }
            }
        }

        public List<OutsourcingCompany> GetPartnerOc(int hiringCompany)
        {

            log.Debug("Enter GetPartnerOc method.");
            using (var access = new AccessDB())
            {
                List<OutsourcingCompany> ret = new List<OutsourcingCompany>();

                foreach (Partnership pr in access.PrartnershipAction)
                {
                    if (pr.HiringCompany.CompanyIdThr.Equals(hiringCompany))
                    {
                        ret.Add(pr.OutsourcingCompany);
                    }
                }
                if (ret.Count == 0)
                {
                    log.Warn("Hiring company doesn't have parnership.");
                }
                else
                {
                    log.Info("Successfully returned list of outsourcing companyes.");
                }
               
                return ret;
            }
        }
    }
}
