using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IEditPositionViewModel
    {
        Employee Employee();

        string Position();
    }
}
