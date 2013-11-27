using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void Setup()
        {
            this._fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        public void Answer_InputEqualValue_OutputCorrect(int input, string expectedOutput)
        {
            string output = this._fizzBuzz.Answer(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
