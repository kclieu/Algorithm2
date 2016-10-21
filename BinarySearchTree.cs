using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //Insert best O(log2n), worst O(n) - eg. adding data already sorted
    //Delete best O(log2n), worst O(n) - eg. adding data already sorted
    //Lookup best O(log2n), worst O(n) - eg. adding data already sorted
    

    public class BinarySearchTree<T> where T:IComparable<T>
    {
        internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
        {
            internal T value;
            internal BinaryTreeNode<T> parent;
            internal BinaryTreeNode<T> leftChild;
            internal BinaryTreeNode<T> rightChild;

            public BinaryTreeNode(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null value!");
                }

                this.value = value;
                this.parent = null;
                this.leftChild = null;
                this.rightChild = null;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }

            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }
        }

        private BinaryTreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);

                if (compareTo < 0)
                {
                    node.leftChild = Insert(value, node, node.leftChild);
                }
                else
                {
                    node.rightChild = Insert(value, node, node.rightChild);
                }

            }

            return node;    
        }

        public void Insert(T value)
        {
            this.root = Insert(value, null, root);
        }

        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                int compareTo = value.CompareTo(node.value);

                if (compareTo < 0)
                    node = node.leftChild;
                else if (compareTo > 0)
                    node = node.rightChild;
                else
                    break;
            }

            return node;
        }

        //private BinaryTreeNode<T> findNodeRecursive(T value)  //Recursively
        //{    if( root == null ) 
        //    return null;    
        //    int currval = root.getValue();            
        //    if( currval == value ) 
        //        return root;               
        //    if( currval < value )
        //    {        
        //        return findNode( root.getRight(), value );    
        //    } 
        //    else 
        //    { 
        //        // currval > value        
        //        return 
        //            findNode( root.getLeft(), value );    
        //    }  
        //}


        /// <summary>
        /// Returns whether given value exists in the tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            bool found = this.Find(value) != null;
            return found;
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            // Case 3: If the node has two children.
            // Note that if we get here at the end
            // the node will be with at most one child
            if (node.leftChild != null && node.rightChild != null)
            {
                BinaryTreeNode<T> replacement = node.rightChild;

                while(replacement.leftChild != null)
                {
                    replacement = replacement.leftChild;
                }
                node.value = replacement.value;
                node = replacement;
            }

            // Case 1 and 2: If the node has at most one child
            BinaryTreeNode<T> theChild = node.leftChild != null?
                node.leftChild:node.rightChild;

            if (theChild != null)
            {
                theChild.parent = node.parent;

                if (node.parent == null)
                {
                    root = theChild;
                }
                else
                {
                    // Replace the element with its child sub-tree
                    if (node.parent.leftChild == node)
                    {
                        node.parent.leftChild = theChild;
                    }
                    else
                    {
                        node.parent.rightChild = theChild;
                    }
                }
            }
            else {
                // Handle the case when the element is the root
                if (node.parent == null)
                    root = null;
                else
                {
                    if (node.parent.leftChild == node)
                        node.parent.leftChild = null;
                    else
                        node.parent.rightChild = null;
                
                }
            }

        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete != null)
            {
                Remove(nodeToDelete); 
            }
        }
    }
}
