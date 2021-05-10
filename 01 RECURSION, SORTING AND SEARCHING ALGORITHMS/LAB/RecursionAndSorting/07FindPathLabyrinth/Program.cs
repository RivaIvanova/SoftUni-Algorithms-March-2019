namespace _07FindPathLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[,] matrix;
        private static List<char> path = new List<char>();
        private static List<int[]> visitedCells = new List<int[]>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            Solve(rows, cols);
        }

        private static void Solve(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string labyrinth = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = labyrinth[j];
                }
            }

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                Console.Write(string.Join("", path.Skip(1)));
                Console.WriteLine();
            }
            else if (!IsVisited(row, col) && !IsWall(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsInBounds(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static bool IsExit(int row, int col)
        {
            if (matrix[row, col] == 'e')
            {
                return true;
            }

            return false;
        }

        private static bool IsVisited(int row, int col)
        {
            if (visitedCells.Any(x => x[0] == row && x[1] == col))
            {
                return true;
            }

            return false;
        }

        private static bool IsWall(int row, int col)
        {
            if (matrix[row, col] == '*')
            {
                return true;
            }

            return false;
        }

        private static void Mark(int row, int col)
        {
            visitedCells.Add(new int[2] { row, col });
        }

        private static void Unmark(int row, int col)
        {
            var cellToRemove = visitedCells.FindLast(x => x[0] == row && x[1] == col);
            visitedCells.Remove(cellToRemove);
        }
    }
}
