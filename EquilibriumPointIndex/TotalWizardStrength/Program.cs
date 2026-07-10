using System;
using System.Collections.Generic;

// brute force: O(n*n)
// consider each contribution: O(n)
// 

class Program
{
    static void Main(string[] args)
    {
        int[] s = { 3, 1, 2 };

        Console.WriteLine("Strength Array:");
        foreach (var x in s)
            Console.Write(x + " ");
        Console.WriteLine();

        long result = TotalGroupStrength(s);

        Console.WriteLine($"\nTotal Group Strength of All Subarrays: {result}");
    }

    public static long TotalGroupStrength(int[] s)
    {
        int n = s.Length;

        long[] prefix = new long[n + 1];
        long[] prefix2 = new long[n + 2];

        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + s[i];

        for (int i = 0; i <= n; i++)
            prefix2[i + 1] = prefix2[i] + prefix[i];

        int[] left = new int[n];
        int[] right = new int[n];

        var st = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            while (st.Count > 0 && s[st.Peek()] > s[i])
                st.Pop();
            left[i] = st.Count == 0 ? -1 : st.Peek();
            st.Push(i);
        }

        st.Clear();

        for (int i = n - 1; i >= 0; i--)
        {
            while (st.Count > 0 && s[st.Peek()] >= s[i])
                st.Pop();
            right[i] = st.Count == 0 ? n : st.Peek();
            st.Push(i);
        }

        long total = 0;

        for (int i = 0; i < n; i++)
        {
            int L = left[i];
            int R = right[i];

            long leftCount = i - L;
            long rightCount = R - i;

            long leftSum = prefix2[i + 1] - prefix2[L + 1];
            long rightSum = prefix2[R + 1] - prefix2[i + 1];

            long contribution = s[i] * (rightSum * leftCount - leftSum * rightCount);

            total += contribution;
        }

        return total;
    }
}
