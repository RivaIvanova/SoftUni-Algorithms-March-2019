namespace _02RecursiveFactorial
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var result = Factorial(number);

            Console.WriteLine(result);
        }

        static long Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
