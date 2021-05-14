namespace _09QuickSort
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Sort(numbers, 0, numbers.Length - 1);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

        private static void Sort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivot = Rearrange(numbers, startIndex, endIndex);

            Sort(numbers, startIndex, pivot - 1);
            Sort(numbers, pivot + 1, endIndex);
        }

        private static int Rearrange(int[] numbers, int pivotIndex, int endIndex)
        {
            if (pivotIndex >= endIndex)
            {
                return pivotIndex;
            }

            int start;
            int end;

            while (true)
            {
                start = pivotIndex + 1;
                end = endIndex;

                for (int i = pivotIndex + 1; i <= endIndex; i++)
                {
                    if (numbers[i] >= numbers[pivotIndex])
                    {
                        break;
                    }

                    if (start == endIndex)
                    {
                        break;
                    }

                    start++;
                }

                for (int i = endIndex; i > pivotIndex; i--)
                {
                    if (numbers[i] < numbers[pivotIndex])
                    {
                        break;
                    }

                    if (end == pivotIndex)
                    {
                        break;
                    }

                    end--;
                }

                if (start >= end)
                {
                    break;
                }

                Swap(numbers, start, end);
            }

            Swap(numbers, pivotIndex, end);
            return end;
        }

        private static void Swap(int[] numbers, int start, int end)
        {
            int temp = numbers[start];
            numbers[start] = numbers[end];
            numbers[end] = temp;
        }
    }
}
