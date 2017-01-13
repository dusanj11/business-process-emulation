using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IDefineUserStoriesViewModel
    {
        Project Project();

        UserStory UserStory();
        List<UserStory> UserStories();
        void UserStories(List<UserStory> stories);
        string Description();
        void Description(string tekst);
    }
}
