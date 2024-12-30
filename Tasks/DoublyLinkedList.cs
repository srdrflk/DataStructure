using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; set; }

        LinkedList<T> linkedList = new LinkedList<T>();
        public void Add(T e)
        {
            linkedList.AddLast(e);
            Length = linkedList.Count;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > linkedList.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = linkedList.First;
            for (int i = 0; i < index && currentNode != null; i++)
            {
                currentNode = currentNode.Next;
            }
            if (currentNode == null)
            {
                linkedList.AddLast(e);
                Length = linkedList.Count;
            }
            else
            {
                linkedList.AddBefore(currentNode, e);
                Length = linkedList.Count;
            }
        }

        public T ElementAt(int index)
        {
            if (linkedList.Count == 0 || linkedList.Count <= index || index < 0) throw new IndexOutOfRangeException();

            return linkedList.ElementAt(index);

        }

        public IEnumerator<T> GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        public void Remove(T item)
        {
            if (linkedList.Count == 0) throw new IndexOutOfRangeException();

            Length = linkedList.Count;

            if (linkedList.Contains(item))
            {
                linkedList.Remove(item);
                Length = linkedList.Count;
            }
            
        }

        public T RemoveAt(int index)
        {
            if (linkedList.Count == 0 || index < 0 || index >= linkedList.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = linkedList.First;
            for (int i = 0; i < index && currentNode != null; i++)
            {
                currentNode = currentNode.Next;
            }

            T removedValue = currentNode.Value;
            linkedList.Remove(currentNode);
            Length = linkedList.Count;

            return removedValue;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }
    }
}
