using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision
{
    public class Node
    {
        public int val;
        public Node left, right;
        public Node(int val)
        {
            this.val = val;
            left = right = null;
        }
    }
    public class BinaryTree
    {
        public Node root;

        public void BinaryTreeMain()
        {
            var bt = new BinaryTree();
            //bt.root = new Revision.Node(1);
            //bt.root.left = new Revision.Node(2);
            //bt.root.left.left = new Revision.Node(4);
            //bt.root.left.right = new Revision.Node(5);
            //bt.root.right = new Revision.Node(3);
            //bt.root.right.right = new Revision.Node(6);

            //bt.Delete(bt.root, 2);

            int[] arr = { 1, 2, 3, 4, 5, 6 };
            bt.BinaryTreeFromArray(arr, bt.root, 0);
            var a = "abc";
        }

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
            PreOrder(node.left);
            PreOrder(node.right);
        }
        public void PostOrder(Node node)
        {
            if (node == null)
                return;
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.val);
        }
        public void InorderIteration(Node node)
        {
            Stack<Node> stc = new Stack<Node>();
            Node curr = node;
            while(curr != null || stc.Count > 0)
            {
                while(curr != null)
                {
                    stc.Push(curr);
                    curr = curr.left;
                }
                curr = stc.Pop();
                Console.WriteLine(curr.val);
                curr = curr.right;
            }
        }
        public void Insert(Node node, int key)
        {
            if(node == null)
            {
                node = new Node(key);
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count > 0)
            {
                Node temp = q.Dequeue();
                if (temp.left == null)
                {
                    temp.left = new Node(key);
                    break;
                }
                else
                    q.Enqueue(temp.left);
                if (temp.right == null)
                {
                    temp.right = new Node(key);
                    break;
                }
                else
                    q.Enqueue(temp.right);
            }
        }

        public Node Delete(Node node,int key)
        {
            if (node == null)
                return node;
            if (node.left == null && node.right == null)
                if (node.val == key)
                    return null;
                else
                    return node;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            Node temp = null, keynode = null;
            while(q.Count > 0)
            {
                temp = q.Dequeue();
                if(temp.val == key)
                {
                    keynode = temp;
                }
                if (temp.left != null)
                    q.Enqueue(temp.left);
                if (temp.right != null)
                    q.Enqueue(temp.right);
            }
            if(keynode != null)
            {
                int x = temp.val;
                DeleteDeepest(node, temp);
                keynode.val = x;
            }
            return node;
        }
        public void DeleteDeepest(Node node, Node last)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count > 0)
            {
                Node temp = q.Dequeue();
                if(temp == last)
                {
                    temp = null;
                    return;
                }
                if(temp.left != null)
                {
                    if(temp.left == last)
                    {
                        temp.left = null;
                        return;
                    }
                    else
                        q.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    if (temp.right == last)
                    {
                        temp.right = null;
                        return;
                    }
                    else
                        q.Enqueue(temp.right);
                }
            }
        }
        public Node BinaryTreeFromArray(int[] arr, Node node,int i)
        {
            if(i < arr.Length)
            {
                node = new Node(arr[i]);
                node.left = BinaryTreeFromArray(arr, node.left, 2 * i + 1);
                node.right = BinaryTreeFromArray(arr, node.right, 2 * i + 2);
            }
            return node;
        }
        public bool IsContinousRecursive(Node node) 
        {
            if (node == null)
                return true;
            if (node.left == null && node.right == null)
                return true;
            if (node.right == null)
                return (Math.Abs(node.val - node.left.val) == 1) && IsContinousRecursive(node.left);
            if (node.left == null)
                return (Math.Abs(node.val - node.right.val) == 1) && IsContinousRecursive(node.right);
            return (Math.Abs(node.val - node.left.val) == 1) && (Math.Abs(node.val - node.right.val) == 1) && IsContinousRecursive(node.left) && IsContinousRecursive(node.right);
        }
        public bool IsContinousIterative(Node node)
        {
            if (node == null)
                return true;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count > 0)
            {
                Node temp = q.Dequeue();
                if(temp.left != null)
                {
                    if (Math.Abs(temp.val - temp.left.val) == 1)
                        q.Enqueue(temp.left);
                    else
                        return false;
                }
                if (temp.right != null)
                {
                    if (Math.Abs(temp.val - temp.right.val) == 1)
                        q.Enqueue(temp.right);
                    else
                        return false;
                }
            }
            return true;
        }
        public Node MirrorRecursive(Node node)
        {
            if (node == null)
                return node;
            Node left = MirrorRecursive(node.left);
            Node right = MirrorRecursive(node.right);
            node.left = right;
            node.right = left;
            return node;
        }
        public Node MirrorIterative(Node node)
        {
            if (node == null)
                return node;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count > 0)
            {
                Node temp = q.Dequeue();
                Node temp1 = temp.left;
                temp.left = temp.right;
                temp.right = temp1;
                if (temp.left != null)
                    q.Enqueue(temp.left);
                if (temp.right != null)
                    q.Enqueue(temp.right);
            }
            return node;
        }
        public bool IsFoldableRecursive(Node node)
        {
            if (node == null)
                return true;
            node.left = MirrorRecursive(node.left);
            bool res = IsFoldableRecursiveUtil(node.left, node.right);
            node.left = MirrorRecursive(node.left);
            return res;
        }
        public bool IsFoldableRecursiveUtil(Node left,Node right)
        {
            if (left == null & right == null)
                return true;
            if (left != null & right != null && IsFoldableRecursiveUtil(left.left, right.left) && IsFoldableRecursiveUtil(left.right, right.right))
                return true;
            return false;
        }
        public bool IsFoldable(Node node)
        {
            if (node == null)
                return true;
            return IsFoldableUtil(node.left, node.right);
        }
        public bool IsFoldableUtil(Node left,Node right)
        {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;
            return IsFoldableUtil(left.left, right.right) && IsFoldableUtil(left.right, right.left);
        }
        public bool IsSymmetric(Node node)
        {
            if (node == null)
                return true;
            return IsSymmetricUtil(node.left, node.right);
        }
        public bool IsSymmetricUtil(Node left,Node right)
        {
            if (left == null && right == null)
                return true;
            if (left != null && right != null && (left.val == right.val))
                return IsSymmetricUtil(left.left, right.right) && IsSymmetricUtil(left.right, right.left);
            return false;
        }

    }
}
