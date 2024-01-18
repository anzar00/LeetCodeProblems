/*
Climbing Stairs 

You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:

    Input: 2
    Output: 2
    Explanation: There are two ways to climb to the top.

        1. 1 step + 1 step
        2. 2 steps

Example 2:

    Input: 3
    Output: 3
    Explanation: There are three ways to climb to the top.

        1. 1 step + 1 step + 1 step
        2. 1 step + 2 steps
        3. 2 steps + 1 step

Constraints:

    1 <= n <= 45

*/

public class Solution {
    public int ClimbStairs(int n) {
        if(n == 1){
            return 1;
        }
        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;
        for(int i = 3; i <= n; i++){
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}

// Explanation

/*

This is a classic dynamic programming problem. The key is to find the recursive formula.

Let dp[i] denotes the number of ways to climb to the top when there are i steps left.

Then we have the following recursive formula:

dp[i] = dp[i - 1] + dp[i - 2]

The base cases are:

dp[1] = 1
dp[2] = 2

The final answer is dp[n].

*/
