using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision_2.Tree
{
    public class BinarySearchTree
    {
        public Node InsertRecursion(Node root, int key)
        {
            return InsertRecursionUtil(root, key);
        }
        public Node InsertRecursionUtil(Node root, int key)
        {
            if(root == null) return new Node(key);
            if(root.val > key)
                root.left = InsertRecursionUtil(root.left, key);
            else if(root.val < key)
                root.right = InsertRecursionUtil(root.right, key);
            return root;
        }

        public Node InsertIteration(Node root, int key)
        {
            Node node = new Node(key);
            if (root == null)
                root = node;
            Node temp = root, prev = null;
            while(temp != null)
            {
                prev = temp;
                if (temp.val > key)
                    temp = temp.left;
                else if (temp.val < key)
                    temp = temp.right;
            }
            if (prev.val > key)
                prev.left = node;
            else if (prev.val < key)
                prev.right = node;
            return root;
        }

        public Node Search(Node root, int key)
        {
            if (root == null || root.val == key)
                return root;
            if(root.val > key)
                return Search(root.left, key);
            return Search(root.right, key);
        }

        public Node DeleteRecusrion(Node root, int key)
        {
            if(root == null)
                return root;
            if(root.val > key)
                root.left = DeleteRecusrion(root.left, key);
            else if(root.val < key)
                root.right = DeleteRecusrion(root.right, key);
            else
            {
                if (root.right == null)
                    return root.left;
                else if(root.left == null)
                    return root.right;

                root.val = InorderSuccessor(root.right);
                root.right = DeleteRecusrion(root.right, root.val);
            }
            return root;
        }
        public int InorderSuccessor(Node node)
        {
            int val = node.val;
            while(node.left != null)
            {
                node = node.left;
                val = node.val;
            }
            return val;
        }

    }
}
