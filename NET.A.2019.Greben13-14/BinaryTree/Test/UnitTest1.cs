using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree_greben_13_14;

namespace UnitTestProject_Greben_13_14
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BinaryTreeTest()
        {
            BinaryTree<int> binaryInt = new BinaryTree<int>();
            BinaryTree<Point> binaryPoint = new BinaryTree<Point>();

            binaryInt.Add(10);
            binaryInt.Add(5);
            binaryInt.Add(8);
            binaryInt.Add(2);
            binaryInt.Add(6);
            binaryInt.Add(4);
            binaryInt.Add(1);
            binaryInt.Add(12);

            string str = null;

            foreach(var item in binaryInt)
            {
                str += item.ToString();
            }
            Assert.AreEqual("1245681012", str);

            binaryPoint.Add(new Point(1, 1));
            binaryPoint.Add(new Point(2, 2));
            binaryPoint.Add(new Point(5, 1));
            binaryPoint.Add(new Point(3, 2));
            binaryPoint.Add(new Point(1, 7));

            string str1 = null;

            foreach (var item in binaryPoint)
            {
                str1 += item.ToString();
            }
            Assert.AreEqual("[ 1 : 7 ] [ 3 : 2 ] [ 5 : 1 ] [ 2 : 2 ] [ 1 : 1 ] ", str1);
        }
    }
}
