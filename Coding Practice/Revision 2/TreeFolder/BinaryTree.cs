using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision_2.Tree
{
    public class Node
    {
        public int val;
        public Node left, right;
        public Node(int val)
        {
            this.val = val;
            this.left = this.right = null;
        }
    }
    public class BinaryTree
    {
        public Node root;

        public void Inorder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Console.WriteLine(node.val);
            Inorder(node.right);
        }
        public void PreOrder(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.val);
            Inorder(node.left);
            Inorder(node.right);
        }
        public void PostOrder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Inorder(node.right);
            Console.WriteLine(node.val);
        }

        public void InorderIteration(Node node)
        {
            Stack<Node> stc = new Stack<Node>();
            while(node != null || stc.Count > 0)
            {
                while(stc != null)
                {
                    stc.Push(node);
                    node = node.left;
                }
                node = stc.Pop();
                Console.WriteLine(node.val);
                node = node.right;
            }
        }

        public int Height(Node node)      // time - O(n), space - O(n) of recursion stack
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }
        public int HeightIterationOrLevelOrder(Node node)    // time - O(n), space - O(n)
        {
            Queue<Node> queue = new Queue<Node>();
            int height = 0;

            // two approach
            #region Approach 1
            //queue.Enqueue(node);
            //queue.Enqueue(null);
            //while (queue.Count > 0)
            //{
            //    Node temp = queue.Dequeue();
            //    if (temp == null)
            //    {
            //        height++;
            //        if (queue.Count > 0)
            //            queue.Enqueue(null);
            //    }
            //    else
            //    {
            //        if (temp.left != null)
            //            queue.Enqueue(temp.left);
            //        if (temp.right != null)
            //            queue.Enqueue(temp.right);
            //    }
            //}
            #endregion

            #region Approach 2
            queue.Enqueue(node);
            int count = 0;
            while (queue.Count > 0)
            {
                count = queue.Count;
                Node temp;
                for(int i = 0; i < count; i++)
                {
                    temp = queue.Dequeue();
                    if(temp.left != null)
                        queue.Enqueue(temp.left);
                    if(temp.right != null)
                        queue.Enqueue(temp.right);
                }
                height++;
            }
            #endregion

            return height;
        }

        public void LevelOrderTraversalUsingHeight(Node root)   // time - O(n*2), space - O(n) of recursion stack
        {
            int height = Height(root);
            for(int i = 1; i <= height; i++)
            {
                LevelOrderTraversalUsingHeightUtil(root, i);
            }
        }
        public void LevelOrderTraversalUsingHeightUtil(Node node, int level)
        {
            if(node == null) return;
            if (level == 1) Console.WriteLine(node.val);
            LevelOrderTraversalUsingHeightUtil(node.left, level - 1);
            LevelOrderTraversalUsingHeightUtil(node.right, level - 1);
        }

        public void LevelOrderTraversalUsingQueue(Node root)
        {
            if(root == null) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                Console.WriteLine(temp.val);

                if(temp.left != null)
                    queue.Enqueue(temp.left);
                if(temp.right != null)
                    queue.Enqueue(temp.right);
            }
        }

        public void Insert(Node root, int key)
        {
            if(root == null)
            {
                root = new Node(key);
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                if (temp.left == null)
                {
                    temp.left = new Node(key);
                    return;
                }
                else
                    queue.Enqueue(temp.left);

                if (temp.right == null)
                {
                    temp.right = new Node(key);
                    return;
                }
                else
                    queue.Enqueue(temp.right);
            }
        }

        public Node Delete(Node root, int key)
        {
            if (root == null)
                return root;
            if(root.left == null && root.right == null)
            {
                if (root.val == key)
                    return null;
                return root;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node delNode = null, temp = null; 
            while(queue.Count > 0)
            {
                temp = queue.Dequeue();
                if(temp.val == key)
                    delNode = temp;
                if(temp.left != null)
                    queue.Enqueue(temp.left);
                if(temp.right != null)
                    queue.Enqueue(temp.right);
            }
            if(delNode != null)
            {
                int x = temp.val;
                DeletDeepest(root, temp);
                delNode.val = x;
            }
            return root;
        }
        public void DeletDeepest(Node root, Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                if(temp == node)
                {
                    temp = null;
                    return;
                }
                if(temp.left != null)
                {
                    if(temp.left == node)
                    {
                        temp.left = null;
                        return;
                    }
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    if (temp.right == node)
                    {
                        temp.right = null;
                        return;
                    }
                    queue.Enqueue(temp.right);
                }
            }
        }

        public void BinaryTreeFromArray(int[] arr)
        {
            // arr = { 1, 2, 3, 4, 5, 6 };
            Node root = null;
            root = BinaryTreeFromArrayUtil(arr, root, 0);
        }
        public Node BinaryTreeFromArrayUtil(int[] arr, Node node, int index)
        {
            if(index < arr.Length)
            {
                node = new Node(arr[index]);
                node.left = BinaryTreeFromArrayUtil(arr,node.left, 2*index + 1);
                node.right = BinaryTreeFromArrayUtil(arr,node.right, 2*index + 2);
            }
            return node;
        }


        // A tree is a Continuous tree if in each root to leaf path, the absolute difference
        // between keys of two adjacent is 1
        public bool isContinuousRecursive(Node node)
        {

            if (node == null)
                return true;
            if(node.left == null && node.right == null) return true;
            if (node.left == null)
                return Math.Abs(node.val - node.right.val) == 1 && isContinuousRecursive(node.right);
            if(node.right == null)
                return Math.Abs(node.val - node.left.val) == 1 && isContinuousRecursive(node.left);
            return Math.Abs(node.val - node.left.val) == 1 && Math.Abs(node.val - node.right.val) == 1 && isContinuousRecursive(node.left) && isContinuousRecursive(node.right);
        }
        public bool isContinuousIteraion(Node node)
        {
            if(node == null) return true;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                if(temp.left != null)
                {
                    if (Math.Abs(temp.val - temp.left.val) == 1)
                        queue.Enqueue(temp.left);
                    else
                        return false;
                }
                if (temp.right != null)
                {
                    if (Math.Abs(temp.val - temp.right.val) == 1)
                        queue.Enqueue(temp.right);
                    else
                        return false;
                }
            }
            return true;
        }

        public Node ConvertIntoMirrorRecursive(Node root)
        {
            if (root == null)
                return root;
            Node left = ConvertIntoMirrorRecursive(root.left);
            Node right = ConvertIntoMirrorRecursive(root.right);
            root.left = right;
            root.right = left;
            return root;
        }
        public Node ConvertIntoMirrorIteration(Node root)
        {
            if (root == null) return root;
            Queue<Node> queue = new Queue<Node>();  
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                Node temp1 = temp.left;
                temp.left = temp.right;
                temp.right = temp1;

                if(temp.left != null)
                    queue.Enqueue(temp.left);
                if(temp.right != null)
                    queue.Enqueue(temp.right);
            }
            return root;
        }



        // A tree can be folded if the left and right subtrees of the tree are structure-wise
        // mirror images of each other. An empty tree is considered foldable. 
        public bool IsFoldableRecursive(Node root)
        {
            if(root == null) return true;
            root.left = ConvertIntoMirrorRecursive(root.left);
            bool res = IsFoldableRecursiveUtil(root.left, root.right);
            root.left = ConvertIntoMirrorRecursive(root.left);
            return res;
        }
        public bool IsFoldableRecursiveUtil(Node left, Node right)
        {
            if(left == null && right == null) return true;
            if (left != null && right != null && IsFoldableRecursiveUtil(left.left, right.left) && IsFoldableRecursiveUtil(left.right, right.right))
                return true;
            return false;
        }

        public bool IsFoldable(Node root)
        {
            if(root == null) return true;
            return IsFoldableUtil(root.left,root.right);
        }
        public bool IsFoldableUtil(Node left, Node right)
        {
            if(left == null && right == null)
                return true;
            if(left == null || right == null)
                return false;
            return IsFoldableUtil(left.left, right.right) && IsFoldableUtil(left.right, right.left);
        }

        //Given a binary tree, check whether it is a mirror of itself.
        public bool isSymmetric(Node root)
        {
            if(root == null) return true;
            return isSymmetricUtil(root.left, root.right);
        }
        public bool isSymmetricUtil(Node left, Node right)
        {
            if (left == null && right == null) return true;
            if(left != null && right != null && left.val == right.val)
                return isSymmetricUtil(left.left, right.right) && isSymmetricUtil(left.right, right.left);
            return false;
        }

        public Node ExpressionTreeFromPostfix(string postfix)
        {
            // postfix = "412*+5/"

            Node node, t1, t2;
            Stack<Node> stack = new Stack<Node>();  
            foreach(char c in postfix)
            {
                if (!isOperator(c))
                {
                    node = new Node((int)c);
                    stack.Push(node);
                }
                else
                {
                    node = new Node(c);
                    t1 = stack.Pop();
                    t2 = stack.Pop();

                    node.right = t1;
                    node.left = t2;
                    stack.Push(node);
                }
            }
            return stack.Pop();
        }
        public bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                return true;
            return false;
        }

        public int EvaluationOfExpressionTree(Node node)
        {
            if (node == null) return 0;
            if(node.left == null && node.right == null) return node.val;
            int left = EvaluationOfExpressionTree(node.left);
            int right = EvaluationOfExpressionTree(node.right);

            if((char) node.val == '+')
                return left + right;
            else if((char)node.val == '-')
                return left - right;
            else if ((char)node.val == '*')
                return left * right;
            else if ((char)node.val == '/')
                return left / right;
            return left ^ right;
        }

    }
}
