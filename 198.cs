/*

House Robber

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
the only constraint stopping you from robbing each of them is that adjacent houses have security system connected
and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money
you can rob tonight without alerting the police.

Example 1:

Input: nums = [1,2,3,1]
Output: 4
Explanation:
    Rob house 1 (money = 1) and then rob house 3 (money = 3).
    Total amount you can rob = 1 + 3 = 4.

Example 2:

Input: nums = [2,7,9,3,1]
Output: 12
Explanation:
    Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
    Total amount you can rob = 2 + 9 + 1 = 12.

Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 400

*/

public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if (n == 0) {
            return 0;
        }
        if (n == 1) {
            return nums[0];
        }
        if (n == 2) {
            return Math.Max(nums[0], nums[1]);
        }
        int[] dp = new int[n];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        
        for (int i = 2; i < n; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }
        
        return dp[n - 1];
    }
}

// Explanation : 

// The idea is to use dynamic programming. We can maintain an array dp[] where dp[i] represents the maximum amount of money that can be robbed from the first i houses.
// Now, since we are not allowed to rob two consecutive houses, we can’t pick the current house and the previous house together. So, dp[i] can be equal to either of the following two values:

//     dp[i-1] which represents the maximum amount of money that can be robbed till the (i-1)th house.
//     dp[i-2] + nums[i] which represents the maximum amount of money that can be robbed till the (i-2)th house plus the money we get by robbing the current house, which is represented by nums[i].

// So, we can say that the recurrence relation for this problem is:

// dp[i] = max(dp[i-1], dp[i-2] + nums[i])

// The base cases for the above recurrence are dp[0] = nums[0] and dp[1] = max(nums[0], nums[1]).
// The final answer will be given by dp[n-1], where n is the number of houses.

// Time complexity : O(n). Single loop upto n.
// Space complexity : O(n). dp array of size n is used.
