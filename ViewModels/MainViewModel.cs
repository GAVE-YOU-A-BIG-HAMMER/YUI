using MaterialDesignThemes.Wpf;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YControlLibrary;
using YUI.Views;

namespace YUI.ViewModels;
public class TestEvent : PubSubEvent<string> { }

internal class MainViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;

    private static LoginWindow? _loginWindow;
    public ICommand OpenLoginDialogCommand { get; }
    public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
    {
        _regionManager = regionManager;
        //_operateCommand = new DelegateCommand<string>(Operate);
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<SideNavigationUpdateEvent>().Subscribe(OnSideNavigationUpdate); 
        OpenLoginDialogCommand = new DelegateCommand(OpenLoginDialog);
    }
    private void OpenLoginDialog()
    {
        // 如果_loginView为空，或者_loginView已经关闭，则重新创建
        if (_loginWindow == null)
        {
            _loginWindow = new LoginWindow();
            _loginWindow.Closed += (s, e) => _loginWindow = null;
            _loginWindow.Show();
        }
        else
        {
            _loginWindow.Activate();
        }
    }

    private void OnSideNavigationUpdate(string str)
    {
        if(str == "主题")
            _regionManager.Regions["CenterView"].RequestNavigate("ColorToolView");
        else if (str == "1")
            _regionManager.Regions["CenterView"].RequestNavigate("DemoCenterView");
    }

}
