namespace _07Sorting
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 64, 60, 29, 34, 25, 12, 22, 11, 99, 90 };

            BubbleSort algorithm = new BubbleSort();
            var array = algorithm.Sort(arr);
            Print(array);
        }

        public class InsertionSort
        {
            public int[] Sort(int[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    var current = i;
                    var previous = i - 1;
                    var key = array[current];

                    while (previous >= 0 && array[previous] > key)
                    {
                        array[current--] = array[previous--];
                    }
                    array[++previous] = key;
                }

                return array;
            }
        }

        public class BubbleSort
        {
            public int[] Sort(int[] array)
            {
                bool issorted = false;

                while (!issorted)
                {
                    var corrected = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        var current = i;
                        var next = i + 1;

                        if (next < array.Length && array[current] > array[next])
                        {
                            Swap(array, current, next);
                            corrected++;
                            issorted = false;
                        }

                        if (next == array.Length && corrected == 0)
                        {
                            issorted = true;
                        }
                    }
                }

                return array;
            }
        }

        public class ShellSort
        {
            public int[] Sort(int[] array)
            {
                // TODO

                return array;
            }
        }

        public class MergeSort
        {
            public int[] Sort(int[] array)
            {
                Split(array, 0, array.Length - 1);
                return array;
            }

            public void Split(int[] array, int start, int end)
            {
                if (start == end)
                {
                    return;
                }

                var middle = (start + end) / 2;

                Split(array, start, middle);
                Split(array, middle + 1, end);

                Merge(array, start, middle, end);
            }

            public void Merge(int[] array, int start, int middle, int end)
            {
                if (array[middle] <= array[middle + 1])
                {
                    return;
                }

                int[] storedArray = new int[array.Length];

                for (int i = start; i <= end; i++)
                {
                    storedArray[i] = array[i];
                }

                int leftIndex = start;
                int rightIndex = middle + 1;

                for (int i = start; i <= end; i++)
                {
                    if (leftIndex > middle)
                    {
                        array[i] = storedArray[rightIndex++];
                    }
                    else if (rightIndex > end)
                    {
                        array[i] = storedArray[leftIndex++];
                    }
                    else if (storedArray[leftIndex] <= storedArray[rightIndex])
                    {
                        array[i] = storedArray[leftIndex++];
                    }
                    else
                    {
                        array[i] = storedArray[rightIndex++];
                    }
                }
            }
        }

        public class QuickSort
        {
            public void Sort(int[] array, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                // Pivot is always the middle of the array
                int pivot = Rearrange(array, start, end);

                Sort(array, start, pivot - 1);
                Sort(array, pivot + 1, end);
            }

            private int Rearrange(int[] array, int start, int end)
            {
                int pivot = (start + end) / 2;

                if (pivot >= end)
                {
                    return pivot;
                }

                int pivotValue = array[pivot];

                while (true)
                {
                    while (array[start] < pivotValue)
                    {
                        if (start == pivot)
                        {
                            pivot = end;
                            break;
                        }

                        start++;
                    }

                    while (array[end] > pivotValue)
                    {
                        if (end == pivot)
                        {
                            pivot = start;
                            break;
                        }

                        end--;
                    } 

                    if (start >= end)
                    {
                        return pivot;
                    }

                    Swap(array, start, end);
                }
            }
        }

        public class BucketSort
        {
            public int[] Sort(int[] array)
            {
                var sortedArray = new List<int>();

                int bucketsCount = 10;
                List<int>[] buckets = new List<int>[bucketsCount];

                for (int i = 0; i < bucketsCount; i++)
                {
                    buckets[i] = new List<int>();
                }

                for (int i = 0; i < array.Length; i++)
                {
                    int current = (array[i] / bucketsCount);
                    buckets[current].Add(array[i]);
                }

                InsertionSort ins = new InsertionSort();

                foreach (var arr in buckets)
                {
                    var sorted = ins.Sort(arr.ToArray());
                    sortedArray.AddRange(sorted);
                }

                return sortedArray.ToArray();
            }
        }

        public static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
