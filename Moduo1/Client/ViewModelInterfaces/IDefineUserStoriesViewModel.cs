using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IDefineUserStoriesViewModel
    {
        string Project();
        string UserStories();
        string Description();
        void Description(string tekst);
    }
}
