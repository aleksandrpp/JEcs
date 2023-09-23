using System.Collections.Generic;

namespace AK.JEcs
{
    public class UniqueSortedList<T>
    {
        private List<T> _list = new();
        private HashSet<T> _set = new();
        private IComparer<T> _comparer;

        public UniqueSortedList(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        // O(n log(n))
        public void Add(T item)
        {
            if (_set.Contains(item))
                return;

            _set.Add(item);

            _list.Add(item);
            _list.Sort(_comparer);
        }

        // O(n)
        public void Remove(T item)
        {
            if (!_set.Contains(item))
                return;

            _set.Remove(item);

            _list.Remove(item);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _list.Count)
                    throw new System.IndexOutOfRangeException();

                return _list[index];
            }
        }

        public int Count => _list.Count;
    }
}