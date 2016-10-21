using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class BinaryTree<T>
    {
        public T Value { get; set; }
        public BinaryTree<T> LeftChild { get; private set; }
        public BinaryTree<T> RightChild { get; private set; }

        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinaryTree(T value) : this(value, null, null) { }

        //Print inorder using DFS
        public void PrintInOrder()
        {
            //visit left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintInOrder();
            }

            Console.Write(this.Value + " ");

            if (this.RightChild != null)
            {
                this.RightChild.PrintInOrder();
            }
        }
    }
}
