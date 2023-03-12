using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch12ExExtra12._5
{
    public class ShortList<T> : IList<T>
    {
        protected int maxSize = 10;
        protected IList<T> innerList;

        public ShortList() : this(10) { }
        public ShortList(List<T> myList)
        {
            maxSize = myList.Count;
        }
        public ShortList(int size)
        {
            maxSize = size;
            innerList = new List<T>();
        }

        public ShortList(int size, IEnumerable<T> list)
        {
            maxSize = size;
            innerList = new List<T>(list);
            if (Count > maxSize)
            {
                ThrowTooManyItemsException();
            }
        }

        protected void ThrowTooManyItemsException()
        {
            throw new IndexOutOfRangeException("Unable to add any more items, maximum size is " + maxSize.ToString() + " items.");
        }


        #region IList<T> Members
        public int IndexOf(T item) => innerList.IndexOf(item);

        public void Insert(int index, T item)
        {
            if(Count < maxSize)
            {
                innerList.Insert(index, item);
            }
            else
            {
                ThrowTooManyItemsException();
            }
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                innerList[index] = value;
            }
        }
        #endregion

        #region ICollection<T> Members
        public void Add(T item)
        {
            if (Count < maxSize)
            {
                innerList.Add(item);
            }
            else
            {
                ThrowTooManyItemsException();
            }
        }

        public void Clear()
        {
            innerList.Clear();
        }

        public bool Contains(T item) => innerList.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
        }
        public int Count { get { return innerList.Count; } }
        public bool IsReadOnly { get { return innerList.IsReadOnly; } }
        public bool Remove(T item) => innerList.Remove(item);
        #endregion

        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
        #endregion

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)innerList).GetEnumerator();
        #endregion

    }
}
