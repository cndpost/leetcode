using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> words = new List<string>
        {
            "eat", "tea", "tan", "ate", "nat", "bat"
        };

        Console.WriteLine("Input words:");
        PrintList(words);

        var groups = GroupAnagrams(words);

        Console.WriteLine("\nAnagram groups:");
        PrintGroups(groups);
    }

    public static List<List<string>> GroupAnagrams(List<string> words)
    {
        Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        foreach (string w in words)
        {
            string key = String.Concat(w.OrderBy(c => c));

            if (!groups.ContainsKey(key))
                groups[key] = new List<string>();

            groups[key].Add(w);
        }

        return groups.Values.ToList();
    }

    public static void PrintList(List<string> list)
    {
        foreach (string s in list)
            Console.Write(s + " ");
        Console.WriteLine();
    }

    public static void PrintGroups(List<List<string>> groups)
    {
        int groupId = 1;
        foreach (var group in groups)
        {
            Console.Write("Group " + groupId + ": ");
            foreach (string s in group)
                Console.Write(s + " ");
            Console.WriteLine();
            groupId++;
        }
    }
}
