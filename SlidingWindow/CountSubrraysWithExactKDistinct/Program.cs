using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 2, 1, 2, 3 };
        int k = 2;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        int result = SubarraysWithKDistinct(nums, k);

        Console.WriteLine("\nTotal subarrays with exactly K distinct integers:");
        Console.WriteLine(result);
    }

    public static int SubarraysWithKDistinct(int[] nums, int k)
    {
        return AtMostK(nums, k) - AtMostK(nums, k - 1);
    }

    private static int AtMostK(int[] nums, int k)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int left = 0;
        int count = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            int val = nums[right];
            if (!freq.ContainsKey(val))
                freq[val] = 0;
            freq[val]++;

            while (freq.Count > k)
            {
                int leftVal = nums[left];
                freq[leftVal]--;
                if (freq[leftVal] == 0)
                    freq.Remove(leftVal);
                left++;
            }

            count += right - left + 1;
        }

        return count;
    }
}
