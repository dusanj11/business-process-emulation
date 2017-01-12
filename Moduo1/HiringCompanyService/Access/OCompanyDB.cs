using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public class OCompanyDB : IOCompanyDB
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                        log.Info("Successfully added outsourcing company into DB");
                        return true;
                    }
                    return false;
                }
                else
                {
                    log.Warn("Outsourcing company already exists in DB");
                    return false;
                }
            }
        }

        public OutsourcingCompany GetOutsourcingCompany(string name)
        {
            using (var access = new AccessDB())
            {
                OutsourcingCompany oc = access.OcActions.FirstOrDefault(f => f.Name.Equals(name));

                if(oc == null)
                {
                    log.Warn("Requestet Outsourcing company doesn't exists in DB.");
                }
                else
                {
                    log.Info("Successfully returned Outsourcing company with specified name.");
                }

                return oc;
            }
        }
    }
}
