using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[][] terrain =
        {
            new[] { 1, 4, 3, 1, 3, 2 },
            new[] { 3, 2, 1, 3, 2, 4 },
            new[] { 2, 3, 3, 2, 3, 1 }
        };

        Console.WriteLine("Terrain Height Map:");
        PrintGrid(terrain);

        int trapped = TrapRainWater(terrain);

        Console.WriteLine($"\nTotal Rainwater Trapped: {trapped}");
    }

    public static int TrapRainWater(int[][] heightMap)
    {
        int m = heightMap.Length;
        int n = heightMap[0].Length;

        bool[,] visited = new bool[m, n];
        var pq = new PriorityQueue<(int r, int c, int h), int>();

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (r == 0 || r == m - 1 || c == 0 || c == n - 1)
                {
                    pq.Enqueue((r, c, heightMap[r][c]), heightMap[r][c]);
                    visited[r, c] = true;
                }
            }
        }

        int total = 0;
        int[][] dirs = new int[][] {
            new[] {1, 0}, new[] {-1, 0},
            new[] {0, 1}, new[] {0, -1}
        };

        while (pq.Count > 0)
        {
            var cell = pq.Dequeue();
            int r = cell.r;
            int c = cell.c;
            int h = cell.h;

            foreach (var d in dirs)
            {
                int nr = r + d[0];
                int nc = c + d[1];

                if (nr < 0 || nr >= m || nc < 0 || nc >= n || visited[nr, nc])
                    continue;

                visited[nr, nc] = true;

                int nh = heightMap[nr][nc];

                if (nh < h)
                    total += h - nh;

                int newHeight = Math.Max(nh, h);
                pq.Enqueue((nr, nc, newHeight), newHeight);
            }
        }

        return total;
    }

    public static void PrintGrid(int[][] grid)
    {
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
                Console.Write(grid[r][c] + " ");
            Console.WriteLine();
        }
    }
}
