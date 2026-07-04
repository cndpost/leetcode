using System;

class Program
{
    static void Main()
    {
        int[] nums1 = { 1, 3, 5, 0, 0, 0 };
        int[] nums2 = { 2, 4, 6 };

        int m = 3; // number of valid elements in nums1
        int n = 3; // number of elements in nums2

        Console.WriteLine("Before merge:");
        Console.WriteLine("nums1: [" + string.Join(", ", nums1) + "]");
        Console.WriteLine("nums2: [" + string.Join(", ", nums2) + "]");

        MergeSorted(nums1, m, nums2, n);

        Console.WriteLine("\nAfter merge:");
        Console.WriteLine("nums1: [" + string.Join(", ", nums1) + "]");
    }

    public static void MergeSorted(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1;
        int j = n - 1;
        int k = m + n - 1;

        while (j >= 0)
        {
            if (i >= 0 && nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }
    }
}

