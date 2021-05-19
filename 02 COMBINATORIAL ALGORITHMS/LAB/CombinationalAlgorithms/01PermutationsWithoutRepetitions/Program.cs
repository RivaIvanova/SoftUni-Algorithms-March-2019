namespace _01PermutationsWithoutRepetitions
{
    using System;

    class Program
    {
        static string[] set;
        static bool[] isUsed;
        static string[] permutated;
        static void Main(string[] args)
        {
            set = Console.ReadLine().Split();

            isUsed = new bool[set.Length];
            permutated = new string[set.Length];

            Permute(0);
            SwapPermute(0);
        }

        private static void Permute(int index)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", permutated));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!isUsed[i])
                    {
                        isUsed[i] = true;
                        permutated[index] = set[i];
                        Permute(index + 1);
                        isUsed[i] = false;
                    }
                }
            }
        }

        private static void SwapPermute(int index)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
            }
            else
            {
                SwapPermute(index + 1);

                for (int i = index + 1; i < set.Length; i++)
                {
                    Swap(set, index, i);
                    SwapPermute(index + 1);
                    Swap(set, index, i);
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
