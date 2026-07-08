using System;
using System.Collections.Generic;

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
    private Bucket head; // smallest count
    private Bucket tail; // largest count

    public void Inc(string key)
    {
        if (!keyMap.ContainsKey(key))
        {
            // Insert new key with count = 1
            if (head == null || head.Count != 1)
            {
                var newBucket = new Bucket(1);
                InsertBucketBefore(newBucket, head);
                head = newBucket;
                if (tail == null) tail = newBucket;
            }

            head.Keys.Add(key);
            keyMap[key] = head;
        }
        else
        {
            Bucket bucket = keyMap[key];
            int newCount = bucket.Count + 1;

            Bucket nextBucket = bucket.Next;
            if (nextBucket == null || nextBucket.Count != newCount)
            {
                var newBucket = new Bucket(newCount);
                InsertBucketAfter(newBucket, bucket);
                if (bucket == tail) tail = newBucket;
                nextBucket = newBucket;
            }

            nextBucket.Keys.Add(key);
            keyMap[key] = nextBucket;

            bucket.Keys.Remove(key);
            if (bucket.Keys.Count == 0)
                RemoveBucket(bucket);
        }
    }

    public void Dec(string key)
    {
        if (!keyMap.ContainsKey(key))
            return;

        Bucket bucket = keyMap[key];
        int newCount = bucket.Count - 1;

        bucket.Keys.Remove(key);

        if (newCount == 0)
        {
            keyMap.Remove(key);
        }
        else
        {
            Bucket prevBucket = bucket.Prev;
            if (prevBucket == null || prevBucket.Count != newCount)
            {
                var newBucket = new Bucket(newCount);
                InsertBucketBefore(newBucket, bucket);
                if (bucket == head) head = newBucket;
                prevBucket = newBucket;
            }

            prevBucket.Keys.Add(key);
            keyMap[key] = prevBucket;
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

    private void InsertBucketBefore(Bucket newBucket, Bucket existing)
    {
        if (existing == null)
        {
            head = tail = newBucket;
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

    private void InsertBucketAfter(Bucket newBucket, Bucket existing)
    {
        if (existing == null)
        {
            head = tail = newBucket;
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

    private void RemoveBucket(Bucket bucket)
    {
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
