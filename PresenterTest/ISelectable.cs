using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    delegate void SelectedChangedEvent(ISelectable o);

    interface ISelectable : INotifyPropertyChanged
    {
        [Bindable(false)]
        bool Selected { get; set; }

        event SelectedChangedEvent SelectedChanged;
    }
}
