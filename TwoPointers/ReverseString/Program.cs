using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Testing ReverseInPlace:");

        string[] tests = {
            "hello",
            "racecar",
            "C# is fun",
            "",
            "a"
        };

        foreach (var t in tests)
        {
            string reversed = ReverseInPlace(t);
            Console.WriteLine($"Original: '{t}'  →  Reversed: '{reversed}'");
        }
    }

    public static string ReverseInPlace(string s)
    {
        if (s == null) return null;

        char[] arr = s.ToCharArray();
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            left++;
            right--;
        }

        return new string(arr);
    }
}
