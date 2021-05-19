namespace _07NChooseKCount
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int result = Binomial(n, k);
            Console.WriteLine(result);
        }

        private static int Binomial(int n, int k)
        {
            if (k > n)
            {
                return 1;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }

            return Binomial(n - 1, k - 1) + Binomial(n - 1, k);
        }
    }
}
