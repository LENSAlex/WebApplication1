using NUnit.Framework;
using System;

namespace NUnitTestProject1
{ 

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestMethodAJoutBon()
        {
            //MethodTest method = new MethodTest();
            //bool test = method.TestAddition("vrai");
            bool test = TestAddition("vrai");
            Assert.IsTrue(test, "la fonction retourn true quand on met vrai");
        }

        [Test]
        public void TestMethodAJoutPasBon()
        {
            //MethodTest method = new MethodTest();
            bool test = TestAddition("autre");
            Assert.IsTrue(test, "la fonction retourn false quand on met autre chose que vrai");
        }
    }
}