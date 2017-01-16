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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Log.Info("Employee rejected user story");
            Project project = DefineUserStoriesViewModel.Instance.Project();
            UserStory userStory = DefineUserStoriesViewModel.Instance.UserStory();

            userStory.UserStoryState = UserStoryState.Rejected;

            //PROXY POZIV KA UPDATE USER STORY - verovatno na osnovu samo id-a. 
            Log.Debug("proxy poziv - ChangeUserStoryState");
            ClientProxy.Instance.ChangeUserStoryState(userStory.Id, userStory.UserStoryState);
            Log.Info("Successfully changed story state");

            Log.Debug("proxy poziv - GetUserStoryFromId");
            UserStory us = ClientProxy.Instance.GetUserStoryFromId(userStory.Id);
            Log.Info("Successfully returned user story");

            Log.Debug("proxy poziv - SendUserStoryToOc");
            ClientProxy.Instance.SendUserStoryToOc(us);
            Log.Info("Successfully sent story to OC");
        }
    }
}
