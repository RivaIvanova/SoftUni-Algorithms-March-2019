namespace _06ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[,] matrix;
        private static List<int[]> visitedCells = new List<int[]>();
        private static ICollection<Area> areas = new HashSet<Area>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            FillMatrix(rows, cols);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!IsVisited(r, c) && !IsWall(r, c))
                    {
                        var area = new Area(r, c);
                        areas.Add(area);
                        FindAreas(r, c, area);
                    }
                }
            }

            PrintSolution();
        }

        class Area
        {
            private readonly int row;
            private readonly int col;

            public Area(int row, int col)
            {
                this.row = row;
                this.col = col;
            }

            public int[] Position => new int[2] { row, col };

            public int Size { get; set; }
        }

        private static void FillMatrix(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string area = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = area[j];
                }
            }
        }

        private static void FindAreas(int row, int col, Area area)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            area.Size++;

            if (!IsVisited(row, col) && !IsWall(row, col))
            {
                Mark(row, col);
                FindAreas(row, col + 1, area);
                FindAreas(row + 1, col, area);
                FindAreas(row, col - 1, area);
                FindAreas(row - 1, col, area);
            }
            else
            {
                area.Size--;
            }
        }

        private static void PrintSolution()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");
            int index = 0;
            foreach (var area in areas.OrderByDescending(x => x.Size).ThenBy(x => x.Position[0]).ThenBy(x => x.Position[1]))
            {
                Console.WriteLine($"Area #{++index} at ({area.Position[0]}, {area.Position[1]}), size: {area.Size}");
            }
        }

        private static bool IsInBounds(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
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
    }
}
