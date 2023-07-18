using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.TreeFolder
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }
    }
    public class Tree
    {
        #region Question 1 - Left View of Binary Tree
        // link - https://practice.geeksforgeeks.org/problems/left-view-of-binary-tree/1
        public List<int> leftView(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            List<int> ans = new List<int>();
            if(root == null)
                return ans;
            queue.Enqueue(root);
            Node node;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for(int i = 1; i <= count; i++)
                {
                    node = queue.Dequeue();
                    if (i == 1)
                        ans.Add(node.data);
                    
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return ans;
        }
        #endregion

        #region Question 2 - Check for BST
        // link - https://practice.geeksforgeeks.org/problems/check-for-bst/1
        public bool isBST(Node root)
        {
            List<int> ans = new List<int>();
            InorderBst(root, ans);
            for(int i = 0; i < ans.Count - 1; i++)
            {
                if (ans[i] >= ans[i+1]) 
                    return false;
            }
            return true;
        }
        public void InorderBst(Node node, List<int> list)
        {
            if(node != null)
            {
                InorderBst(node.left, list);
                list.Add(node.data);
                InorderBst(node.right, list);
            }
        }
        #endregion

        #region Question 3 - Bottom View of Binary Tree 
        // link - https://practice.geeksforgeeks.org/problems/bottom-view-of-binary-tree/1
        #region Approach 1 - Time - O(n*logn), Space - O(n)
        public List<int> bottomView(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            List<int> ans = new List<int>();
            if (root == null) return ans;
            List<int> ind = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            queue.Enqueue(root);
            ind.Add(0);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    Node temp = queue.Dequeue();
                    int index = ind[0];
                    ind.RemoveAt(0);
                    dict[index] = temp.data;
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                        ind.Add(index - 1);
                    }
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                        ind.Add(index + 1);
                    }
                }
            }
            var sorted = from entry in dict orderby entry.Key ascending select entry;
            foreach (var item in sorted)
                ans.Add(item.Value);
            return ans;
        }
        #endregion

        #region Approach 2 - Time - O(n), space - O(n)
        public List<int> bottomView1(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            List<int> ans = new List<int>();
            if (root == null) return ans;
            List<int> ind = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int leftView = 0;
            queue.Enqueue(root);
            ind.Add(0);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    Node temp = queue.Dequeue();
                    int index = ind[0];
                    ind.RemoveAt(0);
                    dict[index] = temp.data;
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                        ind.Add(index - 1);
                    }
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                        ind.Add(index + 1);
                    }

                    leftView = Math.Min(leftView, index);
                }
            }
            while (dict.ContainsKey(leftView))
                ans.Add(dict[leftView++]);
            return ans;
        }
        #endregion
    }
    #endregion

}
