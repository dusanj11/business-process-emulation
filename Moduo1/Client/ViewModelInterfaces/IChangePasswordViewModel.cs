using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IChangePasswordViewModel
    {
        string OldPassword();

        string NewPassword();
    }
}
