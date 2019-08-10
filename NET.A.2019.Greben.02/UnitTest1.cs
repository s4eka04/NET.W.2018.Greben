using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.A._2019.Greben._02;

namespace UnitTest02
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsertNumberMethod()
        {
            int numberSource = 8;
            int numberIn = 15;
            int i = 3;
            int j = 8;

            int result = AllMethodsHere.InsertNumber(i, j, numberSource, numberIn);

            Assert.AreEqual(result, 120);
        }
        [TestMethod]
        public void TestFindNextBiggerNumberMethod()
        {
            int numberForMethod = 3456432;

            int result = AllMethodsHere.FindNextBiggerNumber(numberForMethod);

            Assert.AreEqual(result, 3462345);
        }

        [TestMethod]
        public void TestFindDigitMethod()
        {
            List<int> result = AllMethodsHere.FilterDigit(7, 1, 2, 3, 4, 5, 7, 67, 12, 71, 1234567, 12385, 1274);
            List<int> shouldBeResult = new List<int> { 7, 67, 71, 1234567, 1274 };

            CollectionAssert.AreEqual(result, shouldBeResult);

           
        }

        [TestMethod]
        public void TestFindNthRootMethod()
        {
            double result = AllMethodsHere.FindNthRoot(0.04100625, 4, 0.0001);
            double shouldBeResult = 0.45;
            Assert.AreEqual(result, shouldBeResult);
        }
    }
}
