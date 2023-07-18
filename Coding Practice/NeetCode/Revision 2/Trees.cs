using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision_2
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Trees
    {
        #region Question 1 - Invert Binary Tree
        // link - https://leetcode.com/problems/invert-binary-tree/
        public TreeNode InvertTree(TreeNode root)
        {
            if(root == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                TreeNode temp = node.left;
                node.left= node.right;
                node.right= temp;

                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            return root;
        }
        #endregion

        #region Question 2 - Maximum Depth of Binary Tree
        // link - https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
        public int MaxDepth(TreeNode root)
        {
            if(root == null)
                return 0;
            return 1 + Math.Max(MaxDepth(root.left),MaxDepth(root.right));
        }
        #endregion

        #region Question 3 - Diameter of Binary Tree
        // link - https://leetcode.com/problems/diameter-of-binary-tree/description/
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int max = 0;
            DiameterOfBinaryTreeUtil(root, ref max);
            return max;
        }
        public int DiameterOfBinaryTreeUtil(TreeNode root,ref int max)
        {
            if(root == null)
                 return 0;
            int lheight = DiameterOfBinaryTreeUtil(root.left,ref max);
            int rheight = DiameterOfBinaryTreeUtil(root.right, ref max);
            max = Math.Max(max, lheight + rheight);
            return Math.Max(lheight, rheight) + 1;
        }
        #endregion

        #region Question 4 - Balanced Binary Tree
        // link - https://leetcode.com/problems/balanced-binary-tree/
        public bool IsBalanced(TreeNode root)
        {
            bool isBalanced = true;
            IsBalancedUtil(root, ref isBalanced);
            return isBalanced;
        }
        public int IsBalancedUtil(TreeNode root, ref bool isBalanced)
        {
            if(root == null)
                return 0;
            int lheight = IsBalancedUtil(root.left, ref isBalanced);
            int rheight = IsBalancedUtil(root.right, ref isBalanced);
            if(Math.Abs(lheight-rheight) > 1)
            {
                isBalanced = false;
                return 0;
            }
            return Math.Max(lheight, rheight) + 1;
        }
        #endregion

        #region Question 5 - Same Tree
        // link - https://leetcode.com/problems/same-tree/
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if(p == null && q == null) return true;
            if (p != null && q != null && p.val == q.val) return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            return false;
        }
        #endregion

        #region Question 6 - Subtree of Another Tree
        // link - https://leetcode.com/problems/subtree-of-another-tree/
        #region Approach 1 - Time - O(n*m)
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null) return true;
            if (root == null && subRoot != null) return false;
            if (root != null && subRoot == null) return false;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (IsSameTree(node, subRoot)) return true;
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            return false;
        }
        #endregion

        #region Approach 2 - O(n*m). Not using Queue
        public bool IsSubtree1(TreeNode root, TreeNode subRoot)
        {
            if (IsSameTree(root, subRoot))
                return true;
            if (root == null)
                return false;
            return IsSubtree1(root.left, subRoot) || IsSubtree1(root.right, subRoot);
        }
        #endregion

        #region Approach 3 - O(n+m). Using merkel hash
        public bool IsSubtree2(TreeNode root, TreeNode subRoot)
        {
            string subRootMerkel = merkelHash(subRoot);
            return IsSubtreeUtil(root, subRootMerkel);
        }
        public string hash(string merkel)
        {
            var sha = SHA256.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(merkel);
            var hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash);
        }
        public string merkelHash(TreeNode node)
        {
            if (node == null)
                return "#";
            string leftMerkel = merkelHash(node.left);
            string rightMerkel = merkelHash(node.right);
            return hash(leftMerkel + Convert.ToString(node.val) + rightMerkel);
        }
        public bool IsSubtreeUtil(TreeNode node, string subTreeMerkel)
        {
            if(node == null)
                return false;
            return merkelHash(node) == subTreeMerkel || IsSubtreeUtil(node.left, subTreeMerkel) || IsSubtreeUtil(node.right, subTreeMerkel);
        }
        #endregion
        #endregion

        #region Question 7 - Lowest Common Ancestor of a Binary Search Tree
        // link - https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
        #region Approach 1 - Recursion
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor(root.left, p, q);
            if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor(root.right, p, q);
            return root;
        }
        #endregion

        #region Approach - Iteration
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            while (true)
            {
                if (root.val > p.val && root.val > q.val)
                    root = root.left;
                else if (root.val < p.val && root.val < q.val)
                    root = root.right;
                else break;
            }
            return root;
        }
        #endregion

        #endregion

        #region Question 8 - Binary Tree Level Order Traversal
        // link - https://leetcode.com/problems/binary-tree-level-order-traversal/description/
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> lists = new List<IList<int>>();

            if(root == null)
                return lists;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int count;
            TreeNode temp;
            while (queue.Count > 0)
            {
                count = queue.Count; 
                IList<int> list = new List<int>();
                for(int i = 0; i < count; i++)
                {
                    temp = queue.Dequeue();
                    list.Add(temp.val);
                    if(temp.left != null) queue.Enqueue(temp.left);
                    if(temp.right != null) queue.Enqueue(temp.right);
                }
                lists.Add(list);
            }
            return lists;
        }
        #endregion

        #region Question 9 - Binary Tree Right Side View
        // link - https://leetcode.com/problems/binary-tree-right-side-view/description/
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> list = new List<int>();
            if(root == null)
                return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode temp;
            int count;
            while (queue.Count > 0)
            {
                count = queue.Count;
                for(int i = 0; i < count; i++)
                {
                    temp = queue.Dequeue();
                    if(i == 0)
                        list.Add(temp.val);
                    
                    if(temp.right != null)
                        queue.Enqueue(temp.right);
                    if(temp.left != null)
                        queue.Enqueue(temp.left);
                }
            }
            return list;
        }
        #endregion

        #region Question 10 - Count Good Nodes in Binary Tree
        // link - https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
        public int GoodNodes(TreeNode root)
        {
            return GoodNodesUtil(root, int.MinValue);
        }
        public int GoodNodesUtil(TreeNode root, int MaxValue)
        {
            if (root == null)
                return 0;
            int res = root.val >= MaxValue ? 1 : 0;
            MaxValue = Math.Max(root.val, MaxValue);
            res += GoodNodesUtil(root.left, MaxValue);
            res += GoodNodesUtil(root.right, MaxValue);
            return res;
        }
        #endregion

        #region Question 11 - Validate Binary Search Tree
        // sln link - https://leetcode.com/problems/validate-binary-search-tree/solutions/32112/learn-one-iterative-inorder-traversal-apply-it-to-multiple-tree-questions-java-solution/
        public bool IsValidBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prev = null;
            while(root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (prev != null && prev.val >= root.val)
                    return false;
                prev = root;
                root = root.right;
            }
            return true;
        }
        #endregion

        #region Question 12 - Kth Smallest Element in a BST
        // link - https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
        // sln link - https://leetcode.com/problems/validate-binary-search-tree/solutions/32112/learn-one-iterative-inorder-traversal-apply-it-to-multiple-tree-questions-java-solution/
        public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while(root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if(--k == 0) return root.val;
                root= root.right;
            }
            return -1;
        }
        #endregion

        #region Question 13 - Construct Binary Tree from Preorder and Inorder Traversal
        // link - https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
        // sln link - https://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int,int> map = new Dictionary<int,int>();
            for(int i = 0; i < inorder.Length; i++)
                map[inorder[i]] = i;
            int preIndex = 0;
            return BuildTreeUtil(preorder, inorder, map,ref preIndex, 0,inorder.Length-1);
        }
        public TreeNode BuildTreeUtil(int[]  preorder, int[] inorder, Dictionary<int, int> map,ref int preInd, int inStart, int inEnd)
        {
            if(inStart > inEnd) return null;

            TreeNode node = new TreeNode(preorder[preInd++]);

            if(inStart == inEnd) return node;

            int inIndex = map[node.val];
            node.left = BuildTreeUtil(preorder, inorder, map, ref preInd, inStart, inIndex - 1);
            node.right = BuildTreeUtil(preorder, inorder, map,ref preInd, inIndex + 1, inEnd);
            return node;
        }
        #endregion
    }
}
