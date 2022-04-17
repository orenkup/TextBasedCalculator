using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using TextBaseCalculator;

namespace TextBaseCalculatorTests
{
    [TestClass]
    public class InputParserTests
    {
        [TestMethod]
        public void PreIncrementTest()
        {
            var parser = new InputParser();
            var input = new List<string>();
            input.Add("i = 0");
            input.Add("x = ++i");

            var result = parser.Parse(input);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("i + 1", result.ElementAt(1).VariableExpression);            

        }

        [TestMethod]
        public void PostIncrementTest()
        {
            var parser = new InputParser();
            var input = new List<string>();
            input.Add("i = 0");
            input.Add("x = i++ +5");

            var result = parser.Parse(input);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(" i + 1 +5", result.ElementAt(1).VariableExpression);
            Assert.AreEqual("i + 1", result.ElementAt(2).VariableExpression);
        }

        [TestMethod]
        public void AssignementIncrementIncrementTest()
        {
            var parser = new InputParser();
            var input = new List<string>();
            input.Add("i = 0");
            input.Add("x += i");

            var result = parser.Parse(input);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("x + i", result.ElementAt(1).VariableExpression);

        }

        [TestMethod]
        public void PostIncrementTestTest()
        {
            // Negative
            Assert.AreEqual(Parser.Parse("-10").Eval(null), -10);

            // Positive
            Assert.AreEqual(Parser.Parse("+10").Eval(null), 10);

            // Negative of a negative
            Assert.AreEqual(Parser.Parse("--10").Eval(null), 10);

            // Woah!
            Assert.AreEqual(Parser.Parse("--++-+-10").Eval(null), 10);

            // All together now
            Assert.AreEqual(Parser.Parse("10 + -20 - +30").Eval(null), -40);
        }

        [TestMethod]
        public void MultiplyDivideTest()
        {
            // Add 
            Assert.AreEqual(Parser.Parse("10 * 20").Eval(null), 200);

            // Subtract 
            Assert.AreEqual(Parser.Parse("10 / 20").Eval(null), 0.5);

            // Sequence
            Assert.AreEqual(Parser.Parse("10 * 20 / 50").Eval(null), 4);
        }

        [TestMethod]
        public void OrderOfOperation()
        {
            Parser.Parse("(10 + 20) * 30").Eval(null);
            // No parens
            Assert.AreEqual(Parser.Parse("10 + 20 * 30").Eval(null), 610);

            // Parens
            Assert.AreEqual(Parser.Parse("(10 + 20) * 30").Eval(null), 900);

            // Parens and negative
            Assert.AreEqual(Parser.Parse("-(10 + 20) * 30").Eval(null), -900);

            // Nested
            Assert.AreEqual(Parser.Parse("-((10 + 20) * 5) * 30").Eval(null), -4500);
        }

    }
}