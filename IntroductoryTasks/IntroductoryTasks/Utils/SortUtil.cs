using System;
using System.Collections.Generic;

namespace IntroductoryTasks.Utils
{
    public static class SortUtil
    {
        public static void Sort<T>(IList<T> list) where T : IComparable<T>
        {
            Sorter<T> sorter = new Sorter<T>(list);
            sorter.Sort();
        }

        private class Sorter<T> where T : IComparable<T>
        {
            public double LogOfListSize { get; }

            private readonly IList<T> _list;

            public Sorter(IList<T> list)
            {
                _list = list;
                LogOfListSize = Math.Log(_list.Count, 2);
            }

            public void Sort() => IntroSort(0, _list.Count, 0);

            private void IntroSort(int startIndex, int endIndex, int deep)
            {
                if (endIndex - startIndex <= 16)
                {
                    InsertionSort(startIndex, endIndex);
                    return;
                }
                else if (deep > LogOfListSize)
                {
                    HeapSort(startIndex, endIndex);
                    return;
                }

                int index = Partition(startIndex, endIndex - 1);
                IntroSort(startIndex, index + 1, deep + 1);
                IntroSort(index + 1, endIndex, deep + 1);
            }

            private void InsertionSort(int startIndex, int endIndex)
            {
                for (int i = startIndex + 1; i < endIndex; i++)
                    for (int j = i; j > startIndex && _list[j - 1].CompareTo(_list[j]) == 1; j--)
                        SwapInArrayByIndex(j - 1, j);
            }

            private void HeapSort(int startIndex, int endIndex)
            {
                for (int i = startIndex + (endIndex - startIndex) / 2 - 1; i >= 0; i--)
                    Heapify(endIndex - startIndex, i, startIndex, endIndex);

                for (int i = endIndex - 1; i >= 0; i--)
                {
                    SwapInArrayByIndex(0, i);
                    Heapify(i, 0, startIndex, endIndex);
                }
            }

            private void Heapify(int heapSize, int node, int startIndex, int endIndex)
            {
                int largest = node;
                int leftNode = node * 2 + 1;
                int rightNode = node * 2 + 2;

                if (leftNode < startIndex + heapSize && _list[leftNode].CompareTo(_list[largest]) == 1)
                    largest = leftNode;

                if (rightNode < startIndex + heapSize && _list[rightNode].CompareTo(_list[largest]) == 1)
                    largest = rightNode;

                if (largest != node)
                {
                    SwapInArrayByIndex(node, largest);
                    Heapify(heapSize, largest, startIndex, endIndex);
                }
            }

            private int Partition(int startIndex, int endIndex)
            {
                int pivotIndex = GetMedianIndex(startIndex, (startIndex + endIndex) / 2, endIndex);
                SwapInArrayByIndex(pivotIndex, (startIndex + endIndex) / 2);

                T pivot = _list[(startIndex + endIndex) / 2];

                int i = startIndex, j = endIndex;
                while (i <= j)
                {
                    while (_list[i].CompareTo(pivot) == -1)
                        i++;
                    while (_list[j].CompareTo(pivot) == 1)
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
                if (_list[index1].CompareTo(_list[index2]) > -1)
                {
                    if (_list[index1].CompareTo(_list[index3]) < 1)
                        return index1;
                    else
                        return _list[index2].CompareTo(_list[index3]) < 1 ? index2 : index3;
                }
                else
                {
                    if (_list[index1].CompareTo(_list[index3]) > -1)
                        return index1;
                    else
                        return _list[index2].CompareTo(_list[index3]) > -1 ? index2 : index3;
                }
            }

            private void SwapInArrayByIndex(int index1, int index2)
            {
                T temp = _list[index1];
                _list[index1] = _list[index2];
                _list[index2] = temp;
            }
        }  
    }
}
