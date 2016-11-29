using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    class SelectableBindingList<ObjectT> : BindingList<ObjectT> where ObjectT : ISelectable
    {
        public SelectableBindingList()
            : base()
        {
            SelectedItems = new BindingList<ObjectT>();
            UnselectedItems = new BindingList<ObjectT>();
        }

        public SelectableBindingList(IList<ObjectT> list)
            : base(list)
        {
            SelectedItems = new BindingList<ObjectT>(list.Where(i => i.Selected).ToList());
            UnselectedItems = new BindingList<ObjectT>(list.Where(i => !i.Selected).ToList());

            foreach (var item in list)
            {
                item.SelectedChanged += item_SelectedChanged;
            }
        }

        public BindingList<ObjectT> SelectedItems
        {
            get;
            private set;
        }

        public BindingList<ObjectT> UnselectedItems
        {
            get;
            private set;
        }

        private void item_SelectedChanged(ISelectable obj)
        {
            if (obj.Selected)
            {
                UnselectedItems.Remove((ObjectT)obj);
                SelectedItems.Add((ObjectT)obj);
            }
            else
            {
                SelectedItems.Remove((ObjectT)obj);
                UnselectedItems.Add((ObjectT)obj);
            }

            //var propertyDesc = TypeDescriptor.GetProperties(obj).Find("Selected", false);
            //OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, propertyDesc));
        }

        protected override void InsertItem(int index, ObjectT item)
        {
            item.SelectedChanged += item_SelectedChanged;
            base.InsertItem(index, item);
            if (item.Selected)
            {
                int newIndex = Enumerable.Range(0, index).Where(i => this[i].Selected).Count();
                SelectedItems.Insert(newIndex, item);
            }
            else
            {
                int newIndex = Enumerable.Range(0, index).Where(i => !this[i].Selected).Count();
                UnselectedItems.Insert(newIndex, item);
            }
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            item.SelectedChanged -= item_SelectedChanged;
            SelectedItems.Remove(item);
            UnselectedItems.Remove(item);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.SelectedChanged -= item_SelectedChanged;
            }
            SelectedItems.Clear();
            UnselectedItems.Clear();
            base.ClearItems();
        }

        protected override void SetItem(int index, ObjectT item)
        {
            var oldItem = this[index];
            oldItem.SelectedChanged -= item_SelectedChanged;
            SelectedItems.Remove(oldItem);
            UnselectedItems.Remove(oldItem);

            base.SetItem(index, item);

            item.SelectedChanged += item_SelectedChanged;
            if (item.Selected)
            {
                int newIndex = Enumerable.Range(0, index).Where(i => this[i].Selected).Count();
                SelectedItems.Insert(newIndex, item);
            }
            else
            {
                int newIndex = Enumerable.Range(0, index).Where(i => !this[i].Selected).Count();
                UnselectedItems.Insert(newIndex, item);
            }
        }
    }
}
