namespace _04TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int stepsTaken = 0;
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        static void Main(string[] args)
        {
            var disksCount = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, disksCount).Reverse();
            source = new Stack<int>(range);

            PrintRods();
            Move(disksCount, source, destination, spare);
        }

        private static void Move(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 0)
            {
                return;
            }
            else
            {
                Move(bottomDisk - 1, source, spare, destination);

                stepsTaken++;
                var disk = source.Pop();
                destination.Push(disk);
                Console.WriteLine($"Step # {stepsTaken}: Moved disk {bottomDisk}");
                PrintRods();

                Move(bottomDisk - 1, spare, destination, source);
            }
        }


        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}
