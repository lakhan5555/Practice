using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Practice.Tree;

namespace Coding_Practice.Practice
{
    class BinarySearchTree
    {
        public Node root;


        public void MainBSTFn()
        {
            BinarySearchTree Bst = new BinarySearchTree();
            Bst.InsertRec(100);
            Bst.InsertRec(20);
            Bst.InsertRec(500);
            Bst.InsertRec(10);
            Bst.InsertRec(30);
            Bst.InsertRec(40);

            //Bst.Inorder(Bst.root);

            BinarySearchTree Bst1 = new BinarySearchTree();
            Bst1.InsertIteration(100);
            Bst1.InsertIteration(20);
            Bst1.InsertIteration(500);
            Bst1.InsertIteration(10);
            Bst1.InsertIteration(30);
            Bst1.InsertIteration(40);

            //Bst1.Inorder(Bst1.root);

            Node n = Bst.Search(Bst.root,30);
            //Console.WriteLine(n);

            Bst1.root = Bst1.DeleteRec(Bst1.root, 20);
            Bst1.Inorder(Bst1.root);

        }

        public void Inorder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Console.Write(node.val + " ");
            Inorder(node.right);
        }

        public void InsertRec(int key)
        {
            root = InsertUtil(root, key);
        }
        public Node InsertUtil(Node root, int key)
        {
            if (root == null)
                return new Node(key);
            if (key < root.val)
                root.left = InsertUtil(root.left, key);
            if (key > root.val)
                root.right = InsertUtil(root.right, key);
            return root;
        }

        public void InsertIteration(int key)
        {
            Node node = new Node(key);
            if (root == null)
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
                else
                    temp = temp.right;
            }
            if (prev.val > key)
                prev.left = node;
            else
                prev.right = node;
        }

        public Node Search(Node root, int key)
        {
            if (root == null || root.val == key)
                return root;

            if (root.val > key)
                return Search(root.left, key);
            return Search(root.right, key);
        }

        public Node DeleteRec(Node root, int key)
        {
            if (root == null)
                return root;
            if (root.val > key)
                root.left = DeleteRec(root.left, key);
            else if (root.val < key)
                root.right = DeleteRec(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                if (root.right == null)
                    return root.left;
                root.val = InorderSuccessor(root.right);
                root.right = DeleteRec(root.right, root.val);

            }
            return root;
        }

        public int InorderSuccessor(Node node)
        {
            int value = node.val;
            while(node.left != null)
            {
                value = node.left.val;
                node = node.left;
            }
            return value;
        }

    }
}
