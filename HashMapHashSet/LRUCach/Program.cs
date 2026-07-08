using System;
using System.Collections.Generic;

public class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> map;
    private readonly LinkedList<(int key, int value)> list;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        map = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        list = new LinkedList<(int key, int value)>();
    }


    //get only updates its position to the front only if it hits the cache, if it does not hit
    // the cache, it will not add it to the front of the cache like an implicit put operation.

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
            return -1;

        var node = map[key];

        // Move to front (most recently used)
        list.Remove(node);
        list.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
        {
            // Update existing
            var node = map[key];
            node.Value = (key, value);

            list.Remove(node);
            list.AddFirst(node);
        }
        else
        {
            // Insert new
            if (map.Count == capacity)
            {
                // Evict least recently used (tail)
                var lru = list.Last;
                map.Remove(lru.Value.key);
                list.RemoveLast();
            }

            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            list.AddFirst(newNode);
            map[key] = newNode;
        }
    }

    // Helper to print internal state: most recent → least recent
    public void PrintState(string label)
    {
        Console.WriteLine(label);
        Console.Write("Cache state (MRU → LRU): ");
        foreach (var item in list)
        {
            Console.Write($"[{item.key}:{item.value}] ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        LRUCache cache = new LRUCache(2);

        cache.Put(1, 10);
        cache.PrintState("After Put(1, 10)");

        cache.Put(2, 20);
        cache.PrintState("After Put(2, 20)");

        Console.WriteLine("Get(1) = " + cache.Get(1));   // returns 10
        cache.PrintState("After Get(1)");

        cache.Put(3, 30);  // evicts key 2
        cache.PrintState("After Put(3, 30)  // key 2 should be evicted");

        Console.WriteLine("Get(2) = " + cache.Get(2));   // returns -1
        cache.PrintState("After Get(2)");

        Console.WriteLine("Get(3) = " + cache.Get(3));   // returns 30
        cache.PrintState("After Get(3)");

        cache.Put(4, 40);  // evicts key 1
        cache.PrintState("After Put(4, 40)  // key 1 should be evicted");

        Console.WriteLine("Get(1) = " + cache.Get(1));   // returns -1
        cache.PrintState("After Get(1)");

        Console.WriteLine("Get(3) = " + cache.Get(3));   // returns 30
        cache.PrintState("After Get(3) again");

        Console.WriteLine("Get(4) = " + cache.Get(4));   // returns 40
        cache.PrintState("After Get(4)");
    }
}
