using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearch;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BinarySearchTest()
        {
            int[] arrayInt = new int[] { 5, 6, 7, 3, 2, 3, 5, 1 };
            string[] arrayString = new string[] { "Egor", "grebne", "vlad", "greben", "alex", "pety" };

            Binary<int> binaryInt = new Binary<int>(arrayInt);
            Binary<string> binaryString = new Binary<string>(arrayString);

            binaryInt.Sort((i, j) => i >= j); // 1 2 3 3 5 5 6 7
            Assert.AreEqual(7,binaryInt.SearchIndex(7, (i, j) => i == j));  // return index goal

            binaryInt.Sort((i, j) => i <= j); // 7 6 5 5 3 3 2 1
            Assert.AreEqual(0, binaryInt.SearchIndex(7, (i, j) => i == j));  // --//--

            binaryString.Sort((i, j) => i.ToUpper()[0] > j.ToUpper()[0]); // alex Egor grebne greben pety vlad
            Assert.AreEqual(2, binaryString.SearchIndex("grebne", (i, j) => i == j));
        }
    }
}
