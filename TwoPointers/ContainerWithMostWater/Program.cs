using System;

class Program
{
    static void Main()
    {
        int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

        Console.WriteLine("Heights:");
        Console.WriteLine("[" + string.Join(", ", height) + "]");

        int result = MaxWater(height);

        Console.WriteLine("\nMaximum water container area: " + result);
    }

    public static int MaxWater(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int h = Math.Min(height[left], height[right]);
            int w = right - left;
            int area = h * w;

            if (area > maxArea)
                maxArea = area;

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}
