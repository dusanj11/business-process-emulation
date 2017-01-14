using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Command
{
    public class RejectUserStoryCommand :  ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Project project = DefineUserStoriesViewModel.Instance.Project();
            UserStory userStory = DefineUserStoriesViewModel.Instance.UserStory();

            userStory.UserStoryState = UserStoryState.Rejected;

            //PROXY POZIV KA UPDATE USER STORY - verovatno na osnovu samo id-a. 
            ClientProxy.Instance.ChangeUserStoryState(userStory.Id, userStory.UserStoryState);

            ClientProxy.Instance.SendUserStoryToOc(userStory);
        }
    }
}
