using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LabTen
{
    class Sorter
    {
        #region Merge
        public static int[] MergeSort(int[] array)
        {
            int n = array.Length;
            if (n == 1)
                return array;
            int[] left = new int[(int)Math.Ceiling((double)n / 2)];
            int[] right = new int[(int)Math.Floor((double)n / 2)];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }
            for (int i = left.Length; i < n; i++)
            {
                right[i - left.Length] = array[i];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        public static int[] Merge(int[] leftArray, int[] rightArray)
        {
            List<int> left = leftArray.ToList();
            List<int> right = rightArray.ToList();
            List<int> mergedList = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] > right[0])
                {
                    mergedList.Add(right[0]);
                    right.Remove(right[0]);
                }
                else
                {
                    mergedList.Add(left[0]);
                    left.Remove(left[0]);

                }
            }
            while (left.Count > 0)
            {
                mergedList.Add(left[0]);
                left.Remove(left[0]);
            }
            while (right.Count > 0)
            {
                mergedList.Add(right[0]);
                right.Remove(right[0]);
            }
            return mergedList.ToArray();
        }
        #endregion
        #region Heap
        public static int[] HeapSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);

            for (int i = sortedArray.Length / 2 - 1; i >= 0; i--)
                Heapify(sortedArray, sortedArray.Length, i);
            for (int i = sortedArray.Length - 1; i >= 0; i--)
            {
                int temp = sortedArray[0];
                sortedArray[0] = sortedArray[i];
                sortedArray[i] = temp;
                Heapify(sortedArray, i, 0);
            }
            return sortedArray;
        }
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest);
            }
        }
        #endregion
        #region Quick
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high && !isSorted(array))
            {
                int i = Partition(array, low, high);
                QuickSort(array, low, i - 1);
                QuickSort(array, i + 1, high);
            }

        }
        public static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;
            int temp = 0;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;
            return i + 1;
        }
        static bool isSorted(int[] a)
        {
            int i = a.Length - 1;
            if (i <= 0) return true;
            if ((i & 1) > 0) { if (a[i] < a[i - 1]) return false; i--; }
            for (int ai = a[i]; i > 0; i -= 2)
                if (ai < (ai = a[i - 1]) || ai < (ai = a[i - 2])) return false;
            return a[0] <= a[1];
        }
        #endregion
        public static int[] CountingSort(int[] array, int min, int max)
        {
            int[] sortedArray = new int[array.Length];
            int n = array.Length;
            int range = max - min + 1;
            int[] count = new int[range];
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[count[array[i] - min] - 1] = array[i];
                count[array[i] - min]--;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedArray[i];
            }
            return sortedArray;
        }
    }
}