using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Tree
{
    public class Node
    {
        public int val;
        public Node left, right;
        public Node(int data)
        {
            val = data;
            left = right = null;
        }
    }
    public class BTree
    {
        public Node root;
        

        public  void MainBTreeFn(string[] args)
        {
            

            BTree t = new BTree();
            //t.root = new Node(13);
            //t.root.left = new Node(12);
            //t.root.right = new Node(10);
            //t.root.left.left = new Node(4);
            //t.root.left.right = new Node(19);
            //t.root.right.left = new Node(16);
            //t.root.right.right = new Node(9);
            //t.root = t.Deletion(t.root, 12);
            //t.Inorder(t.root);


            //int[] arr = { 13, 12, 10, 4, 19, 16, 9};
            // t.root = t.BinaryTreeFromGivenArray(arr, t.root, 0);
            //t.Inorder(t.root);

            //bool Is = t.IsContinousRecurrsive(t.root);
            //Console.WriteLine(Is);
            //t.root = t.MirrorReccusrive(t.root);
            //t.MirrorReccusrive(t.root);
            //t.Inorder(t.root);

            //bool res = t.FoldableRecurrsive(t.root);
            //Console.WriteLine(res);

            //bool res1 = t.Foldable(t.root);
            //Console.WriteLine(res1);

            //bool res2 = t.Symmetric(t.root, t.root);
            //Console.WriteLine(res2);

            //string Postfix = "abc*+d/";
            //Node n = t.ExpressionTreeFromPostfixExp(Postfix);
            //t.Inorder(n);

            //string Postfix = "411*+5/";
            //Node n = t.ExpressionTreeFromPostfixExp(Postfix);
            //int n1 = t.EvaluationOfExpressionTree(n);
            //Console.WriteLine(n1);
        }

        public void Inorder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Console.Write(node.val + " ");
            Inorder(node.right);
        }

        public void PreOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.val + " ");
            PreOrder(node.left);
            PreOrder(node.right);

        }
        public void PostOrder(Node node)
        {
            if (node == null)
                return;
            PostOrder(node.left);
            PostOrder(node.right);
            Console.Write(node.val + " ");
        }

        public void InorderIteration(Node node)
        {
            Stack<Node> s = new Stack<Node>();
            Node curr = node;
            while (curr != null || s.Count > 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                Console.Write(curr.val + " ");
                curr = curr.right;
            }
        }

        public void Insert(Node node, int key)
        {
            if (node == null)
            {
                root = new Node(key);
                return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
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

        public void ConvertToList(Node root, List<string> list, string s)
        {
            if (root.left == null && root.right == null)
            {
                string b = root.val.ToString();
                s += b;
                list.Add(s);
                return;
            }
            string a = root.val.ToString();
            s += a;
            if (root.left != null)
                ConvertToList(root.left, list, s);
            if (root.right != null)
                ConvertToList(root.right, list, s);

        }

        public Node Deletion(Node root, int key)
        {
            if (root == null)
                return null;
            if(root.left == null && root.right == null)
            {
                if (root.val == key)
                    return null;
                else
                    return root;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node keyNode = null, temp = null;
            while(q.Count > 0)
            {
                temp = q.Dequeue();
                if(temp.val == key)
                {
                    keyNode = temp;
                }
                if (temp.left != null)
                    q.Enqueue(temp.left);
                if (temp.right != null)
                    q.Enqueue(temp.right);
            }
            if(keyNode != null)
            {
                int x = temp.val;
                DeleteDeepest(root, temp);
                keyNode.val = x;
            }
            return root;
        }

        public void DeleteDeepest(Node root, Node Last)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp;
            while(q.Count > 0)
            {
                temp = q.Dequeue();
                if(temp == Last)
                {
                    temp = null;
                    return;
                }
                if(temp.left != null)
                {
                    if(temp.left == Last)
                    {
                        temp.left = null;
                        return;
                    }
                    q.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    if (temp.right == Last)
                    {
                        temp.right = null;
                        return;
                    }
                    q.Enqueue(temp.right);
                }
            }
        }

        public Node BinaryTreeFromGivenArray(int[] arr, Node root, int i)
        {
            if(i < arr.Length)
            {
                Node temp = new Node(arr[i]);
                root = temp;
                root.left = BinaryTreeFromGivenArray(arr, root.left, 2 * i + 1);
                root.right = BinaryTreeFromGivenArray(arr, root.right, 2 * i + 2);
            }
            return root;
        }

        public bool IsContinousRecurrsive(Node root)
        {
            if (root == null)
                return true;
            if (root.left == null && root.right == null)
                return true;
            if (root.left == null)
                return (Math.Abs(root.val - root.right.val) == 1) && (IsContinousRecurrsive(root.right));
            if (root.right == null)
                return (Math.Abs(root.val - root.left.val) == 1) && (IsContinousRecurrsive(root.left));
            return (Math.Abs(root.val - root.right.val) == 1) && (Math.Abs(root.val - root.left.val) == 1) && (IsContinousRecurrsive(root.right)) && (IsContinousRecurrsive(root.left));
        }

        public bool IsContinousIterative(Node root)
        {
            if (root == null)
                return true;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp;
            int flag = 1;
            while (q.Count > 0)
            {
                temp = q.Dequeue();
                if(temp.left != null)
                {
                    if(Math.Abs(temp.val - temp.left.val) == 1)
                    {
                        q.Enqueue(temp.left);
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (temp.right != null)
                {
                    if (Math.Abs(temp.val - temp.right.val) == 1)
                    {
                        q.Enqueue(temp.right);
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            if (flag == 0)
                return false;
            else
                return true;
        }

        public Node MirrorReccusrive(Node node)
        {
            if (node == null)
                return node;
            Node left = MirrorReccusrive(node.left);
            Node right = MirrorReccusrive(node.right);
            node.left = right;
            node.right = left;
            return node;
        }

        public void MirrorIterative(Node node)
        {
            if (node == null)
                return;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while(q.Count > 0)
            {
                Node curr = q.Dequeue();
                Node temp = curr.left;
                curr.left = curr.right;
                curr.right = temp;
                if(curr.left != null)
                    q.Enqueue(curr.left);
                if (curr.right != null)
                    q.Enqueue(curr.right);
            }
        }


        public bool FoldableRecurrsive(Node node)
        {
            if (node == null)
                return true;
            node.left = MirrorReccusrive(node.left);
            bool res = IsFoldableRecurrsive(node.left, node.right);
            node.left = MirrorReccusrive(node.left);
            return res;
        }

        public bool IsFoldableRecurrsive(Node left, Node right)
        {
            if (left == null && right == null)
                return true;
            if (left != null && right != null && IsFoldableRecurrsive(left.left, right.left) && IsFoldableRecurrsive(left.right, right.right))
                return true;
            return false;
        }

        public bool Foldable(Node root)
        {
            if (root == null)
                return true;
            var res = IsFoldable(root.left, root.right);
            return res;
        }

        public bool IsFoldable(Node left, Node right)
        {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;
            return IsFoldable(left.left, right.right) && IsFoldable(left.right, right.left);
        }

        public bool Symmetric(Node tree1, Node tree2)
        {
            if (tree1 == null && tree2 == null)
                return true;
            if (tree1 != null && tree2 != null && tree1.val == tree2.val)
                return Symmetric(tree1.left, tree2.right) && Symmetric(tree1.right, tree2.left);
            return false;
        }

        public Node ExpressionTreeFromPostfixExp(string Postfix)
        {
            Node temp, t1, t2;
            Stack<Node> s = new Stack<Node>();
            foreach(char c in Postfix)
            {
                if (!isOperator(c))
                {
                    temp = new Node((int)c);
                    s.Push(temp);
                }
                else
                {
                    temp = new Node(c);
                    t1 = s.Pop();
                    t2 = s.Pop();
                    temp.right = t1;
                    temp.left = t2;
                    s.Push(temp);
                }
            }
            return s.Pop();
        }

        public bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                return true;
            return false;
        }


        public int EvaluationOfExpressionTree(Node root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return root.val;
            int leftVal = EvaluationOfExpressionTree(root.left);
            int rightVal = EvaluationOfExpressionTree(root.right);
            if((char)root.val == '+')
                return leftVal + rightVal;
            if ((char)root.val == '-')
                return leftVal - rightVal;
            if ((char)root.val == '*')
                return leftVal * rightVal;
            return leftVal / rightVal;
        }










    }
}
