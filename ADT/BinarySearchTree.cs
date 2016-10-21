using System;
using System.Collections.Generic;

//Memerize this for Google
namespace AlgosBST
{
    //Space best O(n), worst O(n)
    //Insert best O(log2n), worst O(n) - eg. adding data already sorted
    //Delete best O(log2n), worst O(n) - eg. adding data already sorted
    //Lookup best O(log2n), worst O(n) - eg. adding data already sorted

    public class Node
    {
        public Node Left; 
        public Node Right; 
        public int Value;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="value"></param>
        public Node(Node left, Node right, int value) 
        { 
            this.Left = left; 
            this.Right = right; 
            this.Value = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public Node(int data)
        {
            this.Left = null;
            this.Right = null;
            this.Value = data;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Node getLeft() 
        { 
            return Left; 
        }    
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Node getRight() 
        { 
            return Right; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public void setLeft(Node n)
        {
            Left = n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public void setRight(Node n)
        {
            Right = n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getValue() 
        { 
            return Value; 
        }
        /// <summary>
        /// 
        /// </summary>
        public void printValue()
        {
            Console.Write(Value + " ");
        }

        //Balanced BST eg. AVL and red-black trees
        public Node rotateRight()
        {
            Node newRoot = Left;
            Left = newRoot.Right;
            newRoot.Right = this;
            return newRoot;
        }        
    }

    /// <summary>
    /// 
    /// </summary>
    public class BST
    {
        private Node Root;

        /// <summary>
        /// 
        /// </summary>
        public BST()
        {
            Root = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        //O(n)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TreeHeight()
        {
            return TreeHeight(Root);
        }

        private int TreeHeight(Node n)
        {
            if (n == null)
                return 0;
            return 1 + Math.Max(
                TreeHeight(n.getLeft()), TreeHeight(n.getRight()));
        }

        //runs in O(N) time and O(H) space where H is height of the tree
        public bool IsBalanced()
        {
            return IsBalanced(Root);
        }

        private bool IsBalanced(Node n)
        {
            if (CheckHeight(n) == -1)
                return false;
            else
                return true;
        }

        private int CheckHeight(Node n)
        {
            if (n == null)
                return 0;

            //Check if left is balanced
            int leftHeight = CheckHeight(n.Left);

            if (leftHeight == -1)
                return -1; //Not balanced

            //Check if right is balanced
            int rightHeight = CheckHeight(n.Right);

            if (rightHeight == -1)
                return -1;

            //Check if current node is balanced
            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
                return -1;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        //Although this works, it's not very efficient. On each node, we recurse through its entire
        //subtree. This means that TreeHeight is called repeatedly on the same nodes.The algorithm
        //istherefore O(N2).
        private bool IsBalanced2(Node n)
        {
            if (n == null) return true;

            int heightDiff = TreeHeight(n.Left) - TreeHeight(n.Right);
            if (Math.Abs(heightDiff) > 1)
                return false;
            else
                return IsBalanced2(n.Left) && IsBalanced2(n.Right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CountNodes()
        {
            return CountNodes(Root);
        }

        private int CountNodes(Node r)
        {
            if (r == null)
                return 0;
            else
            {
                /*
                int c = 1;
                c += CountNodes(r.getLeft());
                c += CountNodes(r.getRight());
                return c;*/
                return 1 + CountNodes(r.Left) + CountNodes(r.Right);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }
     
        //Preorder — Performs the operation first on the node itself, then on its left descendants,
        //and finally on its right descendants. In other words, a node is always visited before any of its children
        //O(n)
        public void PreorderTraversal(Node node)
        {
            if (node == null) return;
            node.printValue();  //ie. Console.Write(node.getValue());
            PreorderTraversal(node.getLeft());
            PreorderTraversal(node.getRight());
        }

        //This preorder traversal does not use recursion
        public void PreOrderTraversal2(Node node)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                Node curr = stack.Pop();
                curr.printValue();

                Node child = curr.Right;
                if (child != null)
                    stack.Push(child);

                child = curr.Left;
                if (child != null)
                    stack.Push(child);
            }
        }

        //Inorder — Performs the operation first on the node’s left descendants, then on the node itself, 
        //and finally on its right descendants. In other words, the left subtree is visited first, 
        //then the node itself, and then the node’s right subtree.
        /// <summary>
        /// 
        /// </summary>
        public void InorderTraveral()
        {
            InorderTraversal(Root);
        }

        public void InorderTraversal(Node node)
        {
            if (node == null) return;
            InorderTraversal(node.getLeft());
            node.printValue();
            InorderTraversal(node.getRight());
        }

        /// <summary>
        /// 
        /// </summary>
        public void PostorderTraveral()
        {
            PostorderTraversal(Root);
        }

        //Postorder — Performs the operation first on the node’s left descendants, then on the node’s right descendants, and finally on the node itself. In other words, a node is always visited after all its children.
        public void PostorderTraversal(Node node)
        {
            if (node == null) return;
            PostorderTraversal(node.getLeft());
            PostorderTraversal(node.getRight());
            node.printValue();
        }

        //Find Lowest common ancestor
        //O(log2n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        Node FindLowestCommonAncestor(Node root, int value1, int value2)
        {
            while (root != null)
            {
                int value = root.getValue();

                if (value > value1 && value > value2)
                {
                    root = root.getLeft();
                }
                else if (value < value1 && value < value2)
                {
                    root = root.getRight();
                }
                else
                {
                    return root;
                }
            }

            return null; // only if empty tree }
        }

        Node FindLowestCommonAncestor(Node root, Node child1, Node child2)
        {
            if (root == null || child1 == null || child2 == null) { return null; }
                return FindLowestCommonAncestor(root, child1.getValue(), child2.getValue());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            Root = Insert(Root, data);
        }

        private Node Insert(Node node, int data)
        {
            if (node == null)
                node = new Node(data);
            else
            {
                if (data <= node.getValue())
                    node.Left = Insert(node.Left, data);
                else
                    node.Right = Insert(node.Right, data);
            }

            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        public void Delete(int k)
        {
            if (IsEmpty())
                return;
            else if (Search(k) == false)
                return;
            else
            {
                Root = Delete(Root, k);
            }
        }

        //http://algs4.cs.princeton.edu/32bst/BST.java.html
        private Node Delete(Node x, int k)
        {
            if (x == null)
                return null;
            if (k < x.Value)
                x.Left = Delete(x.Left, k);
            else if (k > x.Value)
                x.Right = Delete(x.Right, k);
            else
            {
                if (x.Right == null)
                    return x.Left;
                else if (x.Left == null)
                    return x.Right;

                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }

            return x;
        }


        //Min,Max
        public int Min()
        {
            if (IsEmpty()) return -1; //??
            return Min(Root).Value;
        }

        private Node Min(Node x)
        {
            if (x.Left == null) return x;
            else return Min(x.Left);
        }

        public int Max()
        {
            if (IsEmpty()) return -1;
            return Max(Root).Value;
        }

        private Node Max(Node x)
        {
            if (x.Right == null) return x;
            else return Max(x.Right);
        }

        public void DeleteMin()
        {
            Root   = DeleteMin(Root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null) return x.Right;
            x.Left = DeleteMin(x.Left);
            return x;
        }

        public void DeleteMax()
        {
            Root = DeleteMax(Root);
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null) return x.Left;
            x.Right = DeleteMax(x.Right);
            return x;
        }

        private Node Delete2(Node root, int k)
        {
            Node p, p2, n;

            if (root.getValue() == k)
            {
                Node lt, rt;

                lt = root.getLeft();
                rt = root.getRight();

                if (lt == null && rt == null) //node with no children
                    return null;
                else if (lt == null) //node with one child
                {
                    p = rt;
                    return p;
                }
                else if(rt == null) //node with one child
                {
                    p = lt;
                    return p;
                }
                else { //node with 2 children
                    p2 = rt;
                    p = rt;
                    while (p.getLeft() != null)
                        p = p.getLeft();
                    p.setLeft(lt);
                    return p2;
                }
            }

            if (k < root.getValue())
            {
                n = Delete(root.getLeft(), k);
                root.setLeft(n);
            }
            else
            {
                n = Delete(root.getRight(), k);
                root.setRight(n);
            }

            return root;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Search(int val)
        {
            return Search(Root, val);
        }

        private bool Search(Node r, int val)
        {
            bool found = false;

            while ((r != null) && !found)
            {
                int rval = r.getValue();

                if (val < rval)
                    r = r.getLeft();
                else if (val > rval)
                    r = r.getRight();
                else
                {
                    found = true;
                    break;
                }

                found = Search(r, val);
            }

            return found;
        }

        //Satisfy binary search tree property: keyof node is >= keys stored at left nodes and < keys on right nodes
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public bool IsValidBST()
        {
            return IsValidBST(Root, Int32.MinValue, Int32.MaxValue); 
        }

        //CCI 4.5
        private bool IsValidBST(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.getValue() <= min || node.getValue() > max)
                return false;

            if (!IsValidBST(node.Left, min, node.getValue()) ||
                !IsValidBST(node.Right, node.getValue(), max))
                return false;

            return true;
        }

        private bool IsValidBST2(Node node, int MIN, int MAX)
        {
            if (node == null)
                return true;
            if (node.getValue() > MIN
                && node.getValue() < MAX
                && IsValidBST(node.getLeft(), MIN, Math.Min(node.getValue(), MAX))
                && IsValidBST(node.getRight(), Math.Max(node.getValue(), MIN), MAX))
                return true;
            else
                return false;
        }

        //14.5 Search for first key larger than k in an inorder walk
        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Node FindFirstLargerKWithKExist(int k)
        {
            return FindFirstLargerKWithKExist(Root, k);
        }

        private Node FindFirstLargerKWithKExist(Node node, int k)
        {
            bool found = false;
            Node curr = node;
            Node first = null;

            while (curr != null)
            {
                if (curr.getValue() == k)
                {
                    found = true;
                    curr = curr.getRight();
                }
                else if (curr.getValue() > k)
                {
                    first = curr;
                    curr = curr.getLeft();
                }
                else  //curr.getValue < k
                {
                    curr = curr.getRight();
                }
            }

            return found ? first : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<int> FindKLargestInBST(int k)
        {
            List<int> kElements = new List<int>();

            FindKLargestInBSTHelper(Root, k, kElements);

            return kElements;
        }

        private void FindKLargestInBSTHelper(Node node, int k, List<int> kElements)
        {
            //perform reverse inorder traversal
            if (node != null && k > kElements.Capacity)
            {
                FindKLargestInBSTHelper(node.getRight(), k, kElements);

                if (k > kElements.Capacity)
                {
                    kElements.Add(node.getValue());
                    FindKLargestInBSTHelper(node.getLeft(), k, kElements);
                }
            }
        }

        //CCI 4.3 Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height
        public Node CreateMinimalBST(int[] arr)
        {
            return CreateMinimalBST(arr, 0, arr.Length - 1);
        }

        private Node CreateMinimalBST(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            Node n = new Node(arr[mid]);
            n.Left = CreateMinimalBST(arr, start, mid - 1);
            n.Right = CreateMinimalBST(arr, mid + 1, end);

            return n;
        }

        //CCI 4.4 Given a binary tree, design an algorithm which creates a linked list of all the nodes at
        //each depth (e.g., if you have a tree with depth D, you'll have D linked lists).

        public List<LinkedList<Node>> CreateLevelLinkedList(Node root)
        {
            List<LinkedList<Node>> lists = new List<LinkedList<Node>>();

            CreateLevelLinkedList(root, lists, 0);
            return lists;
        }

        void CreateLevelLinkedList(Node root, List<LinkedList<Node>> lists, int level)
        {
            if (root == null) return;  //base case

            LinkedList<Node> list = null;

            if (lists.Capacity == level)
            {
                list = new LinkedList<Node>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }

            list.AddLast(root);

            CreateLevelLinkedList(root.Left, lists, level + 1);
            CreateLevelLinkedList(root.Right, lists, level + 1);
        }

        //Implementation using Breadth First Search
        //O(n)
        public List<LinkedList<Node>> CreateLevelLinkedList2(Node root)
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();

            //"Visit" the root
            LinkedList<Node> current = new LinkedList<Node>();
            
            if (root != null) current.AddLast(root);

            while (current.Count > 0)
            {
                result.Add(current); //Add previous level

                LinkedList<Node> parents = current; //Go to next level
                current = new LinkedList<Node>();

                foreach (Node parent in parents)
                { 
                    //Visit the children
                    if (parent.Left != null)
                        current.AddLast(parent.Left);

                    if (parent.Right != null)
                        current.AddLast(parent.Right);
                }
            }

            return result;
        }

        //CCI 4.6 Write an algorithm to find the 'next'node (i.e., in-order successor) of a given node in
        //a binary search tree. You may assume that each node has a link to its parent.

        /*
        public Node InOrderSuccessor(Node n)
        {
            if (n == null) return null;

            //Find right children - > return leftmost node of right subtree
            if (n.Right != null)
                return LeftMostChild(n.Right);
            else
            {
                Node q = n;
                Node x = q.Parent;

                //Go up until we are on  left instead of right
                while(x!= null && x.Left != q)
                {
                    q = x;
                    x = x.Parent;
                }

                return x;
            }
        }
        
        public Node LeftMostChild(Node n)
        {
            if (n == null)
                return null;

            while (n.Left != null)
                n = n.Left;

            return n;
        }
         */

      //CCI 4.7 Design an algorithm and write code to find the first common ancestor of two nodes
      //in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
      //necessarily a binary search tree.
        public  class Result
        {
            public Node node;
            public bool isAncestor;
            public Result(Node n, bool isAnc) {
                node = n;
                isAncestor = isAnc;
            }
        }

        public Node FindCommonAncestor(Node root, Node p, Node q)
        {
            Result r = FindCommonAncestorHelper(root, p, q);

            if (r.isAncestor)
            {
                return r.node;
            }

            return null;
        }

        private Result FindCommonAncestorHelper(Node root, Node p, Node q)
        {
            if(root == null)
                return new Result(null, false);

            if (root == p && root == q)
                return new Result(root, true);

            Result rx = FindCommonAncestorHelper(root.Left, p, q);
            if (rx.isAncestor) //Found common ancestor
                return rx;

            Result ry = FindCommonAncestorHelper(root.Right, p, q);
            if (ry.isAncestor)
                return ry;

            if (rx.node != null && ry.node != null)
                return new Result(root, true); //This is the common ancestore
            else if (root == p || root == q)
            {
                /* 
                    If we are currently at p or q, and we also found one of those nodes in a subtree, then this
                    is truly an ancestor and the flag should be true
                 * 
                 */

                bool isAnacestor = rx.node != null || ry.node != null ? true : false;
                return new Result(root, isAnacestor);
            }
            else {
                return new Result(rx.node != null ? rx.node : ry.node, false);
            }
        }

        //CCI 4.8 You have two very large binary trees: Tl, with millions of nodes, and T2, with
        //hundreds of nodes. Create an algorithm to decide if T2 is a subtree ofTl.
        //A tree T2 is a subtree of Tl if there exists a node n in Tl such that the subtree of n
        //is identical to T2. That is, if you cut off the tree at node n, the two trees would be identical.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public bool ContainsTree(Node t1, Node t2)
        {  
            if (t2 == null)  //The empty tree is always a subtree
                return true;

            return SubTree(t1, t2);
        }

        private bool SubTree(Node n1, Node n2)
        {
            if (n1 == null)
                return false;

            if (n1.Value == n2.Value)
                if (MatchTree(n1, n2)) return true;

            return (SubTree(n1.Left, n2) || SubTree(n1.Right, n2));
        }

        private bool MatchTree(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) //if both are empty
                return true;

            //if one, but not both, are tempty
            if (n1 == null || n2 == null)
                return false;

            if (n1.Value != n2.Value)
                return false;

            return (MatchTree(n1.Left, n2.Left) && MatchTree(n1.Right, n2.Right));
        }

        //CCI 4.9 You are given a binary tree in which each node contains a value. Design an algorithm
        //to print all paths which sum to a given value. The path does not need to start
        //or end at the root or a leaf.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sum"></param>
        public void FindSum(Node node, int sum)
        {
            int depth = TreeHeight(node);
            int[] path = new int[depth];
            FindSum(node, sum, path, 0);
        }

        private void FindSum(Node node, int sum, int[] path, int level)
        {
            if (node == null)
                return;

            //Insert current node into path
            path[level] = node.Value;

            //Look for paths with a sum that ends at this node
            int t = 0;
            for (int i = level; i >= 0; i--)
            {
                i += path[i];
                
                if (t == sum)
                {
                    Print(path, i, level);
                }
            }

            //Search for nodes beneath this one
            FindSum(node.Left, sum, path, level + 1);
            FindSum(node.Right, sum, path, level + 1);

            /* Remove current node from path. Not strictly necessary, since
            * we would ignore this value, but it's good practice. */
            path[level] = Int32.MinValue;
        }

        private int FindRank(int d)
        {
            return 1;
        }

        public void Print(int[] path, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(path[i] + " ");
            }

            Console.WriteLine();
        }



        //EPI 12.4
        //Given a set of binary trees A1.......An, how would you compute a new set of
        //binary trees B1......Bn such that for each i, 1 <= i <= n, and Ai and Bi are isomorphic,
        //and no pair of isomorphic nodes exists in the set of nodes defined by B1,.....,Bn.  
        //(this is sometimes refrred to as the canonical form.)  Assume nodes are not shared in
        //A1,......,An
        static Dictionary<Node, Node> NodeToCanonicalNode = new Dictionary<Node, Node>();

        public static Node GetCanonical(Node n)
        {
            Node lc = (n.Left == null) ? null : GetCanonical(n.Left);
            Node rc = (n.Right == null) ? null : GetCanonical(n.Right);

            Node nc = new Node(lc, rc, n.Value);

            if(NodeToCanonicalNode.ContainsKey(nc))
            {
                return NodeToCanonicalNode[nc];
            }

            NodeToCanonicalNode[nc] = nc;
            return nc;
        }

        //HE 18
        //Give a node in a binary tree, implement a function to retrieve its next node in the 
        //inorder traversal sequence.  There is a pointer to the parent node in each tree node
        /*
        public Node GetNext(Node n)
        {
            if (n == null)
                return null;

            //if node have right child, next node is the left most child of right subtree
            Node nNext = null;
            if (n.Right != null)
            {
                Node nRight = n.Right;
                while (nRight.Left != null)
                    nRight = nRight.Left;

                nNext = nRight;
            }
            else if (n.Parent != null)
            {
                //if node does not have right child, its next node is its parents if it is the left 
                //child of its parent
                Node nCurr = n;
                Node nParent = n.Parent;
                while(nParent != null && nCurr == nParent.Right )
                {
                    nCurr = nParent;
                    nParent = nParent.Parent;
                }
                nNext = nParent;
            }

            return nNext;
        }
         */

        //He 20
        //Implement a function to get the largest size of all binary search subtrees in a given binary tree
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LargestBST(Node root)
        {
            int min = -1, max = -1, largestSize = -1;
            LargestBST(root, ref min, ref max, ref largestSize);
            return largestSize;

        }

        private bool LargestBST(Node n, ref int min, ref int max, ref int largestSize)
        {
            if (n == null)
            {
                max = Int32.MaxValue;
                min = Int32.MinValue;
                largestSize = 0;
                return true;
            }

            int minLeft = -1, maxLeft = -1, leftSize = -1;
            bool left = LargestBST(n.Left, ref minLeft, ref maxLeft, ref leftSize);

            int minRight = -1 , maxRight = -1, rightSize = -1;
            bool right = LargestBST(n.Right, ref minRight,  ref maxRight, ref rightSize);

            bool overall = false;
            if (left && right && n.Value >= maxLeft && n.Value <= minRight)
            {
                largestSize = leftSize + rightSize + 1;
                overall = true;
                min = (n.Value < minLeft) ? n.Value : minLeft;
                max = (n.Value > maxRight) ? n.Value : maxRight;
            }
            else
                largestSize = (leftSize > rightSize) ? leftSize : rightSize;

            return overall;
        }

        //He 51
        //Given a binary tree, how do you get is mirred tree?
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public void GetMirrorTree(Node n)
        {
            if (n == null)
                return;

            if (n.Left == null && n.Right == null)
                return;

            Node temp = n.Left;
            n.Left = n.Right;
            n.Right = temp;

            if(n.Left != null)
                GetMirrorTree(n.Left);

            if(n.Right != null)
                GetMirrorTree(n.Right);
        }


        //He 52
        //Implement a function to verify whether a binary tree is symmetrical
        //A tree is symmetrical if its mirrored image looks the same as the tree itself
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSymmetrical()
        {
            return IsSymmetricalTree(Root, Root);
        }

        bool IsSymmetricalTree(Node n1, Node n2)
        {

            if (n1 == null && n2 == null)
                return true;
            if (n1 == null)
                return false;
            if (n2 == null)
                return false;
            if (n1.Value != n2.Value)
                return false;

            return IsSymmetricalTree(n1.Left, n2.Right)
                    && IsSymmetricalTree(n1.Right, n2.Left);

        }

        //He 54
        //How do you print a binary tree in zig-zag order, each level in a line
        //ie. first level, nodes are printed from left to right' 
        //second level, nodes are printed from right to left etc
        //Note: this is a binary tree - not a BST
        public void Print(Node root)
        {
            if (root == null)
                return;
            Stack<Node>[] levels = new Stack<Node>[2];
            int current = 0;
            int next = 1;

            levels[current].Push(root);

            while (levels[0].Count > 0 || levels[1].Count > 0)
            {
                //Node n = levels[current].Peek();
                Node n = levels[current].Pop();

                Console.WriteLine(n.Value);

                if (current == 0)
                {
                    if (n.Left != null)
                        levels[next].Push(n.Left);
                    if (n.Right != null)
                        levels[next].Push(n.Right);
                }
                else {
                    if (n.Right != null)
                        levels[next].Push(n.Right);
                    if (n.Left != null)
                        levels[next].Push(n.Left);
                }

                if (levels[current].Count == 0)
                    Console.Write("\n");

                current = 1 - current;
                next = 1 - next;
            }
        }

        //He 57
        //Print a binary tree from its top levep to bottom, and print nodes at the same level from left to right
        //use a Queue
        public void PrintFromTopToBottom(Node root)
        {
            if (root == null)
                return;
            Queue<Node> qTreeNodes = new Queue<Node>();
            qTreeNodes.Enqueue(root);

            while (qTreeNodes.Count > 0)
            {
                Node current =  qTreeNodes.Dequeue();
                Console.Write(current.Value + " ");

                if (root.Left != null)
                {
                    qTreeNodes.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    qTreeNodes.Enqueue(root.Right);
                }
            }
        }

        //He 58
        //Same as 57 but print each level on a different line

        //He 84
        //How do you get the kth node in a binary search tree in an incremental order of values?
        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        
       //http://users.cis.fiu.edu/~weiss/dsj2/code/weiss/nonstandard/BinarySearchTreeWithRank.java
        public Node BSTKthNode(int k)
        {
            return BSTKthNode(Root, k);
        }

        private Node BSTKthNode(Node n, int k)
        {
            if (n == null)
                return null;

            //int leftSize = (n.Left != null)? CountNodes(n.Left):0;
            int leftSize = CountNodes(n.Left);

            if ( k <= leftSize)
                return BSTKthNode(n.Left, k);
            if (k == leftSize + 1)
                return n;

            return BSTKthNode(n.Right, k - leftSize - 1);
        }

        //private Node BSTKthNode(Node n, int k)
        //{
        //    if (n == null)
        //        return null;

        //    int leftSize = (n.Left != null) ? n.Left.Size : 0;

        //    if (k <= leftSize)
        //        return BSTKthNode(n.Left, k);
        //    if (k == leftSize + 1)
        //        return n;
        //    return BSTKthNode(n.Right, k - leftSize - 1);
                
        //}
        

        /*
        private Node BSTKthNode(Node n, int k)
        {
            if (n == null || k == 0)
                return null;
            return BSTKthNodeCore(n, k);
        }

        private Node BSTKthNodeCore(Node n, int k)
        {
            //if (n == null || k == 0)
            //return null;

            Node target = null;

            if (n.Left != null)
                target = BSTKthNode(n.Left, k);
            if (target == null)
            {
                if (k == 1)
                    target = n;
                k--;
            }
            if (target == null && n.Right != null)
                target = BSTKthNode(n.Right, k);

            return target;
        }
        */
        //He 86 How do you verify whther a binary tree is balanced
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsTreeBalanced1()
        { 
            return IsTreeBalanced1(Root);
        }

        private bool IsTreeBalanced1(Node n)
        {
            if (n == null)
                return true;
            int leftHeight = TreeHeight(n.Left);
            int rightHeight = TreeHeight(n.Right);

            int heightDiff = leftHeight - rightHeight;

            if (heightDiff > 1 || heightDiff < -1)
                return false;
            return IsTreeBalanced1(n.Left) && IsTreeBalanced1(n.Right);
        }

        //Better solution, only visit each node once
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsTeeBalancedTree2()
        {
            int height = 0;
            return IsTreeBalanced2(Root, height);
        }

        private bool IsTreeBalanced2(Node n, int height)
        {
            if (n == null)
            {
                height = 0;
                return true;
            }
            int left = 0, right = 0;
            
            if (IsTreeBalanced2(n.Left, left) &&
               IsTreeBalanced2(n.Right, right))
            {
                int diff = left - right;

                if(Math.Abs(diff)  <= 1)
                {
                    height = 1 + (left > right? left:right);
                    return true;
                }
            }
            return false;
        }

        //CCI 4.4
        //Given a binary tree, design an algorithm which creates a linked list of all the nodes at each
        //e.g if you have a tree with depth D, you'll have D linked lists
        
        //Breadth-First-Search Method
        public static List<LinkedList<Node>>  CreateLevelLinkdedListBFS(Node root)
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();

            Queue<LinkedList<Node>> q = new Queue<LinkedList<Node>>();

            LinkedList<Node> current = new LinkedList<Node>();
            if (root != null)
                current.AddLast(root);
            
            q.Enqueue(current);

            while (q.Count > 0)
            {
                LinkedList<Node> llNodes = q.Dequeue();
                result.Add(llNodes);

                //Go to the next level
                LinkedList<Node> parents = current;
                current = new LinkedList<Node>();

                foreach (Node parent in parents)
                { 
                    //Visit the children
                    if (parent.Left != null)
                        current.AddLast(parent.Left);
                    if (parent.Right != null)
                        current.AddLast(parent.Right);

                    if(current.Count > 0)
                        q.Enqueue(current);
                }
                
            }

            return result;
        }

        private void CreateLevelLinkdedListDFS(Node n, List<LinkedList<Node>> lists, int level)
        {
            if (n == null)
                return;

            LinkedList<Node> list = null;
            {
                if (lists.Count == level)
                {
                    list = new LinkedList<Node>();
                    lists.Add(list);
                }
                else
                {
                    list = lists[level];
                }
            }

            list.AddLast(n);

            CreateLevelLinkdedListDFS(n.Left, lists, level + 1);
            CreateLevelLinkdedListDFS(n.Right, lists, level + 1);
        }


        public List<LinkedList<Node>>  CreateLevelLinkdedListDFS(Node root)
        {
            List<LinkedList<Node>> lists = new List<LinkedList<Node>>();
            CreateLevelLinkdedListDFS(root, lists, 0);
            return lists;
        }

        public void PrintLevelLinkdedList(List<LinkedList<Node>> listNodes)
        {

            for (int i = 0; i < listNodes.Count; i++)
            {
                LinkedList<Node> ll = listNodes[i];

                LinkedList<Node>.Enumerator enumerator = ll.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    Node current = enumerator.Current;
                    Console.Write(current.Value + " ");
                }

                Console.WriteLine();
            }
        }

        public static void MainBST(string[] args)
        {
            Console.WriteLine("Breadth-first traversal of Binary Tree");

            //A B C D E F G H I J
            //1 2 3 4 5 6 7 8 9 10
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);
            Node node8 = new Node(8);
            Node node9 = new Node(9);
            Node node10 = new Node(10);

            node4.Left = node3;  //D
            node4.Right = node5;
            node9.Left = node8;
            node7.Right = node9; //G

            node2.Left = node1;
            node2.Right = node4;

            //Node 6 (F) is the root of this built tree
            node6.Left = node2;
            node6.Right = node7;


            BST tree = new BST();
            List<LinkedList<Node>> listNodes1 = CreateLevelLinkdedListBFS(node6);
            tree.PrintLevelLinkdedList(listNodes1);
           

            Console.WriteLine("Depth-first traversal of Binary Tree");

            
            List<LinkedList<Node>> listNodes2 = tree.CreateLevelLinkdedListDFS(node6);
            tree.PrintLevelLinkdedList(listNodes2);

            int k = 5;
            BST tree1 = new BST();
            tree1.Root = node6;

            //Node n = tree1.BSTKthNode(k);

            //Node n = tree1.FindKLargestInBST(k);

            Node n = tree1.BSTKthNode(k);

            //Console.WriteLine("Number of nodes in tree is " + tree1.CountNodes());
            Console.WriteLine(k + "th largest node in tree is " + n.Value);

            Console.WriteLine("Is symmetrical?" + tree1.IsSymmetrical());

            

            Console.WriteLine("End of BFS");
            Console.Read();
        }
    }

}
