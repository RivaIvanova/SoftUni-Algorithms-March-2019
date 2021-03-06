namespace _05GeneratingCombinations
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int count = int.Parse(Console.ReadLine());

            int[] vector = new int[count];

            GenCombs(set, vector, 0, 0);
        }

        static void GenCombs(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set, vector, index + 1, i + 1);
                }
            }
        }
        static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
