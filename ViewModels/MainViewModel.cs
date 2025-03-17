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
        //_regionManager.Regions["CenterView"].RequestNavigate("LoginView");
        DialogHost.Show(new LoginView(), "RootDialog");
    }
    private void OnSideNavigationUpdate(string str)
    {
        if(str == "主题")
            _regionManager.Regions["CenterView"].RequestNavigate("ColorToolView");
        else if (str == "1")
            _regionManager.Regions["CenterView"].RequestNavigate("DemoCenterView");
        else if (str == "2")
            _regionManager.Regions["CenterView"].RequestNavigate("LoginView");


        // 打印
        //Debug.WriteLine(str);
    }

}
