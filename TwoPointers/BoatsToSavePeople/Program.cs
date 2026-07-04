using System;

class Program
{
    static void Main()
    {
        int[] people = { 50, 70, 80, 40, 90, 20 };
        int limit = 100;

        Console.WriteLine("People weights:");
        Console.WriteLine("[" + string.Join(", ", people) + "]");
        Console.WriteLine("Boat limit = " + limit);

        int boats = MinBoats(people, limit);

        Console.WriteLine("\nMinimum number of boats needed: " + boats);
    }

    public static int MinBoats(int[] people, int limit)
    {
        Array.Sort(people);

        int left = 0;
        int right = people.Length - 1;
        int boats = 0;

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
                left++;

            right--;
            boats++;
        }

        return boats;
    }
}
