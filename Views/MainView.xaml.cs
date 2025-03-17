using MaterialDesignThemes.Wpf;
using Prism.Dialogs;
using Prism.Navigation.Regions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YControlLibrary;

namespace YUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) => ToggleMaximize();
            btnClose.Click += (s, e) => { this.Close(); };
        }

        private void ToggleMaximize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                btnMax.Content = new PackIcon() { Kind = PackIconKind.WindowMaximize };
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                btnMax.Content = new PackIcon() { Kind = PackIconKind.WindowRestore };
            }
        }


        //private void OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        //{
        //    // 处理弹窗关闭事件
        //}
    }
}
