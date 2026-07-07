using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//matches exactly one of the words in L

//appears only once in the entire string S

//return the starting indices of those unique matches

//This is essentially unique substring matching

//the trick is to use two dict, one for word count,
// one for substring index for matched word
//and  use s.IndexOf function

// in this example, 'the' in index 6 and 'man' in index 15 only showed once. So answer is 6, 15

class Program
{
    static void Main()
    {
        string S = "barfoothefoobarmanfoo";
        List<string> L = new List<string> { "foo", "bar", "the", "man" };

        Console.WriteLine("String S: " + S);
        Console.WriteLine("Words L: " + string.Join(", ", L));

        var indices = UniqueWordMatches(S, L);

        Console.WriteLine("\nUnique matches (start indices):");
        foreach (int idx in indices)
            Console.WriteLine(idx);
    }

    public static List<int> UniqueWordMatches(string s, List<string> words)
    {
        Dictionary<string, int> count = new Dictionary<string, int>();
        Dictionary<string, List<int>> positions = new Dictionary<string, List<int>>();

        foreach (string w in words)
        {
            count[w] = 0;
            positions[w] = new List<int>();
        }

        foreach (string w in words)
        {
            int index = 0;
            while (index <= s.Length - w.Length)
            {
                int found = s.IndexOf(w, index, StringComparison.Ordinal);
                if (found == -1)
                    break;

                count[w]++;
                positions[w].Add(found);
                index = found + 1;
            }
        }

        List<int> result = new List<int>();

        foreach (var kv in count)
        {
            if (kv.Value == 1)
                result.Add(positions[kv.Key][0]);
        }

        result.Sort();
        return result;
    }
}
