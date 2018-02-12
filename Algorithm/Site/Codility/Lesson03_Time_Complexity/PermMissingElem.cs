namespace Algorithm.Site.Codility.Lesson03_Time_Complexity
{
    /*
     A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

     Your goal is to find that missing element.

     Write a function:

     class Solution { public int solution(int[] A); }
     that, given a zero-indexed array A, returns the value of the missing element.

     For example, given array A such that:

     A[0] = 2
     A[1] = 3
     A[2] = 1
     A[3] = 5
     the function should return 4, as it is the missing element.

     Assume that:

     N is an integer within the range [0..100,000];
     the elements of A are all distinct;
     each element of array A is an integer within the range [1..(N + 1)].
     Complexity:

     expected worst-case time complexity is O(N);
     expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
     */
    public class PermMissingElem
    {
        public int Solution(int[] A)
        {
            long N = A.Length + 1;
            long sum1 = N * (N + 1) / 2;
            long sum2 = 0;

            foreach (int n in A)
            {
                sum2 += n;
            }

            return (int)(sum1 - sum2);
        }
    }
}