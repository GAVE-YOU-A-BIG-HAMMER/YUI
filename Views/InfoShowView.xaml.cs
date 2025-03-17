using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YControlLibrary
{
    /// <summary>
    /// InfoShowView.xaml 的交互逻辑
    /// </summary>
    public partial class InfoShowView : UserControl
    {
        public InfoShowView()
        {
            InitializeComponent();
            // 设计器模式下不执行依赖注入逻辑
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            //DataContext = new InfoShowViewModel();
        }
    }
}
