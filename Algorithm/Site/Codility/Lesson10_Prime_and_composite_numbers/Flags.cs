using System.Collections.Generic;

namespace Algorithm.Site.Codility.Lesson10_Prime_and_composite_numbers
{
    /*
     A non-empty zero-indexed array A consisting of N integers is given.

     A peak is an array element which is larger than its neighbours. More precisely, it is an index P such that 0 < P < N − 1 and A[P − 1] < A[P] > A[P + 1].
     
     For example, the following array A:
     
         A[0] = 1
         A[1] = 5
         A[2] = 3
         A[3] = 4
         A[4] = 3
         A[5] = 4
         A[6] = 1
         A[7] = 2
         A[8] = 3
         A[9] = 4
         A[10] = 6
         A[11] = 2
     has exactly four peaks: elements 1, 3, 5 and 10.
     
     You are going on a trip to a range of mountains whose relative heights are represented by array A, as shown in a figure below. You have to choose how many flags you should take with you. The goal is to set the maximum number of flags on the peaks, according to certain rules.
     
     
     
     Flags can only be set on peaks. What's more, if you take K flags, then the distance between any two flags should be greater than or equal to K. The distance between indices P and Q is the absolute value |P − Q|.
     
     For example, given the mountain range represented by array A, above, with N = 12, if you take:
     
     two flags, you can set them on peaks 1 and 5;
     three flags, you can set them on peaks 1, 5 and 10;
     four flags, you can set only three flags, on peaks 1, 5 and 10.
     You can therefore set a maximum of three flags in this case.
     
     Write a function:
     
     class Solution { public int solution(int[] A); }
     
     that, given a non-empty zero-indexed array A of N integers, returns the maximum number of flags that can be set on the peaks of the array.
     
     For example, the following array A:
     
         A[0] = 1
         A[1] = 5
         A[2] = 3
         A[3] = 4
         A[4] = 3
         A[5] = 4
         A[6] = 1
         A[7] = 2
         A[8] = 3
         A[9] = 4
         A[10] = 6
         A[11] = 2
     the function should return 3, as explained above.
     
     Assume that:
     
     N is an integer within the range [1..400,000];
     each element of array A is an integer within the range [0..1,000,000,000].
     Complexity:
     
     expected worst-case time complexity is O(N);
     expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
     */
    public class Flags
    {
        public int Solution(int[] A)
        {
            int N = A.Length;
            List<int> peaks = new List<int>();

            for (int i = 1; i < N - 1; i++)
            {
                int peak = A[i];

                if (peak > A[i - 1] && peak > A[i + 1])
                {
                    peaks.Add(i);
                }
            }

            for (int K = 2; K <= peaks.Count; K++)
            {
                int flags = 1;
                int peak = peaks[0];

                for (int i = 1; i < peaks.Count; i++)
                {
                    int distance = peaks[i] - peak;

                    if (distance >= K)
                    {
                        flags++;
                        peak = peaks[i];
                    }

                    if (flags == K)
                    {
                        break;
                    }
                }

                if (flags < K)
                {
                    return K - 1;
                }
            }

            return peaks.Count;
        }
    }
}