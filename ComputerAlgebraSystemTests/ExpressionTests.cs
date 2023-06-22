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
    public class ExpressionTests
    {
        [TestMethod()]
        public void GetStringFormTest() // no simplification
        {
            string desiredOuput = "-14x^(2)+26x^(3)";
            Term a = new Term(-14d, 'x', 2);
            Term b = new Term(+26d, 'x', 3);

            Expression express = new Expression();
            express.AddTerm(a);
            express.AddTerm(b);

            string x = express.GetStringForm();
            //Console.WriteLine(x);
            Assert.AreEqual(desiredOuput, x);
        }

        [TestMethod()]
        public void SimplificationTesNegative() // simplification
        {
            string desiredOuput = "-11x^(2)";
            Term a = new Term(-6d, 'x', 2);
            Term b = new Term(-5d, 'x', 2);

            Expression express = new Expression();
            express.AddTerm(a);
            express.AddTerm(b);

            string x = express.GetStringForm();
            //Console.WriteLine(x);
            Assert.AreEqual(desiredOuput, x);
        }

        [TestMethod()]
        public void SimplificationTesPositive() // simplification
        {
            string desiredOuput = "1x^(2)";
            Term a = new Term(6d, 'x', 2);
            Term b = new Term(-5d, 'x', 2);

            Expression express = new Expression();
            express.AddTerm(a);
            express.AddTerm(b);

            string x = express.GetStringForm();
            //Console.WriteLine(x);
            Assert.AreEqual(desiredOuput, x);
        }

        [TestMethod()]
        public void SubstituteTest()
        {
            // f(x)=2x^2-3x+2; P(8,102), E(-38, 3000)
            Term a = new Term(2d, 'x', 2);
            Term b = new Term(-3, 'x', 1);
            Term c = new Term(-2, 'x', 0); // Prop need to make it more efficient as it does do e.g. 2(x)^0

            Expression express = new Expression();
            express.AddTerm(a); express.AddTerm(b); express.AddTerm(c);

            Console.WriteLine(express.Substitute(8));
            Assert.IsTrue(express.Substitute(8) == 102 && express.Substitute(-38) == 3000);
        }


        [TestMethod()]
        public void ExpansionTest()
        {
            // f(x)=2x^2-3x+2; P(8,102), E(-38, 3000)
            Expression expressOne = new Expression();
            expressOne.AddTerm(new Term(2d, 'x', 2));
            expressOne.AddTerm(new Term(-3, 'x', 1));
            expressOne.AddTerm(new Term(-2, 'x', 0));

            Expression expressTwo = new Expression();
            expressTwo.AddTerm(new Term(8, 'x', 2));
            expressTwo.AddTerm(new Term(5, 'x', 1));
            expressTwo.AddTerm(new Term(5, 'x', 0));

            Expression product = expressOne * expressTwo;

            Console.WriteLine(product.GetStringForm());
            Assert.IsTrue(product.GetDegree()==4);
        }
    }
}