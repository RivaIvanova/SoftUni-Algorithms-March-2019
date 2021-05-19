namespace _02PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static string[] set;

        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
            }
            else
            {
                HashSet<string> swapped = new HashSet<string> { set[index] };
                Permute(index + 1);

                for (int i = index + 1; i < set.Length; i++)
                {
                    if (!swapped.Contains(set[i]))
                    {
                        swapped.Add(set[i]);
                        Swap(set, index, i);
                        Permute(index + 1);
                        Swap(set, index, i);
                    }
                }
            }
        }

        private static void Swap(string[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
