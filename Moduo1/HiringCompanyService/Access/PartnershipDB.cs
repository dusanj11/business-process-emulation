using HiringCompanyData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HiringCompanyService.Access
{
    public class PartnershipDB : IPartnershipDB
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                    partnership.OutsourcingCompany = oc;

                    access.HcActions.Attach(partnership.HiringCompany);
                    access.OcActions.Attach(partnership.OutsourcingCompany);
                    access.PrartnershipAction.Add(partnership);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Log.Info("Successfully added partnership.");
                        return true;
                    }

                    Log.Warn("Failed to add partnership");
                    return false;
                }
                else
                {
                    Log.Warn("Partnership already exists.");
                    return false;
                }
            }
        }

        public List<OutsourcingCompany> GetPartnerOc(int hiringCompany)
        {
            Log.Debug("Enter GetPartnerOc method.");
            using (var access = new AccessDB())
            {
                List<OutsourcingCompany> ret = new List<OutsourcingCompany>();

                //var part = access.PrartnershipAction.Include("HiringCompany").Include("OutsourcingCompany");
                var partnership = access.PrartnershipAction.Include(x => x.HiringCompany).Include(x => x.OutsourcingCompany);

                foreach (var pr in partnership)
                {
                    if (pr.HiringCompany.IDHc.Equals(hiringCompany))
                    {
                        OutsourcingCompany oc = new OutsourcingCompany();
                        oc.Id = pr.OutsourcingCompany.Id;
                        oc.IdFromOutSourcingDB = pr.OutsourcingCompany.IdFromOutSourcingDB;
                        oc.Name = pr.OutsourcingCompany.Name;
                                               
                        ret.Add(oc);
                    }
                }
                if (ret.Count == 0)
                {
                    Log.Warn("Hiring company doesn't have parnership.");
                }
                else
                {
                    Log.Info("Successfully returned list of outsourcing companyes.");
                }

                return ret;
            }
        }

        public List<Project> GetPartnershipProjects(int hiringCompanyTr)
        {
            using (var access = new AccessDB())
            {
                List<Project> ret = new List<Project>();

                List<OutsourcingCompany> oc = new List<OutsourcingCompany>();
                oc = GetPartnerOc(hiringCompanyTr);
                var allProjectList = access.PrActions.Include(x => x.Company);

                //List<Project> projects = allProjectList as List<Project>;

                //foreach (var ocItem in allProjectList)
                //{
                foreach (var o in oc)
                {
                    //var project = access.PrActions.Include(x => x.Company).FirstOrDefault(f => f.Company.Id.Equals(o.Id));
                    foreach (Project pr in allProjectList)
                    {
                        if (pr.Company != null)
                        {
                            if (pr.Company.Id.Equals(o.Id))
                            {
                                Project p = new Project();
                                p.Name = pr.Name;
                                p.Id = pr.Id;
                                p.ProjectState = pr.ProjectState;
                                p.Description = pr.Description;

                                ret.Add(p);
                            }
                        }
                        
                    }
                    
                }

                if (ret.Count == 0)
                {
                    Log.Warn("No project to return");
                }
                else
                {
                    Log.Info("Successfully returned project");
                }

                return ret;
            }
        }
    }
}