using System;
using System.Collections.Generic;

public class AhoCorasick
{
    private class Node
    {
        public Dictionary<char, Node> Children = new Dictionary<char, Node>();
        public Node Fail;
        public List<string> Output = new List<string>();
    }

    private Node root;

    public void BuildTrie(List<string> patterns)
    {
        root = new Node();
        foreach (var pattern in patterns)
        {
            var current = root;
            foreach (var c in pattern)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new Node();
                }
                current = current.Children[c];
            }
            current.Output.Add(pattern);
        }

        BuildFailureLinks();
    }

    private void BuildFailureLinks()
    {
        var queue = new Queue<Node>();
        foreach (var child in root.Children.Values)
        {
            child.Fail = root;									// how to prove it meets the definition, it is largest suffix, also found as a root level prefix 
            queue.Enqueue(child);
        }

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var kvp in current.Children)
            {
                var c = kvp.Key;
                var child = kvp.Value;
                var fail = current.Fail; //node that holds current longest suffix and is also a prefix node 
                while (fail != null && !fail.Children.ContainsKey(c))  //found a prefix node that quals to current longest suffix, but it still cannot extend to c 
                {
                    fail = fail.Fail;									//current.Children[c].Fail  = current.Fail.Fail; further remove the first ch of the longest suffix,  recursively for shorter suffix of parent
                }
                if (fail == null)		// no prefix node exist that equals to current longest suffix. directly go back to root 
                {
                    child.Fail = root;									// current.Children[c].Fail =  root, how to prove it meets the definition
                }
                else
                {														//the found prefix node able to extend the next step by absorbing the incomming c
                    child.Fail = fail.Children[c];						//grow failure chain extended by c, e.g, current.Children[c].Fail = current.Fail.Children[c];
                    child.Output.AddRange(child.Fail.Output);			// current.Children[c].Output.AddRange(current.Fail.Children[c].Output)
                }
                queue.Enqueue(child);
            }
        }
    }

    public List<(int, List<string>)> Search(string text)
    {
        var current = root;
        var results = new List<(int, List<string>)>();

        for (int i = 0; i < text.Length; i++)
        {
            while (current != null && !current.Children.ContainsKey(text[i]))
            {
                current = current.Fail;
            }
            if (current == null)
            {
                current = root;
                continue;
            }
            current = current.Children[text[i]];
            if (current.Output.Count > 0)
            {
                results.Add((i, new List<string>(current.Output)));
            }
        }
        return results;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var patterns = new List<string> { "he", "she", "his", "hers" };
        var text = "ushers";
        var ac = new AhoCorasick();
        ac.BuildTrie(patterns);
        var matches = ac.Search(text);

        foreach (var match in matches)
        {
            Console.WriteLine($"Pattern found at index {match.Item1}: {string.Join(", ", match.Item2)}");
        }
    }
} 