using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductoryTasks
{
    public static class BinarySearchUtil
    {
        public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
        {
            int l = 0, r = array.Length - 1;
            int mid = 0;

            while (l < r)
            {
                mid = l + (r - l) / 2;

                if (value.CompareTo(array[mid]) == 1)
                    l = mid + 1;
                else
                    r = mid;
            }

            return array[l].Equals(value) ? l : (array[l].CompareTo(value) == 1 ? ~l : ~array.Length);
        }

        private static int BSearch<T>(T[] array, T value, int l, int r) where T : IComparable<T>
        {
            int mid = (l + r) / 2;
            if (value.CompareTo(array[mid]) == 1)
                return BSearch(array, value, mid, r);
            else
                return BSearch(array, value, l, mid);
        }
    }
}
