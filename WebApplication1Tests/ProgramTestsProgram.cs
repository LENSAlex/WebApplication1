using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.TestsProgram
{
    [TestClass()]
    public class ProgramTestsProgram
    {
        WebApplication1.Program autre = new WebApplication1.Program();
        //public void init()
        //{
        //    autre.TestAddition("test");
        //}

        [TestMethod()]
        public void TestAdditionTestProgram()
        {
            Assert.AreEqual(true, autre.TestAddition("vrai"));
        }

        [TestMethod()]
        public void CalculTestProgram()
        {
            Assert.AreEqual(10, autre.Calcul(5, 5));
            //Assert.Equals(10, autre.Calcul(5, 5));
        }
    }
}