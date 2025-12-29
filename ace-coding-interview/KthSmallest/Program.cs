namespace acecodeinterview
{
    public class Program
    {
        public static int Bisect_right(int[] A, int N, int m)
        {
            int low = 0, hi = N - 1;
            while (low < hi)
            {
                int mid = (low + hi) / 2;
                if (A[mid] <= m)
                    low++;
                else
                    hi = mid;
            }
            return low;
        }

        public static int  KthSmallest(int[][] Matrix, int N, int K)
        {
            int low = Matrix[0][0];
            int hi = Matrix[N - 1][N - 1];
            while (low < hi)
            {
                int mid = (low + hi) / 2;
                int count = 0;
                for (int i = 0; i < N; i++)
                {
                    count += Bisect_right(Matrix[i], N, mid); //function that returns the index to insert mid 
															  //(which is count of elements <= mid)
                }
                if (count < K)
                {
                    low = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }
            // now we have low = hi 
            return low;
        }

        public static void Main()
        {
            int[][] matrix = { [ 1, 2, 3, 4 ], [ 2, 3, 4, 5 ], [ 3, 4, 5, 6 ], [ 4, 5, 6, 7 ] };
            int K = 3;
            Console.WriteLine("Output suppose to be matrix[1,0], {0} ", matrix[1][0]);
            Console.WriteLine("Actual Output is {0} ", KthSmallest(matrix, 4, K));
        }
    }
 }

