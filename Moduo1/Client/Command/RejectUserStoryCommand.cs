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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            log.Info("Employee rejected user story");
            Project project = DefineUserStoriesViewModel.Instance.Project();
            UserStory userStory = DefineUserStoriesViewModel.Instance.UserStory();

            userStory.UserStoryState = UserStoryState.Rejected;

            //PROXY POZIV KA UPDATE USER STORY - verovatno na osnovu samo id-a. 
            log.Debug("proxy poziv - ChangeUserStoryState");
            ClientProxy.Instance.ChangeUserStoryState(userStory.Id, userStory.UserStoryState);
            log.Info("Successfully changed story state");

            log.Debug("proxy poziv - GetUserStoryFromId");
            UserStory us = ClientProxy.Instance.GetUserStoryFromId(userStory.Id);
            log.Info("Successfully returned user story");

            log.Debug("proxy poziv - SendUserStoryToOc");
            ClientProxy.Instance.SendUserStoryToOc(us);
            log.Info("Successfully sent story to OC");
        }
    }
}
