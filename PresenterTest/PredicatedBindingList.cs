using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    class PredicatedBindingList<ObjectT>// : IBindingList, IList<ObjectT>
    {
        private BindingList<ObjectT> _list;
        private Func<ObjectT, bool> _pred;
        private event Action<ObjectT> OnAdd = delegate { };
        private event Action<ObjectT> OnRemove = delegate { };

        public PredicatedBindingList(BindingList<ObjectT> list, Func<ObjectT, bool> pred, Action<ObjectT> onAdd = null, Action<ObjectT> onRemove = null)
        {
            _list = list;
            _pred = pred;
            OnAdd += onAdd;
            OnRemove += onRemove;
            syncCache();
        }

        private void syncCache()
        {
            //_cache = Enumerable.Where(_list, _pred).ToList();
        }

        private IBindingList Internal { get { return _list; } }
/*
        #region IBindingList
        public void AddIndex(PropertyDescriptor property)
        {
            Internal.AddIndex(property);
        }

        public object AddNew()
        {
            return Internal.AddNew();
        }

        public bool AllowEdit
        {
            get { return _list.AllowEdit; }
        }

        public bool AllowNew
        {
            get { return _list.AllowNew; }
        }

        public bool AllowRemove
        {
            get { return AllowRemove; }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            Internal.ApplySort(property, direction);
        }

        public int Find(PropertyDescriptor property, object key)
        {
            return Internal.Find(property, key);
        }

        public bool IsSorted
        {
            get { return Internal.IsSorted; }
        }

        public event ListChangedEventHandler ListChanged
        {
            add { _list.ListChanged += value; }
            remove { _list.ListChanged -= value; }
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            Internal.RemoveIndex(property);
        }

        public void RemoveSort()
        {
            Internal.RemoveSort();
        }

        public ListSortDirection SortDirection
        {
            get { return Internal.SortDirection; }
        }

        public PropertyDescriptor SortProperty
        {
            get { return Internal.SortProperty; }
        }

        public bool SupportsChangeNotification
        {
            get { return Internal.SupportsChangeNotification; }
        }

        public bool SupportsSearching
        {
            get { return Internal.SupportsSearching; }
        }

        public bool SupportsSorting
        {
            get { return Internal.SupportsSorting; }
        }

        public int Add(object value)
        {
            return Internal.Add(value);
        }

        public void Clear()
        {
            Internal.Clear();
        }

        public bool Contains(object value)
        {
            return Internal.Contains(value);
        }

        public int IndexOf(object value)
        {
            if (value is ObjectT)
                return IndexOf((ObjectT)value);
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (value is ObjectT)
                Insert(index, (ObjectT)value);
            else
                throw new ArgumentException();
        }

        public bool IsFixedSize
        {
            get { return Internal.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return Internal.IsReadOnly; }
        }

        public void Remove(object value)
        {
            Internal.Remove(value);
        }

        public void RemoveAt(int index)
        {
            Internal.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return ((IList<ObjectT>)this)[index];
            }
            set
            {
                if (value is ObjectT)
                    ((IList<ObjectT>)this)[index] = (ObjectT)value;
                else
                    throw new ArgumentException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            var arr = this.ToArray();
            Array.Copy(arr, 0, array, index, arr.Length);
        }

        public int Count
        {
            get { return _cache.Count; }
        }

        public bool IsSynchronized
        {
            get { return Internal.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return Internal.SyncRoot; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return ((IEnumerable<ObjectT>)this).GetEnumerator();
        }
        #endregion
        
        #region IList<ObjectT>
        public int IndexOf(ObjectT item)
        {
            return _cache.IndexOf(item);
        }

        public void Insert(int index, ObjectT item)
        {
            _list.Insert(_list.IndexOf(_cache[index]), item);
        }

        ObjectT IList<ObjectT>.this[int index]
        {
            get
            {
                return _cache[index];
            }
            set
            {
                _list[_list.IndexOf(_cache[index])] = value;
            }
        }

        public void Add(ObjectT item)
        {
            _list.Add(item);
        }

        public bool Contains(ObjectT item)
        {
            return _list.Contains(item) && _pred(item);
        }

        public void CopyTo(ObjectT[] array, int arrayIndex)
        {
            CopyTo((Array)array, arrayIndex);
        }

        public bool Remove(ObjectT item)
        {
            return _list.Remove(item);
        }

        IEnumerator<ObjectT> IEnumerable<ObjectT>.GetEnumerator()
        {
            return _cache.GetEnumerator();
        }
        #endregion
 * */
    }

    static class PredicatedBindingListExtensions
    {
        public static PredicatedBindingList<ObjectT> Where<ObjectT>(this BindingList<ObjectT> list, Func<ObjectT, bool> pred)
        {
            return new PredicatedBindingList<ObjectT>(list, pred);
        }
    }
}
