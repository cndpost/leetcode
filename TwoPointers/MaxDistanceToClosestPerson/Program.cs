using System;

class Program
{
    static void Main()
    {
        int[] seats = { 1, 0, 0, 0, 1, 0, 1 };

        Console.WriteLine("Seats: [" + string.Join(", ", seats) + "]");

        int index = MaxDistSeatIndex(seats);

        Console.WriteLine("Best seat index (max distance to closest person): " + index);
    }

    public static int MaxDistSeatIndex(int[] seats)
    {
        int n = seats.Length;
        int maxDist = -1;
        int bestIndex = -1;

        int prev = -1;

        for (int i = 0; i < n; i++)
        {
            if (seats[i] == 1)
            {
                if (prev == -1)
                {
                    int dist = i;
                    if (dist > maxDist)
                    {
                        maxDist = dist;
                        bestIndex = 0;
                    }
                }
                else
                {
                    int gap = i - prev - 1;
                    if (gap > 0)
                    {
                        int mid = prev + (gap + 1) / 2;
                        int dist = Math.Min(mid - prev, i - mid);

                        if (dist > maxDist)
                        {
                            maxDist = dist;
                            bestIndex = mid;
                        }
                    }
                }

                prev = i;
            }
        }

        if (prev != -1)
        {
            int dist = n - 1 - prev;
            if (dist > maxDist)
            {
                maxDist = dist;
                bestIndex = n - 1;
            }
        }

        if (prev == -1)
            return 0;

        return bestIndex;
    }
}
