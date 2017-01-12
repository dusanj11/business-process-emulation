using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiringCompanyData;

namespace HiringCompanyService.Access
{
    public interface IProjectDB
    {
        bool AddProject(Project project);

        List<Project> GetProjects();

        Project GetProject(string name);
    }
}
