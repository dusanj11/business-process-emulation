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
    public class AcceptUserStoryCommand : ICommand
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            log.Info("Employee accepted user story.");

            Project project = DefineUserStoriesViewModel.Instance.Project();
            UserStory userStory = DefineUserStoriesViewModel.Instance.UserStory();

            userStory.UserStoryState = UserStoryState.Approved;


            ClientProxy.Instance.ChangeUserStoryState(userStory.Id, userStory.UserStoryState);

            UserStory us = ClientProxy.Instance.GetUserStoryFromId(userStory.Id);

            ClientProxy.Instance.SendUserStoryToOc(us);
        }
    }
}
