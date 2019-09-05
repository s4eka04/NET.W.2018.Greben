using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_greben_13_14
{


    public class BinaryTreeNode<T>  
    {
        /// <summary>
        /// Reference to left property
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Reference to right property
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// node value property
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

    }
}
