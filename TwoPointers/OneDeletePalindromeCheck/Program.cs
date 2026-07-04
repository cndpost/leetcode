using System;

class Program
{
    static void Main()
    {
        string s = "abca";

        Console.WriteLine("Input string: " + s);

        bool result = ValidPalindrome(s);

        Console.WriteLine("Can become palindrome by deleting at most one character: " + result);
    }

    public static bool ValidPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return IsPalindrome(s, left + 1, right) ||
                       IsPalindrome(s, left, right - 1);
            }
            left++;
            right--;
        }

        return true;
    }

    private static bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }
        return true;
    }
}
