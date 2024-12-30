using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private LinkedList<T> _items;

        public HybridFlowProcessor()
        {
            _items = new LinkedList<T>();
        }
        public T Dequeue()
        {
            if (!_items.Any())
                throw new InvalidOperationException();

            var first = _items.First.Value;
            _items.RemoveFirst();
            return first;
        }

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Pop()
        {
            if (!_items.Any())
                throw new InvalidOperationException();

            var last = _items.Last.Value;
            _items.RemoveLast();
            return last;
        }

        public void Push(T item)
        {
            _items.AddLast(item);
        }
    }
}
