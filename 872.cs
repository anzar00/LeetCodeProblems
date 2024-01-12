// Leaf Similar Trees

/*
Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.

For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).

Two binary trees are considered leaf-similar if their leaf value sequence is the same.

Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.

Example 1:

Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true

Example 2:

Input: root1 = [1,2,3], root2 = [1,3,2]
Output: false

Constraints:

The number of nodes in each tree will be in the range [1, 200].
Both of the given trees will have values in the range [0, 200].
*/

public class Solution {
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        list1 = GetLeaf(root1, list1);
        list2 = GetLeaf(root2, list2);
        if (list1.Count != list2.Count)
            return false;
        for(int i = 0; i < list1.Count; i++)
        {
            if(list1[i] != list2[i])
            {
                return false;
            }
        }
        return true;
    }
    public List<int> GetLeaf(TreeNode root, List<int> list)
    {
        if (root == null)
        {
            return list;
        }
        if(root.left == null & root.right == null)
        {
            list.Add(root.val);
            return list;
        }
        if(root.left != null)
            list = GetLeaf(root.left, list);
        if(root.right != null)
            list = GetLeaf(root.right, list);
        return list;
    }
}