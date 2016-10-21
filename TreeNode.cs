using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        private bool HasParent { get; set; }
        private List<TreeNode<T>> Children;

        public TreeNode(T val)
        {
            if (val == null)
                throw new ArgumentException("Cannot insert null value!.");
            this.Value = val;
            this.Children = new List<TreeNode<T>>();
        }

        public int ChildrenCount { get { return this.Children.Count; } }

        public void AddChild(TreeNode<T> child)
        { 
            if(child == null)
                throw new ArgumentException("Cannot insert null value!.");
            if (child.HasParent)
            {
                throw new ArgumentException("The node already has a parent.");
            }

            child.HasParent = true;
            this.Children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.Children[index];
        }
    }

    public class Tree<T>
    { 
        private TreeNode<T> Root;

        public Tree(T val)
        {
            if (val == null)
            {
                throw new ArgumentException("Cannot insert null value!.");
            }

            this.Root = new TreeNode<T>(val);
        }

        public Tree(T val, params Tree<T>[] children)
            :this(val)
        {
            foreach (Tree<T> child in children)
            {
                this.Root.AddChild(child.Root);
            }
        }

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if(this.Root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                TreeNode<T> child = root.GetChild(i);
                PrintDFS(child, spaces + "     ");
            }
        }

        public void TraverseDFS()
        {
            this.PrintDFS(this.Root, " ");
        }
    }

}
