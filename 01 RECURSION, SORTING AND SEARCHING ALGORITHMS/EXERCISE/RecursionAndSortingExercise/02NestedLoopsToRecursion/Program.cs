namespace _02NestedLoopsToRecursion
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];

            Solve(0, array);
        }

        private static void Solve(int currentIndex, int[] array)
        {
            if (currentIndex >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array).Trim());
            }
            else
            {
                for (int i = 1; i <= array.Length; i++)
                {
                    array[currentIndex] = i;

                    Solve(currentIndex + 1, array);
                }
            }
        }
    }
}
