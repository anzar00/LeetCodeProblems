/*
Minimun Falling Path Sum

Ginen an n x n array of integers matrix, return the minimun sum of any falling path through matrix.

A falling path starts at any element in the first row and chooses the element in the next row that is either directly below or diagonally left/right. 
Specifically, the next element from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).

Example 1:
Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
Output: 13

Example 2:
Input: matrix = [[-19,57],[-40,-5]]
Output: -59

Constraints:
n == matrix.length == matrix[i].length
1 <= n <= 100
-100 <= matrix[i][j] <= 100

*/

public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        int n = matrix.Length;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++) {
            dp[0, i] = matrix[0][i];
        }
        for (int row = 1; row < n; row++) {
            for (int col = 0; col < n; col++) {
                dp[row, col] = matrix[row][col] + dp[row - 1, col];
                if (col > 0) {
                    dp[row, col] = Math.Min(dp[row, col], matrix[row][col] + dp[row - 1, col - 1]);
                }
                if (col < n - 1) {
                    dp[row, col] = Math.Min(dp[row, col], matrix[row][col] + dp[row - 1, col + 1]);
                }
            }
        }
        int res = int.MaxValue;
        for (int i = 0; i < n; i++) {
            res = Math.Min(res, dp[n - 1, i]);
        }
        return res;
    }
}