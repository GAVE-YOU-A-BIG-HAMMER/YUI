using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using Prism;
using YControlLibrary;
using YUI.ViewModels;
using YUI.Views;

namespace YUI
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            // 返回主窗口实例
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册类型和服务
            containerRegistry.RegisterForNavigation<InfoShowView, InfoShowViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<SideNavigationView, SideNavigationViewModel>();
            containerRegistry.RegisterForNavigation<ColorToolView, ColorToolViewModel>();
            containerRegistry.RegisterForNavigation<DemoCenterView, DemoCenterViewModel>();
        }
    }
}
