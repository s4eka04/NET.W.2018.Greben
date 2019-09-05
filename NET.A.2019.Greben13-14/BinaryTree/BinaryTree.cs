using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_greben_13_14
{

    public struct Point : IComparable<Point>, IComparable
    {
        readonly int x;
        readonly int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point other)
        {
            if (this.x * this.y > other.x * other.y)
            {
                return -1;
            }
            if (this.x * this.y < other.x * other.y)
            {
                return 1;
            }
            return 0;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Point)obj);
        }

        public override string ToString()
        {
            string str = "[ " + x + " : " + y + " ] ";
            return str;
        }
    }
    public class BinaryTree<T>: IEnumerable<T> where T: IComparable
    {
        /// <summary>
        /// head node field
        /// </summary>
        private BinaryTreeNode<T> head;

        /// <summary>
        /// count all nodes
        /// </summary>
        private int count;

        /// <summary>
        /// add node if count = 0
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            
            if (head == null)
            {
                head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddRecurs(head, value);
            }

            count++;
        }

        /// <summary>
        /// add all node exept head
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void AddRecurs(BinaryTreeNode<T> node, T value)
        {

            
                if (value.CompareTo(node.Value) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddRecurs(node.Left, value);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddRecurs(node.Right, value);
                    }
                }
            
        }

        /// <summary>
        /// Count property
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// Preorder tree traversal for head node
        /// </summary>
        /// <param name="action"></param>
        public void Preorder(Action<T> action)
        {
            Preorder(action, head);
        }

        /// <summary>
        /// Preorder tree traversal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        private void Preorder(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                Preorder(action, node.Left);
                Preorder(action, node.Right);
            }
        }

        /// <summary>
        /// Postored tree traversal for head node
        /// </summary>
        /// <param name="action"></param>
        public void Postorder(Action<T> action)
        {
            Postorder(action, head);
        }

        /// <summary>
        /// Postored tree traversal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        private void Postorder(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {

                Postorder(action, node.Left);
                Postorder(action, node.Right);
                action(node.Value);
            }
        }

        /// <summary>
        /// Inorder tree traversal for head node
        /// </summary>
        /// <param name="action"></param>
        public void Inorder(Action<T> action)
        {
            Inorder(action, head);
        }

        /// <summary>
        /// Inorder tree traversal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="node"></param>
        private void Inorder(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Inorder(action, node.Left);

                action(node.Value);

                Inorder(action, node.Right);
            }
        }

        /// <summary>
        /// For Enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return PreorderForEnumerator();
        }

        /// <summary>
        /// Enumerator no recursion
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> PreorderForEnumerator()
        {
            Stack<BinaryTreeNode<T>> listValue = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = head;
            bool nextLeft = true;

            listValue.Push(current);

            while(listValue.Count > 0)
            {
                if(nextLeft)
                {
                    while(current.Left != null)
                    {
                        listValue.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if(current.Right != null)
                {
                    current = current.Right;
                    nextLeft = true;
                }
                else
                {
                    current = listValue.Pop();
                    nextLeft = false;
                }
            }
        }

        /// <summary>
        /// implementation GetEnumerator interface
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
