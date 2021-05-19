namespace _03VariationsWithoutRepetitions
{
    using System;

    class Program
    {
        static int set;
        static string[] elements;
        static bool[] isUsed;
        static string[] variations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            set = int.Parse(Console.ReadLine());

            variations = new string[set];
            isUsed = new bool[elements.Length];

            Vary(0);
        }

        private static void Vary(int index)
        {
            if (index >= set)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!isUsed[i])
                    {
                        isUsed[i] = true;
                        variations[index] = elements[i];
                        Vary(index + 1);
                        isUsed[i] = false;
                    }
                }
            }
        }
    }
}
