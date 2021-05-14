namespace _08MergeSort
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

            SplitArray(numbers, 0, numbers.Length - 1);
        }

        private static void SplitArray(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            SplitArray(numbers, startIndex, middleIndex);
            SplitArray(numbers, middleIndex + 1, endIndex);

            MergeArray(numbers, startIndex, middleIndex, endIndex);
        }

        private static void MergeArray(int[] numbers, int startIndex, int middleIndex, int endIndex)
        {
            int[] storedArray = new int[numbers.Length];

            if (numbers[middleIndex] <= numbers[middleIndex + 1])
            {
                return;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                storedArray[i] = numbers[i];
            }

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {

                if (leftIndex > middleIndex)
                {
                    numbers[i] = storedArray[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    numbers[i] = storedArray[leftIndex++];
                }
                else if (storedArray[leftIndex] <= storedArray[rightIndex])
                {
                    numbers[i] = storedArray[leftIndex++];
                }
                else
                {
                    numbers[i] = storedArray[rightIndex++];
                }
            }
        }
    }
}
