using System;
using System.Linq;


// the trick is to know we have a minimum value of Max(num[]) and a max value of Sum(num[])
// and now we do a binary search to find a smalles possible value in between that it is possible
// to have all subarrays' sum less or equal to it. 
// the posibility check is done by accumulating subarray to its largest until it > the test value,
// then loop next subarray from nex element. If subarray counts > k and we have not finished, then
// we are false and infeasible 

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 7, 2, 5, 10, 8 };
        int k = 2;

        int result = SplitArrayMinLargestSum(nums, k);

        Console.WriteLine("=== Split Array Largest Sum Test ===");
        Console.WriteLine("nums: " + string.Join(", ", nums));
        Console.WriteLine("k = " + k);
        Console.WriteLine("Smallest possible largest subarray sum: " + result);
    }

    public static int SplitArrayMinLargestSum(int[] nums, int k)
    {
        int left = nums.Max();
        int right = nums.Sum();

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanSplit(nums, k, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private static bool CanSplit(int[] nums, int k, int maxAllowed)
    {
        int subarrayCount = 1;
        int currentSum = 0;

        foreach (int num in nums)
        {
            if (currentSum + num > maxAllowed)
            {
                subarrayCount++;
                currentSum = num;

                if (subarrayCount > k)
                    return false;
            }
            else
            {
                currentSum += num;
            }
        }

        return true;
    }
}
