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

    public void Inc(string key)
    {
        if (!keyMap.ContainsKey(key))
        {
            // Insert new key with count = 1
            if (!countMap.ContainsKey(1))
            {
                var b = new Bucket(1);
                AddBucketAfter(null, b);
                countMap[1] = b;
            }

            countMap[1].Keys.Add(key);
            keyMap[key] = countMap[1];
            return;
        }

        Bucket bucket = keyMap[key];
        int oldCount = bucket.Count;
        int newCount = oldCount + 1;

        bucket.Keys.Remove(key);

        // Create next bucket if needed
        if (!countMap.ContainsKey(newCount))
        {
            var newBucket = new Bucket(newCount);
            AddBucketAfter(bucket, newBucket);
            countMap[newCount] = newBucket;
        }

        countMap[newCount].Keys.Add(key);
        keyMap[key] = countMap[newCount];

        // Remove old bucket if empty
        if (bucket.Keys.Count == 0)
            RemoveBucket(bucket);
    }

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
            {
                var newBucket = new Bucket(newCount);
                AddBucketBefore(bucket, newBucket);
                countMap[newCount] = newBucket;
            }

            countMap[newCount].Keys.Add(key);
            keyMap[key] = countMap[newCount];
        }

        if (bucket.Keys.Count == 0)
            RemoveBucket(bucket);
    }

    public string GetMaxKey()
    {
        return tail == null || tail.Keys.Count == 0 ? "" : FirstKey(tail.Keys);
    }

    public string GetMinKey()
    {
        return head == null || head.Keys.Count == 0 ? "" : FirstKey(head.Keys);
    }

    private string FirstKey(HashSet<string> set)
    {
        foreach (var k in set) return k;
        return "";
    }

    private void AddBucketAfter(Bucket existing, Bucket newBucket)
    {
        if (existing == null)
        {
            // Insert at head
            newBucket.Next = head;
            if (head != null) head.Prev = newBucket;
            head = newBucket;
            if (tail == null) tail = newBucket;
            return;
        }

        newBucket.Prev = existing;
        newBucket.Next = existing.Next;

        if (existing.Next != null)
            existing.Next.Prev = newBucket;

        existing.Next = newBucket;

        if (existing == tail)
            tail = newBucket;
    }

    private void AddBucketBefore(Bucket existing, Bucket newBucket)
    {
        if (existing == null)
        {
            // Insert at tail
            newBucket.Prev = tail;
            if (tail != null) tail.Next = newBucket;
            tail = newBucket;
            if (head == null) head = newBucket;
            return;
        }

        newBucket.Next = existing;
        newBucket.Prev = existing.Prev;

        if (existing.Prev != null)
            existing.Prev.Next = newBucket;

        existing.Prev = newBucket;

        if (existing == head)
            head = newBucket;
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


