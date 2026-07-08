using System;

class Program
{
    static void Main(string[] args)
    {
        char[][] matrix =
        {
            new[] {'1','0','1','0','0'},
            new[] {'1','0','1','1','1'},
            new[] {'1','1','1','1','1'},
            new[] {'1','0','0','1','0'}
        };

        int result = MaximalRectangle(matrix);

        Console.WriteLine("=== Maximal Rectangle of 1's Test ===");
        PrintMatrix(matrix);
        Console.WriteLine($"Largest Area: {result}");
    }

    static void PrintMatrix(char[][] matrix)
    {
        Console.WriteLine("Matrix:");
        foreach (var row in matrix)
            Console.WriteLine("  " + string.Join(" ", row));
    }

    public static int MaximalRectangle(char[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return 0;

        int m = matrix.Length;
        int n = matrix[0].Length;
        int[] heights = new int[n];
        int maxArea = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == '1')
                    heights[j] += 1;
                else
                    heights[j] = 0;
            }

            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }

    public static int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;

        for (int i = 0; i <= n; i++)
        {
            int h = (i == n) ? 0 : heights[i];

            while (stack.Count > 0 && h < heights[stack.Peek()])
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            stack.Push(i);
        }

        return maxArea;
    }
}
