using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Web
{
    [TestClass]
    public class TempConversionTest
    {
        [TestMethod]
        public void FarenheitToCelsiusTest()
        {

            int testInput1 = -10;
            int testInput2 = 0;
            int testInput3 = 32;
            int testInput4 = 50;

            int manualOutput1 = -23;
            int manualOutput2 = -17;
            int manualOutput3 = 0;
            int manualOutput4 = 10;

            int testOutput1 = (int)Weather.FarenheitToCelsius(testInput1);
            int testOutput2 = (int)Weather.FarenheitToCelsius(testInput2);
            int testOutput3 = (int)Weather.FarenheitToCelsius(testInput3);
            int testOutput4 = (int)Weather.FarenheitToCelsius(testInput4);

            Assert.AreEqual(manualOutput1, testOutput1);
            Assert.AreEqual(manualOutput2, testOutput2);
            Assert.AreEqual(manualOutput3, testOutput3);
            Assert.AreEqual(manualOutput4, testOutput4);
        }
    }
}
