using System;

class Program
{
    static void Main(string[] args)
    {
        int[] A = { 1, 3 };
        int[] B = { 2 };

        double median = FindMedianSortedArrays(A, B);

        Console.WriteLine("=== Median of Two Sorted Arrays Test ===");
        Console.WriteLine("A: " + string.Join(", ", A));
        Console.WriteLine("B: " + string.Join(", ", B));
        Console.WriteLine("Median: " + median);
    }

    public static double FindMedianSortedArrays(int[] A, int[] B)
    {
        if (A.Length > B.Length)
            return FindMedianSortedArrays(B, A);

        int m = A.Length, n = B.Length;
        int totalLeft = (m + n + 1) / 2;

        int left = 0, right = m;

        while (left <= right)
        {
            int i = (left + right) / 2;
            int j = totalLeft - i;

            int Aleft = (i == 0) ? int.MinValue : A[i - 1];
            int Aright = (i == m) ? int.MaxValue : A[i];

            int Bleft = (j == 0) ? int.MinValue : B[j - 1];
            int Bright = (j == n) ? int.MaxValue : B[j];

            if (Aleft <= Bright && Bleft <= Aright)
            {
                if ((m + n) % 2 == 1)
                    return Math.Max(Aleft, Bleft);

                return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
            }
            else if (Aleft > Bright)
            {
                right = i - 1;
            }
            else
            {
                left = i + 1;
            }
        }

        return 0;
    }
}
