using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenterTest
{
    interface IPresenterControl
    {
        IEnumerable<Object> SelectedItems { get; }


    }
}
