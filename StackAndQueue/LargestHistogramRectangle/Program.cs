using System;

//trick: maintain index stack when height keeps going. Calculate area and maintain max when height goes down 
// 
class Program
{
    static void Main(string[] args)
    {
        int[] heights = { 2, 1, 5, 6, 2, 3 };

        int result = LargestRectangleArea(heights);

        Console.WriteLine("=== Largest Rectangle in Histogram Test ===");
        Console.WriteLine("Heights: " + string.Join(", ", heights));
        Console.WriteLine("Max Area: " + result);
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
