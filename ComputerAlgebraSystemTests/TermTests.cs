using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerAlgebraSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Tests
{
    [TestClass()]
    public class TermTests
    {
        [TestMethod()]
        public void GetStringFormTest()
        {
            string desiredOuput = "-2x^(2)";

            Term TermTest = new Term(-2d,'x',2);
            string x = TermTest.GetStringForm();

            Assert.AreEqual(desiredOuput, x);
        }

        [TestMethod()]
        public void AdditionTest()
        {
            string desiredOuput = "-6x^(2)";
            Term a = new Term(-4d, 'x', 2);
            Term b = new Term(-2d, 'x', 2);

            a = a + b;

            string x = a.GetStringForm();
            //Console.WriteLine(x);
            Assert.AreEqual(desiredOuput, x);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            string desiredOuput = "+12x^(2)";
            Term a = new Term(-14d, 'x', 2);
            Term b = new Term(-26d, 'x', 2);

            a = a - b;

            string x = a.GetStringForm();
            //Console.WriteLine(x);
            Assert.AreEqual(desiredOuput, x);
        }
    }
}