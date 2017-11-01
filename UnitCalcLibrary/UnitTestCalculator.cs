using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLibrary;

namespace UnitCalcLibrary {
    [TestClass]
    public class UnitTestCalculator {

        private Exception ex = new Exception();

        [TestMethod]
        public void TestSum() {

            var calc = new Calculator();

            var result = calc.Sum("3", "2");
            var result1 = calc.Sum("0", "0");
            var result2 = calc.Sum("100", "0");
            var result3 = calc.Sum("a", "b");

            Assert.AreEqual("5", result);
            Assert.AreEqual("0", result1);
            Assert.AreEqual("100", result2);
            Assert.AreEqual("error", result3);

        }

        [TestMethod]
        public void TestSub() {

            var calc = new Calculator();

            var result = calc.Sub("10", "5");
            var result1 = calc.Sub("0", "0");
            var result2 = calc.Sub("0", "50");
            var result3 = calc.Sub("a", "b");
            var result4 = calc.Sub("-40", "-14");
            var result5 = calc.Sub("25", "-5");

            Assert.AreEqual(5, result);
            Assert.AreEqual(0, result1);
            Assert.AreEqual(-50, result2);
            Assert.AreEqual(null, result3);
            Assert.AreEqual(-26, result4);
            Assert.AreEqual(30, result5);

        }

        [TestMethod]
        public void TestMul() {

            var calc = new Calculator();

            var result = calc.Mul("3", "8");
            var result1 = calc.Mul("0", "0");
            var result2 = calc.Mul("0", "-20");
            var result3 = calc.Mul("a", "b");
            var result4 = calc.Mul("-4", "-2");

            Assert.AreEqual(24, result);
            Assert.AreEqual(0, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(null, result3);
            Assert.AreEqual(8, result4);

        }

        [TestMethod]
        public void TestDiv() {

            var calc = new Calculator();

            var result = calc.Div("3", "8");
            var result1 = calc.Div("0", "0");
            var result2 = calc.Div("0", "-20");
            var result3 = calc.Div("a", "b");
            var result4 = calc.Div("-4", "-2");
            var result5 = calc.Div("6", "0");

            Assert.AreEqual(0.375, result);
            Assert.AreEqual(null, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(null, result3);
            Assert.AreEqual(2, result4);
            Assert.AreEqual(null, result5);

        }

        [TestMethod]
        public void TestPow() {

            var calc = new Calculator();

            var result = calc.Pow("2", "3");
            var result1 = calc.Pow("0", "0");
            var result2 = calc.Pow("0", "-20");
            var result3 = calc.Pow("a", "b");
            var result4 = calc.Pow("-4", "-2");
            var result5 = calc.Pow("6", "0");
            var result6 = calc.Pow("2", "-3");

            Assert.AreEqual(8, result);
            Assert.AreEqual(1, result1);
            Assert.AreEqual(null, result2);
            Assert.AreEqual(null, result3);
            Assert.AreEqual(0.0625, result4);
            Assert.AreEqual(1, result5);
            Assert.AreEqual(0.125, result6);

        }

        [TestMethod]
        public void TestRemainder() {

            var calc = new Calculator();

            var result = calc.Remainder("2", "3");
            var result1 = calc.Remainder("0", "0");
            var result2 = calc.Remainder("0", "-20");
            var result3 = calc.Remainder("a", "b");
            var result4 = calc.Remainder("-4", "-2");
            var result5 = calc.Remainder("6", "0");
            var result6 = calc.Remainder("2", "-3");
            var result7 = calc.Remainder("-2", "-3");

            Assert.AreEqual(2, result);
            Assert.AreEqual(null, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(null, result3);
            Assert.AreEqual(0, result4);
            Assert.AreEqual(null, result5);
            Assert.AreEqual(2, result6);
            Assert.AreEqual(-2, result7);

        }

    }
}
 