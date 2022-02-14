using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task3._2
{
    class DynamicArray<T>:ICollection<T>,IEnumerable<T>
    {
        public int index = -1;
        private int capacity = 8;
        private int length = 0;
        private T[] data;
        public DynamicArray()
        {
            Array.Resize(ref data, Capacity);
        }
        public DynamicArray(int capacity)
        {
            Array.Resize(ref data, capacity);
        }
        public DynamicArray(List<T>collection)
        {
            Array.Resize(ref data, collection.Count);
            for (int i = 0; i < collection.Count; i++)
                data[i] = collection[i];
            }
        
        public int Count
        {
            get
            {
                return data.Length;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (capacity >= Length)
                    capacity = value;
            }
        }
        public T this[int index]
        {
            get
            {
                if (index <= Length)
                    return data[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index <= Length)
                    data[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Resize(ref T[] data)
        {
            Array.Resize(ref data, Capacity * 2);
        }
        public struct Enumerator : IEnumerator<T>
        {
            private DynamicArray<T> _da;
            private int curIndex;
            private T curItem;

            public Enumerator(DynamicArray<T> da)
            {
                _da = da;
                curIndex = -1;
                curItem = default(T);
            }

            public bool MoveNext()
            {
                //Avoids going beyond the end of the collection.
                if (++curIndex >= _da.Length)
                {
                    return false;
                }
                else
                {
                    curItem = _da[curIndex];
                }
                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            public T Current
            {
                get { return curItem; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
        public void AddInsert()
        {
            if (index == Capacity - 1)
            {
                Resize(ref data);
                Capacity *= 2;
            }
            index++;
            length++;
        }
        public void Add(T i)
        {
            AddInsert();
            data[index] = i;
        }
        public void AddRange(List<T> coll)
        {
            int i = 0;
            for (i = 0; this.length + coll.Count > Capacity; i++)
                Capacity *= 2;
            if (i > 0)
                Array.Resize(ref data, Capacity);
            for (i = 0; i < coll.Count; i++)
                this.Add(coll[i]);
        }
        public void Insert(T i, int pos)
        {
            AddInsert();
            for (int j = index; j > pos; j--)
                data[j] = data[j - 1];
            data[pos] = i;
        }
        public void Remove(int pos)
        {
            for (int j = pos; j < index; j++)
                data[j] = data[j + 1];
            length--;
            data[index] = default(T);
            index--;
        }

        public void Clear()
        {
            data = null;
        }
        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return false;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
        #region NOT_IMPLEMENTED
        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
            //if (pos >= this.Length || data[pos] == default(T))
            //    return false;
            ////index++;
            //for (int j = pos; j < index; j++)
            //    data[j] = data[j + 1];
            //Length--;
            //data[index] = default(T);
            //index--;
            //return true;
        }
        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }
        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
