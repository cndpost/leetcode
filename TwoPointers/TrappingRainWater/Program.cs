using System;

class Program
{
    static void Main()
    {
        int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

        Console.WriteLine("Wall heights:");
        Console.WriteLine("[" + string.Join(", ", height) + "]");

        int result = TrapRainWater(height);

        Console.WriteLine("\nTotal trapped rain water: " + result);
    }

    public static int TrapRainWater(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int leftMax = 0;
        int rightMax = 0;
        int total = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    total += leftMax - height[left];

                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    total += rightMax - height[right];

                right--;
            }
        }

        return total;
    }
}
