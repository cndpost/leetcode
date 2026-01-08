// page 252. Drill 14. Total Wizard Strength

using System;
using System.Net.NetworkInformation;
public static class Ace_coding
{
    private static List<int> prevLess = new List<int>();
    private static List<int> nextLessEQ = new List<int>();
    private static List<int> countAsMin = new List<int>();
    private static List<int> pref = new List<int>();
    private static List<int> pref2 = new List<int>();
    private static List<long> contrib = new List<long>();
    //how many times nums[i] can show as member of any substrings
    public static long timeAppearInSubstring(int N, int i)
    {
        return 1L * (i + 1) * (N - i);
    }



    //how many times num[i] can show as min member of any substrings
    public static void timeAppearAsMinInSubstring(List<int> nums, int N)
    {   Stack<int> st = new Stack<int>();
       
        for (int i = 0; i < N; i++)
        {
            while ((st.Count >0) && (st.Peek() >= nums[i])) st.Pop();
            int k = (st.Count==0)?-1:st.Peek();
            prevLess.Add(k);
            st.Push(i);
        }

        st = new Stack<int>();
        for (int i = N - 1; i >= 0; i--)
        {
            while ((st.Count > 0) && (st.Peek() > nums[i])) st.Pop();
            int k = (st.Count == 0) ? N : st.Peek();
            nextLessEQ.Add(k);
            st.Push(i);
        }

        for(int i  = 0; i < N; i++) {
            int l = prevLess[i];
            if (l == -1) l = 0;
            int L = i - l;          //left side count of substrings where num[i] is min
            int R = nextLessEQ[i] - i;  //right side count of substrings where num[i] is min
            countAsMin.Add( L*R);       //total count of substrings where num[i] is min
            long contribToLeftSide = (pref[i] - pref[l])*R;
            long contribToRightSide = (pref[nextLessEQ[i]] - pref[i]) * L;
            contrib.Add((contribToLeftSide+contribToRightSide)*nums[i]);
        }
        
    }

    public static long TotalWizard(List<int> nums)
    {

        int curr = 0;
        int curr2 = 0;
        int N = nums.Count;
        long ret = 0;
      
        for (int i = 0; i < N; i++)
        {

            

            curr += nums[i];  //running total from begining
            curr2 += nums[i] * i; // curr2[i+1]-curr2[i] = nums[i+1]*(i+1);
                                  // curr2[i]-curr2[i-1] = nums[i]*(i);  
                                  //...
                                  // curr2[2] - curr2[1] = nums[2]*2;
                                  // curr2[1] - curr2[0] = nums[1]*1;

            pref.Add(curr);
            pref2.Add(curr2);
        }

        timeAppearAsMinInSubstring(nums, N);


        for (int i=0; i < N; i++)
        {
            //calculate the contribution of current node to the totalWizard

            ret += contrib[i];
        }
    
    
        return ret;

    }

}

public class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>() { -1, 0, 2, 3, -4, -5, 0, 1, 2, 3, 4 };

        long totalWizard = Ace_coding.TotalWizard(nums);
        int N = nums.Count;
      
        Console.WriteLine("total wizard is {0} ", totalWizard);
        
    }
}