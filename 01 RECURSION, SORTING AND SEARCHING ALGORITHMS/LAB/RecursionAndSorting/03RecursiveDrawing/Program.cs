namespace _03RecursiveDrawing
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            PrintFigure(number);
        }

        static void PrintFigure(int number)
        {
            if (number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));

            PrintFigure(number - 1);

            Console.WriteLine(new string('#', number));
        }
    }
}
