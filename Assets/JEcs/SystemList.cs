using System;
using System.Collections.Generic;
using System.Reflection;

namespace AK.JEcs
{
    public class SystemList
    {
        private List<ISystem> _items = new();
        private HashSet<Type> _types = new();

        public bool Contains(Type type)
        {
            return _types.Contains(type);
        }

        // O(n)
        public void Add(ISystem item)
        {
            if (item == null)
                return;

            Type type = item.GetType();

            if (Contains(type))
                return;

            _types.Add(type);

            if (_items.Count != 0)
            {
                uint executionOrder = GetExecutionOrder(type);
                int i = 0;

                while (GetExecutionOrder(_items[i].GetType()) <= executionOrder)
                {
                    if (++i >= _items.Count)
                        break;
                }

                _items.Insert(i, item);
            }
            else
            {
                _items.Add(item);
            }
        }

        private uint GetExecutionOrder(Type type)
        {
            return type.GetCustomAttribute<ExecutionOrderAttribute>()?.Value ?? 0;
        }

        // O(n)
        public void Remove(Type type)
        {
            if (type == null)
                return;

            if (!Contains(type))
                return;

            _types.Remove(type);

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].GetType() == type)
                    _items.RemoveAt(i);
            }
        }

        public ISystem this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException();

                return _items[index];
            }
        }

        public int Count => _items.Count;
    }
}