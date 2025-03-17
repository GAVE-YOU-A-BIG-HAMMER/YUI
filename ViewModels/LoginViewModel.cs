using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace YUI.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand LoginCommand { get; private set; }

        // 创建账号
        public DelegateCommand SignupCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(ExecuteLogin, CanExecuteLogin)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);

            SignupCommand = new DelegateCommand(ExecuteCreateAccount);
        }

        private void ExecuteLogin()
        {
            // 在这里添加用户名和密码验证逻辑
            if (UserName == "admin" && Password == "password")
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private bool CanExecuteLogin()
        {
            // 只有当用户名和密码都不为空时，才能执行登录命令
            //return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
            return true;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            Password = passwordBox?.Password ?? string.Empty;
        }

        private void ExecuteCreateAccount()
        {
            MessageBox.Show("创建账号");
        }
    }
}
