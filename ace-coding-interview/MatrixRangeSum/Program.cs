
//page 250, Drill 7. Find Range summation of a Matrix
using System;
public static class Ace_coding
{
    private static List<List<int>> matrix = new List<List<int>>();
    private static List<List<int>> recsum = new List<List<int>>();
    private static int Rows = 0;
    private static int Cols = 0;
    public  static void SetMatrix(List<List<int>>Matrix)
    {
       
        Rows= Matrix.Count;
        Cols = Matrix[0].Count;
        
        for (int i = 0; i < Rows; i++)
        {
            List<int> RowSum = new List<int>();
            List<int> Row = new List<int>();
            for (int j = 0; j < Cols; j++)
            {
                Row.Add(Matrix[i][j]);
                RowSum.Add(0);
            }
            RowSum.Add(0);      //extra column for RowSum
            recsum.Add(RowSum);
            if (i==0) recsum.Add(RowSum);     //extra row

            matrix.Add(Row);
        }
       
    }
    public static int RectSummation(int Rows, int Cols)
    {
        
        Console.WriteLine(" Rows, Cols = {0}, {1}", Rows, Cols);
       
       
        for (int i = 0; i < Rows; i++) {
            int RowSum = 0;
            
            for (int j = 0; j < Cols; j++)
            {
                Console.WriteLine(" i, j = {0},{1}", i, j);
                RowSum +=  matrix[i][j];
                Console.WriteLine(" i, j, rowsum = {0},{1}, {2}", i, j, RowSum);
               
                recsum[i + 1][j + 1] = recsum[i][j+1] + RowSum; 
                
                Console.WriteLine("recsum[i + 1][j + 1], recsum[i][j+1], RowSum = {0}, {1}, {2}", recsum[i + 1][j + 1], recsum[i][j + 1], RowSum);

            }

        }
        Console.WriteLine(" Rows, Cols, recsum[Rows][Cols] = {0}, {1} {2}", Rows, Cols, recsum[Rows][Cols]);

        return recsum[Rows][Cols];
    }

    public static int RangeSummation(int row1, int col1, int row2, int col2)
    {
       
        int result = recsum[row2][col2]- recsum[row2][col1]- recsum[row1][col2]+ recsum[row1][col1];
        return result;

    }

}

public class Program
{
    public static void Main()
    {
        List<List<int>> nums = new List<List<int>> { new List<int>{ -1, 0, 2,3 }, new List<int>{ 3, -4, -5, 0 }, new List<int>{ 1, 2, 3, 4 } };

        Ace_coding.SetMatrix(nums);
        Ace_coding.RectSummation(3, 4);
        int best = Ace_coding.RangeSummation(1,1,2,2);
        
        Console.WriteLine("rec sum at [1,1] , [2,2] is {0}", best);
    }
}