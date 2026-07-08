using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AllOne ds = new AllOne();

        ds.Inc("apple");
        ds.PrintState("After Inc(apple)");

        ds.Inc("banana");
        ds.PrintState("After Inc(banana)");

        ds.Inc("apple");
        ds.PrintState("After Inc(apple) again");

        ds.Inc("orange");
        ds.PrintState("After Inc(orange)");

        ds.Dec("banana");
        ds.PrintState("After Dec(banana)  // banana removed");

        ds.Inc("orange");
        ds.PrintState("After Inc(orange) again");

        ds.Inc("orange");
        ds.PrintState("After Inc(orange) third time");

        Console.WriteLine("Final MinKey = " + ds.GetMinKey());
        Console.WriteLine("Final MaxKey = " + ds.GetMaxKey());
    }
}



public class AllOne
{
    private class Bucket
    {
        public int Count;
        public HashSet<string> Keys = new HashSet<string>();
        public Bucket Prev;
        public Bucket Next;

        public Bucket(int count)
        {
            Count = count;
        }
    }

    private readonly Dictionary<string, Bucket> keyMap = new Dictionary<string, Bucket>();
    private readonly Dictionary<int, Bucket> countMap = new Dictionary<int, Bucket>();

    private Bucket head; // smallest count
    private Bucket tail; // largest count

    // -------------------------
    // Increment
    // -------------------------
    public void Inc(string key)
    {
        if (!keyMap.ContainsKey(key))
        {
            // New key → count = 1
            if (!countMap.ContainsKey(1))
                AddNewBucketAfter(null, 1);

            countMap[1].Keys.Add(key);
            keyMap[key] = countMap[1];
            return;
        }

        Bucket bucket = keyMap[key];
        int oldCount = bucket.Count;
        int newCount = oldCount + 1;

        bucket.Keys.Remove(key);

        if (!countMap.ContainsKey(newCount))
            AddNewBucketAfter(bucket, newCount);

        countMap[newCount].Keys.Add(key);
        keyMap[key] = countMap[newCount];

        if (bucket.Keys.Count == 0)
            RemoveBucket(bucket);
    }

    // -------------------------
    // Decrement
    // -------------------------
    public void Dec(string key)
    {
        if (!keyMap.ContainsKey(key))
            return;

        Bucket bucket = keyMap[key];
        int oldCount = bucket.Count;
        int newCount = oldCount - 1;

        bucket.Keys.Remove(key);

        if (newCount == 0)
        {
            keyMap.Remove(key);
        }
        else
        {
            if (!countMap.ContainsKey(newCount))
                AddNewBucketBefore(bucket, newCount);

            countMap[newCount].Keys.Add(key);
            keyMap[key] = countMap[newCount];
        }

        if (bucket.Keys.Count == 0)
            RemoveBucket(bucket);
    }

    // -------------------------
    // Get Max / Min
    // -------------------------
    public string GetMaxKey()
    {
        return tail == null ? "" : FirstKey(tail.Keys);
    }

    public string GetMinKey()
    {
        return head == null ? "" : FirstKey(head.Keys);
    }

    private string FirstKey(HashSet<string> set)
    {
        foreach (var k in set) return k;
        return "";
    }

    // -------------------------
    // Bucket Helpers
    // -------------------------
    private void AddNewBucketAfter(Bucket bucket, int count)
    {
        var newBucket = new Bucket(count);

        if (bucket == null)
        {
            // Insert at head
            newBucket.Next = head;
            if (head != null) head.Prev = newBucket;
            head = newBucket;
            if (tail == null) tail = newBucket;
        }
        else
        {
            newBucket.Prev = bucket;
            newBucket.Next = bucket.Next;

            if (bucket.Next != null)
                bucket.Next.Prev = newBucket;

            bucket.Next = newBucket;

            if (bucket == tail)
                tail = newBucket;
        }

        countMap[count] = newBucket;
    }

    private void AddNewBucketBefore(Bucket bucket, int count)
    {
        var newBucket = new Bucket(count);

        newBucket.Next = bucket;
        newBucket.Prev = bucket.Prev;

        if (bucket.Prev != null)
            bucket.Prev.Next = newBucket;

        bucket.Prev = newBucket;

        if (bucket == head)
            head = newBucket;

        countMap[count] = newBucket;
    }

    private void RemoveBucket(Bucket bucket)
    {
        countMap.Remove(bucket.Count);

        if (bucket.Prev != null)
            bucket.Prev.Next = bucket.Next;
        else
            head = bucket.Next;

        if (bucket.Next != null)
            bucket.Next.Prev = bucket.Prev;
        else
            tail = bucket.Prev;
    }

    // -------------------------
    // Debug Print
    // -------------------------
    public void PrintState(string label)
    {
        Console.WriteLine(label);
        Console.WriteLine("Buckets (min → max):");

        Bucket cur = head;
        while (cur != null)
        {
            Console.Write($"Count {cur.Count}: ");
            foreach (var k in cur.Keys)
                Console.Write($"[{k}] ");
            Console.WriteLine();
            cur = cur.Next;
        }

        Console.WriteLine($"MinKey = {GetMinKey()}");
        Console.WriteLine($"MaxKey = {GetMaxKey()}");
        Console.WriteLine();
    }
}
