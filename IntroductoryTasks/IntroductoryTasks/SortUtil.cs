using System;

namespace IntroductoryTasks
{
    public static class SortUtil
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Sorter<T> sorter = new Sorter<T>(array);
            sorter.Sort();
        }

        private class Sorter<T> where T : IComparable<T>
        {
            public double SizeLog { get; }
            private T[] _array;

            public Sorter(T[] array)
            {
                _array = array;
                SizeLog = Math.Log(_array.Length, 2);
            }

            public void Sort() => IntroSort(0, _array.Length, 0);

            private void IntroSort(int l, int r, int deep)
            {
                if (r - l <= 16)
                {
                    InsertionSort(l, r);
                    return;
                }
                else if (deep > SizeLog)
                {
                    HeapSort(l, r);
                    return;
                }

                int index = Partition(l, r - 1);
                IntroSort(l, index + 1, deep + 1);
                IntroSort(index + 1, r, deep + 1);
            }

            private void InsertionSort(int l, int r)
            {
                for (int i = l + 1; i < r; i++)
                    for (int j = i; j > l && _array[j - 1].CompareTo(_array[j]) == 1; j--)
                        SwapInArrayByIndex(j - 1, j);
            }

            private void HeapSort(int l, int r)
            {
                for (int i = l + (r - l) / 2 - 1; i >= 0; i--)
                    Heapify(r - l, i, l, r);

                for (int i = r - 1; i >= 0; i--)
                {
                    SwapInArrayByIndex(0, i);
                    Heapify(i, 0, l, r);
                }
            }

            private void Heapify(int heapSize, int node, int l, int r)
            {
                int largest = node;
                int lNode = node * 2 + 1;
                int rNode = node * 2 + 2;

                if (lNode < l + heapSize && _array[lNode].CompareTo(_array[largest]) == 1)
                    largest = lNode;

                if (rNode < l + heapSize && _array[rNode].CompareTo(_array[largest]) == 1)
                    largest = rNode;

                if (largest != node)
                {
                    SwapInArrayByIndex(node, largest);
                    Heapify(heapSize, largest, l, r);
                }
            }

            private int Partition(int l, int r)
            {
                int pivotIndex = GetMedianIndex(l, (l + r) / 2, r);
                SwapInArrayByIndex(pivotIndex, (l + r) / 2);

                T pivot = _array[(l + r) / 2];

                int i = l, j = r;
                while (i <= j)
                {
                    while (_array[i].CompareTo(pivot) == -1)
                        i++;
                    while (_array[j].CompareTo(pivot) == 1)
                        j--;

                    if (i >= j)
                        break;

                    SwapInArrayByIndex(i, j);

                    i++;
                    j--;
                }

                return j;
            }

            private int GetMedianIndex(int index1, int index2, int index3)
            {
                if (_array[index1].CompareTo(_array[index2]) > -1)
                {
                    if (_array[index1].CompareTo(_array[index3]) < 1)
                        return index1;
                    else
                        return _array[index2].CompareTo(_array[index3]) < 1 ? index2 : index3;
                }
                else
                {
                    if (_array[index1].CompareTo(_array[index3]) > -1)
                        return index1;
                    else
                        return _array[index2].CompareTo(_array[index3]) > -1 ? index2 : index3;
                }
            }

            private void SwapInArrayByIndex(int index1, int index2)
            {
                T temp = _array[index1];
                _array[index1] = _array[index2];
                _array[index2] = temp;
            }
        }  
    }
}
