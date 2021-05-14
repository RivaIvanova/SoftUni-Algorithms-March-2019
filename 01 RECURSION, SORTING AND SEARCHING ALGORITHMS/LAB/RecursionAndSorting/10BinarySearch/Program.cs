namespace _10BinarySearch
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

            var key = int.Parse(Console.ReadLine());

            var index = BinarySearch(numbers, key);
            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] numbers, int key)
        {
            int low = 0;
            int high = numbers.Length - 1;

            while (low <= high)
            {
                int middle = (low + high) / 2;

                if (key < numbers[middle])
                {
                    high = middle - 1;
                }
                else if (key > numbers[middle])
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
