using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUI.ViewModels
{
    internal class DemoCenterViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public DemoCenterViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
