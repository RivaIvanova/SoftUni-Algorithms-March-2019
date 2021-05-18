namespace _08Searching
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 64, 60, 29, 34, 25, 12, 22, 11, 99, 90 };

            BinarySearch algorithm = new BinarySearch();

            int index = algorithm.Search(arr, 60);
            Console.WriteLine(index);
        }

        public class LinearSearch
        {
            public int Search(int[] array, int number)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == number)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public class BinarySearch
        {
            // Array should be sorted
            public int Search(int[] array, int number)
            {
                int low = 0;
                int high = array.Length - 1;

                while (low <= high)
                {
                    int middle = (low + high) / 2;

                    if (number < array[middle])
                    {
                        high = middle - 1;
                    }
                    else if (number > array[middle])
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        return middle;
                    }
                }

                return -1;
            }
        }
    }
}
