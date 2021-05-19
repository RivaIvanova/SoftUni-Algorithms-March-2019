namespace _05CombinationsWithoutRepetition
{
    using System;

    class Program
    {
        static int set;
        static string[] elements;
        static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            set = int.Parse(Console.ReadLine());

            combinations = new string[set];

            Combine(0, 0);
        }

        private static void Combine(int index, int border)
        {
            if (index >= set)
            {
                Console.WriteLine(string.Join(" ", combinations ));
            }
            else
            {
                for (int i = border; i < elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    Combine(index + 1, i + 1);
                }
            }
        }
    }
}
