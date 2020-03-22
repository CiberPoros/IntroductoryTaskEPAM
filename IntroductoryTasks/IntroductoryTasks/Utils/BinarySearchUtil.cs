using System;
using System.Collections.Generic;

namespace IntroductoryTasks.Utils
{
    public static class BinarySearchUtil
    {
        public static int BinarySearch<T>(IList<T> list, T value) where T : IComparable<T>
        {
            int left = 0; 
            int right = list.Count - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (value.CompareTo(list[mid]) == 1)
                    left = mid + 1;
                else
                    right = mid;
            }

            return list[left].Equals(value) ? left : (list[left].CompareTo(value) == 1 ? ~left : ~list.Count);
        }
    }
}
