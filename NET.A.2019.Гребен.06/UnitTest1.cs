using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomial;
using BubbleSort;

namespace PolynomialTest
{
    [TestClass]
    public class UnitTest1
    {

        Polynomial p1 = new Polynomial(1, 2, 3, 4, 7, 150);
        Polynomial p2 = new Polynomial(2, 5, 6, 6, 7, 88, 5, 4, 5);

        int[][] arr = new int[5][]
        {
            new int[] { 10, 5, 2 },
            new int[] { 2, 5, 7, 1, 2 },
            new int[] { 14, 5, 111, 22, 4 },
            new int[] { 7, 91 },
            new int[] { 2, 4, 5, 6, 12 }
        };



       [TestMethod]
        public void  ToStringTest()
        {

            Assert.AreEqual(p2.ToString(), "2x^8 + 5x^7 + 6x^6 + 6x^5 + 7x^4 + 88x^3 + 5x^2 + 4x^1 + 5");
            Assert.AreEqual(p1.ToString(), "x^5 + 2x^4 + 3x^3 + 4x^2 + 7x^1 + 150");
        }

        [TestMethod]
        public void OperatorMinusTest()
        {
            Assert.AreEqual((p1 - p2).ToString(), "-2x^8 + -5x^7 + -6x^6 + -5x^5 + -5x^4 + -85x^3 + -1x^2 + 3x^1 + 145");
            Assert.AreEqual((p2 - p1).ToString(), "2x^8 + 5x^7 + 6x^6 + 5x^5 + 5x^4 + 85x^3 + x^2 + -3x^1 + -145");
        }

        [TestMethod]
        public void OpertorPlusTest()
        {
            Assert.AreEqual((p1 + p2).ToString(), "2x^8 + 5x^7 + 6x^6 + 7x^5 + 9x^4 + 91x^3 + 9x^2 + 11x^1 + 155");
            Assert.AreEqual((p2 + p1).ToString(), "2x^8 + 5x^7 + 6x^6 + 7x^5 + 9x^4 + 91x^3 + 9x^2 + 11x^1 + 155");

        }
        [TestMethod]
        public void OperatorEqualTest()
        {
            Assert.IsFalse(p1 == p2);
            Assert.IsTrue(p1 != p2);
            Assert.IsTrue(p1 != null);
            Assert.IsFalse(p1 == null);


        }

        [TestMethod]
        public void OperatorMultiplyTest()
        {
            Assert.AreEqual((p1 * p2).ToString(), "2x^13 + 9x^12 + 22x^11 + 41x^10 + 71x^9 + " +
                "479x^8 + 1018x^7 + 1248x^6 + 1329x^5 + 1708x^4 + 13266x^3 + 798x^2 + 635x^1 + 750");
            Assert.AreEqual((p2 * p1).ToString(), "2x^13 + 9x^12 + 22x^11 + 41x^10 + 71x^9 + " +
       "479x^8 + 1018x^7 + 1248x^6 + 1329x^5 + 1708x^4 + 13266x^3 + 798x^2 + 635x^1 + 750");
        }


        [TestMethod]
        public void BubbleSortTest()
        {
            
            int[][] arr = new int[5][]
            {
            new int[3] { 10, 5, 2 },
            new int[] { 2, 5, 7, 1, 2 },
            new int[] { 14, 5, Int32.MaxValue , 22, 4 },
            new int[] { 7, 91 },
            new int[] { 2, 4, 5, 6, 12 }
            };
            JaggedArray jaggedArray = new JaggedArray(arr);

            int[][] arrDeCreaseMax = new int[5][]
            {
                new int[] { 14, 5, Int32.MaxValue , 22, 4 },
                new int[] { 7, 91 },
                new int[] { 2, 4, 5, 6, 12 },
                new int[3] { 10, 5, 2 },
                new int[] { 2, 5, 7, 1, 2 }
            };

           
            jaggedArray.BubbleSortByDecreaseMaxElement();
            Assert.IsTrue(jaggedArray.EqualsArray(arrDeCreaseMax));

            jaggedArray.BubbleSortByIncreaseMaxElement();
            Array.Reverse(arrDeCreaseMax);
            Assert.IsTrue(jaggedArray.EqualsArray(arrDeCreaseMax));


        }

    }
}
