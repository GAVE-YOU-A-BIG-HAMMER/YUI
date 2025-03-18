using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YUI.Views
{
    /// <summary>
    /// TransparentWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TransparentWindow : Window
    {
        public TransparentWindow()
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
    }
}
