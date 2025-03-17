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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YUI.ViewModels;

namespace YUI.Views;

public partial class SideNavigationView : UserControl
{
    public SideNavigationView()
    {
        InitializeComponent();
        //this.DataContext = new SideNavigationViewModel(new Prism.Events.EventAggregator());
    }
}
