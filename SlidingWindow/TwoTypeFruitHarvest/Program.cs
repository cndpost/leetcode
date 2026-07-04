using System;
using System.Collections.Generic;

public class Fruit
{
    public int TypeId { get; set; }
    public Fruit(int id) => TypeId = id;
}


class Program
{
    static void Main()
    {
        Fruit[] fruits = new Fruit[]
        {
            new Fruit(1),
            new Fruit(2),
            new Fruit(1),
            new Fruit(3),
            new Fruit(2),
            new Fruit(2),
            new Fruit(1)
        };

        Console.WriteLine("Fruit types:");
        foreach (var f in fruits)
            Console.Write(f.TypeId + " ");
        Console.WriteLine();

        int result = MaxFruitsWithTwoBuckets(fruits);

        Console.WriteLine("\nMaximum fruits harvestable with two buckets: " + result);
    }

    public static int MaxFruitsWithTwoBuckets(Fruit[] fruits)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < fruits.Length; right++)
        {
            int type = fruits[right].TypeId;

            if (!count.ContainsKey(type))
                count[type] = 0;

            count[type]++;

            while (count.Count > 2)
            {
                int leftType = fruits[left].TypeId;
                count[leftType]--;

                if (count[leftType] == 0)
                    count.Remove(leftType);

                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
