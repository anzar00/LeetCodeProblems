/*
Unique Number of Occurrences

Given an array of integers arr, return true if the number of occurrences of each value in the array is unique, or false otherwise.

Example 1:

    Input: arr = [1,2,2,1,1,3]
    Output: true
    Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. 
                 No two values have the same number of occurrences.

Example 2:

    Input: arr = [1,2]
    Output: false

Example 3:

    Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
    Output: true

Constraints:

    1 <= arr.length <= 1000
    -1000 <= arr[i] <= 1000

*/

public class Solution{
    public bool UniqueOccurrences(int[] arr){
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach(int i in arr){
            if(dict.ContainsKey(i)){
                dict[i]++;
            }
            else{
                dict.Add(i, 1);
            }
        }
        HashSet<int> set = new HashSet<int>();
        foreach(KeyValuePair<int, int> kvp in dict){
            if(set.Contains(kvp.Value)){
                return false;
            }
            else{
                set.Add(kvp.Value);
            }
        }
        return true;
    }
}

// Improvement

public class Solution{
    public bool UniqueOccurrences(int[] arr){
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach(int i in arr){
            if(dict.ContainsKey(i)){
                dict[i]++;
            }
            else{
                dict.Add(i, 1);
            }
        }
        HashSet<int> set = new HashSet<int>(dict.Values);
        return set.Count == dict.Count;
    }
}

// Improvement

public class Solution{
    public bool UniqueOccurrences(int[] arr){
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach(int i in arr){
            if(dict.ContainsKey(i)){
                dict[i]++;
            }
            else{
                dict.Add(i, 1);
            }
        }
        return dict.Values.Distinct().Count() == dict.Count;
    }
}

// Explanation

/*

We can use a dictionary to store the number of occurrences of each value in the array. 
Then we can use a hashset to store the number of occurrences of each value in the dictionary. 
If the hashset contains the number of occurrences of a value, then we know that the number of occurrences of that value is not unique. 
If the hashset does not contain the number of occurrences of a value, then we know that the number of occurrences of that value is unique. 
We can return false if the hashset contains the number of occurrences of a value and return true if the hashset does not contain the number of occurrences of a value.

*/