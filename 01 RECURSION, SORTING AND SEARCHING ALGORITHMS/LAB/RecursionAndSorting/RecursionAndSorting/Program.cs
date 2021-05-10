namespace _01RecursiveArraySum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = Sum(numbers, 0);

            Console.WriteLine(result);
        }

        static int Sum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
