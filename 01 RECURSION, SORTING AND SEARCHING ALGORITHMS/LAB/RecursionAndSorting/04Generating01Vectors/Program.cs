namespace _04Generating01Vectors
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var vectorLength = int.Parse(Console.ReadLine());
                
            int[] vector = new int[vectorLength];

            Gen01(0, vector);
        }

        static void Gen01(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;

                    Gen01(index + 1, vector);
                }
            }
        }

        static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(string.Empty, vector));
        }
    }
}
