

using System;
public static class ace_coding { 
    public static int Max_continuous_segment(List<int> nums)
    {
            int best = nums[0];
            int curr = nums[0];
            foreach(int x in nums)
            {
                curr = Math.Max(curr+x, x);
                best = Math.Max(best, curr);
            }

            return best;

    }
   
}

public class Program
{ 
    public static void Main()
    {
        List<int> nums = new List<int>() { -1, 0, 2, 3, -4, -5, 0, 1, 2, 3, 4};

        int best = ace_coding.Max_continuous_segment(nums);
        Console.WriteLine("best is : {0}",best);
    }
}