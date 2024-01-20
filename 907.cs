/*

Sum of Subarray Minimums

Given an array of integers arr, find the sum of min(b), where b ranges over every (contiguous) subarray of arr. 
Since the answer may be large, return the answer modulo 109 + 7.

Example 1:

Input: arr = [3,1,2,4]
Output: 17
Explanation:
Subarrays are [3], [1], [2], [4], [3,1], [1,2], [2,4], [3,1,2], [1,2,4], [3,1,2,4].
Minimums are 3, 1, 2, 4, 1, 1, 2, 1, 1, 1.
Sum is 17.

Example 2:

Input: arr = [11,81,94,43,3]
Output: 444

Constraints:

1 <= arr.length <= 3 * 104
1 <= arr[i] <= 3 * 104

*/

public class Solution {
    public int SumSubarrayMins(int[] arr) {
        const int MOD = 1000000007;
        Stack<int> stack = new Stack<int>();
        int n = arr.Length;
        int[] right = new int[n];
        
        for (int i = n - 1; i >= 0; i--) {
            while (stack.Count > 0 && arr[stack.Peek()] >= arr[i]) {
                stack.Pop();
            }
            right[i] = (stack.Count > 0) ? stack.Peek() : n;
            stack.Push(i);
        }
        
        stack.Clear();
        long result = 0; 
        
        for (int i = 0; i < n; i++) {
            while (stack.Count > 0 && arr[stack.Peek()] > arr[i]) {
                stack.Pop();
            }
            int left = (stack.Count > 0) ? stack.Peek() : -1;
            stack.Push(i);
            
            result = (result + (long)arr[i] * (i - left) * (right[i] - i) % MOD) % MOD;
        }
        
        return (int)result;
    }
}