
//page 250, Drill 7. Find Range summation of a Matrix
using System;
public static class Ace_coding
{
    private static List<List<int>> RectSum = new List<List<int>>();
    public static List<List<int>> RectSummation(List<List<int>>matrix)
    {
        int Rows = matrix.Count;
        int Cols = matrix[0].Count;

        Console.WriteLine(" Rows, Cols = {0}, {1}", Rows, Cols);
        int RowsSum = 0;
       
        for (int i = 0; i < Rows; i++) {
            int RowSum = 0;
            List<int> Row = new List<int>();
            for (int j = 0; j < Cols; j++)
            {
                Console.WriteLine(" i, j = {0},{1}", i, j);
                RowSum +=  matrix[i][j];
                Console.WriteLine(" i, j, sum = {0},{1}, {2}", i, j, RowSum);
                Row.Add(RowSum+RowsSum);
            }
            RowsSum += RowSum;
            RectSum.Add(Row);
        }
        return RectSum;
    }
    public static int RangeSummation(int row1, int col1, int row2, int col2)
    {
        
        int result = RectSum[row2][col2]- RectSum[row2][col1]- RectSum[row1][col2]+ RectSum[row1][col1];
        return result;

    }

}

public class Program
{
    public static void Main()
    {
        List<List<int>> nums = new List<List<int>> { new List<int>{ -1, 0, 2,3 }, new List<int>{ 3, -4, -5, 0 }, new List<int>{ 1, 2, 3, 4 } };

        Ace_coding.RectSummation(nums);
        int best = Ace_coding.RangeSummation(1,1,2,2);
        
        Console.WriteLine("rec sum at [1,1] , [2,2] is {0}", best);
    }
}