using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    interface IPresenterItem<ObjectT> : ISelectable
    {
        [Bindable(false)]
        ObjectT Item { get; }
    }

    class BasePresenterItem<ObjectT> : IPresenterItem<ObjectT>
    {
        public BasePresenterItem(ObjectT item)
        {
            Item = item;
        }
        
        public ObjectT Item { get; private set; }

        private bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    SelectedChanged(this);
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public event SelectedChangedEvent SelectedChanged = delegate { };
    }
}
