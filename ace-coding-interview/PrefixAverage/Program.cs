
//page 249, Drill 6. Prefix average calculator
using System;
public static class Ace_coding
{
    public static List<int> PrefixAverage(List<int> nums)
    {
        
        int curr = 0;
        int N = 0;
        List<int> ret = new List<int>();
        foreach (int x in nums)
        {
            curr += x;  //running total from begining
            N++;
            ret.Add( (int)(curr)/N);  //global min of running totals
        }

        return ret;

    }

}

public class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>() { -1, 0, 2, 3, -4, -5, 0, 1, 2, 3, 4 };

        List<int> ave = Ace_coding.PrefixAverage(nums);
        int N = nums.Count;
        for (int i = 0; i < N; i++) { 
        Console.WriteLine("Average at {0} is : {1}", i, ave[i]);
         }
    }
}