namespace _01ReverseArray
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Reverse(input, 0, input.Length - 1);
            Print(input);
        }

        private static void Print(int[] input)
        {
            Console.WriteLine(string.Join(" ", input).Trim());
        }

        private static void Reverse(int[] input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            Swap(input, start, end);
            Reverse(input, start + 1, end - 1);
        }

        private static void Swap(int[] input, int start, int end)
        {
            int temp = input[start];
            input[start] = input[end];
            input[end] = temp;
        }
    }
}
