namespace _05CombinationsWithoutRepetitions
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int set = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var vector = new int[k];
            Combine(set, vector, 0, 1);
        }

        static void Combine(int set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Print(vector);
                return;
            }

            for (int i = border; i <= set; i++)
            {
                vector[index] = i;
                Combine(set, vector, index + 1, i + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr).Trim());
        }
    }
}
