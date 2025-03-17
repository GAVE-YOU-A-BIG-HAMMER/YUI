using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YControlLibrary;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace YUI.ViewModels;

public sealed class SideNavigationItem
{
    public SideNavigationItem(string name, string icon)
    {
        Name = name;
        Icon = icon;
    }

    public string Name { get; }

    public string Icon { get; }
}

public sealed class SideNavigationItemModel
{
    public SideNavigationItemModel(string name, params SideNavigationItem[] items)
    {
        Name = name;
        Items = new ObservableCollection<SideNavigationItem>(items);
    }

    public SideNavigationItemModel(string name, string icon, params SideNavigationItem[] items)
    {
        Name = name;
        Icon = icon;
        Items = new ObservableCollection<SideNavigationItem>(items);
    }

    public string Name { get; }
    public string Icon { get; } = string.Empty;

    public ObservableCollection<SideNavigationItem> Items { get; }
}

public class SideNavigationUpdateEvent : PubSubEvent<string> { }

class SideNavigationViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    public DelegateCommand<object> SelectItemChangeCommand { get; private set; }
    public ObservableCollection<SideNavigationItemModel> SideNavigationItemModels { get; set; }
    public string Icon { get; set; }

    private SideNavigationItem _selectedItem;
    public SideNavigationItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            if(SetProperty(ref _selectedItem, value))
                SelectItemChangeCommand.Execute(_selectedItem);
        }
    }

    public SideNavigationViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        SelectItemChangeCommand = new DelegateCommand<object>(SelectItemChange);
        Icon = "AirConditioner";
        SideNavigationItemModels = new ObservableCollection<SideNavigationItemModel>
        {
            new("1","AirplaneSettings", new SideNavigationItem("1", "Apple"), new SideNavigationItem("2", "Banana")),
            new("2", new SideNavigationItem("3", "Carrot"), new SideNavigationItem("4", "Tomato")),
            new("3", new SideNavigationItem("5", "Beef"), new SideNavigationItem("6", "Pork"), new SideNavigationItem("7", "Chicken")),
            new("设置","Cog", new SideNavigationItem("主题", "ThemeLightDark")),
        };
    }

    private void SelectItemChange(object item)
    {
        if (item is SideNavigationItem sideNavigationItem)
        {
            _eventAggregator.GetEvent<SideNavigationUpdateEvent>().Publish(sideNavigationItem.Name);
        }
    }
}
