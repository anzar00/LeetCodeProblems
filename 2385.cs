// Amount of time for Binary Tree to be Infected

/* 
You are given the root of a binary tree with unique values, and an integer start. At minute 0, an infection starts from the node with value start.

Each minute, a node becomes infected if:

The node is currently uninfected.
The node is adjacent to an infected node.
Return the number of minutes needed for the entire tree to be infected.

Example 1:

Input: root = [1,5,3,null,4,10,6,9,2], start = 3
Output: 4
Explanation: The following nodes are infected during:
- Minute 0: Node 3
- Minute 1: Nodes 1, 10 and 6
- Minute 2: Node 5
- Minute 3: Node 4
- Minute 4: Nodes 9 and 2
It takes 4 minutes for the whole tree to be infected so we return 4.

Example 2:

Input: root = [1], start = 1
Output: 0
Explanation: At minute 0, the only node in the tree is infected so we return 0.
 

Constraints:

The number of nodes in the tree is in the range [1, 105].
- 1 <= Node.val <= 105
- Each node has a unique value.
- A node with a value of start exists in the tree.
*/

 public class GraphNode {
    public int val;
    public List<GraphNode> neighbors;

    public GraphNode(int val) {
        this.val = val;
        this.neighbors = new List<GraphNode>();
    }
}

public class Solution {
    public int AmountOfTime(TreeNode root, int start) {
        if (root == null) return 0;

        Dictionary<int, GraphNode> nodeMap = new Dictionary<int, GraphNode>();
        BuildGraph(root, nodeMap);

        return BFS(nodeMap[start]);
    }

    private void BuildGraph(TreeNode root, Dictionary<int, GraphNode> nodeMap) {
        if (root == null) return;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0) {
            TreeNode current = stack.Pop();

            if (!nodeMap.ContainsKey(current.val)) {
                nodeMap[current.val] = new GraphNode(current.val);
            }

            if (current.left != null) {
                if (!nodeMap.ContainsKey(current.left.val)) {
                    nodeMap[current.left.val] = new GraphNode(current.left.val);
                }

                nodeMap[current.val].neighbors.Add(nodeMap[current.left.val]);
                nodeMap[current.left.val].neighbors.Add(nodeMap[current.val]);

                stack.Push(current.left);
            }

            if (current.right != null) {
                if (!nodeMap.ContainsKey(current.right.val)) {
                    nodeMap[current.right.val] = new GraphNode(current.right.val);
                }

                nodeMap[current.val].neighbors.Add(nodeMap[current.right.val]);
                nodeMap[current.right.val].neighbors.Add(nodeMap[current.val]);

                stack.Push(current.right);
            }
        }
    }

    private int BFS(GraphNode startNode) {
        Queue<GraphNode> queue = new Queue<GraphNode>();
        HashSet<GraphNode> visited = new HashSet<GraphNode>();

        queue.Enqueue(startNode);
        visited.Add(startNode);

        int currentTime = 0;

        while (queue.Count > 0) {
            int size = queue.Count;

            for (int i = 0; i < size; i++) {
                GraphNode current = queue.Dequeue();

                foreach (var neighbor in current.neighbors) {
                    if (!visited.Contains(neighbor)) {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            currentTime++;
        }

        return currentTime - 1;
    }
}