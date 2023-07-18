using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision
{
    public class BinarySearchTree
    {
        public Node root;

        public void InsertRecursive(int key)
        {
            root = InsertRecursiveUtil(root, key);
        }
        public Node InsertRecursiveUtil(Node node,int key)
        {
            if (node == null)
                return new Node(key);
            if (node.val > key)
                node.left = InsertRecursiveUtil(node.left, key);
            if(node.val < key)
                node.right = InsertRecursiveUtil(node.right, key);
            return node;
        }
        public void InsertIteration(int key)
        {
            Node node = new Node(key);
            if(root == null)
            {
                root = node;
                return;
            }
            Node temp = root, prev = null;
            while(temp != null)
            {
                prev = temp;
                if (temp.val > key)
                    temp = temp.left;
                if (temp.val < key)
                    temp = temp.right;
            }
            if (prev.val > key)
                prev.left = node;
            if (prev.val < key)
                prev.right = node;
        }
        public Node Search(Node root,int key)
        {
            if (root == null || root.val == key)
                return root;
            if (root.val > key)
                return Search(root.left, key);
            return Search(root.right, key);
        }
        public Node DeleteRecursive(Node root, int key)
        {
            if (root == null)
                return root;
            if (root.val > key)
                return DeleteRecursive(root.left, key);
            else if (root.val < key)
                return DeleteRecursive(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;
                root.val = InorderSuccessor(root.right);
                root.right = DeleteRecursive(root.right, root.val);
            }
            return root;
        }
        public int InorderSuccessor(Node node)
        {
            int val = node.val;
            while(node.left != null)
            {
                val = node.left.val;
                node = node.left;
            }
            return val;
        }
    }
}
