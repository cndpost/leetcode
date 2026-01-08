
//page 249, Drill 5. Find minimum starting Value so that running total never below 1
using System;
public static class Ace_coding
{
    public static int min_positive_baseline(List<int> nums)
    {
        int min_p = 0;
        int curr = 0;
        foreach (int x in nums)
        {
            curr += x;  //running total from begining
            min_p = Math.Min(min_p, curr);  //global min of running totals
        }

        return 1-min_p;

    }

}

public class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>() { -1, 0, 2, 3, -4, -5, 0, 1, 2, 3, 4 };

        int best = Ace_coding.min_positive_baseline(nums);
        Console.WriteLine("best is : {0}", best);
    }
}