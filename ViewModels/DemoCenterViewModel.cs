using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUI.Views;

namespace YUI.ViewModels
{
    internal class DemoCenterViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        //TestCommand
        public DelegateCommand TestCommand { get; }

        public DemoCenterViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            TestCommand = new DelegateCommand(ExecuteTest);
        }

        private void ExecuteTest()
        {
            TransparentWindow transparentWindow = new TransparentWindow();
            transparentWindow.Show();
        }
    }
}
