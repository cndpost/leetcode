using System;
using System.Collections.Generic;
using System.Linq;

//Find substrings that contain each word exactly once but not necessarily adjacent

//Each word must appear exactly once

//Order does not matter

//They do not need to be adjacent

//The substring is the smallest range covering all unique occurrences

class Program
{
    public static (int start, int end, string substring) FindSubstringEachWordOnce(string s, List<string> words)
    {
        // Count occurrences of each word in S
        var occurrences = new Dictionary<string, List<int>>();

        foreach (var word in words)
        {
            occurrences[word] = new List<int>();

            for (int i = 0; i <= s.Length - word.Length; i++)
            {
                if (s.Substring(i, word.Length) == word)
                    occurrences[word].Add(i);
            }
        }

        // Keep only words that appear exactly once
        var uniqueWords = occurrences
            .Where(kvp => kvp.Value.Count == 1)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value[0]);

        if (uniqueWords.Count == 0)
            return (-1, -1, "");

        // Find smallest window covering all unique occurrences
        int minIndex = uniqueWords.Values.Min();
        int maxIndex = uniqueWords.Values.Max();

        // The substring ends at maxIndex + length of the word that ends there
        // We find which word ends at maxIndex
        int endIndex = maxIndex;
        foreach (var kvp in uniqueWords)
        {
            string w = kvp.Key;
            int idx = kvp.Value;
            if (idx == maxIndex)
            {
                endIndex = maxIndex + w.Length - 1;
                break;
            }
        }

        string result = s.Substring(minIndex, endIndex - minIndex + 1);

        return (minIndex, endIndex, result);
    }

    static void Main(string[] args)
    {
        string S = "barfoothefoobarmanfoo";
        List<string> L = new List<string> { "foo", "bar", "the", "man" };

        var (start, end, substring) = FindSubstringEachWordOnce(S, L);

        Console.WriteLine("Input String: " + S);
        Console.WriteLine("Words List: " + string.Join(", ", L));
        Console.WriteLine();
        Console.WriteLine("Result:");
        Console.WriteLine("Start Index: " + start);
        Console.WriteLine("End Index: " + end);
        Console.WriteLine("Substring: " + substring);
    }
}
