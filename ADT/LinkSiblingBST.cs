using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.ADT
{

    //LoanPal interview question
    //Allan Carroll<allan@loanpal.com>
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
        public TreeNode sibling;

        public TreeNode(int val)
        {
            value = val;
            left = null;
            right = null;
            sibling = null;
        }
    }

    public class BSTTree
    {
        private TreeNode root;

        public BSTTree()
        {
            root = null;
        }

        public BSTTree(TreeNode root)
        {
            this.root = root;
        }


        public void LinkSiblings(TreeNode root)
        {
            if (root == null)
                return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();

                if (node.left != null && node.right != null)
                {
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                    node.left.sibling = node.right;
                    node.right.sibling = null;
                }
                else if (node.left != null)
                {

                    q.Enqueue(node.left);

                    TreeNode sibling = node.sibling;

                    while (sibling != null && sibling.left == null & sibling.right == null)
                        sibling = sibling.sibling;

                    if (sibling != null)
                    {
                        if (sibling.left != null)
                        {
                            node.left.sibling = sibling.left;
                        }
                        else if (sibling.right != null)
                        {
                            node.left.sibling = sibling.right;
                        }
                    }
                }
                else if (node.right != null)
                {
                    q.Enqueue(node.right);

                    TreeNode sibling = node.sibling;

                    while (sibling != null && sibling.left == null & sibling.right == null)
                        sibling = sibling.sibling;


                    if (sibling != null)
                    {
                        if (sibling.left != null)
                        {
                            node.right.sibling = sibling.left;
                        }
                        else if (sibling.right != null)
                        {
                            node.right.sibling = sibling.right;
                        }
                    }
                }
                else if (node.left == null && node.right == null)
                {
                    continue;
                }
            }
        }

        public void PrintSiblings(TreeNode root)
        {
            if (root == null)
                return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                else if (node.right != null)
                {
                    q.Enqueue(node.right);
                }

                PrintNodeVal(node);
                while (node.sibling != null)
                {
                    node = node.sibling;
                    Console.Write("  ----------> ");
                    PrintNodeVal(node);
                }

                Console.Write("\n");
            }
        }

        public void PrintNodeVal(TreeNode node)
        {
            if (node == null)
                return;

            Console.Write(node.value);

        }

        public static void Main()
        {

            //            1            -> null                 
            //        /       \
            //      2    ->     3      -> null          
            //   /    _      /     \
            //   4       -> 5   ->  6  -> null      
            //  /                     \
            // 7                       8 -> null


            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);
            TreeNode node4 = new TreeNode(4);
            node4.left = node7;

            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            node6.right = node8;

            TreeNode node2 = new TreeNode(2);
            node2.left = node4;

            TreeNode node3 = new TreeNode(3);
            node3.left = node5;
            node3.right = node6;

            TreeNode node1 = new TreeNode(1);
            node1.left = node2;
            node1.right = node3;

            BSTTree tree = new BSTTree();
            tree.LinkSiblings(node1);

            tree.PrintSiblings(node1);

            Console.Read();
        }
    }
}
