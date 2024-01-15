/*
Find players with zero or one losses.

You are given an integer array matches where matches[i] = [winneri, loseri] indicates that the player winneri defeated the player loseri in a match. 
Return a list answer of size 2 where :
answer[0] is a list of all players that have not lost any matches.
answere[1] is a list of all players that have lost exactly one  match 

the values in the two lists should be returned in incereasing order

Note 
You should only consider the players that have played at least one match 
The testcase will be generated such that no two matches will have the same outcome

Example 1:

Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
Output: [[1,2,10],[4,5,7,8]]
Explanation:
Players 1, 2, and 10 have not lost any matches.
Players 4, 5, 7, and 8 each have lost one match.
Players 3, 6, and 9 each have lost two matches.
Thus, answer[0] = [1,2,10] and answer[1] = [4,5,7,8].
Example 2:

Input: matches = [[2,3],[1,3],[5,4],[6,4]]
Output: [[1,2,5,6],[]]
Explanation:
Players 1, 2, 5, and 6 have not lost any matches.
Players 3 and 4 each have lost two matches.
Thus, answer[0] = [1,2,5,6] and answer[1] = [].

Constraints:

1 <= matches.length <= 10^5
matches[i].length == 2
1 <= winneri, loseri <= 10^5
winneri != loseri
All matches[i] are unique.
*/

// Solution one with hashset

public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var winners = new HashSet<int>();
        var losers = new HashSet<int>();
        var multipleLosses = new HashSet<int>();

        foreach (var match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            winners.Add(winner);

            if (losers.Contains(loser))
            {
                multipleLosses.Add(loser);
            }
            else
            {
                losers.Add(loser);
            }
        }

        winners.ExceptWith(losers);
        winners.ExceptWith(multipleLosses);
        losers.ExceptWith(multipleLosses);

        var answer = new List<IList<int>>();
        answer.Add(winners.ToList().OrderBy(x => x).ToList());
        answer.Add(losers.ToList().OrderBy(x => x).ToList());

        return answer;
    }
}

// Solution two with dictionary

public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        Dictionary<int, int> playerLosses = new Dictionary<int, int>();
        List<int> noLosses = new List<int>();
        List<int> oneLoss = new List<int>();

        foreach (var match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            // Increment loss count for the loser
            playerLosses[loser] = playerLosses.GetValueOrDefault(loser, 0) + 1;

            // Track winners only if they haven't lost before
            if (!playerLosses.ContainsKey(winner))
            {
                playerLosses[winner] = 0; // Mark as played with 0 losses initially
            }
        }

        // Categorize players based on loss count
        foreach (var kvp in playerLosses)
        {
            if (kvp.Value == 0)
            {
                noLosses.Add(kvp.Key);
            }
            else if (kvp.Value == 1)
            {
                oneLoss.Add(kvp.Key);
            }
        }

        // Sort results in ascending order
        noLosses.Sort();
        oneLoss.Sort();

        return new List<IList<int>> { noLosses, oneLoss };
    }
}

/* 
Explanation

Solution 1 - HashSet Approach 
We can use a hashset to keep track of the players that have lost at least one match.
We can also use a hashset to keep track of the players that have lost more than one match.
We can then use a hashset to keep track of the players that have not lost any matches.
We can then return the results in the required format.

Solution 2 - Dictionary Approach

We can use a dictionary to keep track of the players and their loss count.
We can then categorize the players based on their loss count.
We can then return the results in the required format.
*/