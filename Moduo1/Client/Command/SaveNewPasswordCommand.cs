using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Windows;
using System.Windows.Input;

namespace Client.Command
{
    public class SaveNewPasswordCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string oldPassword = ChangePasswordViewModel.Instance.OldPassword();
            string newPassword = ChangePasswordViewModel.Instance.NewPassword();

            string username = ClientDialogViewModel.Instance.LogInUser().Username;

            bool ret = ClientProxy.Instance.ChangePassword(username, oldPassword, newPassword);

            if (ret)
            {
                ClientDialogViewModel.Instance.LogInUser().Password = newPassword;
            }

            //omogucavanje normalnog prikaza nakon promene sifre
            Employee signedUser = ClientProxy.Instance.GetEmployee(username, newPassword);
            signedUser.PasswordUpadateDate = DateTime.Today;
            ClientProxy.Instance.UpdateEmployee(signedUser);
            if (signedUser.Position.ToString().Equals("PO"))
            {
                ClientDialog cd = ClientDialogViewModel.Instance.CDialog();
                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                cd.editPosBtn.Visibility = Visibility.Collapsed;
                cd.showProjBtn.IsEnabled = true;
                cd.showEmployBtn.IsEnabled = true;
                cd.editYDBtn.IsEnabled = true;
                cd.timeTableBtn.IsEnabled = true;
                cd.passChngBtn.IsEnabled = true;
                cd.createProjBtn.IsEnabled = true;
                cd.defUSBtn.IsEnabled = true;
                cd.showCompBtn.IsEnabled = true;
                cd.Show();
            }
            else if (signedUser.Position.ToString().Equals("HR"))
            {
                ClientDialog cd = ClientDialogViewModel.Instance.CDialog();
                cd.showProjBtn.Visibility = Visibility.Collapsed;
                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                cd.defUSBtn.Visibility = Visibility.Collapsed;
                cd.createProjBtn.Visibility = Visibility.Collapsed;
                cd.showEmployBtn.IsEnabled = true;
                cd.addEmployBtn.IsEnabled = true;
                cd.editYDBtn.IsEnabled = true;
                cd.timeTableBtn.IsEnabled = true;
                cd.passChngBtn.IsEnabled = true;
                cd.showCompBtn.IsEnabled = true;
                cd.editPosBtn.IsEnabled = true;
                cd.Show();
            }
            else if (signedUser.Position.ToString().Equals("CEO"))
            {
                ClientDialog cd = ClientDialogViewModel.Instance.CDialog();
                cd.defUSBtn.Visibility = Visibility.Collapsed;
                cd.createProjBtn.Visibility = Visibility.Collapsed;
                cd.showProjBtn.IsEnabled = true;
                cd.showEmployBtn.IsEnabled = true;
                cd.addEmployBtn.IsEnabled = true;
                cd.editYDBtn.IsEnabled = true;
                cd.timeTableBtn.IsEnabled = true;
                cd.passChngBtn.IsEnabled = true;
                cd.sendReqCompBtn.IsEnabled = true;
                cd.sendReqProjBtn.IsEnabled = true;
                cd.showCompBtn.IsEnabled = true;
                cd.editPosBtn.IsEnabled = true;
                cd.Show();
            }
            else if (signedUser.Position.ToString().Equals("SM"))
            {
                ClientDialog cd = ClientDialogViewModel.Instance.CDialog();
                cd.sendReqCompBtn.Visibility = Visibility.Collapsed;
                cd.sendReqProjBtn.Visibility = Visibility.Collapsed;
                cd.addEmployBtn.Visibility = Visibility.Collapsed;
                cd.defUSBtn.Visibility = Visibility.Collapsed;
                cd.createProjBtn.Visibility = Visibility.Collapsed;
                cd.editPosBtn.Visibility = Visibility.Collapsed;
                cd.showProjBtn.IsEnabled = true;
                cd.showEmployBtn.IsEnabled = true;
                cd.editYDBtn.IsEnabled = true;
                cd.timeTableBtn.IsEnabled = true;
                cd.passChngBtn.IsEnabled = true;
                cd.showCompBtn.IsEnabled = true;
                cd.Show();
            }
        }
    }
}