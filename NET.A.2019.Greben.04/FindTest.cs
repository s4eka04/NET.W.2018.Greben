using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Find;
using ConvertDouble;
namespace UnitTestFindGCM
{
    [TestClass]
    public class FindTest
    {
        [TestMethod]
        public void BySteinTest()
        {
            int resultFromStein = FindGCM.ByStein(4, new int[] { 169, 117, 585, 26 });
            Assert.AreEqual(13, resultFromStein);
        }

        [TestMethod]
        public void ByEuclid()
        {
            int resultFromEuklid = FindGCM.ByEuclid(4, new int[] { 169, 117, 585, 26 });
            Assert.AreEqual(13, resultFromEuklid);
        }
    }

    [TestClass]
    public class  ConvertTest
    {
        [TestMethod]
        public void ToBinaryTest()
        {
            string result1 = (255.255).ToBinary();
            string shouldBeResult1 = "0100000001101111111010000010100011110101110000101000111101011100";
            Assert.AreEqual(result1, shouldBeResult1);

            string result2 = (4294967295.0).ToBinary();
            string shouldBeResult2 = "0100000111101111111111111111111111111111111000000000000000000000";
            Assert.AreEqual(result2, shouldBeResult2);

            string result3 = (-255.255).ToBinary();
            string shouldBeResult3 = "1100000001101111111010000010100011110101110000101000111101011100";
            Assert.AreEqual(result3, shouldBeResult3);

            string result4 = (double.MinValue).ToBinary();
            string shouldBeResult4 = "1111111111101111111111111111111111111111111111111111111111111111";
            Assert.AreEqual(result4, shouldBeResult4);

            string result5 = (double.NaN).ToBinary();
            string shouldBeResult5 = "1111111111111000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(result5, shouldBeResult5);

            string result6 = (double.Epsilon).ToBinary();
            string shouldBeResult6 = "0000000000000000000000000000000000000000000000000000000000000001";
            Assert.AreEqual(result6, shouldBeResult6);

            string result7 = (double.PositiveInfinity).ToBinary();
            string shouldBeResult7 = "0111111111110000000000000000000000000000000000000000000000000000";
            Assert.AreEqual(result7, shouldBeResult7);

        }
    }
}
