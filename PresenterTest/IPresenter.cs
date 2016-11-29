using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    interface IPresenter
    {
        IBindingList AllItems { get; }
        IBindingList SelectedItems { get; }
        IBindingList UnselectedItems { get; }
    }
}
