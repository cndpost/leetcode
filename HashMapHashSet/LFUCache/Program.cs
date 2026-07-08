using System;
using System.Collections.Generic;

public class LFUCache
{
    private class Node
    {
        public int key;
        public int value;
        public int freq;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
            this.freq = 1;
        }
    }

    private readonly int capacity;
    private int minFreq;

    private readonly Dictionary<int, Node> nodes;
    private readonly Dictionary<int, LinkedList<Node>> freqList;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        nodes = new Dictionary<int, Node>();
        freqList = new Dictionary<int, LinkedList<Node>>();
        minFreq = 0;
    }

    public int Get(int key)
    {
        if (!nodes.ContainsKey(key))
            return -1;

        Node node = nodes[key];
        IncreaseFrequency(node);
        return node.value;
    }

    public void Put(int key, int value)
    {
        if (capacity == 0)
            return;

        if (nodes.ContainsKey(key))
        {
            Node node = nodes[key];
            node.value = value;
            IncreaseFrequency(node);
            return;
        }

        if (nodes.Count == capacity)
            EvictLFU();

        Node newNode = new Node(key, value);
        nodes[key] = newNode;

        if (!freqList.ContainsKey(1))
            freqList[1] = new LinkedList<Node>();

        freqList[1].AddFirst(newNode);
        minFreq = 1;
    }

    private void IncreaseFrequency(Node node)
    {
        int oldFreq = node.freq;
        freqList[oldFreq].Remove(node);

        if (freqList[oldFreq].Count == 0)
        {
            freqList.Remove(oldFreq);
            if (minFreq == oldFreq)
                minFreq++;
        }

        node.freq++;

        if (!freqList.ContainsKey(node.freq))
            freqList[node.freq] = new LinkedList<Node>();

        freqList[node.freq].AddFirst(node);
    }

    private void EvictLFU()
    {
        LinkedList<Node> list = freqList[minFreq];
        Node lruNode = list.Last.Value;

        list.RemoveLast();
        if (list.Count == 0)
            freqList.Remove(minFreq);

        nodes.Remove(lruNode.key);
    }

    public void PrintState(string label)
    {
        Console.WriteLine(label);
        Console.WriteLine("Cache State:");

        foreach (var f in freqList)
        {
            Console.Write($"Freq {f.Key}: ");
            foreach (var node in f.Value)
                Console.Write($"[{node.key}:{node.value}] ");
            Console.WriteLine();
        }

        Console.WriteLine($"minFreq = {minFreq}");
        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        LFUCache cache = new LFUCache(2);

        cache.Put(1, 10);
        cache.PrintState("After Put(1, 10)");

        cache.Put(2, 20);
        cache.PrintState("After Put(2, 20)");

        Console.WriteLine("Get(1) = " + cache.Get(1));
        cache.PrintState("After Get(1)  // freq(1) becomes 2");

        cache.Put(3, 30);  // Evicts key 2 (freq=1, LRU among freq=1)
        cache.PrintState("After Put(3, 30)  // key 2 evicted");

        Console.WriteLine("Get(2) = " + cache.Get(2));
        cache.PrintState("After Get(2)  // still missing");

        Console.WriteLine("Get(3) = " + cache.Get(3));
        cache.PrintState("After Get(3)  // freq(3) becomes 2");

        cache.Put(4, 40);  // Evicts key 1 (freq=2, but 1 is LRU among freq=2)
        cache.PrintState("After Put(4, 40)  // key 1 evicted");

        Console.WriteLine("Get(1) = " + cache.Get(1));
        cache.PrintState("After Get(1)");

        Console.WriteLine("Get(3) = " + cache.Get(3));
        cache.PrintState("After Get(3)");

        Console.WriteLine("Get(4) = " + cache.Get(4));
        cache.PrintState("After Get(4)");
    }
}
