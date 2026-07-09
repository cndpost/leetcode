using System;

class Program
{
    static void Main(string[] args)
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };

        int result = MaxProfit(prices);

        Console.WriteLine("=== Best Time to Buy and Sell Stock Test ===");
        Console.WriteLine("Prices: " + string.Join(", ", prices));
        Console.WriteLine("Max Profit: " + result);
    }

    public static int MaxProfit(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices)
        {
            if (price < minPrice)
                minPrice = price;

            int profit = price - minPrice;
            if (profit > maxProfit)
                maxProfit = profit;
        }

        return maxProfit;
    }
}
