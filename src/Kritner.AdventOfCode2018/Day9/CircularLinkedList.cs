using System.Collections.Generic;

namespace Kritner.AdventOfCode2018.Day9
{
    public class CircularLinkedList<T>
    {
        public LinkedList<T> List = new LinkedList<T>();

        protected LinkedListNode<T> CurrentItem;
        
        public void Add(T item)
        {
            if (CurrentItem == null)
            {
                CurrentItem = List.AddFirst(item);
                return;
            }

            CurrentItem = List.AddAfter(CurrentItem, item);
        }

        public void Remove(T item)
        {
            CurrentItem = CurrentItem.Next ?? CurrentItem.List.First;
            List.Remove(item);
        }

        public T GetNext(int numberOfPositionsToRotate)
        {
            for (int i = 0; i < numberOfPositionsToRotate; i++)
            {
                CurrentItem = CurrentItem.Next ?? CurrentItem.List.First;
            }

            return CurrentItem.Value;
        }

        public T GetPrevious(int numberOfPositionsToRotate)
        {
            for (int i = 0; i < numberOfPositionsToRotate; i++)
            {
                CurrentItem = CurrentItem.Previous ?? CurrentItem.List.Last;
            }

            return CurrentItem.Value;
        }
    }
}
