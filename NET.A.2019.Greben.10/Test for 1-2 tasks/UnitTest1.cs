using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAT.A._2019.Greben._08;

namespace TestRepresentation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReperrepresentationTest()
        {
            Book book = new Book(1, "Pushkin", "Blizzard", "Boldino", 1830, 250, 250.1m);

            Assert.AreEqual(book.ToString("I"), "1");
            Assert.AreEqual(book.ToString("I", "A", "N"), "1,Pushkin,Blizzard");
            Assert.AreEqual(book.ToString("I", "N", "A"), "1,Blizzard,Pushkin");
        }
    }
}
