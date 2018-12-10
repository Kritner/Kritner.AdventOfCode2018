using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kritner.AdventOfCode2018.Day9
{
    public class CircularList<T>
    {
        protected List<T> List = new List<T>();
        protected int CurrentIndex;

        public ReadOnlyCollection<T> UnderlyingList => List.AsReadOnly();

        public void Add(int position, T item)
        {
            List.Insert(position, item);
            CurrentIndex = position;
        }

        public T Remove(int position)
        {
            var item = List[position];
            List.RemoveAt(position);
            CurrentIndex = position;
            
            return item;
        }

        public int GetIndexRotatingClockWise(int numberOfPositionsToRotate)
        {
            return GetIndexRotatingClockWise(numberOfPositionsToRotate, CurrentIndex);
        }

        public int GetIndexRotatingClockWise(int numberOfPositionsToRotate, int currentIndex)
        {
            // no more rotation, this is the index to insert onto
            if (numberOfPositionsToRotate == 0)
            {
                return currentIndex;
            }
            // The current index is greater than the length of the underlying array, start from beginning
            else if (currentIndex + 1 > List.Count)
            {
                return GetIndexRotatingClockWise(numberOfPositionsToRotate - 1, 1);
            }

            // normal rotation
            return GetIndexRotatingClockWise(numberOfPositionsToRotate - 1, currentIndex + 1);
        }

        public int GetIndexRotatingCounterClockWise(int numberOfPositionsToRotate)
        {
            return GetIndexRotatingCounterClockWise(numberOfPositionsToRotate, CurrentIndex);
        }

        public int GetIndexRotatingCounterClockWise(int numberOfPositionsToRotate, int currentIndex)
        {
            // no more rotation, this is the index to insert onto
            if (numberOfPositionsToRotate == 0)
            {
                return currentIndex;
            }
            // The current index is less than the minimum of the underlying array, start from end
            else if (currentIndex - 1 < 0)
            {
                return GetIndexRotatingCounterClockWise(numberOfPositionsToRotate - 1, List.Count - 1);
            }

            // normal rotation
            return GetIndexRotatingCounterClockWise(numberOfPositionsToRotate - 1, currentIndex - 1);
        }
    }
}
