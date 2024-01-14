using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalSysWPF.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }

        private string userNameTip;

        public string UserNameTip
        {
            get { return userNameTip; }
            set { userNameTip = value; RaisePropertyChanged(); }
        }

        private string pwdTip;

        public string PwdTip
        {
            get { return pwdTip; }
            set { pwdTip = value; RaisePropertyChanged(); }
        }

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public string Title { get; set; } = "登录界面";
        public event Action<IDialogResult> RequestClose;
        public LoginViewModel()
        {
            UserName = "admin";
            Password = "admin";
            LoginCommand = new DelegateCommand(() =>
            {
                if (UserName == null)
                {
                    UserNameTip = "用户名不能为空";
                    return;
                }
                else if (Password == null)
                {
                    PwdTip = "密码不能为空";
                    return;
                }
                else if(UserName != "admin" && Password != "admin")
                {
                    MessageBox.Show("用户名或密码错误！","提示信息",MessageBoxButton.OKCancel,MessageBoxImage.Information);
                    return;
                }
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });

            CancelCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
