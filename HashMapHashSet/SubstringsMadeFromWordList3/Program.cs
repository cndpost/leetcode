using System;
using System.Collections.Generic;

//Version B — Substring With Concatenation of All Words (LeetCode 30)
//You want:

//All words in L

//Used exactly once

//Concatenated together

//In any order

//No gaps

//Return starting indices in S

// use two dictionary, word frequency, and substring seen frequency.  skip those substring that
// is not a word in word list

// double loop: all possible substring, jump by word length; loop all word matches; record the start index
// if all words matched

class Program
{
    public static List<int> FindSubstringConcatenation(string s, List<string> words)
    {
        var result = new List<int>();
        if (words.Count == 0) return result;

        int wordLength = words[0].Length;
        int totalWords = words.Count;
        int windowLength = wordLength * totalWords;

        // Frequency map of words
        var wordCount = new Dictionary<string, int>();
        foreach (var w in words)
        {
            if (!wordCount.ContainsKey(w))
                wordCount[w] = 0;
            wordCount[w]++;
        }

        // Slide over S
        for (int i = 0; i <= s.Length - windowLength; i++)
        {
            var seen = new Dictionary<string, int>();
            int j = 0;

            while (j < totalWords)
            {
                int start = i + j * wordLength;
                string sub = s.Substring(start, wordLength);

                if (!wordCount.ContainsKey(sub))
                    break;

                if (!seen.ContainsKey(sub))
                    seen[sub] = 0;
                seen[sub]++;

                if (seen[sub] > wordCount[sub]) //respect the word frequency in words, not check if >1
                    break;

                j++;
            }

            if (j == totalWords)
                result.Add(i);
        }

        return result;
    }

    static void Main(string[] args)
    {
        string S = "barfoothefoobarmanfoo";
        List<string> L = new List<string> { "foo", "bar", "the", "man" };

        var indices = FindSubstringConcatenation(S, L);

        Console.WriteLine("Input String: " + S);
        Console.WriteLine("Words List: " + string.Join(", ", L));
        Console.WriteLine();
        Console.WriteLine("Concatenation Version (B):");
        Console.WriteLine("Starting Indices:");

        if (indices.Count == 0)
        {
            Console.WriteLine("No valid concatenation found.");
        }
        else
        {
            foreach (var idx in indices)
                Console.WriteLine(idx);
        }
    }
}
